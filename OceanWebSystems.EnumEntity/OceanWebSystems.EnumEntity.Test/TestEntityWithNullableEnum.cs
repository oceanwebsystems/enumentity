using System.ComponentModel.DataAnnotations;

namespace OceanWebSystems.EnumEntity.Test
{
    internal class TestEntityWithNullableEnum
    {
        [Key]
        public int Id { get; set; }

        public TestEnum? NullableValue { get; set; }
    }
}
