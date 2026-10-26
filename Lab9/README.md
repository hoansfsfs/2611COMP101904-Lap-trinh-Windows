Lab 9 - Thiết kế và in thẻ sinh viên (WinForms)
Ứng dụng Windows Forms hỗ trợ nhập thông tin sinh viên, chọn ảnh đại diện, xem trước thẻ sinh viên bằng GDI+ và thực hiện in thông qua PrintDocument.

Cách chạy
Cách 1 - Visual Studio 2022
Mở file:
InTheSinhVien.sln
Nhấn:
F5
để chạy chương trình.

Cách 2 - Build thủ công
Build → Rebuild Solution
Sau đó:

Debug → Start Debugging
hoặc:

F5
Cách sử dụng
Nhập:

Mã sinh viên
Họ và tên
Lớp
Khoa
Khóa học
Ngày sinh
Giới tính
Bấm Chọn ảnh để tải ảnh đại diện.

Thẻ sẽ tự động hiển thị ở vùng Xem trước thẻ sinh viên.

Chọn:

Xem trước in để xem trước khi in.
In thẻ để chọn máy in và in.
Chọn Làm mới để đặt lại dữ liệu.

Chọn Thoát để đóng chương trình.

Bảng đặt tên Control
Control	Tên	Kiểu
Form chính	FrmStudentCard	Form
Nhóm thông tin	grpThongTin	GroupBox
Mã sinh viên	lblMaSV, txtMaSV	Label, TextBox
Họ tên	lblHoTen, txtHoTen	Label, TextBox
Lớp	lblLop, cboLop	Label, ComboBox
Khoa	lblKhoa, cboKhoa	Label, ComboBox
Khóa học	lblKhoaHoc, cboKhoaHoc	Label, ComboBox
Ngày sinh	lblNgaySinh, dtpNgaySinh	Label, DateTimePicker
Giới tính	lblGioiTinh, cboGioiTinh	Label, ComboBox
Nhóm ảnh	grpAnh	GroupBox
Ảnh đại diện	picAnhDaiDien	PictureBox (Zoom)
Nút chọn ảnh	btnChonAnh	Button
Hộp thoại chọn ảnh	dlgChonAnh	OpenFileDialog
Vùng xem trước	grpXemTruoc, pnlXemTruoc	GroupBox, Panel
Các nút	btnLamMoi, btnXemTruocIn, btnIn, btnThoat	Button
In ấn	docInThe, dlgXemTruocIn, dlgIn	PrintDocument, PrintPreviewDialog, PrintDialog
Quy tắc kiểm tra dữ liệu
Mã sinh viên
Mã sinh viên phải có định dạng:

51.01.104.030
Điều kiện:

Chỉ chứa số và dấu .
Theo mẫu:
xx.xx.xxx.xxx
Ví dụ hợp lệ:

51.01.104.030
49.01.101.123
Ví dụ không hợp lệ:

5101104030
51-01-104-030
abc123
Họ và tên
Điều kiện:

Không để trống
Chỉ chứa chữ cái và khoảng trắng
Không chứa số
Không chứa ký tự đặc biệt
Độ dài tối đa 50 ký tự
Ví dụ:

✅ Nguyễn Bá Hoan

✅ Trần Thị Minh Anh

❌ Nguyễn123

❌ Nguyễn@Hoan

Cấu trúc Code
Thành phần	Chức năng
StudentCardInfo	Lưu thông tin sinh viên
ValidateInput()	Kiểm tra dữ liệu đầu vào
btnChonAnh_Click()	Chọn ảnh đại diện
btnLamMoi_Click()	Làm mới Form
btnThoat_Click()	Thoát chương trình
pnlXemTruoc_Paint()	Vẽ giao diện xem trước
DrawStudentCard()	Vẽ thẻ sinh viên
btnXemTruocIn_Click()	Xem trước khi in
btnIn_Click()	In thẻ sinh viên
docInThe_PrintPage()	Xử lý nội dung in
Hình ảnh minh họa
1. Kiểm tra khi bỏ trống mã sinh viên
Kiểm tra MSSV

2. Kiểm tra khi bỏ trống họ tên
Kiểm tra họ tên

3. Hiển thị thẻ sinh viên sau khi nhập dữ liệu
Preview thẻ sinh viên

Test Case
STT	Test Case	Bước thực hiện	Kết quả mong đợi	Kết quả
1	Mở chương trình	Chạy ứng dụng	Form hiển thị đầy đủ	✅ Đạt
2	Thiếu MSSV	Bỏ trống MSSV	Hiển thị cảnh báo	✅ Đạt
3	Thiếu họ tên	Bỏ trống họ tên	Hiển thị cảnh báo	✅ Đạt
4	Thiếu ảnh	Không chọn ảnh	Hiển thị cảnh báo	✅ Đạt
5	Chọn ảnh	Chọn file JPG/PNG/BMP	Ảnh hiển thị đúng	✅ Đạt
6	Preview dữ liệu	Nhập thông tin	Preview cập nhật tức thì	✅ Đạt
7	Xem trước in	Bấm Xem trước in	Mở PrintPreviewDialog	✅ Đạt
8	In thẻ	Chọn Microsoft Print to PDF	Xuất PDF thành công	✅ Đạt
9	Làm mới	Nhấn Làm mới	Xóa dữ liệu và ảnh	✅ Đạt
10	Thoát	Nhấn Thoát	Đóng chương trình	✅ Đạt
11	MSSV sai định dạng	Nhập ký tự không hợp lệ	Hiển thị cảnh báo	✅ Đạt
12	Họ tên chứa số	Nhập Nguyễn123	Hiển thị cảnh báo	✅ Đạt
13	Ngày sinh tương lai	Chọn ngày > hiện tại	Không cho phép chọn	✅ Đạt
Cấu trúc Project
InTheSinhVien
│
├── FrmStudentCard.cs
├── FrmStudentCard.Designer.cs
├── FrmStudentCard.resx
│
├── StudentCardInfo.cs
│
├── Program.cs
│
├── README.md
│
└── images
    ├── validation-mssv.png
    ├── validation-hoten.png
    └── preview-card.png
Kết quả đạt được
✅ Thiết kế giao diện bằng Windows Forms

✅ Kiểm tra dữ liệu đầu vào

✅ Chọn ảnh đại diện

✅ Xem trước thẻ sinh viên bằng GDI+

✅ In thẻ sinh viên bằng PrintDocument

✅ Xem trước khi in

✅ Quản lý sự kiện trên Form

✅ Làm mới dữ liệu

✅ Hoàn thành yêu cầu Lab 09
