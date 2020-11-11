
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/08/2016 17:06:14
-- Generated from EDMX file: C:\MyWorks\FrameworkForReadHouse\RHF.Business.Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_R_RoleType_Member]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_Member] DROP CONSTRAINT [FK_R_RoleType_Member];
GO
IF OBJECT_ID(N'[dbo].[FK_T_MemberT_LoginLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_LoginLog] DROP CONSTRAINT [FK_T_MemberT_LoginLog];
GO
IF OBJECT_ID(N'[dbo].[FK_T_MemberT_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_Book] DROP CONSTRAINT [FK_T_MemberT_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_T_BookR_BookCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_BookCategory] DROP CONSTRAINT [FK_T_BookR_BookCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_M_BookCategoryR_BookCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_BookCategory] DROP CONSTRAINT [FK_M_BookCategoryR_BookCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_T_BookT_Commentary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_Commentary] DROP CONSTRAINT [FK_T_BookT_Commentary];
GO
IF OBJECT_ID(N'[dbo].[FK_T_MemberT_Commentary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_Commentary] DROP CONSTRAINT [FK_T_MemberT_Commentary];
GO
IF OBJECT_ID(N'[dbo].[FK_M_RoleType_inherits_BaseEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[M_RoleType] DROP CONSTRAINT [FK_M_RoleType_inherits_BaseEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_T_Member_inherits_BaseEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_Member] DROP CONSTRAINT [FK_T_Member_inherits_BaseEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_T_LoginLog_inherits_BaseEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_LoginLog] DROP CONSTRAINT [FK_T_LoginLog_inherits_BaseEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_T_Book_inherits_BaseEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_Book] DROP CONSTRAINT [FK_T_Book_inherits_BaseEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_R_BookCategory_inherits_BaseEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_BookCategory] DROP CONSTRAINT [FK_R_BookCategory_inherits_BaseEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_M_BookCategory_inherits_BaseEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[M_BookCategory] DROP CONSTRAINT [FK_M_BookCategory_inherits_BaseEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_T_Commentary_inherits_BaseEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_Commentary] DROP CONSTRAINT [FK_T_Commentary_inherits_BaseEntity];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BaseEntity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaseEntity];
GO
IF OBJECT_ID(N'[dbo].[M_RoleType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_RoleType];
GO
IF OBJECT_ID(N'[dbo].[T_Member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Member];
GO
IF OBJECT_ID(N'[dbo].[T_LoginLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_LoginLog];
GO
IF OBJECT_ID(N'[dbo].[T_Book]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Book];
GO
IF OBJECT_ID(N'[dbo].[R_BookCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_BookCategory];
GO
IF OBJECT_ID(N'[dbo].[M_BookCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_BookCategory];
GO
IF OBJECT_ID(N'[dbo].[T_Commentary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Commentary];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BaseEntity'
CREATE TABLE [dbo].[BaseEntity] (
    [ID] bigint  NOT NULL
);
GO

-- Creating table 'M_RoleType'
CREATE TABLE [dbo].[M_RoleType] (
    [TypeName] nvarchar(20)  NOT NULL,
    [ID] bigint  NOT NULL
);
GO

-- Creating table 'T_Member'
CREATE TABLE [dbo].[T_Member] (
    [UserName] nvarchar(20)  NOT NULL,
    [Password] nvarchar(32)  NOT NULL,
    [NickName] nvarchar(20)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [RoleType] bigint  NOT NULL,
    [ID] bigint  NOT NULL
);
GO

-- Creating table 'T_LoginLog'
CREATE TABLE [dbo].[T_LoginLog] (
    [MemberID] bigint  NOT NULL,
    [IpAddress] nvarchar(20)  NOT NULL,
    [ID] bigint  NOT NULL,
    [T_Member_ID] bigint  NOT NULL
);
GO

-- Creating table 'T_Book'
CREATE TABLE [dbo].[T_Book] (
    [Name] nvarchar(100)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [MemberID] bigint  NOT NULL,
    [ID] bigint  NOT NULL
);
GO

-- Creating table 'R_BookCategory'
CREATE TABLE [dbo].[R_BookCategory] (
    [BookID] bigint  NOT NULL,
    [BookCategoryID] bigint  NOT NULL,
    [ID] bigint  NOT NULL
);
GO

-- Creating table 'M_BookCategory'
CREATE TABLE [dbo].[M_BookCategory] (
    [TypeName] nvarchar(30)  NOT NULL,
    [ID] bigint  NOT NULL
);
GO

-- Creating table 'T_Commentary'
CREATE TABLE [dbo].[T_Commentary] (
    [Grade] smallint  NOT NULL,
    [Content] nvarchar(500)  NOT NULL,
    [BookID] bigint  NOT NULL,
    [MemberID] bigint  NOT NULL,
    [ID] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'BaseEntity'
ALTER TABLE [dbo].[BaseEntity]
ADD CONSTRAINT [PK_BaseEntity]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'M_RoleType'
ALTER TABLE [dbo].[M_RoleType]
ADD CONSTRAINT [PK_M_RoleType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

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

-- Creating primary key on [ID] in table 'R_BookCategory'
ALTER TABLE [dbo].[R_BookCategory]
ADD CONSTRAINT [PK_R_BookCategory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'M_BookCategory'
ALTER TABLE [dbo].[M_BookCategory]
ADD CONSTRAINT [PK_M_BookCategory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'T_Commentary'
ALTER TABLE [dbo].[T_Commentary]
ADD CONSTRAINT [PK_T_Commentary]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleType] in table 'T_Member'
ALTER TABLE [dbo].[T_Member]
ADD CONSTRAINT [FK_R_RoleType_Member]
    FOREIGN KEY ([RoleType])
    REFERENCES [dbo].[M_RoleType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_R_RoleType_Member'
CREATE INDEX [IX_FK_R_RoleType_Member]
ON [dbo].[T_Member]
    ([RoleType]);
GO

-- Creating foreign key on [T_Member_ID] in table 'T_LoginLog'
ALTER TABLE [dbo].[T_LoginLog]
ADD CONSTRAINT [FK_T_MemberT_LoginLog]
    FOREIGN KEY ([T_Member_ID])
    REFERENCES [dbo].[T_Member]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_T_MemberT_LoginLog'
CREATE INDEX [IX_FK_T_MemberT_LoginLog]
ON [dbo].[T_LoginLog]
    ([T_Member_ID]);
GO

-- Creating foreign key on [MemberID] in table 'T_Book'
ALTER TABLE [dbo].[T_Book]
ADD CONSTRAINT [FK_T_MemberT_Book]
    FOREIGN KEY ([MemberID])
    REFERENCES [dbo].[T_Member]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_T_MemberT_Book'
CREATE INDEX [IX_FK_T_MemberT_Book]
ON [dbo].[T_Book]
    ([MemberID]);
GO

-- Creating foreign key on [BookID] in table 'R_BookCategory'
ALTER TABLE [dbo].[R_BookCategory]
ADD CONSTRAINT [FK_T_BookR_BookCategory]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[T_Book]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_T_BookR_BookCategory'
CREATE INDEX [IX_FK_T_BookR_BookCategory]
ON [dbo].[R_BookCategory]
    ([BookID]);
GO

-- Creating foreign key on [BookCategoryID] in table 'R_BookCategory'
ALTER TABLE [dbo].[R_BookCategory]
ADD CONSTRAINT [FK_M_BookCategoryR_BookCategory]
    FOREIGN KEY ([BookCategoryID])
    REFERENCES [dbo].[M_BookCategory]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_M_BookCategoryR_BookCategory'
CREATE INDEX [IX_FK_M_BookCategoryR_BookCategory]
ON [dbo].[R_BookCategory]
    ([BookCategoryID]);
GO

-- Creating foreign key on [BookID] in table 'T_Commentary'
ALTER TABLE [dbo].[T_Commentary]
ADD CONSTRAINT [FK_T_BookT_Commentary]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[T_Book]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_T_BookT_Commentary'
CREATE INDEX [IX_FK_T_BookT_Commentary]
ON [dbo].[T_Commentary]
    ([BookID]);
GO

-- Creating foreign key on [MemberID] in table 'T_Commentary'
ALTER TABLE [dbo].[T_Commentary]
ADD CONSTRAINT [FK_T_MemberT_Commentary]
    FOREIGN KEY ([MemberID])
    REFERENCES [dbo].[T_Member]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_T_MemberT_Commentary'
CREATE INDEX [IX_FK_T_MemberT_Commentary]
ON [dbo].[T_Commentary]
    ([MemberID]);
GO

-- Creating foreign key on [ID] in table 'M_RoleType'
ALTER TABLE [dbo].[M_RoleType]
ADD CONSTRAINT [FK_M_RoleType_inherits_BaseEntity]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[BaseEntity]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'T_Member'
ALTER TABLE [dbo].[T_Member]
ADD CONSTRAINT [FK_T_Member_inherits_BaseEntity]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[BaseEntity]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'T_LoginLog'
ALTER TABLE [dbo].[T_LoginLog]
ADD CONSTRAINT [FK_T_LoginLog_inherits_BaseEntity]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[BaseEntity]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'T_Book'
ALTER TABLE [dbo].[T_Book]
ADD CONSTRAINT [FK_T_Book_inherits_BaseEntity]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[BaseEntity]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'R_BookCategory'
ALTER TABLE [dbo].[R_BookCategory]
ADD CONSTRAINT [FK_R_BookCategory_inherits_BaseEntity]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[BaseEntity]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'M_BookCategory'
ALTER TABLE [dbo].[M_BookCategory]
ADD CONSTRAINT [FK_M_BookCategory_inherits_BaseEntity]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[BaseEntity]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'T_Commentary'
ALTER TABLE [dbo].[T_Commentary]
ADD CONSTRAINT [FK_T_Commentary_inherits_BaseEntity]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[BaseEntity]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------