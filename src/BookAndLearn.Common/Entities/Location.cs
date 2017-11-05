using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookAndLearn.Common.Entities
{
    [Table("Location")]
    public class Location
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        public int? Floor { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
