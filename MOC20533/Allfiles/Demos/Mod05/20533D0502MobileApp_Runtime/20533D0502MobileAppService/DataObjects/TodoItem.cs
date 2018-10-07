using Microsoft.Azure.Mobile.Server;

namespace 20533D0502MobileAppService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}