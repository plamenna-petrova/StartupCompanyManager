using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Extensions
{
    public static class SystemMethodsExtensions
    {
        public static decimal ParseDecimal(this string stringToParse)
        {
            return decimal.Parse(stringToParse.ReplaceCommasWithDots(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static int ParseInt(this string stringToParse)
        {
            return int.Parse(stringToParse.ReplaceCommasWithDots(), NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static bool TryParseDecimal(this string stringToTryParse, out decimal decimalValue)
        {
            return decimal.TryParse(
                stringToTryParse.ReplaceCommasWithDots(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimalValue
            );
        }

        public static bool TryParseInt(this string stringToTryParse, out int intValue)
        {
            return int.TryParse(
                stringToTryParse.ReplaceCommasWithDots(), NumberStyles.Any, CultureInfo.InvariantCulture, out intValue
            );
        }

        public static DateTime ParseDateTimeExactly(this string stringToParseDateTimeExactly)
        {
            return DateTime.ParseExact(
                stringToParseDateTimeExactly, 
                new string[] { "dd.MM.yyyy", "d.M.yyyy", "dd/MM/yyyy", "dd-MM-yyyy" }, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None
            );
        }

        public static bool ParseDateTimeExactly(this string stringToTryParseAsDateTimeExactly, out DateTime exactlyParseDateTime)
        {
            return DateTime.TryParseExact(
                stringToTryParseAsDateTimeExactly,
                new string[] { "dd.MM.yyyy", "d.M.yyyy", "dd/MM/yyyy", "dd-MM-yyyy" },
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out exactlyParseDateTime
            );
        }

        public static string ReplaceCommasWithDots(this string replacementString)
        {
            return replacementString.Replace(",", ".");
        }
    }
}
