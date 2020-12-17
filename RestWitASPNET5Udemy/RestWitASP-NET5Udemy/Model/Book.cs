using RestWitASP_NET5Udemy.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWitASP_NET5Udemy.Model
{
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
