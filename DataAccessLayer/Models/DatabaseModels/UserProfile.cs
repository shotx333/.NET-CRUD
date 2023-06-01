
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models.DatabaseModels
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(11, ErrorMessage = "Personal number cannot be longer than 11 characters.")]
        public string PersonalNumber { get; set; }

        public virtual DBUser? User { get; set; }
    }

}
