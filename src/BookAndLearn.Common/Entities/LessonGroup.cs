namespace BookAndLearn.Common.Entities
{
    public class LessonGroup
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
