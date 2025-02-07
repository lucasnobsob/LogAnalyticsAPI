namespace LogAnalyticsAPI
{
    using System;
    using System.Globalization;
    using System.Text;

    public static class Utils
    {
        // Método de extensão para converter uma string para PascalCase
        public static string ToPascalCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var result = new StringBuilder();
            result.Append(char.ToUpper(input[0]));
            result.Append(input.Substring(1));
            return result.ToString();

        }

        public static Dictionary<string, object> GetSelectedProperties(object obj, string[] properties)
        {
            var result = new Dictionary<string, object>();
            var type = obj.GetType();

            foreach (var propName in properties)
            {
                var prop = type.GetProperty(propName.ToPascalCase());
                if (prop != null)
                {
                    result.Add(propName, prop.GetValue(obj));
                }
            }

            return result;
        }
    }
}
