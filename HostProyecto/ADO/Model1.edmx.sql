
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/21/2019 11:11:02
-- Generated from EDMX file: C:\Users\rockm\source\repos\HostProyecto\ADO\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Proyecto];
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

-- Creating table 'JugadorSet'
CREATE TABLE [dbo].[JugadorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [contrasenia] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [usuario] nvarchar(max)  NOT NULL,
    [estado] int  NOT NULL,
    [fichaCampania] int  NOT NULL,
    [idioma] int  NOT NULL,
    [campania] int  NOT NULL,
    [partidasJugadas] int  NOT NULL,
    [codigo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PuntuacionSet'
CREATE TABLE [dbo].[PuntuacionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [puntuacion] int  NOT NULL,
    [fecha] datetime  NOT NULL,
    [Jugador_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'JugadorSet'
ALTER TABLE [dbo].[JugadorSet]
ADD CONSTRAINT [PK_JugadorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PuntuacionSet'
ALTER TABLE [dbo].[PuntuacionSet]
ADD CONSTRAINT [PK_PuntuacionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Jugador_Id] in table 'PuntuacionSet'
ALTER TABLE [dbo].[PuntuacionSet]
ADD CONSTRAINT [FK_PuntuacionJugador]
    FOREIGN KEY ([Jugador_Id])
    REFERENCES [dbo].[JugadorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PuntuacionJugador'
CREATE INDEX [IX_FK_PuntuacionJugador]
ON [dbo].[PuntuacionSet]
    ([Jugador_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------