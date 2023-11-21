using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Context
{
    public sealed class MaintenanceEntity : BaseEntity
    {
        [Column("ITEM")]
        public string? Item { get; set; }

        [Column("OPERATION")]
        public string? Operation { get; set; }

        [Column("EVERY")]
        public int Every { get; set; }
    }
}
