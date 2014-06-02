using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class RequestQuote {
        [DisplayName("RequestQuote Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RequestQuoteId { get; set; }

        [DisplayName("Full Name"), Required]
        public string FullName { get; set; }

        [DisplayName("E-mail"), Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Phone"), Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}