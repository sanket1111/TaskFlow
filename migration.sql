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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260802154949_InitialCreate'
)
BEGIN
    CREATE TABLE [Projects] (
        [Id] int NOT NULL IDENTITY,
        [ProjectName] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [Priority] nvarchar(max) NOT NULL,
        [IsActive] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260802154949_InitialCreate'
)
BEGIN
    CREATE TABLE [TaskItem] (
        [Id] int NOT NULL IDENTITY,
        [TaskTitle] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [Priority] nvarchar(max) NOT NULL,
        [DueDate] datetime2 NOT NULL,
        [ProjectId] int NOT NULL,
        CONSTRAINT [PK_TaskItem] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TaskItem_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260802154949_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_TaskItem_ProjectId] ON [TaskItem] ([ProjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260802154949_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260802154949_InitialCreate', N'10.0.10');
END;

COMMIT;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260805123705_UpdatedAppContext'
)
BEGIN
    DROP TABLE [TaskItem];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260805123705_UpdatedAppContext'
)
BEGIN
    CREATE TABLE [TaskItems] (
        [Id] int NOT NULL IDENTITY,
        [TaskTitle] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [Priority] nvarchar(max) NOT NULL,
        [DueDate] datetime2 NOT NULL,
        [ProjectId] int NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TaskItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TaskItems_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260805123705_UpdatedAppContext'
)
BEGIN
    CREATE INDEX [IX_TaskItems_ProjectId] ON [TaskItems] ([ProjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260805123705_UpdatedAppContext'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260805123705_UpdatedAppContext', N'10.0.10');
END;

COMMIT;
GO

