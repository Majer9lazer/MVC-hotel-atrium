
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/12/2018 15:03:27
-- Generated from EDMX file: C:\Users\user\Source\Repos\MVC-hotel-atrium\HotelAtr.DAL\Model\HotelAtrEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HotelAtr];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Room_RoomType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_RoomType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room];
GO
IF OBJECT_ID(N'[dbo].[RoomType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomType];
GO
IF OBJECT_ID(N'[dbo].[Service]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Service];
GO
IF OBJECT_ID(N'[dbo].[SliderAreas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SliderAreas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SliderAreas'
CREATE TABLE [dbo].[SliderAreas] (
    [SliderAreaId] int IDENTITY(1,1) NOT NULL,
    [Header] nvarchar(100)  NULL,
    [Description] nvarchar(250)  NULL,
    [Url] nvarchar(500)  NULL,
    [PathImg] nvarchar(500)  NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [RoomId] int IDENTITY(1,1) NOT NULL,
    [RoomTypeId] int  NOT NULL,
    [Square] decimal(18,0)  NULL,
    [MaxPersons] int  NULL,
    [IsFreeWifi] bit  NOT NULL,
    [IsPrivateBalcony] bit  NOT NULL,
    [IsFullAC] bit  NOT NULL,
    [Floor] int  NOT NULL,
    [HasTV] bit  NOT NULL,
    [IsBeachView] bit  NOT NULL
);
GO

-- Creating table 'RoomTypes'
CREATE TABLE [dbo].[RoomTypes] (
    [RoomTypeId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL,
    [RoomTypeDescription] nvarchar(1000)  NULL,
    [Price] int  NULL,
    [Imagepath] nvarchar(1000)  NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [ServiceId] int IDENTITY(1,1) NOT NULL,
    [ServiceName] nvarchar(50)  NOT NULL,
    [ServiceDescription] nvarchar(500)  NOT NULL,
    [ServiceIconPath] nvarchar(500)  NOT NULL,
    [ServiceImagePath] nvarchar(500)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SliderAreaId] in table 'SliderAreas'
ALTER TABLE [dbo].[SliderAreas]
ADD CONSTRAINT [PK_SliderAreas]
    PRIMARY KEY CLUSTERED ([SliderAreaId] ASC);
GO

-- Creating primary key on [RoomId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([RoomId] ASC);
GO

-- Creating primary key on [RoomTypeId] in table 'RoomTypes'
ALTER TABLE [dbo].[RoomTypes]
ADD CONSTRAINT [PK_RoomTypes]
    PRIMARY KEY CLUSTERED ([RoomTypeId] ASC);
GO

-- Creating primary key on [ServiceId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([ServiceId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoomTypeId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_Room_RoomType]
    FOREIGN KEY ([RoomTypeId])
    REFERENCES [dbo].[RoomTypes]
        ([RoomTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_RoomType'
CREATE INDEX [IX_FK_Room_RoomType]
ON [dbo].[Rooms]
    ([RoomTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------