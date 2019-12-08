using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KfcCoupons.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Telegram.Bot;

namespace KfcCoupons
{
    public class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false)
            .Build();

        private static async Task Main()
        {
            var chatId = Configuration.GetValue<dynamic>("kfccoupons:chatid");
            var telegramClient = new TelegramBotClient(Configuration.GetValue<string>("telegram:botToken"));
            var descriptionGenerator = new DescriptionGenerator();
            var poster = new Poster(telegramClient, chatId);
            var kfcClient = new KfcClient();

            PostedProduct[] oldProcuts = null;
            (IEnumerable<Product> newProducts, string newHash) = await kfcClient.GetProductsWithCoupon();
            var postedProducts = new List<PostedProduct>();

            bool firstLaunch = !File.Exists("hash.txt") && !File.Exists("products.json");

            if (!firstLaunch)
            {
                string oldHash = File.ReadAllText("hash.txt");
                if (oldHash == newHash)
                    Environment.Exit(0);

                string oldProductsText = await File.ReadAllTextAsync("products.json");
                oldProcuts = JsonConvert.DeserializeObject<PostedProduct[]>(oldProductsText);

                foreach (PostedProduct oldProduct in oldProcuts.Where(p => newProducts.All(x => x.Id != p.Id)))
                    await telegramClient.DeleteMessageAsync(chatId, oldProduct.MessageId);
            }

            foreach (Product newProduct in firstLaunch
                ? newProducts
                : newProducts.Where(p => oldProcuts.All(x => x.Id != p.Id)))
            {
                int messageId = await poster.Post(descriptionGenerator.Generate(newProduct), new Uri($"https://s82079.cdn.ngenix.net/{newProduct.Thumbnail}?dw=250"));
                postedProducts.Add(new PostedProduct(newProduct.Id, messageId));
            }


            await File.WriteAllTextAsync("hash.txt", newHash);
            await File.WriteAllTextAsync("products.json", JsonConvert.SerializeObject(postedProducts));
        }
    }
}