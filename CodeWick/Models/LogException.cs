using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class LogException {
        [DisplayName("Exception Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogExceptionId { get; set; }

        [DisplayName("Type"), Required]
        public string Type { get; set; }

        [DisplayName("Source"), Required]
        public string Source { get; set; }

        [DisplayName("Stack Trace"), Required]
        public string StackTrace { get; set; }

        [DisplayName("Module Name"), Required]
        public string ModuleName { get; set; }

        [DisplayName("Message"), Required]
        public string Message { get; set; }

        [DisplayName("Exception"), Required]
        public string Exception { get; set; }

        [DisplayName("Time"), Required]
        public DateTime Time { get; set; }
    }
}