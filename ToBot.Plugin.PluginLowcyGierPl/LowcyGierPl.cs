// The MIT License (MIT)
//
// Copyright (c) 2022 tariel36
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using ToBot.Common.Maintenance;
using ToBot.Common.Maintenance.Logging;
using ToBot.Communication.Messaging.Formatters;
using ToBot.Communication.Messaging.Providers;
using ToBot.Data.Repositories;
using ToBot.Plugin.GenericRssPlugin;
using ToBot.Plugin.LowcyGierPl.Data;
using ToBot.Rss.Pocos;

namespace ToBot.Plugin.PluginLowcyGierPl
{
    public class LowcyGierPl
        : PluginGenericRss<LowcyGierPlEntry>
    {
        public const string Prefix = "lgp";

        public LowcyGierPl(IRepository repository,
            ILogger logger,
            IMessageFormatter messageFormatter,
            IEmoteProvider emoteProvider,
            string commandsPrefix,
            ExceptionHandler exceptionHandler)
            : base(repository, logger, messageFormatter, emoteProvider, commandsPrefix, exceptionHandler, RssEntryToLowcyGierplEntry)
        {

        }

        public override string Name { get { return nameof(LowcyGierPl); } }

        public override Version Version { get { return typeof(LowcyGierPl).Assembly.GetName().Version; } }

        protected override string TaggedUrlWithPageTemplate { get { return "https://lowcygier.pl/feed/?paged={0}"; } }

        private static LowcyGierPlEntry RssEntryToLowcyGierplEntry(RssEntry rssEntry)
        {
            return new LowcyGierPlEntry(rssEntry);
        }
    }
}
