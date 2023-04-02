using System.ComponentModel.DataAnnotations;

namespace WebApi.DataAccess.Models
{
    public class CustomerPayload
    {
        [Required]
        public string Firstname { get; init; }

        [Required]
        public string Lastname { get; init; }
    }
}
