using System.Globalization;

namespace Pillage.Common.Extensions;

public static class StringExtensions
{
    public static string ToTitleCase(this string s) =>
        CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToLower());
}
