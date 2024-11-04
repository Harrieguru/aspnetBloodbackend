using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    public class DCandidate
    {
        [Key]
        public int Id {  get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Fullname { get; set; }

        [Column(TypeName = "varchar(16)")]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        public int Age { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string BloodGroup { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }


    }
}
