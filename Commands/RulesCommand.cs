using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPlus.Commands
{
    public class RulesCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "rules";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (player.HasPermission("rules"))
            {
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine1"), RedPlus.Instance.MessageColour);
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine2"), RedPlus.Instance.MessageColour);
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine3"), RedPlus.Instance.MessageColour);
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine4"), RedPlus.Instance.MessageColour);
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine5"), RedPlus.Instance.MessageColour);
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine6"), RedPlus.Instance.MessageColour);
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine7"), RedPlus.Instance.MessageColour);
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine8"), RedPlus.Instance.MessageColour);
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("RuleLine9"), RedPlus.Instance.MessageColour);
            }
        }
    }
}
