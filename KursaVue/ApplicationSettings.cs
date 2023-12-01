using Microsoft.Extensions.Options; 
namespace KursaVue
{
    public class ApplicationSettings
    {
        private readonly ApplicationSettings _settings;
     
        public string[] AllowedOrigins { get; set; }
    }
}
