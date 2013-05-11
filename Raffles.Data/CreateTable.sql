CREATE TABLE [dbo].[RaffleEntities](
	[RaffleId] INT IDENTITY (1,1) NOT NULL,
	[RaffleName] NVARCHAR (100) NOT NULL,
	[RaffleDescription] NVARCHAR (200),
	CONSTRAINT [pk_dbo.RaffleEntities] PRIMARY KEY ([RaffleId])
);

CREATE TABLE [dbo].[ParticipantEntities](
	[ParticipantId] INT IDENTITY (1,1) NOT NULL,
	[ParticipantName] NVARCHAR (100) NOT NULL,
	[ParticipantContact] NVARCHAR (200),
	CONSTRAINT [pk_dbo.ParticipantEntities] PRIMARY KEY ([ParticipantId])
);

CREATE TABLE [dbo].[ItemEntities](
	[ItemId] INT IDENTITY (1,1) NOT NULL,
	[ItemName] NVARCHAR (100) NOT NULL,
	[ItemDescription] NVARCHAR (200),
	[ItemSKU] NVARCHAR (50),
	CONSTRAINT [pk_dbo.ItemEntities] PRIMARY KEY ([ItemId])
);

CREATE TABLE [dbo].[ParticipantEntityRaffleEntities](
	[RaffleParticipantId] INT IDENTITY (1,1) NOT NULL,
	[RaffleEntity_RaffleId] INT NOT NULL,
	[ParticipantEntity_ParticipantId] INT NOT NULL,
	[RaffleEntries] INT NOT NULL,
	CONSTRAINT [pk_dbo.ParticipantEntityRaffleEntities] PRIMARY KEY ([RaffleParticipantId]),
	CONSTRAINT [fk_dbo.ParticipantEntityRaffleEntities_dbo.RaffleEntities_RaffleId] FOREIGN KEY ([RaffleEntity_RaffleId]) REFERENCES [dbo].[RaffleEntities] ([RaffleId]),
	CONSTRAINT [fk_dbo.ParticipantEntityRaffleEntities_dbo.ParticipantEntities_ParticipantId] FOREIGN KEY ([ParticipantEntity_ParticipantId]) REFERENCES [dbo].[ParticipantEntities] ([ParticipantId]),
	CONSTRAINT [uq_dbo.ParticipantEntityRaffleEntities] UNIQUE ([RaffleEntity_RaffleId],[ParticipantEntity_ParticipantId])
);

CREATE TABLE [dbo].[ItemEntityRaffleEntities](
	[RaffleItemId] INT IDENTITY (1,1) NOT NULL,
	[RaffleEntity_RaffleId] INT NOT NULL,
	[ItemEntity_ItemId] INT NOT NULL,
	[ItemQuantities] INT NOT NULL,
	CONSTRAINT [pk_dbo.ItemEntityRaffleEntities] PRIMARY KEY ([RaffleItemId]),
	CONSTRAINT [fk_dbo.ItemEntityRaffleEntities_dbo.RaffleEntities_RaffleId] FOREIGN KEY ([RaffleEntity_RaffleId]) REFERENCES [dbo].[RaffleEntities] ([RaffleId]),
	CONSTRAINT [fk_dbo.ItemEntityRaffleEntities_dbo.ItemEntities_ItemId] FOREIGN KEY ([ItemEntity_ItemId]) REFERENCES [dbo].[ItemEntities] ([ItemId]),
	CONSTRAINT [uq_dbo.ItemEntityRaffleEntities] UNIQUE ([RaffleEntity_RaffleId],[ItemEntity_ItemId])
);

CREATE TABLE [dbo].[WinnerEntities](
	[WinnerId] INT IDENTITY (1,1) NOT NULL,
	[ParticipantEntityRaffleEntity_RaffleParticipantId] INT NOT NULL,
	[ItemEntityRaffleEntity_RaffleItemId] INT NOT NULL,
	[Quantity] INT,
	CONSTRAINT [pk_dbo.WinnerEntities] PRIMARY KEY ([WinnerId]),
	CONSTRAINT [fk_WinnerEntities_dbo.ParticipantEntityRaffleEntities_RaffleParticipantId] FOREIGN KEY ([ParticipantEntityRaffleEntity_RaffleParticipantId]) REFERENCES [dbo].[ParticipantEntityRaffleEntities] ([RaffleParticipantId]),
	CONSTRAINT [fk_WinnerEntities_dbo.ItemEntityRaffleEntities_RaffleItemId] FOREIGN KEY ([ItemEntityRaffleEntity_RaffleItemId]) REFERENCES [dbo].[ItemEntityRaffleEntities] ([RaffleItemId]),
	CONSTRAINT [uq_dbo.WinnerEntities] UNIQUE ([ParticipantEntityRaffleEntity_RaffleParticipantId],[ItemEntityRaffleEntity_RaffleItemId])
);