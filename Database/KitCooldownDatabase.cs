using RedPlus.Models;
using RedPlus.Storage;
using System.Collections.Generic;

namespace RedPlus.Database
{
    public class KitCooldownDatabase
    {
        private DataStorage<List<KitCooldown>> DataStorage { get; set; }
        public List<KitCooldown> Data { get; private set; }

        public KitCooldownDatabase()
        {
            DataStorage = new DataStorage<List<KitCooldown>>(RedPlus.Instance.Directory, "KitCooldowns.json");
        }

        public void Reload()
        {
            Data = DataStorage.Read();
            if (Data == null)
            {
                Data = new List<KitCooldown>();
                DataStorage.Save(Data);
            }
        }

        public void AddKitCooldown(KitCooldown cooldown)
        {
            Data.Add(cooldown);
            DataStorage.Save(Data);
        }
    }
}
