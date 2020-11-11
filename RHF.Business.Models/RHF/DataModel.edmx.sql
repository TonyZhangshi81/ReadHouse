
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/24/2018 18:33:58
-- Generated from EDMX file: D:\MyWorks\FrameworkForReadHouse\RHF.Business.Models\RHF\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RHFDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[T_Member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Member];
GO
IF OBJECT_ID(N'[dbo].[T_LoginLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_LoginLog];
GO
IF OBJECT_ID(N'[dbo].[T_Book]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Book];
GO
IF OBJECT_ID(N'[dbo].[M_BookCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_BookCategory];
GO
IF OBJECT_ID(N'[dbo].[R_BookCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_BookCategory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T_Member'
CREATE TABLE [dbo].[T_Member] (
    [ID] bigint  NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [Password] nvarchar(32)  NOT NULL,
    [NickName] nvarchar(20)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [RoleType] smallint  NOT NULL
);
GO

-- Creating table 'T_LoginLog'
CREATE TABLE [dbo].[T_LoginLog] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [IpAddress] nvarchar(20)  NOT NULL,
    [MemberID] bigint  NOT NULL
);
GO

-- Creating table 'T_Book'
CREATE TABLE [dbo].[T_Book] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [MemberID] bigint  NOT NULL,
    [Image] varchar(500)  NULL,
    [CreateDateTime] datetime  NOT NULL
);
GO

-- Creating table 'M_BookCategory'
CREATE TABLE [dbo].[M_BookCategory] (
    [ID] int  NOT NULL,
    [TypeName] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'R_BookCategory'
CREATE TABLE [dbo].[R_BookCategory] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [BookID] bigint  NOT NULL,
    [BookCategoryID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'T_Member'
ALTER TABLE [dbo].[T_Member]
ADD CONSTRAINT [PK_T_Member]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'T_LoginLog'
ALTER TABLE [dbo].[T_LoginLog]
ADD CONSTRAINT [PK_T_LoginLog]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'T_Book'
ALTER TABLE [dbo].[T_Book]
ADD CONSTRAINT [PK_T_Book]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'M_BookCategory'
ALTER TABLE [dbo].[M_BookCategory]
ADD CONSTRAINT [PK_M_BookCategory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_BookCategory'
ALTER TABLE [dbo].[R_BookCategory]
ADD CONSTRAINT [PK_R_BookCategory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------