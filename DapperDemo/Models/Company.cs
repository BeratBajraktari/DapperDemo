﻿using System.ComponentModel.DataAnnotations;

namespace DapperDemo.Models
{
    public class Company
    {
        [Key]
        public int CompayId { get; set; }   
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

    }
}
