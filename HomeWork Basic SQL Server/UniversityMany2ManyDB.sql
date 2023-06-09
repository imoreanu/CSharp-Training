USE [University]
GO
/****** Object:  Table [dbo].[students_teachers]    Script Date: 09/06/2023 18:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students_teachers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teachers]    Script Date: 09/06/2023 18:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teachers](
	[teacher_id] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[gender] [varchar](20) NULL,
	[age] [tinyint] NULL,
	[class] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[univ_students]    Script Date: 09/06/2023 18:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[univ_students](
	[student_id] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[gender] [varchar](20) NULL,
	[age] [tinyint] NULL,
	[major] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[students_teachers]  WITH CHECK ADD FOREIGN KEY([student_id])
REFERENCES [dbo].[univ_students] ([student_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[students_teachers]  WITH CHECK ADD FOREIGN KEY([teacher_id])
REFERENCES [dbo].[teachers] ([teacher_id])
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[SelectAllStudents]    Script Date: 09/06/2023 18:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllStudents]
AS
SELECT * FROM univ_students
GO;
GO
