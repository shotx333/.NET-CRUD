using System.ComponentModel.DataAnnotations;


namespace DataAccessLayer.Models.DatabaseModels
{
    public class DBUser 
    {

        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }

}
