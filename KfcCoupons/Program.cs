using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KfcCoupons.Models;
using Microsoft.Extensions.Configuration;
using Serilog;
using Telegram.Bot;

namespace KfcCoupons
{
    public static class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false)
            .Build();

        private static async Task Main()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration, "Serilog")
                .CreateLogger();

            var kfcClient = new KfcClient();
            var chatId = Configuration.GetValue<dynamic>("KfcCoupons:ChatId");

            (IEnumerable<Product> newProducts, string newHash) = await kfcClient.GetProductsWithCoupon();

            PostedProduct[] oldProducts = null;

            var postedProducts = new List<PostedProduct>();
            bool firstLaunch = !File.Exists("hash.txt") && !File.Exists("products.json");
            var telegramClient = new TelegramBotClient(Configuration.GetValue<string>("telegram:botToken"));

            if (!firstLaunch)
            {
                Log.Information("hash.txt and products.json are exists");
                string oldHash = File.ReadAllText("hash.txt");
                if (oldHash == newHash)
                {
                    Log.Information("New hash is the same as in file. Returning");
                    return;
                }

                string oldProductsText = await File.ReadAllTextAsync("products.json");
                oldProducts = JsonSerializer.Deserialize<PostedProduct[]>(oldProductsText);

                foreach (PostedProduct oldProduct in oldProducts.Where(p => newProducts.All(x => x.Id != p.Id)))
                {
                    Log.Information($"Deleting messge with ID {oldProduct.Id}...");
                    await telegramClient.DeleteMessageAsync(chatId, oldProduct.MessageId);
                }
            }

            var descriptionGenerator = new DescriptionGenerator();
            var poster = new Poster(telegramClient, chatId);

            foreach (Product newProduct in firstLaunch
                ? newProducts
                : newProducts.Where(p => oldProducts.All(x => x.Id != p.Id)))
            {
                Log.Information($"Posting product with ID {newProduct.Id}...");
                int messageId = await poster.Post(descriptionGenerator.Generate(newProduct),
                    new Uri($"https://s82079.cdn.ngenix.net/{newProduct.Thumbnail}?dw=250"));
                postedProducts.Add(new PostedProduct(newProduct.Id, messageId));
            }

            Log.Information("Writing files...");
            await File.WriteAllTextAsync("hash.txt", newHash);
            await File.WriteAllTextAsync("products.json", JsonSerializer.Serialize(postedProducts));
        }
    }
}