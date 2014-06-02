using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CodeWick.Models {
    [Serializable]
    public class User {
        [DisplayName("User Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid UserId { get; set; }

        [DisplayName("Username"), Required]
        public virtual String Username { get; set; }

        [DisplayName("Email"), Required]
        public virtual String Email { get; set; }

        [DisplayName("Password"), Required, DataType(DataType.Password)]
        public virtual String Password { get; set; }

        [DisplayName("First Name")]
        public virtual String FirstName { get; set; }

        [DisplayName("Last Name")]
        public virtual String LastName { get; set; }

        [DisplayName("Comment"), DataType(DataType.MultilineText)]
        public virtual String Comment { get; set; }

        [DisplayName("Approved")]
        public virtual Boolean IsApproved { get; set; }

        [DisplayName("Failure Amount")]
        public virtual int PasswordFailuresSinceLastSuccess { get; set; }

        [DisplayName("Password Failure")]
        public virtual DateTime? LastPasswordFailureDate { get; set; }

        [DisplayName("Last Activity")]
        public virtual DateTime? LastActivityDate { get; set; }

        [DisplayName("Last Lockout")]
        public virtual DateTime? LastLockoutDate { get; set; }

        [DisplayName("Last Login")]
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual String ConfirmationToken { get; set; }

        [DisplayName("Created")]
        public virtual DateTime? CreateDate { get; set; }

        [DisplayName("Account Locked")]
        public virtual Boolean IsLockedOut { get; set; }

        [DisplayName("Password Changed")]
        public virtual DateTime? LastPasswordChangedDate { get; set; }
        public virtual String PasswordVerificationToken { get; set; }
        public virtual DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}