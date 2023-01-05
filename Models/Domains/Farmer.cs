using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace crowdfarming.Models.Domains
{
    public class Farmer
    {     
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]

        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter  a valid Email" ) ]
        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Status { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedAt { get; set; }
        




    }
}