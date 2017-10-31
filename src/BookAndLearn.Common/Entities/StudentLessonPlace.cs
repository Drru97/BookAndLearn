namespace BookAndLearn.Common.Entities
{
    public class StudentLessonPlace
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int LessonPlaceId { get; set; }

        public virtual LessonPlace LessonPlace { get; set; }

        public virtual Student Student { get; set; }
    }
}
