using System;
using System.ComponentModel.DataAnnotations;

namespace BookAndLearn.Web.Models.Account
{
    public class FullNameModel : IEquatable<FullNameModel>
    {
        [Display(Name = "Ім'я")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Прізвище")]
        [Required]
        public string LastName { get; set; }

        public bool Equals(FullNameModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FullNameModel)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
            }
        }
    }
}
