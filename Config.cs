using Rocket.API;

namespace Unturned_AllPlugins
{
    public class Config : IRocketPluginConfiguration
    {
        public string permission;
        public void LoadDefaults()
        {
            permission = "permission";
        }
    }
}