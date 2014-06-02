using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;

namespace CodeWick.Helpers {
    public class EmailHelper {
        public string Send(string to, string message) {
            string rtn = "";
            try {
                MailMessage Message = new MailMessage(ConfigurationManager.AppSettings["EmailFrom"], to);
                Message.Subject = "CodeWick Password Recovery";
                Message.Body = "Your password is: " + message;

                SmtpClient smtpMail = new SmtpClient(ConfigurationManager.AppSettings["EmailServer"], 587);
                smtpMail.EnableSsl = true;
                smtpMail.UseDefaultCredentials = false;

                NetworkCredential networkCredential = new NetworkCredential("bobby@CodeWick.com", "lop12311!");
                smtpMail.Credentials = new NetworkCredential("bobby@CodeWick.com", "lop12311!");
                smtpMail.Send(Message);
            } catch (Exception ex) {
                rtn = ex.Message;
            }
            return rtn;
        }
    }
}