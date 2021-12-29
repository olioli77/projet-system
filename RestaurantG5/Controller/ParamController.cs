using System.Configuration;

namespace RestaurantG5.Controller
{
    public class ParamController
    {
        public static string GetValueOrDefault(string key, string defaultValue, bool numericalValue = false)
        {
            if (numericalValue == true)
            {
                string value = ConfigurationManager.AppSettings[key];
                if (int.TryParse(value, out int result))
                    return value;
                else
                    return defaultValue;
            }
            return ConfigurationManager.AppSettings[key] ?? defaultValue;

        }
    }
}
