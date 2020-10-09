using System;
using System.Security.Cryptography;
using System.Text;


namespace SrcFramework.Utils
{
    public static class DataHelper
    {
        public static string GenerateRandomPassword(int length=8, int maxNumberOfNonAlphanumericCharacters=3)
        {
            if (length < 1 || length > 30)
            {
                throw new ArgumentException(nameof(length));
            }

            if (maxNumberOfNonAlphanumericCharacters > length || maxNumberOfNonAlphanumericCharacters < 0)
            {
                throw new ArgumentException(nameof(maxNumberOfNonAlphanumericCharacters));
            }

            string specialCharacters = "!$@%&?";
            Random random = new Random();
            int specialCharacterCount = 0;
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int decision = random.Next(4);
                while (specialCharacterCount >= maxNumberOfNonAlphanumericCharacters && decision == 3)
                {
                    decision = random.Next(4);
                }
                if (decision == 0)
                {
                    //numbers
                    var number = random.Next(48, 58);
                    result.Append(Convert.ToChar(number));
                }
                else if (decision == 1)
                {
                    //uppercase
                    var number = random.Next(65, 91);
                    result.Append(Convert.ToChar(number));
                }
                else if (decision == 2)
                {
                    //lowercase
                    var number = random.Next(97, 123);
                    result.Append(Convert.ToChar(number));
                }
                else
                {
                    //special characters
                    var number = random.Next(specialCharacters.Length);
                    result.Append(specialCharacters[number]);
                    specialCharacterCount++;
                }
            }

            return result.ToString();
        }

        public static string GenerateUniqueShortText(DateTime? startDate = null)
        {
            if (!startDate.HasValue)
            {
                startDate = new DateTime(2020, 1, 1, 0, 0, 0);
            }


            var span = DateTime.Now.Subtract(startDate.Value);

            var tickInMiliseconds = Convert.ToInt64(span.TotalMilliseconds);

            return Base36.NumberToBase36(tickInMiliseconds);
        }
    }
}