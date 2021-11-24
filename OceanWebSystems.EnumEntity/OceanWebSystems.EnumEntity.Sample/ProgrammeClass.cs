using System.ComponentModel.DataAnnotations;

namespace OceanWebSystems.EnumEntity.Sample
{
    public enum ProgrammeClass
    {
        [Display(Order = 1)]
        Medical = 1,

        [Display(Order = 2)]
        Dental = 2,

        [Display(Name = "Healthcare Science", Order = 8)]
        HealthcareScience = 3,

        [Display(Order = 4)]
        Psychology = 4,

        [Display(Order = 3)]
        Pharmacy = 5,

        [Display(Name = "Social Care", Order = 7)]
        SocialCare = 6,

        [Display(Order = 9)]
        General = 7,

        [Display(Order = 5)]
        Optometry = 8,

        [Display(Order = 11)]
        Covid = 9,

        [Display(Order = 6)]
        Nursing = 10,

        [Display(Name = "Dental SQA Activity", Order = 10)]
        DentalSqaActivity = 11,
    }
}
