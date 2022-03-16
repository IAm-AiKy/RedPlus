using System.Xml.Serialization;

namespace RedPlus.Models
{
    public class Kit
    {
        public string Name { get; set; }
        public int Cooldown { get; set; }

        [XmlArrayItem("itemId")]
        public ushort[] Items { get; set; }
    }
}
