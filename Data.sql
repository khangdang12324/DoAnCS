CREATE DATABASE QuanLyNCKH
GO

USE QuanLyNCKH
GO
--Projects
--Account

CREATE TABLE Account
(
    UserName NVARCHAR(100) PRIMARY KEY,
    DisplayName NVARCHAR(100) NOT NULL,
    PassWord NVARCHAR(100) NOT NULL
)
GO  

	-- Tạo lại bảng Projects với cấu trúc mới
	CREATE TABLE Projects
	(
		QDSo NVARCHAR(100) PRIMARY KEY,
		type NVARCHAR(100),
		nameProject NVARCHAR(100) DEFAULT N'Chưa đặt tên',
		nameResearchers NVARCHAR(100),
		nameMember NVARCHAR(100),
		status NVARCHAR(100) DEFAULT N'Đang thực hiện',
		ngayBatDau DATE DEFAULT GETDATE(),
		ngayKetThuc DATE,
		kinhPhi FLOAT DEFAULT 0,
		artical NVARCHAR(100),
		prize NVARCHAR(100)
	);
	GO



	-- Thêm dữ liệu mẫu vào bảng Projects
	INSERT INTO Projects (QDSo, type, nameProject, nameResearchers, nameMember, status, ngayBatDau, ngayKetThuc, kinhPhi, artical, prize)
	VALUES 
	(N'QD001', N'Sinh viên', N'Đề tài A', N'Nguyễn Văn A', N'Lê Thị B', N'Đã nghiệm thu', '2024-01-01', '2024-12-31', 1000000, N'Bài báo 1', N'Giải Nhất'),
	(N'QD002', N'Giảng viên', DEFAULT, N'Trần Văn C', N'Nguyễn Thị D', N'Đã hủy', DEFAULT, DEFAULT, 500000, N'Bài báo 2', N'Giải Nhì'),
	(N'QD003', N'Giảng viên', N'Đề tài B', N'Lê Văn E', N'Phạm Thị F', N'Đang thực hiện', '2024-05-01', '2024-11-01', 2000000, N'Bài báo 3', NULL);
	GO
	SELECT * FROM dbo.Projects



	-- Kiểm tra dữ liệu trong bảng Projects
	SELECT 
		QDSo AS [Quyết định số],
		type AS [Loại],
		nameProject AS [Tên đề tài],
		nameResearchers AS [Người nghiên cứu chính],
		nameMember AS [Thành viên tham gia],
		status AS [Trạng thái],
		ngayBatDau AS [Ngày bắt đầu],
		ngayKetThuc AS [Ngày kết thúc],
		kinhPhi AS [Kinh phí],
		artical AS [Bài báo liên quan],
		prize AS [Giải thưởng]
	FROM Projects;
	GO



	CREATE PROC USP_GetAccountByUserName
@userName NVARCHAR(100) 
AS
BEGIN
    SELECT*FROM dbo.Account WHERE UserName = @userName
END
GO	

	EXECUTE dbo.USP_GetAccountByUserName @userName = N'admin' -- nvarchar(100)



GO	
CREATE PROC	USP_Login
@userName NVARCHAR(100), @passWord nvarchar(100)
AS	
BEGIN
    SELECT * FROM dbo.Account WHERE	UserName = @userName AND PassWord = @passWord
	
END
GO