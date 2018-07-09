
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/09/2018 17:33:20
-- Generated from EDMX file: C:\Users\СидоренкоЕ\Source\Repos\MVC-hotel-atrium\HotelAtr.DAL\Model\HotelAtrEntity.edmx
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

-- Creating primary key on [SliderAreaId] in table 'SliderAreas'
ALTER TABLE [dbo].[SliderAreas]
ADD CONSTRAINT [PK_SliderAreas]
    PRIMARY KEY CLUSTERED ([SliderAreaId] ASC);
GO
