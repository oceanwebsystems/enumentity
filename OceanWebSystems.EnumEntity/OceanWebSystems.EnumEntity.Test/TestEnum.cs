using System.ComponentModel.DataAnnotations;

namespace OceanWebSystems.EnumEntity.Test
{
    public enum TestEnum
    {
        ValueOne = 1,
        [Display(Name = "Value Two")]
        ValueTwo = 2,
        [Display(Name = "Value Three", Description = "The description for value three.")]
        ValueThree = 3,
        [Display(Name = "Value Four", Description = "The description for value four.", Order = 3)]
        ValueFour = 4,
        [Display(Order = 2)]
        ValueFive = 5,
        [Display(Order = 1)]
        ValueSix = 6,
        [EnumDeleted]
        ValueSeven = 7,
    }
}
