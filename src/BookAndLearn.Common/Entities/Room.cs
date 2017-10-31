using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookAndLearn.Common.Entities
{
    [Table("Room")]
    public class Room
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? Capacity { get; set; }

        public int LocationId { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual Location Location { get; set; }
    }
}
