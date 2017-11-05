----------##########----------##########----------

IF DB_ID('BookAndLearn.SQL') IS NULL
BEGIN
	CREATE DATABASE [BookAndLearn.SQL]
	COLLATE SQL_Latin1_General_CP1_CI_AS
	PRINT N'Database created'
END
ELSE
BEGIN
	PRINT N'Database already exists'
END
GO

USE [BookAndLearn.SQL]
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Address]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Address]
GO

CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Address] NVARCHAR(MAX)
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Location]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Location]
GO

CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Floor] INT,
	[AddressId] INT NOT NULL,
	CONSTRAINT [FK_Location_AddressId] FOREIGN KEY([AddressId]) REFERENCES [dbo].[Address]([Id])
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Room]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Room]
GO

CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(MAX),
	[Capacity] INT,
	[LocationId] INT NOT NULL,
	CONSTRAINT [FK_Room_LocationId] FOREIGN KEY([LocationId]) REFERENCES [dbo].[Location]([Id])
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Lecturer]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Lecturer]
GO

CREATE TABLE [dbo].[Lecturer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(MAX)
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Subject]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Subject]
GO

CREATE TABLE [dbo].[Subject]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(MAX)
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Status]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Status]
GO

CREATE TABLE [dbo].[Status]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[StatusName] NVARCHAR(MAX)
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[LessonType]', 'U') IS NOT NULL
	DROP TABLE [dbo].[LessonType]
GO

CREATE TABLE [dbo].[LessonType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Type] NVARCHAR(MAX)
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Group]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Group]
GO

CREATE TABLE [dbo].[Group]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(MAX)
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[WeekFrequency]', 'U') IS NOT NULL
	DROP TABLE [dbo].[WeekFrequency]
GO

CREATE TABLE [dbo].[WeekFrequency]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(MAX)
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[LessonSchedule]', 'U') IS NOT NULL
	DROP TABLE [dbo].[LessonSchedule]
GO

CREATE TABLE [dbo].[LessonSchedule]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(MAX),
	[StartTime] TIME,
	[EndTime] TIME
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[SubjectDay]', 'U') IS NOT NULL
	DROP TABLE [dbo].[SubjectDay]
GO

CREATE TABLE [dbo].[SubjectDay]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[DayOfWeek] INT, -- TODO: add constraint
	[SubjectId] INT NOT NULL,
	[WeekFrequencyId] INT NOT NULL,
	CONSTRAINT [FK_SubjectDay_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject]([Id]),
	CONSTRAINT [FK_SubjectDay_WeekFrequencyId] FOREIGN KEY ([WeekFrequencyId]) REFERENCES [dbo].[WeekFrequency]([Id])
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[SubjectLecturer]', 'U') IS NOT NULL
	DROP TABLE [dbo].[SubjectLecturer]
GO

CREATE TABLE [dbo].[SubjectLecturer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[SubjectId] INT NOT NULL,
	[LecturerId] INT NOT NULL,
	[StatusId] INT NOT NULL,
	CONSTRAINT [FK_SubjectLecturer_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject]([Id]),
	CONSTRAINT [FK_SubjectLecturer_LecturerId] FOREIGN KEY ([LecturerId]) REFERENCES [dbo].[Lecturer]([Id]),
	CONSTRAINT [FK_SubjectLecturer_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status]([Id])
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Lesson]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Lesson]
GO

CREATE TABLE [dbo].[Lesson]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[RoomId] INT NOT NULL,
	[SubjectId] INT NOT NULL,
	[LecturerId] INT NOT NULL,
	[LessonTypeId] INT NOT NULL,
	[SubjectDayId] INT NOT NULL,
	[LessonScheduleId] INT NOT NULL,
	CONSTRAINT [FK_Lesson_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room]([Id]),
	CONSTRAINT [FK_Lesson_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject]([Id]),
	CONSTRAINT [FK_Lesson_LecturerId] FOREIGN KEY ([LecturerId]) REFERENCES [dbo].[Lecturer]([Id]),
	CONSTRAINT [FK_Lesson_LessonTypeId] FOREIGN KEY ([LessonTypeId]) REFERENCES [dbo].[LessonType]([Id]),
	CONSTRAINT [FK_Lesson_SubjectDayId] FOREIGN KEY ([SubjectDayId]) REFERENCES [dbo].[SubjectDay]([Id]),
	CONSTRAINT [FK_Lesson_LessonScheduleId] FOREIGN KEY ([LessonScheduleId]) REFERENCES [dbo].[LessonSchedule]([Id])
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[LessonGroups]', 'U') IS NOT NULL
	DROP TABLE [dbo].[LessonGroups]
GO

CREATE TABLE [dbo].[LessonGroups]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[LessonId] INT NOT NULL,
	[GroupId] INT NOT NULL,
	CONSTRAINT [FK_LessonGroups_LessonId] FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lesson]([Id]),
	CONSTRAINT [FK_LessonGroups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group]([Id])
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[Student]', 'U') IS NOT NULL
	DROP TABLE [dbo].[Student]
GO

CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[FirstName] NVARCHAR(MAX),
	[LastName] NVARCHAR(MAX),
	[GroupId] INT NOT NULL,
	CONSTRAINT [FK_Student_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group]([Id])
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[LessonPlace]', 'U') IS NOT NULL
	DROP TABLE [dbo].[LessonPlace]
GO

CREATE TABLE [dbo].[LessonPlace]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[LessonId] INT NOT NULL,
	CONSTRAINT [FK_LessonPlace_LessonId] FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lesson]([Id])
)
GO

----------##########----------##########----------

IF OBJECT_ID('[dbo].[StudentLessonPlaces]', 'U') IS NOT NULL
	DROP TABLE [dbo].[StudentLessonPlaces]
GO

CREATE TABLE [dbo].[StudentLessonPlaces]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[StudentId] INT NOT NULL,
	[LessonPlaceId] INT NOT NULL,
	CONSTRAINT [FK_StudentLessonPlaces_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student]([Id]),
	CONSTRAINT [FK_StudentLessonPlaces_LessonPlaceId] FOREIGN KEY ([LessonPlaceId]) REFERENCES [dbo].[LessonPlace]([Id])
)
GO

----------##########----------##########----------
