﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorAlertToSlack.Services
{
    public class SlackMessageSender : IMessageSender
    {
        private ISlackSender sender;
        private ISlackMessageFactory messageFactory;

        public SlackMessageSender(ISlackSender sender, ISlackMessageFactory messageFactory)
        {
            this.sender = sender;
            this.messageFactory = messageFactory;
        }

        public async Task SendMessage(IEnumerable<AlertInfo> parts)
        {
            var slackBody = messageFactory.CreateMessage(parts);
            await sender.SendAlert(slackBody);
        }
    }

}
