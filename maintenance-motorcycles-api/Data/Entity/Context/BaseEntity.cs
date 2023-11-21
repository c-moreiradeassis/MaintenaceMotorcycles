using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Context
{
    public class BaseEntity
    {
        [Column("ID")]
        public int Id { get; set; }
    }
}
