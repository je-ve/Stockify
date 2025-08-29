IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Street] nvarchar(50) NOT NULL,
    [Number] nvarchar(10) NOT NULL,
    [City] nvarchar(50) NOT NULL,
    [ZipCode] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [Status] int NOT NULL,
    [CustomerId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderActions] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_OrderActions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderActions_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderLines] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_OrderLines] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderLines_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderLines_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [StockActions] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [Type] int NOT NULL,
    [Quantity] int NOT NULL,
    [OrderLineId] int NULL,
    CONSTRAINT [PK_StockActions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_StockActions_OrderLines_OrderLineId] FOREIGN KEY ([OrderLineId]) REFERENCES [OrderLines] ([Id]),
    CONSTRAINT [FK_StockActions_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_OrderActions_OrderId] ON [OrderActions] ([OrderId]);
GO

CREATE INDEX [IX_OrderLines_OrderId] ON [OrderLines] ([OrderId]);
GO

CREATE INDEX [IX_OrderLines_ProductId] ON [OrderLines] ([ProductId]);
GO

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);
GO

CREATE INDEX [IX_StockActions_OrderLineId] ON [StockActions] ([OrderLineId]);
GO

CREATE INDEX [IX_StockActions_ProductId] ON [StockActions] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250520233534_InitialCreate', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Number');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Customers] DROP COLUMN [Number];
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'Name', N'Street', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Customers]'))
    SET IDENTITY_INSERT [Customers] ON;
INSERT INTO [Customers] ([Id], [City], [Name], [Street], [ZipCode])
VALUES (1, N'Antwerpen', N'Liesbeth Peeters', N'Meir', N'2000'),
(2, N'Gent', N'Tom De Smet', N'Veldstraat', N'9000'),
(3, N'Brugge', N'Sofie Maes', N'Zuidzandstraat', N'8000'),
(4, N'Leuven', N'Bram Janssens', N'Bondgenotenlaan', N'3000'),
(5, N'Mechelen', N'Eline Willems', N'Onze-Lieve-Vrouwestraat', N'2800'),
(6, N'Antwerpen', N'Niels Vermeulen', N'Groenplaats', N'2000'),
(7, N'Oostende', N'Karen Van Damme', N'Kapellestraat', N'8400'),
(8, N'Kortrijk', N'Dries De Clercq', N'Kortrijksesteenweg', N'8500'),
(9, N'Knokke-Heist', N'Inge Goossens', N'Lippenslaan', N'8300'),
(10, N'Brussel', N'Wim Van den Broeck', N'Rue de Namur', N'1000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'Name', N'Street', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Customers]'))
    SET IDENTITY_INSERT [Customers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [Name])
VALUES (1, N'Toothbrush'),
(2, N'Schrijfbic'),
(3, N'Notitieboekje'),
(4, N'Afwasborstel'),
(5, N'Wc-borstel'),
(6, N'Flesopener'),
(7, N'Zaklamp'),
(8, N'Brooddoos'),
(9, N'Koffiemok'),
(10, N'Drinkfles'),
(11, N'Keukenschaar'),
(12, N'Tandenstoker'),
(13, N'Stekkerdoos'),
(14, N'Timer'),
(15, N'Fietslichtje'),
(16, N'Ovenwant'),
(17, N'Schroevendraaier'),
(18, N'Gsm-houder'),
(19, N'Rekenmachine'),
(20, N'Geurkaars');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250521141115_SeedInitialData', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] ADD [SerialNumber] bigint NOT NULL DEFAULT CAST(0 AS bigint);
GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [SerialNumber] = CAST(0 AS bigint)
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250524144130_SerialNumberAdded', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] ADD [AvailableStock] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Products] ADD [TotalStock] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Products] ADD [TotalStockActions] int NOT NULL DEFAULT 0;
GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [AvailableStock] = 0, [TotalStock] = 0, [TotalStockActions] = 0
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250525104324_AddedStocktotals', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [StockActions] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '2025-08-27T10:23:15.3557744Z';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250525122248_AddedStockActionCreatedAt', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] ADD [LastStockAction] datetime2 NULL;
GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastStockAction] = NULL
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250525131333_AddedLastStockAction', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [OrderLines] ADD [Quantity] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250525190756_OrderLineQuantity', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250603081105_addIdentity', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Customers] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Customers] ADD [CreatedById] nvarchar(450) NULL;
GO

