using RedPlus.Database;
using RedPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedPlus.Services
{
    public class CooldownService : MonoBehaviour
    {
        public Dictionary<string, List<KitCooldown>> PlayersKitCooldowns { get; private set; }
        private KitCooldownDatabase database => RedPlus.Instance.KitCooldownDatabase;

        void Awake()
        {
            PlayersKitCooldowns = new Dictionary<string, List<KitCooldown>>();
        }

        void Start()
        {

        }

        void OnDestroy()
        {

        }

        public bool HasCooldown(string playerId, string kitName, out TimeSpan timeLeft)
        {
            timeLeft = TimeSpan.Zero;

            var activeCooldown = database.Data.FirstOrDefault(x => x.KitName.Equals(kitName, StringComparison.OrdinalIgnoreCase)
                && x.PlayerId == playerId && x.ExpireDate > DateTime.UtcNow);

            if (activeCooldown == null)
            {
                return false;
            }

            timeLeft = activeCooldown.ExpireDate - DateTime.UtcNow;
            return true;
        }

        public void RegisterCooldown(string playerId, Kit kit)
        {
            var kitCooldown = new KitCooldown()
            {
                PlayerId = playerId,
                KitName = kit.Name,
                ExpireDate = DateTime.UtcNow.AddSeconds(kit.Cooldown)
            };

            database.AddKitCooldown(kitCooldown);
        }
    }
}
