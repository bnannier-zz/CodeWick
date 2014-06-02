using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class Theme {
        [DisplayName("Theme Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ThemeId { get; set; }

        [DisplayName("Theme Name"), Required]
        public string ThemeName { get; set; }

        [DisplayName("Abbreviation"), Required]
        public string Abbreviation { get; set; }
    }
}