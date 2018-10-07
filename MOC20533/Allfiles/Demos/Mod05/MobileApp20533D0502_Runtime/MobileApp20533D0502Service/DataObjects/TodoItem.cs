using Microsoft.Azure.Mobile.Server;

namespace MobileApp20533D0502Service.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}