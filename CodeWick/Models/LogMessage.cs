using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class LogMessage {
        [DisplayName("Message Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogMessageId { get; set; }

        [DisplayName("Location"), Required]
        public string Location { get; set; }

        [DisplayName("Message"), Required]
        public string Message { get; set; }

        [DisplayName("Time"), Required]
        public DateTime Time { get; set; }
    }
}