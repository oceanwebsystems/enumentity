namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// An attribute that indicates that an enum value should be soft deleted from the database.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumDeletedAttribute : Attribute
    {
    }
}