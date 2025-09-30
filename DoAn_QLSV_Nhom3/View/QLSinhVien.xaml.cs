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
    /// Interaction logic for QLSinhVien.xaml
    /// </summary>
    public partial class QLSinhVien : Window
    {
        public QLSinhVien()
        {
            InitializeComponent();
        }
        ViewModel.SinhVienModelView svmd = new ViewModel.SinhVienModelView();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            svmd.LoadSV(DG_SinhVien);

            using (var db = new Model.QLSinhVienEntities())
            {
                var listLop = db.LOP.ToList();
                cb_MaLop.ItemsSource = listLop;
                cb_MaLop.DisplayMemberPath = "MaLop";   
                cb_MaLop.SelectedValuePath = "MaLop";   
            }

        }

        private void Btn_Them_Click(object sender, RoutedEventArgs e)
        {
            string gt = rb_Nam.IsChecked == true ? "Nam" : "Nữ";

            if (cb_MaLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp!");
                return;
            }

            Model.SINHVIEN sv = new Model.SINHVIEN
            {
                MaSV = txt_MaSV.Text,
                HoTen = txt_HoTen.Text,
                NgaySinh = dp_NgaySinh.SelectedDate,
                GioiTinh = gt,
                DiaChi = txt_DiaChi.Text,
                MaLop = cb_MaLop.SelectedValue.ToString()
            };

            svmd.ThemSV(sv);
            svmd.LoadSV(DG_SinhVien);
            MessageBox.Show("Thêm sinh viên thành công!");
            ClearForm();
        }

        private void Btn_Sua_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên!");
                return;
            }

            string gt = rb_Nam.IsChecked == true ? "Nam" : "Nữ";

            Model.SINHVIEN svCapNhat = new Model.SINHVIEN
            {
                MaSV = txt_MaSV.Text,
                HoTen = txt_HoTen.Text,
                NgaySinh = dp_NgaySinh.SelectedDate,
                GioiTinh = gt,
                DiaChi = txt_DiaChi.Text,
                MaLop = cb_MaLop.SelectedValue?.ToString()
            };

            svmd.SuaSV(svCapNhat);
            svmd.LoadSV(DG_SinhVien);
            MessageBox.Show("Cập nhật sinh viên thành công!");
            ClearForm();
        }

        private void Btn_Xoa_Click(object sender, RoutedEventArgs e)
        {
            Model.SINHVIEN svchon = DG_SinhVien.SelectedItem as Model.SINHVIEN;
            if (svchon == null)
            {
                MessageBox.Show("Hãy chọn sinh viên cần xoá");
                return;
            }
            svmd.XoaSV(svchon);
            svmd.LoadSV(DG_SinhVien);
            MessageBox.Show("Xoá sinh viên thành công");
            ClearForm();
        }

        private void DG_SinhVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DG_SinhVien.SelectedItem is Model.SINHVIEN svchon)
            {
                txt_MaSV.Text = svchon.MaSV;
                txt_HoTen.Text = svchon.HoTen;
                dp_NgaySinh.SelectedDate = svchon.NgaySinh;
                txt_DiaChi.Text = svchon.DiaChi;

                if (svchon.GioiTinh == "Nam")
                    rb_Nam.IsChecked = true;
                else
                    rb_Nu.IsChecked = true;

                cb_MaLop.SelectedValue = svchon.MaLop;
            }
        }
        private void ClearForm()
        {
            txt_MaSV.Clear();
            txt_HoTen.Clear();
            dp_NgaySinh.SelectedDate = null;
            rb_Nam.IsChecked = false;
            rb_Nu.IsChecked = false;
            txt_DiaChi.Clear();
            cb_MaLop.SelectedIndex = -1;
        }
    }
}
