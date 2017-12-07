using System.ComponentModel.DataAnnotations;

namespace BrunoFontes.Portifolio.ASP.NETView.Models
{
    public class ContactFields
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        //[Display(Name = "Let's get in touch")]
        public string Message { get; set; }

    }
}