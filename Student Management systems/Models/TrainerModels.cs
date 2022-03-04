using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_systems.Models
{
    [Table("Trainers")]
    public class TrainerModels
    {
        [Key]
        public int TrainerId { get; set; }
        [Display(Name = "Trainer ID")]
        public int TrainerIdNum { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string TrainerFullName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }
        [Required]
        [Display(Name = "Phone.No")]
        public int PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}