namespace OceanWebSystems.EnumEntity
{
    /// <summary>
    /// Generic entity representing a enum.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    public class EnumEntity<T>
        where T : Enum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumEntity{T}" /> class.
        /// </summary>
        /// <param name="value">
        /// The enumeration value.
        /// </param>
        public EnumEntity(T value)
        {
            this.Id = Convert.ToInt32(value);
            this.Value = value;
            this.Name = value.GetDisplayName() ?? value.ToString();

            if (!string.IsNullOrWhiteSpace(value.GetDisplayDescription()))
            {
                this.Description = value.GetDisplayDescription();
            }

            if (value.GetDisplayOrder().HasValue)
            {
                this.Order = value.GetDisplayOrder();
            }
        }

        /// <summary>
        /// Gets or sets the integer value of the enumeration.
        /// </summary>
        /// <value>
        /// The integer value of the enumeration.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the value of the enumeration.
        /// </summary>
        /// <value>
        /// The value of the enumeration.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the name of the enumeration value for display purposes.
        /// </summary>
        /// <value>
        /// The name of the enumeration value for display purposes.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the enumeration value for display purposes.
        /// </summary>
        /// <value>
        /// The description of the enumeration value for display purposes.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the order in which to display the enumeration value.
        /// </summary>
        /// <value>
        /// The order in which to display the enumeration value.
        /// </value>
        public int? Order { get; set; }
    }
}