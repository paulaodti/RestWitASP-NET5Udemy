﻿using RestWitASP_NET5Udemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWitASP_NET5Udemy.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("gender")]
        public string Gender { get; set; }
    }
}
