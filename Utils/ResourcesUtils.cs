using System.Resources;

namespace CardurrexAPI.Utils
{
    public class ResourcesUtils
    {

        private static readonly string  resourcesLocation = "CardurrexAPI.Resources.Messages";

        public static string GetMessageFromResource(string key)
        {
            var rm = new ResourceManager(resourcesLocation, typeof(Program).Assembly);

            string message = rm.GetString(key);

            return message;
        }

    }
}
