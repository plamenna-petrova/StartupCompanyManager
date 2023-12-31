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
        public static bool ParseDateTimeExactly(this string stringToParseAsDateTimeExactly, out DateTime exactlyParseDateTime)
        {
            return DateTime.TryParseExact(
                stringToParseAsDateTimeExactly,
                new string[] { "dd.MM.yyyy", "d.M.yyyy", "dd/MM/yyyy", "dd-MM-yyyy" },
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out exactlyParseDateTime
            );
        }
    }
}
