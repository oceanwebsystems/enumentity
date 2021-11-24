using System.ComponentModel.DataAnnotations;

namespace OceanWebSystems.EnumEntity.Test
{
    internal class TestEntityWithNonNullableEnum
    {
        [Key]
        public int Id { get; set; }

        public TestEnum NonNullableValue { get; set; }
    }
}
