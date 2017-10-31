using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookAndLearn.Common.Entities
{
    [Table("Lesson")]
    public class Lesson
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lesson()
        {
            LessonGroups = new HashSet<LessonGroup>();
            LessonPlaces = new HashSet<LessonPlace>();
        }

        public int Id { get; set; }

        public int RoomId { get; set; }

        public int SubjectId { get; set; }

        public int LecturerId { get; set; }

        public int LessonTypeId { get; set; }

        public int SubjectDayId { get; set; }

        public int LessonScheduleId { get; set; }

        public virtual Lecturer Lecturer { get; set; }

        public virtual LessonSchedule LessonSchedule { get; set; }

        public virtual LessonType LessonType { get; set; }

        public virtual Room Room { get; set; }

        public virtual SubjectDay SubjectDay { get; set; }

        public virtual Subject Subject { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonGroup> LessonGroups { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonPlace> LessonPlaces { get; set; }
    }
}
