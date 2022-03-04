using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Management_systems.Models
{
    [Table("Classes")]
    public class ClassModels
    {
        [Key]
        public int ClassId { get; set; }

        [Display(Name = "Descriptions")]
        public string Descriptions { get; set; }

        [Display(Name = "Course")]
        public string Course_Name { get; set; }

        [ForeignKey("TrainerModels")]
        [DisplayName("Trainer")]
        public int TrainerId { get; set; }

        public TrainerModels TrainerModels { get; set; }


    }
}