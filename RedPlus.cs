using Rocket.Unturned.Chat;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.API.Collections;
using RedPlus.Database;
using RedPlus.Services;

namespace RedPlus
{

    public class RedPlus : RocketPlugin<RedPlusConfiguration> {

        public static RedPlus Instance { get; private set; }
        public UnityEngine.Color MessageColour { get; private set; }
        public KitCooldownDatabase KitCooldownDatabase { get; private set; }
        public CooldownService CooldownService { get; private set; }
        

        protected override void Load() {

            Instance = this;
            MessageColour = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColour, UnityEngine.Color.magenta);

            KitCooldownDatabase = new KitCooldownDatabase();
            KitCooldownDatabase.Reload();

            CooldownService = gameObject.AddComponent<CooldownService>();

            Logger.Log(Configuration.Instance.LoadMessage);
            Logger.Log($"{Name} v{Assembly.GetName().Version} has successfully loaded!");
            
        }

        protected override void Unload() {

            Destroy(CooldownService);
            Logger.Log($"{Name} v{Assembly.GetName().Version} has been unloaded!");

        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "KitInvalid", "You must specify a kit name!" },
            { "KitNotFound", "The specified kit was not found!" },
            { "KitSuccess", "You recieved the kit: {0}" },
            { "KitNoPermission", "You don't have permission to exeute this command!" },
            { "KitCooldown", "This kit is on cooldown! You have to wait {0} to use this kit again!" },
            { "KitsList", "The available kits are: Put the kits names here :)" },
            { "DiscordLink", "Join our discord! discord.gg/gvSFWSesKY" }
        };

    }

}
