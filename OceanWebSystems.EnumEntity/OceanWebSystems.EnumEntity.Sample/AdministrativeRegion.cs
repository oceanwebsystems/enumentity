using System.ComponentModel.DataAnnotations;

namespace OceanWebSystems.EnumEntity.Sample
{
    public enum AdministrativeRegion
    {
        West = 1,

        [Display(Name = "South East")]
        SouthEast = 2,

        East = 3,

        North = 4,
    }
}
