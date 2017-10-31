using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookAndLearn.Common.Entities
{
    [Table("LessonPlace")]
    public class LessonPlace
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LessonPlace()
        {
            StudentLessonPlaces = new HashSet<StudentLessonPlace>();
        }

        public int Id { get; set; }

        public int LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentLessonPlace> StudentLessonPlaces { get; set; }
    }
}
