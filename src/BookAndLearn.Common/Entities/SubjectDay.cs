using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookAndLearn.Common.Entities
{
    [Table("SubjectDay")]
    public class SubjectDay
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubjectDay()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int Id { get; set; }

        public int? DayOfWeek { get; set; }

        public int SubjectId { get; set; }

        public int WeekFrequencyId { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual WeekFrequency WeekFrequency { get; set; }
    }
}
