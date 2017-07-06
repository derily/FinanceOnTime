
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/05/2017 17:26:36
-- Generated from EDMX file: c:\users\administrator\documents\visual studio 2015\Projects\FinanceOnTime\DomainEntities\Entities\FinanceDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FinanceOnTime];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ArticleSet'
CREATE TABLE [dbo].[ArticleSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Source] nvarchar(max)  NOT NULL,
    [Keyword] nvarchar(max)  NOT NULL,
    [Tags] nvarchar(max)  NOT NULL,
    [Focused] nvarchar(max)  NOT NULL,
    [Recommended] bit  NOT NULL,
    [PagePosition] int  NOT NULL,
    [Enabled] bit  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [PraiseNum] nvarchar(max)  NOT NULL,
    [ViewNum] nvarchar(max)  NOT NULL,
    [CoverImagePath] nvarchar(max)  NOT NULL,
    [CreateTime] nvarchar(max)  NOT NULL,
    [CreateUserId] nvarchar(max)  NOT NULL,
    [RelateProductId] nvarchar(max)  NOT NULL,
    [CategoryId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EventSet'
CREATE TABLE [dbo].[EventSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'IndexSet'
CREATE TABLE [dbo].[IndexSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'IndexDataSet'
CREATE TABLE [dbo].[IndexDataSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'MessageSet'
CREATE TABLE [dbo].[MessageSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'GoodsSet'
CREATE TABLE [dbo].[GoodsSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'DictionarySet'
CREATE TABLE [dbo].[DictionarySet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ArticleSet'
ALTER TABLE [dbo].[ArticleSet]
ADD CONSTRAINT [PK_ArticleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventSet'
ALTER TABLE [dbo].[EventSet]
ADD CONSTRAINT [PK_EventSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IndexSet'
ALTER TABLE [dbo].[IndexSet]
ADD CONSTRAINT [PK_IndexSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IndexDataSet'
ALTER TABLE [dbo].[IndexDataSet]
ADD CONSTRAINT [PK_IndexDataSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MessageSet'
ALTER TABLE [dbo].[MessageSet]
ADD CONSTRAINT [PK_MessageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GoodsSet'
ALTER TABLE [dbo].[GoodsSet]
ADD CONSTRAINT [PK_GoodsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DictionarySet'
ALTER TABLE [dbo].[DictionarySet]
ADD CONSTRAINT [PK_DictionarySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------