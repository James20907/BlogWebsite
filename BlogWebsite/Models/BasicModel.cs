namespace BlogWebsite.Models
{
    public class BasicModel
    {
        public bool IsEnabled { get; set; }

        public bool DelFlag { get; set; }

        public DateTime CreateDatetime { get; set; }

        public long Creator { get; set; }

        public DateTime? EditDatetime { get; set; }

        public long? Editor { get; set; } 
    }
}
