using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace KfcCoupons
{
    public class Poster
    {
        private readonly TelegramBotClient _client;
        private readonly ChatId _chatId;

        public Poster(TelegramBotClient client,ChatId chatId) =>
            (_client, _chatId) = (client, chatId);

        public async Task<int> Post(string description, Uri thumbnail)
        {
            var resultMessage = await _client.SendPhotoAsync(_chatId, new InputOnlineFile(thumbnail), description, ParseMode.Markdown);
            return resultMessage.MessageId;
        }
    }
}