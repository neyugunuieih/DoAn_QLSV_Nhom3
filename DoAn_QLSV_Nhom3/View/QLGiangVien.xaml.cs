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
    /// Interaction logic for QLGiangVien.xaml
    /// </summary>
    public partial class QLGiangVien : Window
    {
        public QLGiangVien()
        {
            InitializeComponent();
            Loaded += QLGiangVien_Loaded;
        }

        ViewModel.GiangVienModelView gvVM = new ViewModel.GiangVienModelView();

        private void QLGiangVien_Loaded(object sender, RoutedEventArgs e)
        {
            gvVM.LoadGiangVien(DG_GiangVien);
            DG_GiangVien.SelectionChanged += DG_GiangVien_SelectionChanged;
        }

        private void DG_GiangVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = DG_GiangVien.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                txt_MaGV.Text = data.MaGV;
                txt_HoTen.Text = data.HoTen;
                dt_NgaySinh.SelectedDate = data.NgaySinh;
                rb_Nam.IsChecked = data.GioiTinh == "Nam";
                rb_Nu.IsChecked = data.GioiTinh == "Nữ";
                txt_DiaChi.Text = data.DiaChi;

                foreach (ComboBoxItem item in cb_BoMon.Items)
                {
                    if (item.Content.ToString() == data.BoMon)
                    {
                        cb_BoMon.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void Btn_Luu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaGV.Text) || string.IsNullOrEmpty(txt_HoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var gv = new Model.GIANGVIEN
            {
                MaGV = txt_MaGV.Text,
                HoTen = txt_HoTen.Text,
                NgaySinh = dt_NgaySinh.SelectedDate ?? DateTime.Now,
                GioiTinh = rb_Nam.IsChecked == true ? "Nam" : "Nữ",
                DiaChi = txt_DiaChi.Text,
                BoMon = (cb_BoMon.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

            gvVM.ThemHoacSuaGiangVien(gv);
            gvVM.LoadGiangVien(DG_GiangVien);
            MessageBox.Show("Lưu giảng viên thành công!");
            ClearForm();
        }

        private void Btn_Sua_Click(object sender, RoutedEventArgs e)
        {
            var row = DG_GiangVien.SelectedItem;
            if (row != null)
            {
                MessageBox.Show("Chỉnh sửa thông tin và nhấn Lưu.");
            }
            else
            {
                MessageBox.Show("Hãy chọn giảng viên để sửa.");
            }
        }

        private void Btn_Xoa_Click(object sender, RoutedEventArgs e)
        {
            var row = DG_GiangVien.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                var result = MessageBox.Show($"Bạn có chắc muốn xóa giảng viên {data.HoTen}?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    gvVM.XoaGiangVien(data.MaGV);
                    gvVM.LoadGiangVien(DG_GiangVien);
                    MessageBox.Show("Xóa giảng viên thành công!");
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn giảng viên để xóa.");
            }
        }

        private void Btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txt_MaGV.Clear();
            txt_HoTen.Clear();
            dt_NgaySinh.SelectedDate = null;
            rb_Nam.IsChecked = false;
            rb_Nu.IsChecked = false;
            cb_BoMon.SelectedIndex = -1;
            DG_GiangVien.UnselectAll();
        }
    }
}
