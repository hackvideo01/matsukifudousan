USE [matsuki]
GO
/****** Object:  Table [dbo].[DetachedDB]    Script Date: 2021/09/22 16:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetachedDB](
	[DetachedHouseNo] [nchar](50) NOT NULL,
	[DetachedHouseName] [nchar](100) NULL,
	[DetachedPost] [nchar](50) NULL,
	[DetachedAddress] [nvarchar](50) NULL,
	[NearestSation] [nvarchar](500) NULL,
	[Price] [nvarchar](200) NULL,
	[FloorPlanType] [nvarchar](200) NULL,
	[FloorPlanDetails] [nvarchar](500) NULL,
	[LandArea] [nvarchar](250) NULL,
	[BuildingArea] [nvarchar](250) NULL,
	[BuildingStructure] [nvarchar](250) NULL,
	[DateConstruction] [nvarchar](200) NULL,
	[LandRights] [nvarchar](250) NULL,
	[Ground] [nvarchar](250) NULL,
	[CityPlanning] [nvarchar](500) NULL,
	[UseDistrict] [nvarchar](500) NULL,
	[BuildingCoverageRatio] [nvarchar](50) NULL,
	[FloorAreaRatio] [nvarchar](50) NULL,
	[OtherLegalRestrictions] [nvarchar](100) NULL,
	[Terrain] [nvarchar](100) NULL,
	[CurrentSituation] [nvarchar](100) NULL,
	[DeliveryConditionTime] [nvarchar](250) NULL,
	[Parking] [nvarchar](100) NULL,
	[TransactionMode] [nvarchar](100) NULL,
	[RoadsideSituation] [nvarchar](350) NULL,
	[Facility] [nvarchar](500) NULL,
	[SchoolDistrict] [nvarchar](500) NULL,
	[NeighborhoodInformation] [nvarchar](500) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_DetachedDB] PRIMARY KEY CLUSTERED 
(
	[DetachedHouseNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageDB]    Script Date: 2021/09/22 16:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageDB](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](1000) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[ImageType] [nvarchar](50) NULL,
	[HouseNo] [varchar](100) NULL,
	[DetachedHouseNo] [nchar](50) NULL,
 CONSTRAINT [PK__Image__7516F70C5B918074] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalManagementDB]    Script Date: 2021/09/22 16:13:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalManagementDB](
	[HouseNo] [varchar](100) NOT NULL,
	[HouseName] [nvarchar](100) NULL,
	[HousePost] [nvarchar](50) NULL,
	[HouseAddress] [nvarchar](500) NULL,
	[NearestSation] [nvarchar](500) NULL,
	[HouseType] [nvarchar](250) NULL,
	[Construction] [nvarchar](500) NULL,
	[YearConstruction] [nvarchar](250) NULL,
	[Decorate] [nvarchar](500) NULL,
	[TotalArea] [nvarchar](200) NULL,
	[Parking] [nvarchar](500) NULL,
	[Pets] [nvarchar](500) NULL,
	[OtherEquipment] [nvarchar](1000) NULL,
	[HouseRemarks] [nvarchar](1000) NULL,
	[SecurityDeposit] [nvarchar](1000) NULL,
	[KeyMoney] [nvarchar](150) NULL,
	[CommonFee] [nvarchar](500) NULL,
	[ManagementFee] [nvarchar](250) NULL,
	[Rent] [nvarchar](250) NULL,
	[ParkingFee] [nvarchar](250) NULL,
	[OtherFee] [nvarchar](500) NULL,
	[MNGMTCOName] [nvarchar](500) NULL,
	[CompanyAddress] [nvarchar](500) NULL,
	[COPhone] [nvarchar](150) NULL,
	[COFax] [nvarchar](150) NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [nvarchar](150) NULL,
	[Fax] [nvarchar](150) NULL,
	[MNGMTForm] [nvarchar](500) NULL,
	[Remarks] [nvarchar](1000) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_RentalManagementDB] PRIMARY KEY CLUSTERED 
(
	[HouseNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ImageDB]  WITH CHECK ADD  CONSTRAINT [FK__Image__HouseNo__7C4F7684] FOREIGN KEY([HouseNo])
REFERENCES [dbo].[RentalManagementDB] ([HouseNo])
GO
ALTER TABLE [dbo].[ImageDB] CHECK CONSTRAINT [FK__Image__HouseNo__7C4F7684]
GO
ALTER TABLE [dbo].[ImageDB]  WITH CHECK ADD  CONSTRAINT [FK_ImageDB_DetachedDB] FOREIGN KEY([DetachedHouseNo])
REFERENCES [dbo].[DetachedDB] ([DetachedHouseNo])
GO
ALTER TABLE [dbo].[ImageDB] CHECK CONSTRAINT [FK_ImageDB_DetachedDB]
GO
