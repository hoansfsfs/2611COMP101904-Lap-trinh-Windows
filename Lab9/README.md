Lab 09 - Thiết kế và in thẻ sinh viên (WinForms)
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
Sau đó chạy:

Debug → Start Debugging
hoặc

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
Bấm Chọn ảnh để chọn ảnh đại diện.

Thông tin sẽ được hiển thị tại khu vực Xem trước thẻ sinh viên.

Bấm:

Xem trước in để xem trước khi in
In thẻ để tiến hành in
Bấm Làm mới để đưa Form về trạng thái ban đầu.

Bấm Thoát để đóng chương trình.

Bảng đặt tên Control
Chức năng	Tên Control	Kiểu
Form chính	FrmStudentCard	Form
Mã SV	txtMaSV	TextBox
Họ tên	txtHoTen	TextBox
Lớp	cboLop	ComboBox
Khoa	cboKhoa	ComboBox
Khóa học	cboKhoaHoc	ComboBox
Ngày sinh	dtpNgaySinh	DateTimePicker
Giới tính	cboGioiTinh	ComboBox
Ảnh đại diện	picAnhDaiDien	PictureBox
Chọn ảnh	btnChonAnh	Button
Làm mới	btnLamMoi	Button
Xem trước in	btnXemTruocIn	Button
In thẻ	btnIn	Button
Thoát	btnThoat	Button
Open File	dlgChonAnh	OpenFileDialog
Preview Panel	pnlXemTruoc	Panel
In thẻ	docInThe	PrintDocument
Validation dữ liệu
Mã sinh viên
Mã sinh viên phải theo định dạng:

51.01.104.030
Điều kiện:

Chỉ chứa số và dấu .
Đúng mẫu:
xx.xx.xxx.xxx
Ví dụ:

✅ 51.01.104.030

✅ 49.01.101.123

❌ 5101104030

❌ 51-01-104-030

❌ abc123

Họ và tên
Điều kiện:

Không được để trống
Chỉ chứa chữ cái và khoảng trắng
Không chứa số
Không chứa ký tự đặc biệt
Tối đa 50 ký tự
Ví dụ:

✅ Nguyễn Bá Hoan

✅ Trần Thị Kim Ngân

❌ Nguyễn123

❌ Nguyễn@Hoan

Hình ảnh minh họa
1. Kiểm tra khi bỏ trống mã sinh viên
images/validation-mssv.png

2. Kiểm tra khi bỏ trống họ tên
images/validation-hoten.png

3. Xem trước thẻ sinh viên sau khi nhập dữ liệu
images/preview-card.png

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
Cấu trúc Code
Thành phần	Chức năng
StudentCardInfo	Lưu thông tin sinh viên
ValidateInput()	Kiểm tra dữ liệu đầu vào
btnChonAnh_Click()	Chọn ảnh đại diện
btnLamMoi_Click()	Làm mới dữ liệu
btnThoat_Click()	Thoát chương trình
pnlXemTruoc_Paint()	Vẽ thẻ xem trước
DrawStudentCard()	Vẽ thẻ sinh viên
btnXemTruocIn_Click()	Xem trước khi in
btnIn_Click()	In thẻ
docInThe_PrintPage()	Vẽ nội dung khi in
Test Case
STT	Chức năng	Kết quả mong đợi
1	Mở chương trình	Form hiển thị đầy đủ
2	Thiếu MSSV	Hiển thị thông báo lỗi
3	Thiếu họ tên	Hiển thị thông báo lỗi
4	Thiếu ảnh	Hiển thị thông báo lỗi
5	Chọn ảnh	Ảnh hiển thị trong PictureBox
6	Preview	Cập nhật tức thời
7	Xem trước in	Mở PrintPreviewDialog
8	In thẻ	Mở PrintDialog
9	Làm mới	Xóa dữ liệu
10	Thoát	Đóng ứng dụng
Kết quả đạt được
✅ Thiết kế giao diện Windows Forms

✅ Validation dữ liệu đầu vào

✅ Chọn ảnh đại diện

✅ Hiển thị xem trước thẻ sinh viên

✅ Xem trước khi in

✅ In thẻ sinh viên

✅ Sử dụng OpenFileDialog

✅ Sử dụng Graphics (GDI+)

✅ Sử dụng PrintDocument

✅ Hoàn thành yêu cầu Lab 09
