using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookAndLearn.Common.Entities
{
    [Table("LessonSchedule")]
    public class LessonSchedule
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LessonSchedule()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
