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
 
     QDSo NVARCHAR(100) PRIMARY KEY NOT NULL,
    type NVARCHAR(100),
    nameProject NVARCHAR(100) DEFAULT N'Chưa đặt tên',
    cap NVARCHAR(100) DEFAULT N'Cấp trường',
    nameResearchers NVARCHAR(100),
    nameMember NVARCHAR(100),
    status NVARCHAR(100) DEFAULT N'Đang thực hiện',
    ngayBatDau DATE DEFAULT NULL,
    ngayKetThuc DATE DEFAULT NULL,
    ngayGiaHan DATE DEFAULT NULL,
    ngayNghiemThu DATE DEFAULT NULL,
    kinhPhi FLOAT DEFAULT 0,
    artical NVARCHAR(100),
    prize NVARCHAR(100)
);
GO

	-- Thêm dữ liệu mẫu vào bảng Projects
-- Nhập dữ liệu vào bảng Projects
INSERT INTO Projects ( QDSo, type, nameProject, nameResearchers, nameMember, status, ngayBatDau, ngayKetThuc, ngayGiaHan,ngayNghiemThu,kinhPhi, artical, prize)
VALUES 
(N'825/QĐ-ĐHĐL', N'Sinh viên', N'Xây dựng ứng dụng hỗ trợ phụ huynh tra cứu tình hình học tập của sinh viên', 
N'Trần Nguyễn Đông Gon', N'Trịnh Nguyễn Hồng Phi, Nguyễn Khánh Linh, Lê Sỹ Hùng', N'Đang thực hiện', 
'2024-01-01', '2024-12-01',NULL,	NULL, 5000000, NULL, NULL),

(N'876/QĐ-ĐHĐL', N'Sinh viên', N'Xây dựng hệ thống điểm danh sinh viên dựa trên nhận diện khuôn mặt', 
N'Nguyễn Bảo Long', N'Nguyễn Danh, Lê Hoàng Nhật, Nguyễn Tùng Hiếu, Trần Hữu Khai Quan', N'Đang thực hiện', 
'2023-01-01', '2024-02-01',NULL,	NULL, 5000000, NULL, NULL),

(N'874/QĐ-ĐHĐL', N'Sinh viên', N'Mô phỏng, xác định thông lượng neutron nhiệt và neutron trên nhiệt lò phản ứng hạt nhân Đà Lạt', 
N'Trần Nguyễn Kha', N'Trần Đăng Quang, Cao Hiệp Hòa', N'Đang thực hiện', 
'2024-01-01', '2024-6-01', NULL,	NULL,5000000, NULL, NULL);
GO
	SELECT * FROM dbo.Projects


	-- Kiểm tra dữ liệu trong bảng Projects
	SELECT 
		QDSo AS [Quyết định số],
		type AS [Loại dự án],
		nameProject AS [Tên đề tài],
		cap AS [Cấp đề tài],
		nameResearchers AS [Tên chủ nhiệm],
		nameMember AS [Thành viên tham gia],
		status AS [Trạng thái],
 FORMAT(ngayBatDau, 'MM-yyyy') AS [Tháng bắt đầu],
    FORMAT(ngayKetThuc, 'MM-yyyy') AS [Tháng kết thúc],
		FORMAT(ngayGiaHan, 'MM-yyyy') AS [Tháng gia hạn],
		FORMAT(ngayNghiemThu, 'MM-yyyy') AS [Tháng nghiệm thu],
	  CASE 
        WHEN ngayGiaHan IS NULL AND ngayNghiemThu IS NULL THEN NULL
        ELSE DATEDIFF(MONTH, ngayKetThuc, ISNULL(ngayGiaHan, GETDATE())) 
    END AS [Số tháng đã gia hạn],
		kinhPhi AS [Kinh phí],
		prize AS [Giải thưởng]
	FROM Projects;
	
	--BẢNG MEMBERS
	CREATE TABLE Members (
    MemberID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);
GO
SELECT DISTINCT Name FROM dbo.Members
-- Thêm dữ liệu mẫu cho bảng Members
INSERT INTO Members (Name) VALUES 
(N'Nguyễn Thị Lương'),
(N'Hoàng Như Phương'),
(N'Nguyễn Hữu Khánh'),
(N'Trần Thị Ngọc Kim');
GO
SELECT * FROM articles


