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
    /// Interaction logic for QLGiangDay.xaml
    /// </summary>
    public partial class QLGiangDay : Window
    {
        public QLGiangDay()
        {
            InitializeComponent();
        }

        ViewModel.GiangDayModelView giangdayVM = new ViewModel.GiangDayModelView();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            giangdayVM.LoadGiangDay(DG_GiangDay);

            using (var db = new Model.QLSinhVienEntities())
            {
                cb_GiangVien.ItemsSource = db.GIANGVIEN.ToList();
                cb_GiangVien.DisplayMemberPath = "HoTen";
                cb_GiangVien.SelectedValuePath = "MaGV";

                cb_Lop.ItemsSource = db.LOP.ToList();
                cb_Lop.DisplayMemberPath = "TenLop";
                cb_Lop.SelectedValuePath = "MaLop";

                cb_MonHoc.ItemsSource = db.MONHOC.ToList();
                cb_MonHoc.DisplayMemberPath = "TenMon";
                cb_MonHoc.SelectedValuePath = "MaMon";
            }
        }

        private void Btn_Luu_Click(object sender, RoutedEventArgs e)
        {
            if (cb_GiangVien.SelectedValue == null || cb_Lop.SelectedValue == null || cb_MonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đủ thông tin!");
                return;
            }

            Model.GIANGDAY gd = new Model.GIANGDAY
            {
                MaGV = cb_GiangVien.SelectedValue.ToString(),
                MaLop = cb_Lop.SelectedValue.ToString(),
                MaMon = cb_MonHoc.SelectedValue.ToString()
            };

            giangdayVM.ThemHoacSuaGiangDay(gd);
            giangdayVM.LoadGiangDay(DG_GiangDay);

            MessageBox.Show("Lưu phân công giảng dạy thành công!");
            ClearForm();
        }

        private void Btn_Sua_Click(object sender, RoutedEventArgs e)
        {
            var row = DG_GiangDay.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                cb_GiangVien.SelectedValue = data.MaGV;
                cb_Lop.SelectedValue = data.MaLop;
                cb_MonHoc.SelectedValue = data.MaMon;
            }
            else
            {
                MessageBox.Show("Hãy chọn bản ghi cần sửa.");
            }
        }

        private void Btn_Xoa_Click(object sender, RoutedEventArgs e)
        {
            var row = DG_GiangDay.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                var gd = new Model.GIANGDAY
                {
                    MaGV = data.MaGV,
                    MaLop = data.MaLop,
                    MaMon = data.MaMon
                };
                giangdayVM.XoaGiangDay(gd);
                giangdayVM.LoadGiangDay(DG_GiangDay);
                ClearForm();
                MessageBox.Show("Xóa phân công thành công!");
            }
            else
            {
                MessageBox.Show("Hãy chọn bản ghi cần xóa.");
            }
        }


        private void ClearForm()
        {
            cb_GiangVien.SelectedIndex = -1;
            cb_Lop.SelectedIndex = -1;
            cb_MonHoc.SelectedIndex = -1;
            DG_GiangDay.UnselectAll();
        }

        private void Btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
