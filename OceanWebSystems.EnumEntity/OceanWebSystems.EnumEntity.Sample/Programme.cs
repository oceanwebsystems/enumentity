using System.ComponentModel.DataAnnotations.Schema;

namespace OceanWebSystems.EnumEntity.Sample
{
    [Table(nameof(Programme))]
    public class Programme
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ProgrammeClass ProgrammeClass { get; set; }

        public AdministrativeRegion? AdministrativeRegion { get; set; }
    }
}