ALTER TABLE [Customers] ADD [UpdatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Customers] ADD [UpdatedById] nvarchar(450) NULL;
GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212467Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212469Z', [UpdatedById] = NULL
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212474Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212474Z', [UpdatedById] = NULL
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212477Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212477Z', [UpdatedById] = NULL
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212479Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212479Z', [UpdatedById] = NULL
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212481Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212481Z', [UpdatedById] = NULL
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212482Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212483Z', [UpdatedById] = NULL
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212484Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212485Z', [UpdatedById] = NULL
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212487Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212487Z', [UpdatedById] = NULL
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212488Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212489Z', [UpdatedById] = NULL
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T14:21:53.7212490Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T14:21:53.7212491Z', [UpdatedById] = NULL
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Customers_CreatedById] ON [Customers] ([CreatedById]);
GO

CREATE INDEX [IX_Customers_UpdatedById] ON [Customers] ([UpdatedById]);
GO

ALTER TABLE [Customers] ADD CONSTRAINT [FK_Customers_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]);
GO

ALTER TABLE [Customers] ADD CONSTRAINT [FK_Customers_AspNetUsers_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [AspNetUsers] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250607142154_AddCustomerAuditFieldsNullable', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Products] ADD [CreatedById] nvarchar(450) NULL;
GO

ALTER TABLE [Products] ADD [UpdatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Products] ADD [UpdatedById] nvarchar(450) NULL;
GO

ALTER TABLE [Orders] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Orders] ADD [CreatedById] nvarchar(450) NULL;
GO

ALTER TABLE [Orders] ADD [UpdatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [Orders] ADD [UpdatedById] nvarchar(450) NULL;
GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612558Z', [UpdatedAt] = '2025-06-07T18:18:37.5612560Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612563Z', [UpdatedAt] = '2025-06-07T18:18:37.5612563Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612565Z', [UpdatedAt] = '2025-06-07T18:18:37.5612565Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612566Z', [UpdatedAt] = '2025-06-07T18:18:37.5612567Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612568Z', [UpdatedAt] = '2025-06-07T18:18:37.5612568Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612569Z', [UpdatedAt] = '2025-06-07T18:18:37.5612569Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612570Z', [UpdatedAt] = '2025-06-07T18:18:37.5612571Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612571Z', [UpdatedAt] = '2025-06-07T18:18:37.5612572Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612573Z', [UpdatedAt] = '2025-06-07T18:18:37.5612573Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-07T18:18:37.5612574Z', [UpdatedAt] = '2025-06-07T18:18:37.5612574Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612705Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612705Z', [UpdatedById] = NULL
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612708Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612709Z', [UpdatedById] = NULL
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612714Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612715Z', [UpdatedById] = NULL
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612716Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612716Z', [UpdatedById] = NULL
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612717Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612717Z', [UpdatedById] = NULL
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612718Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612719Z', [UpdatedById] = NULL
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612719Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612720Z', [UpdatedById] = NULL
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612720Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612721Z', [UpdatedById] = NULL
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612721Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612722Z', [UpdatedById] = NULL
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612722Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612723Z', [UpdatedById] = NULL
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612723Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612724Z', [UpdatedById] = NULL
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612724Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612725Z', [UpdatedById] = NULL
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612725Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612726Z', [UpdatedById] = NULL
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612726Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612727Z', [UpdatedById] = NULL
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612727Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612728Z', [UpdatedById] = NULL
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612728Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612729Z', [UpdatedById] = NULL
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612729Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612730Z', [UpdatedById] = NULL
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612730Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612731Z', [UpdatedById] = NULL
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612731Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612732Z', [UpdatedById] = NULL
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-07T18:18:37.5612732Z', [CreatedById] = NULL, [UpdatedAt] = '2025-06-07T18:18:37.5612733Z', [UpdatedById] = NULL
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Products_CreatedById] ON [Products] ([CreatedById]);
GO

