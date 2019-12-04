using System;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace KfcCoupons
{
    public class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false)
            .Build();

        private static void Main(string[] args)
        {
            var telegramClient = new TelegramBotClient(Configuration.GetValue<string>("telegram:botToken"));
            var descriptionGenerator = new DescriptionGenerator();
            var poster = new Poster(telegramClient, Configuration.GetValue<string>("kfccoupons:chatid"));
            var kfcClient = new KfcClient();
        }
    }
}