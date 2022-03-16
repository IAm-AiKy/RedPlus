using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace RedPlus.Commands
{
    public class CustomCommandThree : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => RedPlus.Instance.Translate("CustomCommand3Name");

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (player.HasPermission(RedPlus.Instance.Translate("CustomCommand3Permission")))
            {
                UnturnedChat.Say(caller, RedPlus.Instance.Translate("CustomCommand3Text"), RedPlus.Instance.MessageColour);
            }
        }
    }
}
