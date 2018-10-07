
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/11/2018 13:26:06
-- Generated from EDMX file: D:\Temp\MOC20483\Mod07\Democode\Demo2\FourthCoffee.Employees\FourthCoffee.Employees\FourthCoffeeEmployeesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FourthCoffee];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Employees_Branches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Branches];
GO
IF OBJECT_ID(N'[dbo].[FK_Employees_JobTitles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_JobTitles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Branches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branches];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[JobTitles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobTitles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [BranchID] int  NOT NULL,
    [BranchName] varchar(50)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int  NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [DateOfBirth] datetime  NULL,
    [Branch] int  NULL,
    [JobTitle] int  NULL
);
GO

-- Creating table 'JobTitles'
CREATE TABLE [dbo].[JobTitles] (
    [JobTitleId] int  NOT NULL,
    [Job] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BranchID] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([BranchID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [JobTitleId] in table 'JobTitles'
ALTER TABLE [dbo].[JobTitles]
ADD CONSTRAINT [PK_JobTitles]
    PRIMARY KEY CLUSTERED ([JobTitleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Branch] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_Branches]
    FOREIGN KEY ([Branch])
    REFERENCES [dbo].[Branches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_Branches'
CREATE INDEX [IX_FK_Employees_Branches]
ON [dbo].[Employees]
    ([Branch]);
GO

-- Creating foreign key on [JobTitle] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_JobTitles]
    FOREIGN KEY ([JobTitle])
    REFERENCES [dbo].[JobTitles]
        ([JobTitleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_JobTitles'
CREATE INDEX [IX_FK_Employees_JobTitles]
ON [dbo].[Employees]
    ([JobTitle]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------