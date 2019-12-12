using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace KfcCoupons
{
    public class Poster
    {
        private readonly ChatId _chatId;
        private readonly TelegramBotClient _client;

        public Poster(TelegramBotClient client, ChatId chatId) => (_client, _chatId) = (client, chatId);

        public async Task<int> Post(string description, Uri thumbnail)
        {
            Message resultMessage = await _client.SendPhotoAsync(_chatId, new InputOnlineFile(thumbnail), description, ParseMode.Markdown);
            return resultMessage.MessageId;
        }
    }
}