USE [StaffBase]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 29.05.2022 17:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) NULL,
	[DateOfBirth] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[IdPosition] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 29.05.2022 17:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IdSubdivision] [int] NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subdivisions]    Script Date: 29.05.2022 17:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subdivisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Info] [nvarchar](50) NULL,
	[IdType] [int] NULL,
 CONSTRAINT [PK_Subdivisions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesOfSubdivisions]    Script Date: 29.05.2022 17:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesOfSubdivisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_TypesOfSubdivisions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FIO], [DateOfBirth], [Gender], [IdPosition]) VALUES (1, N'Ларионов Емельян Митрофанович', N'25.10.1984', N'Мужской', 1)
INSERT [dbo].[Employees] ([Id], [FIO], [DateOfBirth], [Gender], [IdPosition]) VALUES (2, N'Бобылёв Александр Станиславович', N'08.08.1990', N'Мужской', 2)
INSERT [dbo].[Employees] ([Id], [FIO], [DateOfBirth], [Gender], [IdPosition]) VALUES (3, N'Назаров Владимир Владиславович', N'12.04.1982', N'Мужской', 2)
INSERT [dbo].[Employees] ([Id], [FIO], [DateOfBirth], [Gender], [IdPosition]) VALUES (4, N'Павлов Игнат Митрофановиf', N'21.04.1989', N'Мужской', 3)
INSERT [dbo].[Employees] ([Id], [FIO], [DateOfBirth], [Gender], [IdPosition]) VALUES (5, N'Крылов Елисей Михаилович', N'02.01.1986', N'Мужской', 4)
INSERT [dbo].[Employees] ([Id], [FIO], [DateOfBirth], [Gender], [IdPosition]) VALUES (6, N'Третьяков Кассиан Святославович', N'26.06.1987', N'Мужской', 4)
INSERT [dbo].[Employees] ([Id], [FIO], [DateOfBirth], [Gender], [IdPosition]) VALUES (7, N'Борисов Захар Никитевич', N'22.01.1982', N'Мужской', 4)
INSERT [dbo].[Employees] ([Id], [FIO], [DateOfBirth], [Gender], [IdPosition]) VALUES (8, N'Белоусов Владимир Дмитриевич', N'23.06.1990', N'Мужской', 4)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([Id], [Name], [IdSubdivision]) VALUES (1, N'Директор', 3)
INSERT [dbo].[Positions] ([Id], [Name], [IdSubdivision]) VALUES (2, N'Руководитель подразделения', 1)
INSERT [dbo].[Positions] ([Id], [Name], [IdSubdivision]) VALUES (3, N'Контроллер', 4)
INSERT [dbo].[Positions] ([Id], [Name], [IdSubdivision]) VALUES (4, N'Рабочий', 2)
SET IDENTITY_INSERT [dbo].[Positions] OFF
GO
SET IDENTITY_INSERT [dbo].[Subdivisions] ON 

INSERT [dbo].[Subdivisions] ([Id], [Info], [IdType]) VALUES (1, N'Отдел логистики', 1)
INSERT [dbo].[Subdivisions] ([Id], [Info], [IdType]) VALUES (2, N'Куликов Василий Андреевич', 2)
INSERT [dbo].[Subdivisions] ([Id], [Info], [IdType]) VALUES (3, N'ООО Омск', 3)
INSERT [dbo].[Subdivisions] ([Id], [Info], [IdType]) VALUES (4, N'Анализ производства', 4)
INSERT [dbo].[Subdivisions] ([Id], [Info], [IdType]) VALUES (1003, N'Отдел стандартизации', 1)
INSERT [dbo].[Subdivisions] ([Id], [Info], [IdType]) VALUES (1004, N'Отдел маркетинга', 1)
SET IDENTITY_INSERT [dbo].[Subdivisions] OFF
GO
SET IDENTITY_INSERT [dbo].[TypesOfSubdivisions] ON 

INSERT [dbo].[TypesOfSubdivisions] ([Id], [Name]) VALUES (1, N'Название подразделения')
INSERT [dbo].[TypesOfSubdivisions] ([Id], [Name]) VALUES (2, N'ФИО руководителя')
INSERT [dbo].[TypesOfSubdivisions] ([Id], [Name]) VALUES (3, N'Название компании')
INSERT [dbo].[TypesOfSubdivisions] ([Id], [Name]) VALUES (4, N'Тип анализа')
SET IDENTITY_INSERT [dbo].[TypesOfSubdivisions] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Positions] FOREIGN KEY([IdPosition])
REFERENCES [dbo].[Positions] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Positions]
GO
ALTER TABLE [dbo].[Positions]  WITH CHECK ADD  CONSTRAINT [FK_Positions_Subdivisions] FOREIGN KEY([IdSubdivision])
REFERENCES [dbo].[Subdivisions] ([Id])
GO
ALTER TABLE [dbo].[Positions] CHECK CONSTRAINT [FK_Positions_Subdivisions]
GO
ALTER TABLE [dbo].[Subdivisions]  WITH CHECK ADD  CONSTRAINT [FK_Subdivisions_TypesOfSubdivisions] FOREIGN KEY([IdType])
REFERENCES [dbo].[TypesOfSubdivisions] ([Id])
GO
ALTER TABLE [dbo].[Subdivisions] CHECK CONSTRAINT [FK_Subdivisions_TypesOfSubdivisions]
GO
