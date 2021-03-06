USE [QuanLyQuanNet]
GO
/****** Object:  Table [dbo].[PhongMay]    Script Date: 1/9/2022 4:31:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongMay](
	[TenMay] [nvarchar](50) NOT NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[SoPhutChoi] [int] NULL,
	[TaiKhoan] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongMay] PRIMARY KEY CLUSTERED 
(
	[TenMay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuanLi]    Script Date: 1/9/2022 4:31:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLi](
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThanhVien]    Script Date: 1/9/2022 4:31:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhVien](
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[TenThanhVien] [nvarchar](50) NULL,
	[SoPhutConLai] [int] NULL,
	[MatKhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThanhVien] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PhongMay]  WITH CHECK ADD  CONSTRAINT [FK_PhongMay_ThanhVien] FOREIGN KEY([TaiKhoan])
REFERENCES [dbo].[ThanhVien] ([TaiKhoan])
GO
ALTER TABLE [dbo].[PhongMay] CHECK CONSTRAINT [FK_PhongMay_ThanhVien]
GO
