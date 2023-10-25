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

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Document] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    [Type] int NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Messages] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [HasBeenReaded] bit NOT NULL,
    [DateTime] datetime2 NOT NULL,
    [Type] int NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Messages_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reservations] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [LeisureSpace] nvarchar(max) NOT NULL,
    [DateTime] datetime2 NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reservations_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Services] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Value] decimal(18,2) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Services_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Messages_UserId] ON [Messages] ([UserId]);
GO

CREATE INDEX [IX_Reservations_UserId] ON [Reservations] ([UserId]);
GO

CREATE INDEX [IX_Services_UserId] ON [Services] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231024152353_Initial', N'7.0.12');
GO

COMMIT;
GO

