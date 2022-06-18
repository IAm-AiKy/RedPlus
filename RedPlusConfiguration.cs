using Rocket.API;
using RedPlus.Models;

namespace RedPlus
{
    public class RedPlusConfiguration : IRocketPluginConfiguration {

        public string MessageColour { get; set; }
        public string LoadMessage { get; set; }
        public Kit[] Kits { get; set; } 

        public void LoadDefaults() {

            MessageColour = "magenta";
            LoadMessage = "RedPlus is made by: _Jak.#6967";
            Kits = new Kit[]
            {
                new Kit()
                {
                    Name = "default",
                    Cooldown = 300,
                    Items = new ushort[]
                    {
                        16,
                        2,
                        3
                    }
                }
            };

        }

    }

}
