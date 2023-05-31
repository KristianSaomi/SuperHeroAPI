using SuperHeroAPI.Models.Enums;

namespace SuperHeroAPI.DataTransferObjects
{
    public class PowerUpsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RpgEnum RpgClass { get; set; }
    }
}
