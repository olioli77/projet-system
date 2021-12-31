/*
Script de déploiement pour BDDRestaurant

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BDDRestaurant"
:setvar DefaultFilePrefix "BDDRestaurant"
:setvar DefaultDataPath "C:\Users\Heidy\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Heidy\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Création de Table [dbo].[compose]...';


GO
CREATE TABLE [dbo].[compose] (
    [id_compose]    INT NOT NULL,
    [id_etape]      INT NOT NULL,
    [id_Ingredient] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id_compose] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Table [dbo].[Etape]...';


GO
CREATE TABLE [dbo].[Etape] (
    [id_etape]     INT          NOT NULL,
    [nom_etape]    VARCHAR (50) NOT NULL,
    [temps_etape]  INT          NOT NULL,
    [sync_etape]   INT          NOT NULL,
    [id_Ustensile] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([id_etape] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Table [dbo].[Ingredient]...';


GO
CREATE TABLE [dbo].[Ingredient] (
    [id_Ingredient]  INT          NOT NULL,
    [nom_Ingredient] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Ingredient] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Table [dbo].[Recette]...';


GO
CREATE TABLE [dbo].[Recette] (
    [id_recette]           INT          NOT NULL,
    [nom_recette]          VARCHAR (50) NOT NULL,
    [liste_etapes_recette] TEXT         NOT NULL,
    [categorie]            VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_recette] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Table [dbo].[Stock]...';


GO
CREATE TABLE [dbo].[Stock] (
    [id_stock]               INT       NOT NULL,
    [date_expire_ingredient] TIMESTAMP NOT NULL,
    [quantite_stock]         INT       NOT NULL,
    [id_Ingredient]          INT       NOT NULL,
    PRIMARY KEY CLUSTERED ([id_stock] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Table [dbo].[Ustensile]...';


GO
CREATE TABLE [dbo].[Ustensile] (
    [id_Ustensile]      INT          NOT NULL,
    [Nom_ust_Ustensile] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Ustensile] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Clé étrangère [dbo].[FK_compose_Etape]...';


GO
ALTER TABLE [dbo].[compose] WITH NOCHECK
    ADD CONSTRAINT [FK_compose_Etape] FOREIGN KEY ([id_etape]) REFERENCES [dbo].[Etape] ([id_etape]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Clé étrangère [dbo].[FK_compose_Ingredient]...';


GO
ALTER TABLE [dbo].[compose] WITH NOCHECK
    ADD CONSTRAINT [FK_compose_Ingredient] FOREIGN KEY ([id_Ingredient]) REFERENCES [dbo].[Ingredient] ([id_Ingredient]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Etape_Ustensile]...';


GO
ALTER TABLE [dbo].[Etape] WITH NOCHECK
    ADD CONSTRAINT [FK_Etape_Ustensile] FOREIGN KEY ([id_Ustensile]) REFERENCES [dbo].[Ustensile] ([id_Ustensile]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Stock_Ingredient]...';


GO
ALTER TABLE [dbo].[Stock] WITH NOCHECK
    ADD CONSTRAINT [FK_Stock_Ingredient] FOREIGN KEY ([id_Ingredient]) REFERENCES [dbo].[Ingredient] ([id_Ingredient]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'Succès de la mise à jour de la portion de base de données traitée.'
COMMIT TRANSACTION
END
ELSE PRINT N'Échec de la mise à jour de la portion de base de données traitée.'
GO
IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[compose] WITH CHECK CHECK CONSTRAINT [FK_compose_Etape];

ALTER TABLE [dbo].[compose] WITH CHECK CHECK CONSTRAINT [FK_compose_Ingredient];

ALTER TABLE [dbo].[Etape] WITH CHECK CHECK CONSTRAINT [FK_Etape_Ustensile];

ALTER TABLE [dbo].[Stock] WITH CHECK CHECK CONSTRAINT [FK_Stock_Ingredient];


GO
PRINT N'Mise à jour terminée.';


GO
