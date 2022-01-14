using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OceanWebSystems.EnumEntity
{
    /// <summary>
    /// Helper extension class for enumerations.
    /// </summary>
    internal static class EnumExtensions
    {
        /// <summary>
        /// Gets the display name for the enum value.
        /// </summary>
        /// <param name="enumValue">
        /// The <see cref="Enum"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Nullable{String}"/> containing the value of the Name property of the Display attribute.
        /// </returns>
        internal static string? GetDisplayName(this Enum enumValue)
        {
            DisplayAttribute? attribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();

            return !string.IsNullOrEmpty(attribute?.GetName()) ? attribute?.GetName() : enumValue.ToString();
        }

        /// <summary>
        /// Gets the display description for the enum value.
        /// </summary>
        /// <param name="enumValue">
        /// The <see cref="Enum"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Nullable{String}"/> containing the value of the Description property of the Display attribute.
        /// </returns>
        internal static string? GetDisplayDescription(this Enum enumValue)
        {
            DisplayAttribute? attribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();

            return attribute?.GetDescription();
        }

        /// <summary>
        /// Gets the display order for the enum value.
        /// </summary>
        /// <param name="enumValue">
        /// The <see cref="Enum"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Nullable{Int32}"/> containing the value of the Order property of the Display attribute.
        /// </returns>
        internal static int? GetDisplayOrder(this Enum enumValue)
        {
            DisplayAttribute? attribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();

            return attribute?.GetOrder();
        }

        /// <summary>
        /// Gets a value indicating whether the enum value has been deleted.
        /// </summary>
        /// <param name="enumValue">
        /// The <see cref="Enum"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Nullable{Boolean}"/> containing the value of the Order property of the Display attribute.
        /// </returns>
        internal static bool? GetIsDeleted(this Enum enumValue)
        {
            EnumDeletedAttribute? attribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<EnumDeletedAttribute>();

            return attribute != null;
        }
    }
}
