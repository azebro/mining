IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PoolWorkerReadings_PoolReadings]') AND parent_object_id = OBJECT_ID(N'[dbo].[PoolWorkerReadings]'))
ALTER TABLE [dbo].[PoolWorkerReadings] DROP CONSTRAINT [FK_PoolWorkerReadings_PoolReadings]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PoolReadings_Pools]') AND parent_object_id = OBJECT_ID(N'[dbo].[PoolReadings]'))
ALTER TABLE [dbo].[PoolReadings] DROP CONSTRAINT [FK_PoolReadings_Pools]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Balances_PoolReadings]') AND parent_object_id = OBJECT_ID(N'[dbo].[Balances]'))
ALTER TABLE [dbo].[Balances] DROP CONSTRAINT [FK_Balances_PoolReadings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PoolReadings_ReadingId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PoolReadings] DROP CONSTRAINT [DF_PoolReadings_ReadingId]
END

GO
/****** Object:  Table [dbo].[Rigs]    Script Date: 01/04/2014 13:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rigs]') AND type in (N'U'))
DROP TABLE [dbo].[Rigs]
GO
/****** Object:  Table [dbo].[RigReadings]    Script Date: 01/04/2014 13:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RigReadings]') AND type in (N'U'))
DROP TABLE [dbo].[RigReadings]
GO
/****** Object:  Table [dbo].[PoolWorkerReadings]    Script Date: 01/04/2014 13:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PoolWorkerReadings]') AND type in (N'U'))
DROP TABLE [dbo].[PoolWorkerReadings]
GO
/****** Object:  Table [dbo].[Pools]    Script Date: 01/04/2014 13:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pools]') AND type in (N'U'))
DROP TABLE [dbo].[Pools]
GO
/****** Object:  Table [dbo].[PoolReadings]    Script Date: 01/04/2014 13:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PoolReadings]') AND type in (N'U'))
DROP TABLE [dbo].[PoolReadings]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 01/04/2014 13:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payments]') AND type in (N'U'))
DROP TABLE [dbo].[Payments]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 01/04/2014 13:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locations]') AND type in (N'U'))
DROP TABLE [dbo].[Locations]
GO
/****** Object:  Table [dbo].[Balances]    Script Date: 01/04/2014 13:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Balances]') AND type in (N'U'))
DROP TABLE [dbo].[Balances]
GO
/****** Object:  Table [dbo].[Balances]    Script Date: 01/04/2014 13:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Balances]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Balances](
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[ReadingId] [uniqueidentifier] NOT NULL,
	[Sent] [float] NULL,
	[Confirmed] [float] NULL,
	[Unconverted] [float] NULL,
 CONSTRAINT [PK_Balances] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 01/04/2014 13:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 01/04/2014 13:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Payments](
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[TxId] [varchar](200) NOT NULL,
	[Amount] [float] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[TxId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[PoolReadings]    Script Date: 01/04/2014 13:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PoolReadings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PoolReadings](
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[ReadingId] [uniqueidentifier] NOT NULL,
	[Reading] [float] NOT NULL,
	[Time] [datetime] NOT NULL,
	[Pool] [int] NOT NULL,
	[Error] [nvarchar](500) NULL,
 CONSTRAINT [PK_PoolReadings] PRIMARY KEY CLUSTERED 
(
	[ReadingId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Pools]    Script Date: 01/04/2014 13:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pools]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Pools](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Pools] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[PoolWorkerReadings]    Script Date: 01/04/2014 13:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PoolWorkerReadings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PoolWorkerReadings](
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[ReadingId] [uniqueidentifier] NOT NULL,
	[Worker] [nvarchar](50) NOT NULL,
	[Hashrate] [float] NOT NULL,
	[LastSeen] [datetime] NOT NULL,
	[StaleRate] [float] NOT NULL,
 CONSTRAINT [PK_PoolWorkerReadings] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[RigReadings]    Script Date: 01/04/2014 13:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RigReadings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RigReadings](
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[Rig] [uniqueidentifier] NOT NULL,
	[Reading] [float] NOT NULL,
	[ReadingTime] [timestamp] NOT NULL,
 CONSTRAINT [PK_RigReadings] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Rigs]    Script Date: 01/04/2014 13:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rigs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rigs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Hashrate] [float] NULL,
	[Location] [int] NULL,
 CONSTRAINT [PK_Rigs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
SET IDENTITY_INSERT [dbo].[Balances] ON 

GO
INSERT [dbo].[Balances] ([RowId], [ReadingId], [Sent], [Confirmed], [Unconverted]) VALUES (1, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', 3.4175164699554443, 0.010875700041651726, 0.028317127376794815)
GO
SET IDENTITY_INSERT [dbo].[Balances] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

GO
INSERT [dbo].[Locations] ([Id], [Name], [Description]) VALUES (1, N'Closet', NULL)
GO
INSERT [dbo].[Locations] ([Id], [Name], [Description]) VALUES (2, N'Living Room', NULL)
GO
INSERT [dbo].[Locations] ([Id], [Name], [Description]) VALUES (3, N'Dining', NULL)
GO
INSERT [dbo].[Locations] ([Id], [Name], [Description]) VALUES (4, N'Garage', NULL)
GO
INSERT [dbo].[Locations] ([Id], [Name], [Description]) VALUES (5, N'Office', NULL)
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (1, N'02dfa6cbcc43eedb627322b38c93e7d1801cc3cfa7a363257795ff6cb24fd4fb', 0.049292359501123428, CAST(0x0000A3000091AEEC AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (2, N'236bb1279534d6e55bf441b3897983b19ac257e823b4d0828451d114b78e19fb', 0.037426788359880447, CAST(0x0000A2FD015C9198 AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (3, N'562c649ba64c2e0b210764befd3c79da8b52ac0d1184f148741cab7de82449db', 0.016557240858674049, CAST(0x0000A2FA0164DF60 AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (4, N'57bd24c9fe610142c4ddf5237b8fb5fafa0ea6c893ade757348901d95c23bbbb', 0.050266038626432419, CAST(0x0000A2FB010C0B24 AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (5, N'59a3cb2ccbe4cc98a82658bc59bd5f2e016a562b3e4cbf17b22f6bb90f4100a8', 0.056557908654212952, CAST(0x0000A2FD008FE008 AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (6, N'996e789e263b7dc66b0f416953ae11087257444cd84feed8f0458684e41f015a', 0.051583681255578995, CAST(0x0000A2FE00C31824 AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (7, N'a99e5d10981e779747a25862f16deb9d26ae5a2c1dc6cecb2685562909072906', 0.075996853411197662, CAST(0x0000A2FC00D8C3CC AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (8, N'ba0b50228a77f68400dcec813b6ce38f9c202430301bd24bd7a6b826930d2680', 0.026036299765110016, CAST(0x0000A2FF00736374 AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (9, N'c090d3bfbebad9f7f04106f7a4b419b0e885fc4003d746104768ec0bab7b64c8', 0.040061749517917633, CAST(0x0000A2FE015DFCE0 AS DateTime))
GO
INSERT [dbo].[Payments] ([RowId], [TxId], [Amount], [TransactionDate]) VALUES (10, N'ecb3ef699145d32c3b09b91e286e27fab340295b19c1c0a571dfaecf3cc02e4d', 0.034680679440498352, CAST(0x0000A2FF0131139C AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[PoolReadings] ON 

GO
INSERT [dbo].[PoolReadings] ([RowId], [ReadingId], [Reading], [Time], [Pool], [Error]) VALUES (2, N'5cd966d5-437a-47a5-90fd-74e2def63126', 12785168, CAST(0x0000A30000D7D554 AS DateTime), 1, NULL)
GO
INSERT [dbo].[PoolReadings] ([RowId], [ReadingId], [Reading], [Time], [Pool], [Error]) VALUES (3, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', 13876615, CAST(0x0000A30000DD95A5 AS DateTime), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[PoolReadings] OFF
GO
SET IDENTITY_INSERT [dbo].[Pools] ON 

GO
INSERT [dbo].[Pools] ([Id], [Name], [Description]) VALUES (1, N'Waffle', N'Waffle Pool')
GO
SET IDENTITY_INSERT [dbo].[Pools] OFF
GO
SET IDENTITY_INSERT [dbo].[PoolWorkerReadings] ON 

GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (1, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'Empty', 0, CAST(0x0000A2EF016040F4 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (2, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'garage1', 0, CAST(0x0000A2D9010DB938 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (3, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'garage2', 0, CAST(0x0000A2D901083AF8 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (4, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'garage3', 0, CAST(0x0000A2D9010D2DC4 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (5, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'garage32', 0, CAST(0x0000A2D9010E00B4 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (6, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'off1', 0, CAST(0x0000A2D9010E00B4 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (7, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'off2', 0, CAST(0x0000A2D9010ED728 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (8, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig1', 0, CAST(0x0000A2FF01344210 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (9, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig2', 0, CAST(0x0000A2FE006BFA30 AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (10, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig3', 1289270, CAST(0x0000A30000DD787C AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (11, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig4', 1967833, CAST(0x0000A30000DD787C AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (12, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig5', 2239258, CAST(0x0000A30000DD787C AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (13, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig6', 2748180, CAST(0x0000A30000DD787C AS DateTime), 0)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (14, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig7', 1526767, CAST(0x0000A30000DD787C AS DateTime), 4.2600002288818359)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (15, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig8', 1730336, CAST(0x0000A30000DD787C AS DateTime), 1.9199999570846558)
GO
INSERT [dbo].[PoolWorkerReadings] ([RowId], [ReadingId], [Worker], [Hashrate], [LastSeen], [StaleRate]) VALUES (16, N'4616553b-d5a3-41cd-965f-a024daf0a0fe', N'rig9', 2374971, CAST(0x0000A30000DD787C AS DateTime), 1.4099999666213989)
GO
SET IDENTITY_INSERT [dbo].[PoolWorkerReadings] OFF
GO
SET IDENTITY_INSERT [dbo].[Rigs] ON 

GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (1, N'Rig4', N'Rig4 - Home', 1600, 4)
GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (2, N'Rig9', N'Rig9 - Home', 1600, 2)
GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (3, N'Rig8', N'Rig8 - Home', 2400, 2)
GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (4, N'Rig1', N'Rig1 - Office', 800, 5)
GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (5, N'Rig2', N'Rig2 - Office', 1200, 5)
GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (6, N'Rig6', N'Rig6 - Home', 3000, 4)
GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (7, N'Rig5', N'Rig5 - Home', 1800, 4)
GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (8, N'Rig3', N'Rig2 - Home', 1200, 3)
GO
INSERT [dbo].[Rigs] ([Id], [Name], [Description], [Hashrate], [Location]) VALUES (9, N'RIg7', N'Rig7 - Home', 1600, 1)
GO
SET IDENTITY_INSERT [dbo].[Rigs] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PoolReadings_ReadingId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PoolReadings] ADD  CONSTRAINT [DF_PoolReadings_ReadingId]  DEFAULT (newid()) FOR [ReadingId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Balances_PoolReadings]') AND parent_object_id = OBJECT_ID(N'[dbo].[Balances]'))
ALTER TABLE [dbo].[Balances]  WITH CHECK ADD  CONSTRAINT [FK_Balances_PoolReadings] FOREIGN KEY([ReadingId])
REFERENCES [dbo].[PoolReadings] ([ReadingId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Balances_PoolReadings]') AND parent_object_id = OBJECT_ID(N'[dbo].[Balances]'))
ALTER TABLE [dbo].[Balances] CHECK CONSTRAINT [FK_Balances_PoolReadings]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PoolReadings_Pools]') AND parent_object_id = OBJECT_ID(N'[dbo].[PoolReadings]'))
ALTER TABLE [dbo].[PoolReadings]  WITH CHECK ADD  CONSTRAINT [FK_PoolReadings_Pools] FOREIGN KEY([Pool])
REFERENCES [dbo].[Pools] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PoolReadings_Pools]') AND parent_object_id = OBJECT_ID(N'[dbo].[PoolReadings]'))
ALTER TABLE [dbo].[PoolReadings] CHECK CONSTRAINT [FK_PoolReadings_Pools]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PoolWorkerReadings_PoolReadings]') AND parent_object_id = OBJECT_ID(N'[dbo].[PoolWorkerReadings]'))
ALTER TABLE [dbo].[PoolWorkerReadings]  WITH CHECK ADD  CONSTRAINT [FK_PoolWorkerReadings_PoolReadings] FOREIGN KEY([ReadingId])
REFERENCES [dbo].[PoolReadings] ([ReadingId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PoolWorkerReadings_PoolReadings]') AND parent_object_id = OBJECT_ID(N'[dbo].[PoolWorkerReadings]'))
ALTER TABLE [dbo].[PoolWorkerReadings] CHECK CONSTRAINT [FK_PoolWorkerReadings_PoolReadings]
GO
