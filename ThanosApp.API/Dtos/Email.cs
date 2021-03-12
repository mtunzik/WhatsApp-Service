
namespace ThanosApp
{
    public class Email
    {
        public string mailFrom { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public bool  IsBodyHtml { get; set; }
    }
}