using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace WinFormsAppISAD.Configuration
{
    public class Config
    {
        public required string ConnectionString { get; init; }
        private static readonly Lazy<Config> _instance = new(()
            => JsonSerializer.Deserialize<Config>(File.ReadAllText("./config.json"))!
            );
        public static Config GetConfig() => _instance.Value;
    }
}
