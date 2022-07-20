using Newtonsoft.Json;

namespace CarDealer
{
    public static class Injector
    {
        public static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
        };
    }
}