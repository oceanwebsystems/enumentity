using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OceanWebSystems.EnumEntity
{
    /// <summary>
    /// Helper extension class to create database backed tables for enumerations.
    /// </summary>
    public static class EnumEntityExtensions
    {
        /// <summary>
        /// Scan all registered entities and builds a enum lookup table for any enum properties.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        public static void CreateEnumEntityTables(this ModelBuilder modelBuilder)
        {
            List<string> enumEntities = new();

            foreach (IMutableProperty property in modelBuilder.Model.GetEntityTypes().Where(et => !et.IsKeyless).SelectMany(t => t.GetProperties()).ToArray())
            {
                IMutableEntityType entityType = property.DeclaringEntityType;
                Type propertyType = Nullable.GetUnderlyingType(property.ClrType) ?? property.ClrType;

                if (!propertyType.IsEnum || propertyType.Namespace == typeof(object).Namespace)
                {
                    continue;
                }

                Type concreteType = typeof(EnumEntity<>).MakeGenericType(propertyType);

                EntityTypeBuilder enumEntityBuilder = modelBuilder
                    .Entity(concreteType)
                    .ToTable(propertyType.Name);

                enumEntityBuilder.HasAlternateKey(nameof(EnumEntity<Enum>.Value));

                if (!enumEntities.Contains(propertyType.Name))
                {
                    enumEntities.Add(propertyType.Name);

                    var enumEntityData = new List<object>();
                    var enumValues = Enum.GetValues(propertyType)
                        .Cast<object>();

                    if (enumValues != null)
                    {
                        foreach(var enumValue in enumValues)
                        {
                            if (enumValue != null)
                            {
                                var enumEntityType = Activator.CreateInstance(concreteType, new object[] { enumValue });
                                if (enumEntityType != null)
                                {
                                    enumEntityData.Add(enumEntityType);
                                }
                            }
                        }
                    }

                    enumEntityBuilder.HasData(enumEntityData);
                }

                modelBuilder.Entity(entityType.Name)
                   .HasOne(concreteType)
                   .WithMany()
                   .HasPrincipalKey(nameof(EnumEntity<Enum>.Value))
                   .HasForeignKey(property.Name);
            }
        }
    }
}
