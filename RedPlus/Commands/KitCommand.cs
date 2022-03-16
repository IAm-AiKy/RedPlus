using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedPlus.Commands
{
    public class KitCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "kit";

        public string Help => "";

        public string Syntax => "<name>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("KitInvalid"), RedPlus.Instance.MessageColour);
                return;
            }

            var kit = RedPlus.Instance.Configuration.Instance.Kits.FirstOrDefault(x => x.Name == command[0]);

            if (kit == null)
            {
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("KitNotFound"), RedPlus.Instance.MessageColour);
                return;
            }

            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (!player.HasPermission($"kit.{kit.Name}"))
            {
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("KitNoPermission"), RedPlus.Instance.MessageColour);
                return;
            }

            if (RedPlus.Instance.CooldownService.HasCooldown(player.Id, kit.Name, out TimeSpan timeLeft))
            {
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("KitCooldown", (int)timeLeft.TotalSeconds), RedPlus.Instance.MessageColour);
                return;
            }

            foreach (var item in kit.Items)
            {
                player.GiveItem(item, 1);
            }

            RedPlus.Instance.CooldownService.RegisterCooldown(player.Id, kit);
            UnturnedChat.Say(caller, RedPlus.Instance.Translate("KitSuccess", kit.Name), RedPlus.Instance.MessageColour);
        }
    }
}
