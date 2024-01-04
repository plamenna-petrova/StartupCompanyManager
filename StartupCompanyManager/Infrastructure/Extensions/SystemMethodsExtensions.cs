using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Extensions
{
    public static class SystemMethodsExtensions
    {
        public static CultureInfo enUSCulture = CultureInfo.CreateSpecificCulture("en-US");

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

        public static bool TryChangeType(this object value, Type type)
        {
            try
            {
                var response = ChangeType(value, type);
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                return false;
            }
        }

        public static object ChangeType(object value, Type type)
        {
            var conversionType = type;

            if (conversionType.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null!;
                }

                conversionType = Nullable.GetUnderlyingType(type)!;
            }

            return conversionType == typeof(decimal) ? ParseDecimalWithDot(value) : Convert.ChangeType(value, conversionType);
        }

        public static bool TryParseEnum<T>(this string stringToConvertToEnumValue, bool caseSensitive, out T enumValue) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type parameter must be an enum.");
            }

            var enumNames = Enum.GetNames(typeof(T));

            enumValue = (Enum.GetValues(typeof(T)) as T[])![0]; 

            foreach (var enumName in enumNames)
            {
                if (string.Equals(enumName, stringToConvertToEnumValue, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase))
                {
                    enumValue = (T)Enum.Parse(typeof(T), enumName);
                    return true;
                }
            }

            return false;
        }

        public static decimal ParseDecimalWithDot(object value)
        {
            const string separator = ".";

            var numberFormat = new NumberFormatInfo
            {
                NumberDecimalSeparator = separator
            };

            var convertedValue = value.ToString()!.ParseDecimal().ToString(enUSCulture);

            return decimal.Parse(convertedValue, NumberStyles.AllowDecimalPoint, numberFormat);
        }

        public static string ReplaceCommasWithDots(this string replacementString)
        {
            return replacementString.Replace(",", ".");
        }
    }
}
