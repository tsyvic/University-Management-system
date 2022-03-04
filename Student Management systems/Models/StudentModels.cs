using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_systems.Models
{
    [Table("Students")]
    public class StudentModels
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Student ID")]
        public int StudentIdNum { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string StudentFullName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }
        [Required]
        [Display(Name = "Phone.No")]
        public int PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [ForeignKey("ClassModels")]
        [DisplayName("Classes")]
        public int ClassId { get; set; }

        public ClassModels ClassModels { get; set; }
    }
}