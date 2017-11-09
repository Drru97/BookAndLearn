using System.ComponentModel.DataAnnotations;

namespace BookAndLearn.Common.Entities.Identity
{
   public class UserModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
