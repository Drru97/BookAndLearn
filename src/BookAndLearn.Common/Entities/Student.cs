using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookAndLearn.Common.Entities
{
    [Table("Student")]
    public class Student
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudentLessonPlaces = new HashSet<StudentLessonPlace>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentLessonPlace> StudentLessonPlaces { get; set; }
    }
}
