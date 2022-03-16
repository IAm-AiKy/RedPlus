using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace RedPlus.Commands
{
    public class CustomCommandOne : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => RedPlus.Instance.Translate("CustomCommand1Name");

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (player.HasPermission(RedPlus.Instance.Translate("CustomCommand1Permission")))
            {
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("CustomCommand1Text"), RedPlus.Instance.MessageColour);
            }
        }
    }
}