-- Bang quan he projects va members
CREATE TABLE ProjectMembers (
    ProjectID NVARCHAR(100),
    MemberID INT,
    FOREIGN KEY (ProjectID) REFERENCES Projects(QDSo),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);
GO

-- Ví dụ thêm dữ liệu mẫu cho bảng ProjectMembers
INSERT INTO ProjectMembers (ProjectID, MemberID) VALUES 
(N'825/QĐ-ĐHĐL', 1),
(N'847/QĐ-ĐHĐL', 2),
(N'845/QĐ-ĐHĐL', 3),
(N'823/QĐ-ĐHĐL', 4);
GO    


SELECT * FROM Articles
CREATE TABLE Articles (
    ArticleID INT IDENTITY(1,1) PRIMARY KEY, -- Thêm khóa chính tự tăng để quản lý bài báo dễ dàng hơn
    qdSo NVARCHAR(100) NOT NULL, -- Khóa ngoại tham chiếu đến Projects
    tenBaiBao NVARCHAR(500), -- Tên bài báo
    tenTapChi NVARCHAR(500), -- Tên tạp chí
    tenTacGia NVARCHAR(200), -- Tên tác giả chính
    tenThanhVienBaiBao NVARCHAR(500), -- Các thành viên tham gia bài báo
    ngayDang DATE, -- Ngày đăng
    CONSTRAINT FK_Article_Projects FOREIGN KEY (qdSo) REFERENCES Projects(QDSo) -- Ràng buộc khóa ngoại
);
 GO	
 INSERT INTO dbo.Article
 (
     qdSo,
     tenBaiBao,
     tenTapChi,
     tenTacGia,
     tenThanhVienBaiBao,
     ngayDang
 )
 VALUES
 (   N'	',  -- qdSo - nvarchar(100)
     NULL, -- tenBaiBao - nvarchar(500)
     NULL, -- tenTapChi - nvarchar(500)
     NULL, -- tenTacGia - nvarchar(200)
     NULL, -- tenThanhVienBaiBao - nvarchar(max)
     NULL  -- ngayDang - date
     )

-- thu tuc	them thanh vien moi
CREATE PROC	 USP_AddMember
	@Name NVARCHAR(100)
AS
BEGIN
    INSERT INTO	Members (Name) VALUES (@Name);
	SELECT SCOPE_IDENTITY()	AS	NewMemberID;
END
GO	
--Thu tuc lien ket thanh vien voi du an
CREATE PROC USP_AddMemberToProject
    @ProjectID NVARCHAR(100),
    @MemberID INT
AS
BEGIN
    IF EXISTS (SELECT * FROM Projects WHERE QDSo = @ProjectID) AND EXISTS (SELECT * FROM Members WHERE MemberID = @MemberID)
    BEGIN
        INSERT INTO ProjectMembers (ProjectID, MemberID) VALUES (@ProjectID, @MemberID);
    END
    ELSE
    BEGIN
        RAISERROR('Project or Member does not exist', 16, 1);
    END
END;
GO
-- Truy Xuất Dữ Liệu Thành Viên Theo Dự Án
CREATE PROC USP_GetMembersByProject
    @ProjectID NVARCHAR(100)
AS
BEGIN
    SELECT m.MemberID, m.Name
    FROM ProjectMembers pm
    JOIN Members m ON pm.MemberID = m.MemberID
    WHERE pm.ProjectID = @ProjectID;
END;
GO

--------
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

CREATE PROCEDURE USP_UpdateNgayNghiemThu
    @QDSo NVARCHAR(100),
    @Status NVARCHAR(100)
AS
BEGIN
    IF @Status = N'Đã hoàn thành'
    BEGIN
        UPDATE Projects
        SET ngayNghiemThu = GETDATE() -- Ngày hiện tại
        WHERE QDSo = @QDSo;
    END
    ELSE IF @Status = N'Đã hủy'
    BEGIN
        UPDATE Projects
        SET ngayNghiemThu = NULL
        WHERE QDSo = @QDSo;
    END
END;
GO


