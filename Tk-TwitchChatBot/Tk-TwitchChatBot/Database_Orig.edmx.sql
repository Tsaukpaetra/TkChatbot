
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server Compact Edition
-- --------------------------------------------------
-- Date Created: 12/29/2015 22:23:15
-- Generated from EDMX file: C:\Users\Anthony\Google Drive\Personal Projects\Tk-TwitchChatBot\Tk-TwitchChatBot\Database.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- NOTE: if the table does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    DROP TABLE [Commands];
GO
    DROP TABLE [Cooldowns];
GO
	DROP TABLE [Users];
GO 
	DROP TABLE [UserAttributes];
GO
	DROP TABLE [Timers]
Go

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Commands'
CREATE TABLE [Commands] (
    [Id] int  NOT NULL,
    [Keyword] nvarchar(40)  NOT NULL,
    [Enabled] bit  NOT NULL default (1),
    [GlobalCD] int  NOT NULL default(0),
    [UserCD] int  NOT NULL default(0),
    [MinPermissionLevel] int  NOT NULL default(0),
    [ExtraPrecondition] nvarchar(500)  NULL,
	[CoolDownMessage] nvarchar(500) null default ('This command is on cooldown.'),
    [Actions] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'Cooldowns'
CREATE TABLE [Cooldowns] (
    [CommandId] int  NOT NULL,
    [User] nvarchar(25)  NOT NULL,
    [Expiration] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [Users] (
	[UserName] nvarchar(25) not null,
	[FirstSeen] datetime not null default(GETDATE()),
	[FirstSeenThisSession] datetime not null default(GETDATE()),
	[LastSeen] datetime not null default(GETDATE()),
	[PermissionLevel] int not null default(0)

);

-- Creating table 'UserAttributes'

CREATE TABLE [UserAttributes] (
	[UserName] nvarchar(25) not null,
	[Key] nvarchar(20) not null,
	[Value] nvarchar(4000) null
);

-- Creating Table 'Timers'

CREATE TABLE [Timers] (
	[Name] nvarchar(25) not null,
	[Enabled] bit not null,
	[Repeat] int not null,
	[RepeatSeconds] int not null,
	[NextTrigger] datetime not null,
	[Action] nvarchar(4000) not null
);

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Commands'
ALTER TABLE [Commands]
ADD CONSTRAINT [PK_Commands]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [CommandId], [User] in table 'Cooldowns'
ALTER TABLE [Cooldowns]
ADD CONSTRAINT [PK_Cooldowns]
    PRIMARY KEY ([CommandId], [User] );
GO

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users]
	PRIMARY KEY (UserName);

ALTER TABLE [UserAttributes]
ADD CONSTRAINT [PK_UserAttributes]
	PRIMARY KEY([UserName],[Key]);

Alter Table [Timers]
Add Constraint [PK_Timers]
	Primary Key([Name]);
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------
Create unique index Ix_Commands on Commands
(Keyword);

Create index Ix_Timers on [Timers]
([Enabled],[NextTrigger]);
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------