using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookAndLearn.Common.Entities
{
    public class Status
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Status()
        {
            SubjectLecturers = new HashSet<SubjectLecturer>();
        }

        public int Id { get; set; }

        public string StatusName { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectLecturer> SubjectLecturers { get; set; }
    }
}
