using System.ComponentModel.DataAnnotations.Schema;

namespace RestWitASP_NET5Udemy.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
