using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity {

    public class Internship {
        
        public Internship(IDataReader reader) {
            InternshipId = Convert.ToInt32(reader["internship_id"]);
            CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            StudentId = Convert.ToInt32(reader["student_id"]);
            CompanyId = Convert.ToInt32(reader["company_id"]);
            AdvertisementId = Convert.ToInt32(reader["advertisement_id"]);
            StartDate = DateTime.Parse(reader["start_date"].ToString());
            EndDate = DateTime.Parse(reader["end_date"].ToString());
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InternshipId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public DateTime EndDate { get; set; }


        // Navigation properties

        public Student Student { get; set; }
        public Company Company { get; set; }
        public Advertisement Advertisement { get; set; }
        public Feedback Feedback { get; set; }

    }

}
