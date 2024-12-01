USE [master]
GO
/****** Object:  Database [MotorSportTestDB]    Script Date: 12/1/2024 8:59:54 AM ******/
CREATE DATABASE [MotorSportTestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MotorSportTestDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MotorSportTestDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MotorSportTestDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MotorSportTestDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MotorSportTestDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MotorSportTestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MotorSportTestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MotorSportTestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MotorSportTestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MotorSportTestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MotorSportTestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MotorSportTestDB] SET  MULTI_USER 
GO
ALTER DATABASE [MotorSportTestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MotorSportTestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MotorSportTestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MotorSportTestDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MotorSportTestDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MotorSportTestDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MotorSportTestDB', N'ON'
GO
ALTER DATABASE [MotorSportTestDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MotorSportTestDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MotorSportTestDB]
GO
/****** Object:  Table [dbo].[EventManager]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventManager](
	[UserID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ManagerID] [int] NOT NULL,
 CONSTRAINT [PK_EventManager4] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventParticipants]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventParticipants](
	[EventParticipantID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[ParticipantID] [int] NULL,
	[TeamID] [int] NULL,
	[RacePosition] [int] NULL,
 CONSTRAINT [PK_EventParticipants] PRIMARY KEY CLUSTERED 
(
	[EventParticipantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](50) NOT NULL,
	[VenueID] [int] NULL,
	[EventDate] [datetime] NOT NULL,
	[TotalLaps] [int] NOT NULL,
	[StatusID] [int] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventSponsors]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventSponsors](
	[EventSponsorID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[SponsorID] [int] NOT NULL,
 CONSTRAINT [PK_EventSponsors] PRIMARY KEY CLUSTERED 
(
	[EventSponsorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participants]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participants](
	[ParticipantID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[LicenseNumber] [nvarchar](50) NOT NULL,
	[TeamID] [int] NULL,
 CONSTRAINT [PK_Participants] PRIMARY KEY CLUSTERED 
(
	[ParticipantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RaceResults]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RaceResults](
	[RaceResultID] [int] IDENTITY(1,1) NOT NULL,
	[EventParticipantID] [int] NOT NULL,
	[LapTime] [time](7) NOT NULL,
	[LapNumber] [int] NOT NULL,
	[Position] [int] NULL,
	[FinishTime] [time](7) NULL,
 CONSTRAINT [PK_RaceResults] PRIMARY KEY CLUSTERED 
(
	[RaceResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RaceSchedules]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RaceSchedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK__RaceSche__3214EC07CE2E0A04] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RaceStandings]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RaceStandings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DriverName] [nvarchar](100) NOT NULL,
	[Position] [int] NOT NULL,
	[Points] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sponsors]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sponsors](
	[SponsorID] [int] IDENTITY(1,1) NOT NULL,
	[SponsorName] [nvarchar](50) NOT NULL,
	[SponsorType] [nvarchar](50) NOT NULL,
	[ContactInfo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sponsors] PRIMARY KEY CLUSTERED 
(
	[SponsorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
	[TeamManagerID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PaswordHash] [nvarchar](50) NOT NULL,
	[EMail] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venues]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venues](
	[VenueID] [int] IDENTITY(1,1) NOT NULL,
	[VenueName] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[Capacity] [int] NOT NULL,
	[TrackLength] [decimal](18, 3) NOT NULL,
 CONSTRAINT [PK_Venues] PRIMARY KEY CLUSTERED 
(
	[VenueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventParticipants]  WITH CHECK ADD  CONSTRAINT [FK_EventParticipants_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[EventParticipants] CHECK CONSTRAINT [FK_EventParticipants_Events]
GO
ALTER TABLE [dbo].[EventParticipants]  WITH CHECK ADD  CONSTRAINT [FK_EventParticipants_Participants] FOREIGN KEY([ParticipantID])
REFERENCES [dbo].[Participants] ([ParticipantID])
GO
ALTER TABLE [dbo].[EventParticipants] CHECK CONSTRAINT [FK_EventParticipants_Participants]
GO
ALTER TABLE [dbo].[EventParticipants]  WITH CHECK ADD  CONSTRAINT [FK_EventParticipants_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO
ALTER TABLE [dbo].[EventParticipants] CHECK CONSTRAINT [FK_EventParticipants_Teams]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Status]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Venues] FOREIGN KEY([VenueID])
REFERENCES [dbo].[Venues] ([VenueID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Venues]
GO
ALTER TABLE [dbo].[EventSponsors]  WITH CHECK ADD  CONSTRAINT [FK_EventSponsors_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[EventSponsors] CHECK CONSTRAINT [FK_EventSponsors_Events]
GO
ALTER TABLE [dbo].[EventSponsors]  WITH CHECK ADD  CONSTRAINT [FK_EventSponsors_Sponsors] FOREIGN KEY([SponsorID])
REFERENCES [dbo].[Sponsors] ([SponsorID])
GO
ALTER TABLE [dbo].[EventSponsors] CHECK CONSTRAINT [FK_EventSponsors_Sponsors]
GO
ALTER TABLE [dbo].[Participants]  WITH CHECK ADD  CONSTRAINT [FK_Participants_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO
ALTER TABLE [dbo].[Participants] CHECK CONSTRAINT [FK_Participants_Teams]
GO
ALTER TABLE [dbo].[Participants]  WITH CHECK ADD  CONSTRAINT [FK_Participants_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Participants] CHECK CONSTRAINT [FK_Participants_Users]
GO
ALTER TABLE [dbo].[RaceResults]  WITH CHECK ADD  CONSTRAINT [FK_RaceResults_EventParticipants] FOREIGN KEY([EventParticipantID])
REFERENCES [dbo].[EventParticipants] ([EventParticipantID])
GO
ALTER TABLE [dbo].[RaceResults] CHECK CONSTRAINT [FK_RaceResults_EventParticipants]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Users] FOREIGN KEY([TeamManagerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Users]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DeleteUser]
	@UserID int
AS
BEGIN
SET NOCOUNT ON
DELETE FROM Users
WHERE @UserID = UserID
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSponsorsByEventID]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSponsorsByEventID]
	@EventID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT
		SP.SponsorID,
		SP.SponsorName,
		SP.SponsorType,
		SP.ContactInfo
	FROM
		Sponsors SP
		JOIN EventSponsors ESP ON ESP.SponsorID = SP.SponsorID
	WHERE
		ESP.EventID = @EventID;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertEvent]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertEvent]
	@EventName nvarchar(50),
	@EventDate nvarchar(50),
	@VenueID int,
	@TotalLaps int,
	@EventStatus int,
	@SponsorID int
AS
BEGIN
SET NOCOUNT ON
INSERT INTO [Events]
VALUES
(
	@EventName,
	@EventDate,
	@VenueID,
	@TotalLaps,
	@EventStatus,
	@SponsorID

)
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertEventParticipant]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertEventParticipant]
	@EventID int,
	@ParticipantID int,
	@TeamID int,
	@RacePosition int
AS
BEGIN
SET NOCOUNT ON
INSERT INTO EventParticipants
VALUES
(
	@EventID,
	@ParticipantID,
	@TeamID,
	@RacePosition
)
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertEventSponsor]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertEventSponsor]
	@EventID int,
	@SponsorID int
AS
BEGIN
SET NOCOUNT ON
INSERT INTO EventSponsors
VALUES
(
	@EventID,
	@SponsorID
)
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertParticipant]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertParticipant]
	@UserID int,
	@TeamID int,
	@LicenseNumber int
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Teams
VALUES
(
	@UserID,
	@TeamID,
	@LicenseNumber
)
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertRaceResult]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertRaceResult]
	@EventParticipantID int,
	@Laptime datetime,
	@LapNumber int
AS
BEGIN
SET NOCOUNT ON
INSERT INTO RaceResults
VALUES
(
	@EventParticipantID,
	@Laptime,
	@LapNumber
)
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertSponsor]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertSponsor]
	@SponsorName nvarchar(50),
	@SponsorType nvarchar(50),
	@ContactInfo nvarchar(50)
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Sponsors
VALUES
(
	@SponsorName,
	@SponsorType,
	@ContactInfo
)
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertTeam]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertTeam]
	@TeamName nvarchar(50),
	@TeamManagerID int
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Teams
VALUES
(
	@TeamName,
	@TeamManagerID,
	GETDATE()
)
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[InsertUser]
	@UserName nvarchar(50),
	@PasswordHash nvarchar(50),
	@EMail nvarchar(50),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@RoleID int,
	@UserID int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO 
		Users
	VALUES
		(
			@UserName,
			@PasswordHash,
			@EMail,
			@FirstName,
			@LastName,
			GETDATE()
		);

	SET @UserID = SCOPE_IDENTITY()

	INSERT INTO UserRoles
	VALUES
	(
		@UserID,
		@RoleID
	);

	RETURN @UserID;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertUserRole]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[InsertUserRole]
	@UserID int,
	@RoleID int
AS
BEGIN
SET NOCOUNT ON
INSERT INTO UserRoles
VALUES
(
	@UserID,
	@RoleID
)
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertVenue]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[InsertVenue]
	@VenueName int,
	@Location nvarchar(50),
	@Capacity int,
	@TrackLength decimal(18,3)
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Venues
VALUES
(
	@VenueName,
	@Location,
	@Capacity,
	@TrackLength
)
END;
GO
/****** Object:  StoredProcedure [dbo].[ViewAllEvents]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewAllEvents]
AS
BEGIN
SET NOCOUNT ON
SELECT
	EV.EventID,
	EV.EventName,
	EV.VenueID,
	VE.VenueName,
	EV.EventDate,
	EV.TotalLaps,
	EV.StatusID,
	ST.StatusName
FROM
	Events EV
	JOIN Venues VE ON VE.VenueID = EV.VenueID
	JOIN Status ST ON ST.StatusID = EV.StatusID
END
GO
/****** Object:  StoredProcedure [dbo].[ViewAllPlayers]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewAllPlayers]
AS
BEGIN
SET NOCOUNT ON
SELECT
	*
FROM
	Participants
END
GO
/****** Object:  StoredProcedure [dbo].[ViewAllRoles]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewAllRoles]
AS
BEGIN
SET NOCOUNT ON
SELECT
	*
FROM
	Users
END;
GO
/****** Object:  StoredProcedure [dbo].[ViewAllStatuses]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewAllStatuses]
AS
BEGIN
SET NOCOUNT ON
SELECT 
                            e.EventID,
                            e.EventName,
                            e.EventDate,
                            e.TotalLaps,
                            s.StatusName
                      FROM 
                          Events e
                     LEFT JOIN 
                              Status s ON e.StatusID = s.StatusID;
END
GO
/****** Object:  StoredProcedure [dbo].[ViewPlayerPerformas]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewPlayerPerformas]
@EventParticipantId INT
AS
BEGIN
SET NOCOUNT ON
SELECT 
                             ep.EventParticipantId,
                             ep.EventId,
                             ep.TeamId,
                             rr.RaceResultId,
                             rr.Position,
                             rr.LapTime,
                             rr.FinishTime
                        FROM 
                            EventParticipants ep
                        INNER JOIN 
                            RaceResults rr ON ep.EventParticipantId = rr.EventParticipantId
                        WHERE 
                            ep.EventParticipantId = @EventParticipantId
END
GO
/****** Object:  StoredProcedure [dbo].[ViewRaceResults]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewRaceResults]
AS
BEGIN
SET NOCOUNT ON
SELECT
	*
FROM
	RaceResults
END
GO
/****** Object:  StoredProcedure [dbo].[ViewRaceSchedule]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewRaceSchedule]
AS
BEGIN
SET NOCOUNT ON
SELECT
                            EventId,
                            EventName,
                            VenueId,
                            EventDate,
                            TotalLaps,
                            StatusId
                     FROM
                         [Events]
                     ORDER BY
                             EventDate
END
GO
/****** Object:  StoredProcedure [dbo].[ViewRaceStandings]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewRaceStandings]
AS
BEGIN
SET NOCOUNT ON
SELECT
	*
FROM
	RaceStandings
END
GO
/****** Object:  StoredProcedure [dbo].[ViewSponsoredEvents]    Script Date: 12/1/2024 8:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewSponsoredEvents]
    @SponsorID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        e.EventId,
        e.EventName,
        e.VenueId,
        e.EventDate,
        e.TotalLaps,
        e.StatusId
    FROM
        [Events] AS e
    INNER JOIN
        [EventSponsors] AS es ON e.EventId = es.EventId
    WHERE
        es.SponsorID = @SponsorID;
END;
GO
USE [master]
GO
ALTER DATABASE [MotorSportTestDB] SET  READ_WRITE 
GO
