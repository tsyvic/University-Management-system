using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Management_systems.Models
{
    [Table("Attentence")]
    public class AttentenceModels
    {
        [Key]
        public int AttentenceId { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Start of Class")]
        public string Start_Time { get; set; }

        [Display(Name = "End of Class")]
        public string End_Time { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [ForeignKey("StudentModels")]
        [DisplayName("Student")]
        public int StudentId { get; set; }

        public StudentModels StudentModels { get; set; }

    }
}