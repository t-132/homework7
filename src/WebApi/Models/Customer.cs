using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Customer
    {
        public Guid Id { get; init; }
        
        [Required]
        public string Firstname { get; init; }

        [Required]
        public string Lastname { get; init; }
    }
}