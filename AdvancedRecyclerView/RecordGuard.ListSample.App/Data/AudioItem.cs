using System;

namespace RecordGuard.ListSample.App.Data
{
    public class AudioItem
    {
        public string Title { get; set; }

        public Uri AudioUri { get; set; }

        public DateTime CreatedDateUtc { get; set; }
    }
}