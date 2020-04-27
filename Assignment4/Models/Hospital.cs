using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment4.Models
{

    public class Hospital
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string hospital_name { get; set; }
        public string city { get; set; }
        public string phone_number { get; set; }
        public string hospital_overall_rating { get; set; }

    }
}
