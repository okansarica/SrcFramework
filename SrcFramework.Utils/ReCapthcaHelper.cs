using Newtonsoft.Json;

namespace SrcFramework.Utils
{
    public class ReCapthcaHelper
    {
        public static bool VerifyResponse(string response,string remoteIp)
        {
            var parameters = new ReCaptchaRequest
            {
                secret = "6LftOEoUAAAAAIiR3nf9EgKgc9RPyBCH0XdFZz89",
                response = response,
                remoteip = remoteIp
            };

            try
            {
                string textResult = ApiHelper.MakeACall(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", parameters.secret, parameters.response));
                ReCaptchaResponse reCaptchaCallResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(textResult);
                if (reCaptchaCallResponse.success != "true")
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class ReCaptchaResponse
    {
        public string success { get; set; }
        public string challenge_ts { get; set; }
        public string hostname { get; set; }

    }

    public class ReCaptchaRequest
    {
        public string secret { get; set; }
        public string response { get; set; }
        public string remoteip { get; set; }
    }
}
