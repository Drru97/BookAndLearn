using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndLearn.Common.Entities
{
    [Table("SubjectLecturer")]
    public class SubjectLecturer
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int LecturerId { get; set; }

        public int StatusId { get; set; }

        public virtual Lecturer Lecturer { get; set; }

        public virtual Status Status { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
