using System.Data.Entity;
using BookAndLearn.Common.Entities;

namespace BookAndLearn.DataAccess
{
    public class BookAndLearnContext : DbContext
    {
        public BookAndLearnContext()
            : base("name=BookAndLearn")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<LessonGroup> LessonGroups { get; set; }
        public virtual DbSet<LessonPlace> LessonPlaces { get; set; }
        public virtual DbSet<LessonSchedule> LessonSchedules { get; set; }
        public virtual DbSet<LessonType> LessonTypes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentLessonPlace> StudentLessonPlaces { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectDay> SubjectDays { get; set; }
        public virtual DbSet<SubjectLecturer> SubjectLecturers { get; set; }
        public virtual DbSet<WeekFrequency> WeekFrequencies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.LessonGroups)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lecturer>()
                .HasMany(e => e.Lessons)
                .WithRequired(e => e.Lecturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lecturer>()
                .HasMany(e => e.SubjectLecturers)
                .WithRequired(e => e.Lecturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lesson>()
                .HasMany(e => e.LessonGroups)
                .WithRequired(e => e.Lesson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lesson>()
                .HasMany(e => e.LessonPlaces)
                .WithRequired(e => e.Lesson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LessonPlace>()
                .HasMany(e => e.StudentLessonPlaces)
                .WithRequired(e => e.LessonPlace)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LessonSchedule>()
                .HasMany(e => e.Lessons)
                .WithRequired(e => e.LessonSchedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LessonType>()
                .HasMany(e => e.Lessons)
                .WithRequired(e => e.LessonType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Lessons)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.SubjectLecturers)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentLessonPlaces)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Lessons)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.SubjectDays)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.SubjectLecturers)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectDay>()
                .HasMany(e => e.Lessons)
                .WithRequired(e => e.SubjectDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WeekFrequency>()
                .HasMany(e => e.SubjectDays)
                .WithRequired(e => e.WeekFrequency)
                .WillCascadeOnDelete(false);
        }
    }
}
