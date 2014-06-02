using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class Setting {
        [DisplayName("Settings Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SettingsId { get; set; }

        [DisplayName("Site Name"), Required]
        public string SiteName { get; set; }

        [DisplayName("URL"), Required]
        public string URL { get; set; }

        [DisplayName("Theme"), Required]
        public long ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
    }
}