
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/09/2016 17:51:45
-- Generated from EDMX file: C:\Users\Anthony\Google Drive\Personal Projects\Tk-TwitchChatBot\Tk-TwitchChatBot\Database.edmx
-- --------------------------------------------------

--SET QUOTED_IDENTIFIER OFF;
--GO
--USE [Database];
--GO
--IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
--GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Commands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Commands];
GO
IF OBJECT_ID(N'[dbo].[Cooldowns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cooldowns];
GO
IF OBJECT_ID(N'[dbo].[Timers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Timers];
GO
IF OBJECT_ID(N'[dbo].[UserAttributes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAttributes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Commands'
CREATE TABLE [dbo].[Commands] (
    [Id] int  NOT NULL,
    [Keyword] nvarchar(40)  NOT NULL,
    [Enabled] bit  NOT NULL,
    [GlobalCD] int  NOT NULL,
    [UserCD] int  NOT NULL,
    [MinPermissionLevel] int  NOT NULL,
    [ExtraPrecondition] nvarchar(500)  NULL,
    [CoolDownMessage] nvarchar(500)  NULL,
    [Actions] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'Cooldowns'
CREATE TABLE [dbo].[Cooldowns] (
    [CommandId] int  NOT NULL,
    [User] nvarchar(25)  NOT NULL,
    [Expiration] datetime  NOT NULL
);
GO

-- Creating table 'Timers'
CREATE TABLE [dbo].[Timers] (
    [Name] nvarchar(25)  NOT NULL,
    [Enabled] bit  NOT NULL,
    [Repeat] int  NOT NULL,
    [RepeatSeconds] int  NOT NULL,
    [NextTrigger] datetime  NOT NULL,
    [Action] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'UserAttributes'
CREATE TABLE [dbo].[UserAttributes] (
    [UserName] nvarchar(25)  NOT NULL,
    [Key] nvarchar(20)  NOT NULL,
    [Value] nvarchar(4000)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserName] nvarchar(25)  NOT NULL,
    [FirstSeen] datetime  NOT NULL,
    [FirstSeenThisSession] datetime  NOT NULL,
    [LastSeen] datetime  NOT NULL,
    [PermissionLevel] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Commands'
ALTER TABLE [dbo].[Commands]
ADD CONSTRAINT [PK_Commands]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CommandId], [User] in table 'Cooldowns'
ALTER TABLE [dbo].[Cooldowns]
ADD CONSTRAINT [PK_Cooldowns]
    PRIMARY KEY CLUSTERED ([CommandId], [User] ASC);
GO

-- Creating primary key on [Name] in table 'Timers'
ALTER TABLE [dbo].[Timers]
ADD CONSTRAINT [PK_Timers]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [UserName], [Key] in table 'UserAttributes'
ALTER TABLE [dbo].[UserAttributes]
ADD CONSTRAINT [PK_UserAttributes]
    PRIMARY KEY CLUSTERED ([UserName], [Key] ASC);
GO

-- Creating primary key on [UserName] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------