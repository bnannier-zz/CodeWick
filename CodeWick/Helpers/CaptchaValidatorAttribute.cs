using System.Web.Mvc;
using System.Configuration;

namespace CodeWick.Helpers {
    public class CaptchaValidatorAttribute : ActionFilterAttribute {
        private const string ChallengeFieldKey = "recaptcha_challenge_field";
        private const string ResponseFieldKey = "recaptcha_response_field";

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var captchaChallengeValue = filterContext.HttpContext.Request.Form[ChallengeFieldKey];
            var captchaResponseValue = filterContext.HttpContext.Request.Form[ResponseFieldKey];
            var captchaValidtor = new Recaptcha.RecaptchaValidator {
                PrivateKey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"],
                RemoteIP = filterContext.HttpContext.Request.UserHostAddress,
                Challenge = captchaChallengeValue,
                Response = captchaResponseValue
            };

            var recaptchaResponse = captchaValidtor.Validate();
            filterContext.ActionParameters["captchaValid"] = recaptchaResponse.IsValid;
            base.OnActionExecuting(filterContext);
        }
    }
}