CREATE INDEX [IX_Products_UpdatedById] ON [Products] ([UpdatedById]);
GO

CREATE INDEX [IX_Orders_CreatedById] ON [Orders] ([CreatedById]);
GO

CREATE INDEX [IX_Orders_UpdatedById] ON [Orders] ([UpdatedById]);
GO

ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]);
GO

ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_AspNetUsers_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [AspNetUsers] ([Id]);
GO

ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_AspNetUsers_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [AspNetUsers] ([Id]);
GO

ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_AspNetUsers_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [AspNetUsers] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250607181837_AddProductAndOrderAuditFieldsNullable', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [OrderActions] DROP CONSTRAINT [FK_OrderActions_Orders_OrderId];
GO

DROP INDEX [IX_OrderActions_OrderId] ON [OrderActions];
GO

EXEC sp_rename N'[OrderActions].[Status]', N'ActionType', N'COLUMN';
GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620653Z', [UpdatedAt] = '2025-06-09T08:39:08.6620656Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620661Z', [UpdatedAt] = '2025-06-09T08:39:08.6620661Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620663Z', [UpdatedAt] = '2025-06-09T08:39:08.6620664Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620666Z', [UpdatedAt] = '2025-06-09T08:39:08.6620666Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620668Z', [UpdatedAt] = '2025-06-09T08:39:08.6620668Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620670Z', [UpdatedAt] = '2025-06-09T08:39:08.6620670Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620672Z', [UpdatedAt] = '2025-06-09T08:39:08.6620673Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620675Z', [UpdatedAt] = '2025-06-09T08:39:08.6620675Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620677Z', [UpdatedAt] = '2025-06-09T08:39:08.6620677Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-09T08:39:08.6620679Z', [UpdatedAt] = '2025-06-09T08:39:08.6620679Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620885Z', [UpdatedAt] = '2025-06-09T08:39:08.6620886Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620890Z', [UpdatedAt] = '2025-06-09T08:39:08.6620890Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620892Z', [UpdatedAt] = '2025-06-09T08:39:08.6620892Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620894Z', [UpdatedAt] = '2025-06-09T08:39:08.6620894Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620896Z', [UpdatedAt] = '2025-06-09T08:39:08.6620896Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620897Z', [UpdatedAt] = '2025-06-09T08:39:08.6620898Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620899Z', [UpdatedAt] = '2025-06-09T08:39:08.6620900Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620901Z', [UpdatedAt] = '2025-06-09T08:39:08.6620901Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620903Z', [UpdatedAt] = '2025-06-09T08:39:08.6620903Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620904Z', [UpdatedAt] = '2025-06-09T08:39:08.6620905Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620906Z', [UpdatedAt] = '2025-06-09T08:39:08.6620907Z'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620908Z', [UpdatedAt] = '2025-06-09T08:39:08.6620908Z'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620910Z', [UpdatedAt] = '2025-06-09T08:39:08.6620910Z'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620911Z', [UpdatedAt] = '2025-06-09T08:39:08.6620912Z'
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620913Z', [UpdatedAt] = '2025-06-09T08:39:08.6620914Z'
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620915Z', [UpdatedAt] = '2025-06-09T08:39:08.6620915Z'
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620917Z', [UpdatedAt] = '2025-06-09T08:39:08.6620917Z'
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620918Z', [UpdatedAt] = '2025-06-09T08:39:08.6620919Z'
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620920Z', [UpdatedAt] = '2025-06-09T08:39:08.6620921Z'
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-09T08:39:08.6620922Z', [UpdatedAt] = '2025-06-09T08:39:08.6620922Z'
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609083909_removedOrderActionsFromOrder', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Messages] (
    [Id] int NOT NULL IDENTITY,
    [HighPriority] bit NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedById] nvarchar(max) NOT NULL,
    [CreatedByName] nvarchar(max) NULL,
    [RecipientId] nvarchar(max) NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id])
);
GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166404Z', [UpdatedAt] = '2025-06-10T15:23:10.3166406Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166409Z', [UpdatedAt] = '2025-06-10T15:23:10.3166409Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166411Z', [UpdatedAt] = '2025-06-10T15:23:10.3166411Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166412Z', [UpdatedAt] = '2025-06-10T15:23:10.3166412Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166413Z', [UpdatedAt] = '2025-06-10T15:23:10.3166414Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166415Z', [UpdatedAt] = '2025-06-10T15:23:10.3166415Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166416Z', [UpdatedAt] = '2025-06-10T15:23:10.3166416Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166417Z', [UpdatedAt] = '2025-06-10T15:23:10.3166417Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166418Z', [UpdatedAt] = '2025-06-10T15:23:10.3166419Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T15:23:10.3166420Z', [UpdatedAt] = '2025-06-10T15:23:10.3166420Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166553Z', [UpdatedAt] = '2025-06-10T15:23:10.3166553Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166555Z', [UpdatedAt] = '2025-06-10T15:23:10.3166556Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166557Z', [UpdatedAt] = '2025-06-10T15:23:10.3166557Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166558Z', [UpdatedAt] = '2025-06-10T15:23:10.3166558Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166559Z', [UpdatedAt] = '2025-06-10T15:23:10.3166559Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166560Z', [UpdatedAt] = '2025-06-10T15:23:10.3166560Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166561Z', [UpdatedAt] = '2025-06-10T15:23:10.3166561Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166562Z', [UpdatedAt] = '2025-06-10T15:23:10.3166563Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166647Z', [UpdatedAt] = '2025-06-10T15:23:10.3166648Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166649Z', [UpdatedAt] = '2025-06-10T15:23:10.3166649Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166650Z', [UpdatedAt] = '2025-06-10T15:23:10.3166651Z'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166651Z', [UpdatedAt] = '2025-06-10T15:23:10.3166652Z'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166652Z', [UpdatedAt] = '2025-06-10T15:23:10.3166653Z'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166654Z', [UpdatedAt] = '2025-06-10T15:23:10.3166654Z'
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166655Z', [UpdatedAt] = '2025-06-10T15:23:10.3166655Z'
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166656Z', [UpdatedAt] = '2025-06-10T15:23:10.3166656Z'
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166657Z', [UpdatedAt] = '2025-06-10T15:23:10.3166657Z'
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166658Z', [UpdatedAt] = '2025-06-10T15:23:10.3166658Z'
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166659Z', [UpdatedAt] = '2025-06-10T15:23:10.3166659Z'
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T15:23:10.3166660Z', [UpdatedAt] = '2025-06-10T15:23:10.3166660Z'
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250610152310_MessagesAdded', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Customers] ADD [Email] nvarchar(100) NOT NULL DEFAULT N'';
GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947579Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947581Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947583Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947584Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947585Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947586Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947587Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947587Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947588Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947588Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947589Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947589Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947590Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947590Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947592Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947592Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947593Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947593Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-10T22:00:48.5947594Z', [Email] = N'test@test.test', [UpdatedAt] = '2025-06-10T22:00:48.5947594Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947705Z', [UpdatedAt] = '2025-06-10T22:00:48.5947706Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947708Z', [UpdatedAt] = '2025-06-10T22:00:48.5947708Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947709Z', [UpdatedAt] = '2025-06-10T22:00:48.5947709Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947710Z', [UpdatedAt] = '2025-06-10T22:00:48.5947711Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947712Z', [UpdatedAt] = '2025-06-10T22:00:48.5947712Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947713Z', [UpdatedAt] = '2025-06-10T22:00:48.5947713Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947714Z', [UpdatedAt] = '2025-06-10T22:00:48.5947715Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947715Z', [UpdatedAt] = '2025-06-10T22:00:48.5947715Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947716Z', [UpdatedAt] = '2025-06-10T22:00:48.5947716Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947717Z', [UpdatedAt] = '2025-06-10T22:00:48.5947717Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947718Z', [UpdatedAt] = '2025-06-10T22:00:48.5947718Z'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947719Z', [UpdatedAt] = '2025-06-10T22:00:48.5947719Z'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947720Z', [UpdatedAt] = '2025-06-10T22:00:48.5947720Z'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947721Z', [UpdatedAt] = '2025-06-10T22:00:48.5947721Z'
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947722Z', [UpdatedAt] = '2025-06-10T22:00:48.5947722Z'
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947723Z', [UpdatedAt] = '2025-06-10T22:00:48.5947723Z'
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947724Z', [UpdatedAt] = '2025-06-10T22:00:48.5947724Z'
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947725Z', [UpdatedAt] = '2025-06-10T22:00:48.5947725Z'
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947726Z', [UpdatedAt] = '2025-06-10T22:00:48.5947726Z'
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-10T22:00:48.5947727Z', [UpdatedAt] = '2025-06-10T22:00:48.5947727Z'
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250610220048_CustomerEmailAdded', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Customers] ADD [HouseNumber] nvarchar(5) NOT NULL DEFAULT N'';
GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837637Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837639Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837643Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837643Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837645Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837645Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837646Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837647Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837648Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837648Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837649Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837650Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837651Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837651Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837653Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837653Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837654Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837655Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T08:38:14.0837656Z', [HouseNumber] = N'2', [UpdatedAt] = '2025-06-11T08:38:14.0837656Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837800Z', [UpdatedAt] = '2025-06-11T08:38:14.0837800Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837803Z', [UpdatedAt] = '2025-06-11T08:38:14.0837803Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837805Z', [UpdatedAt] = '2025-06-11T08:38:14.0837805Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837807Z', [UpdatedAt] = '2025-06-11T08:38:14.0837807Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837808Z', [UpdatedAt] = '2025-06-11T08:38:14.0837808Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837809Z', [UpdatedAt] = '2025-06-11T08:38:14.0837810Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837811Z', [UpdatedAt] = '2025-06-11T08:38:14.0837811Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837812Z', [UpdatedAt] = '2025-06-11T08:38:14.0837812Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837813Z', [UpdatedAt] = '2025-06-11T08:38:14.0837814Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837815Z', [UpdatedAt] = '2025-06-11T08:38:14.0837815Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837816Z', [UpdatedAt] = '2025-06-11T08:38:14.0837816Z'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837817Z', [UpdatedAt] = '2025-06-11T08:38:14.0837817Z'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837818Z', [UpdatedAt] = '2025-06-11T08:38:14.0837819Z'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837820Z', [UpdatedAt] = '2025-06-11T08:38:14.0837820Z'
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837821Z', [UpdatedAt] = '2025-06-11T08:38:14.0837821Z'
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837822Z', [UpdatedAt] = '2025-06-11T08:38:14.0837823Z'
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837824Z', [UpdatedAt] = '2025-06-11T08:38:14.0837824Z'
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837825Z', [UpdatedAt] = '2025-06-11T08:38:14.0837825Z'
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837826Z', [UpdatedAt] = '2025-06-11T08:38:14.0837827Z'
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T08:38:14.0837828Z', [UpdatedAt] = '2025-06-11T08:38:14.0837828Z'
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250611083814_CustomerHouseNumberAdded', N'8.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Customers] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186133Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186135Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186138Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186138Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186140Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186141Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186142Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186142Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186144Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186144Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186145Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186146Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186147Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186147Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186148Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186149Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186150Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186150Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Customers] SET [CreatedAt] = '2025-06-11T09:17:11.4186151Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186152Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186293Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186293Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186296Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186296Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186298Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186298Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186299Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186300Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186301Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186301Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186302Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186302Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186303Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186304Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186305Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186305Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186306Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186306Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186307Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186308Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186309Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186309Z'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186310Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186310Z'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186311Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186312Z'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186313Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186313Z'
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186314Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186314Z'
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186315Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186315Z'
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186316Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186317Z'
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186318Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186318Z'
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186319Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186319Z'
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [CreatedAt] = '2025-06-11T09:17:11.4186320Z', [IsActive] = CAST(1 AS bit), [UpdatedAt] = '2025-06-11T09:17:11.4186321Z'
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250611091711_AddedisActiveForCustomersAndProducts', N'8.0.15');
GO

COMMIT;
GO

