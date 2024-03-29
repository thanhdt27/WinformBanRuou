USE [QuanLyBanRuou]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/29/2019 4:09:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [int] NOT NULL,
	[MaSanPham] [nchar](10) NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 10/29/2019 4:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSanPham](
	[MaDanhMuc] [nchar](10) NOT NULL,
	[TenDanhMuc] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_DanhMucSanPham] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/29/2019 4:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[Ngay] [date] NULL,
	[ThanhTien] [int] NULL,
	[KhachHang] [nvarchar](max) NULL,
	[MaNhanVien] [nchar](10) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 10/29/2019 4:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [nchar](10) NOT NULL,
	[TenNCC] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/29/2019 4:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](max) NULL,
	[GioiTinh] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[TenTaiKhoan] [nvarchar](max) NULL,
	[MatKhau] [nvarchar](max) NULL,
	[LoaiTaiKhoan] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 10/29/2019 4:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [nchar](10) NOT NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[DungTich] [int] NULL,
	[NongDo] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[MaDanhMuc] [nchar](10) NULL,
	[MaNCC] [nchar](10) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPhamHoaDon]    Script Date: 10/29/2019 4:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamHoaDon](
	[TenSanPham] [nvarchar](max) NULL,
	[DungTich] [int] NULL,
	[NongDo] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (3, N'SP06      ', 12)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (5, N'SP06      ', 90)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (6, N'SP11      ', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (8, N'SP03      ', 5)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (8, N'SP12      ', 3)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (9, N'SP03      ', 2)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (9, N'SP11      ', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (10, N'SP11      ', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (11, N'SP03      ', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (12, N'SP03      ', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (12, N'SP11      ', 1)
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (N'DM1       ', N'Vang Pháp', N'Rượu vang là một trong những điều văn minh nhất trên thế giới')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (N'DM2       ', N'Brandy', N'Brandy')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (N'DM3       ', N'Vang Chile', N'Rượu mạnh từ Chile')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (N'DM4       ', N'Cognacc', N'Cognac luôn được coi là đồ uống quý tộc')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [MoTa]) VALUES (N'DM6       ', N'Vang Tây Ban Nha', N'')
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (3, CAST(N'2019-05-08' AS Date), 92100, N'thanh', N'NV04      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (4, CAST(N'2019-05-08' AS Date), 300, N'1', N'NV03      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (5, CAST(N'2019-05-10' AS Date), 27150, N'thanh', N'NV06      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (6, CAST(N'2019-05-10' AS Date), 1500, N'Aaa', N'NV06      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (7, CAST(N'2019-05-10' AS Date), 0, N'a', N'NV03      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (8, CAST(N'2019-06-16' AS Date), 11575, N'thành', N'NV01      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (9, CAST(N'2019-08-11' AS Date), 6070, N'thanh', N'NV01      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (10, CAST(N'2019-08-11' AS Date), 3000, N'thanh', N'NV06      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (11, CAST(N'2019-08-21' AS Date), 3070, N'rttttt', N'NV03      ')
INSERT [dbo].[HoaDon] ([MaHoaDon], [Ngay], [ThanhTien], [KhachHang], [MaNhanVien]) VALUES (12, CAST(N'2019-09-09' AS Date), 4570, N'a', N'NV04      ')
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC1      ', N'Alpha', N'Hà Nội', N'alpha@gmail.com', N'012415454')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC3      ', N'Hồng Hà', N'Ninh Bình', N'hongha@gmail.com', N'012348217')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC4      ', N'Nam Thư', N'Hà Nội', N'namthu@gmail.com', N'012457151')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC5      ', N'SunHouse', N'Hà Nội', N'sunhouse@gmail.com', N'012851848')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC6      ', N'Vin', N'Nam Đinh', N'vin@gmail.com', N'01325158415')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC7      ', N'FPT', N'HCM', N'fpt@gmail.com', N'0248501551')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC8      ', N'Meg', N'Ninh Bình', N'meg@gmail.com', N'012511514')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV01      ', N'Thanh Tu', N'Nam', N'01234679', N'thanhtu123', N'thanhtu123', N'User')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV03      ', N'Lam', N'Nam', N'012512524', N'lam', N'lam', N'Admin')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV04      ', N'Nam', N'Nam', N'01251851485', N'nam345', N'nam345', N'User')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV06      ', N'Linh', N'Nam', N'123459826', N'linh123', N'linh123', N'User')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'SP01      ', N'Thanh', N'Nam', N'01234679', N'thanh123', N'thanh123', N'User')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'SP02      ', N'Tu', N'Nu', N'01244859', N'tu123', N'tu123', N'Admin')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [SDT], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'SP03      ', N'Nam', N'Nam', N'123459826', N'nam123', N'tu123', N'User')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DungTich], [NongDo], [SoLuong], [DonGia], [MaDanhMuc], [MaNCC]) VALUES (N'SP03      ', N'Rượu Gạo', 600, 400, 982, 1535, N'DM4       ', N'NCC3      ')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DungTich], [NongDo], [SoLuong], [DonGia], [MaDanhMuc], [MaNCC]) VALUES (N'SP06      ', N'Rượu Thuốc', 400, 50, 0, 300, N'DM2       ', N'NCC4      ')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DungTich], [NongDo], [SoLuong], [DonGia], [MaDanhMuc], [MaNCC]) VALUES (N'SP11      ', N'Rượu Linh Xà', 300, 200, 0, 1500, N'DM2       ', N'NCC8      ')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DungTich], [NongDo], [SoLuong], [DonGia], [MaDanhMuc], [MaNCC]) VALUES (N'SP12      ', N'Rượu Mật Rắn', 300, 200, 43, 400, N'DM2       ', N'NCC5      ')
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DanhMucSanPham] FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMucSanPham] ([MaDanhMuc])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_DanhMucSanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaCungCap]
GO
