using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoAn_QLSV_Nhom3.View
{
    /// <summary>
    /// Interaction logic for QLLopHoc.xaml
    /// </summary>
    public partial class QLLopHoc : Window
    {
        public QLLopHoc()
        {
            InitializeComponent();
            Loaded += QLLopHoc_Loaded;
        }

        ViewModel.LopHocModelView lopVM = new ViewModel.LopHocModelView();
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        private void QLLopHoc_Loaded(object sender, RoutedEventArgs e)
        {
            lopVM.LoadLop(DG_Lop);
            cb_khoa.ItemsSource = db.KHOA.ToList();
            cb_khoa.DisplayMemberPath = "TenKhoa";
            cb_khoa.SelectedValuePath = "MaKhoa";

            cb_covan.ItemsSource = db.GIANGVIEN.ToList();
            cb_covan.DisplayMemberPath = "HoTen";  
            cb_covan.SelectedValuePath = "MaGV";

            cb_trangthai.ItemsSource = new List<string> { "Đang hoạt động", "Ngừng" };

            DG_Lop.SelectionChanged += DG_Lop_SelectionChanged;
        }

        private void DG_Lop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = DG_Lop.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                txt_malop.Text = data.MaLop;
                txt_tenlop.Text = data.TenLop;
                txt_khoahoc.Text = data.KhoaHoc;
                cb_khoa.SelectedValue = data.MaKhoa;
                cb_covan.SelectedValue = data.CoVanHocTap;
                txt_siso.Text = data.SiSo.ToString();
                txt_namhoc.Text = data.NamHoc;
                cb_trangthai.SelectedItem = data.TrangThai;
            }
        }

        private void Btn_Luu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_malop.Text) || string.IsNullOrEmpty(txt_tenlop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var lop = new Model.LOP
            {
                MaLop = txt_malop.Text,
                TenLop = txt_tenlop.Text,
                KhoaHoc = txt_khoahoc.Text,
                MaKhoa = cb_khoa.SelectedValue?.ToString(),
                CoVanHocTap = cb_covan.SelectedValue?.ToString(),
                SiSo = int.TryParse(txt_siso.Text, out int siso) ? siso : 0,
                NamHoc = txt_namhoc.Text,
                TrangThai = cb_trangthai.Text
            };

            lopVM.ThemHoacSuaLop(lop);
            lopVM.LoadLop(DG_Lop);
            MessageBox.Show("Lưu lớp thành công!");
            ClearForm();
        }

        private void Btn_Sua_Click(object sender, RoutedEventArgs e)
        {
            if (DG_Lop.SelectedItem != null)
            {
                MessageBox.Show("Chỉnh sửa thông tin và nhấn Lưu.");
            }
            else
            {
                MessageBox.Show("Hãy chọn lớp để sửa.");
            }
        }

        private void Btn_Xoa_Click(object sender, RoutedEventArgs e)
        {
            var row = DG_Lop.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                var result = MessageBox.Show($"Bạn có chắc muốn xóa lớp {data.TenLop}?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    lopVM.XoaLop(data.MaLop);
                    lopVM.LoadLop(DG_Lop);
                    MessageBox.Show("Xóa lớp thành công!");
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn lớp để xóa.");
            }
        }

        private void Btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txt_malop.Clear();
            txt_tenlop.Clear();
            txt_khoahoc.Clear();
            cb_khoa.SelectedIndex = -1;
            cb_covan.SelectedIndex = -1;
            txt_siso.Clear();
            txt_namhoc.Clear();
            cb_trangthai.SelectedIndex = -1;
            DG_Lop.UnselectAll();
        }
    }
}
