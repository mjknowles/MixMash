using MixMash.Shared.BL.Contracts;
using SQLite.Net.Attributes;

namespace MixMash.Shared.BL.Entities
{
    /// <summary>
    /// Business entity base class. Provides the ID property.
    /// </summary>
    public abstract class BusinessEntityBase : IBusinessEntity
    {
        public BusinessEntityBase()
        {
        }

        /// <summary>
        /// Gets or sets the Database ID.
        /// </summary>
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}
