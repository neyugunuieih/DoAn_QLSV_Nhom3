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
    /// Interaction logic for QLDiem.xaml
    /// </summary>
    public partial class QLDiem : Window
    {
        public QLDiem()
        {
            InitializeComponent();
        }

        ViewModel.DiemModelView diemVM = new ViewModel.DiemModelView();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            diemVM.LoadDiem(DG_Diem);

            using (var db = new Model.QLSinhVienEntities())
            {
                cb_MonHoc.ItemsSource = db.MONHOC.ToList();
                cb_MonHoc.DisplayMemberPath = "TenMH";
                cb_MonHoc.SelectedValuePath = "MaMH";
            }
        }

        private void Btn_Luu_Click(object sender, RoutedEventArgs e)
        {
            if (cb_MonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!");
                return;
            }

            double diemGK, diemCK;
            if (!double.TryParse(txt_DiemGK.Text, out diemGK) || !double.TryParse(txt_DiemCK.Text, out diemCK))
            {
                MessageBox.Show("Điểm nhập không hợp lệ!");
                return;
            }

            double diemTK = Math.Round((diemGK * 0.4 + diemCK * 0.6), 2);
            txt_DiemTK.Text = diemTK.ToString();

            Model.DIEM d = new Model.DIEM
            {
                MaSV = txt_MaSV.Text,
                MaMon = cb_MonHoc.SelectedValue.ToString(),
                DiemGK = (decimal)diemGK,
                DiemCK = (decimal)diemCK,
                DiemTK = (decimal)diemTK
            };

            diemVM.ThemHoacSuaDiem(d);
            diemVM.LoadDiem(DG_Diem);

            MessageBox.Show("Lưu điểm thành công!");
            ClearForm();
        }

        private void Btn_Sua_Click(object sender, RoutedEventArgs e)
        {
            if (DG_Diem.SelectedItem is Model.DIEM dchon)
            {
                txt_MaSV.Text = dchon.MaSV;
                txt_TenSV.Text = dchon.SINHVIEN.HoTen;
                txt_DiemGK.Text = dchon.DiemGK?.ToString();
                txt_DiemCK.Text = dchon.DiemCK?.ToString();
                txt_DiemTK.Text = dchon.DiemTK?.ToString();
                cb_MonHoc.SelectedValue = dchon.MaMon;
            }
        }

        private void Btn_Xoa_Click(object sender, RoutedEventArgs e)
        {
            if (DG_Diem.SelectedItem is Model.DIEM dchon)
            {
                diemVM.XoaDiem(dchon);
                diemVM.LoadDiem(DG_Diem);
                MessageBox.Show("Xóa điểm thành công!");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Hãy chọn bản ghi cần xóa!");
            }
        }

        private void ClearForm()
        {
            txt_MaSV.Clear();
            txt_TenSV.Clear();
            txt_DiemGK.Clear();
            txt_DiemCK.Clear();
            txt_DiemTK.Clear();
            cb_MonHoc.SelectedIndex = -1;
        }

        private void Btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
