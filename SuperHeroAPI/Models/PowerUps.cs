using System.Text.Json.Serialization;
using SuperHeroAPI.Models.Enums;

namespace SuperHeroAPI.Models
{
    public class PowerUps
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RpgEnum RpgClass { get; set; }
        public SuperHero? SuperHero { get; set; }

    }
}
