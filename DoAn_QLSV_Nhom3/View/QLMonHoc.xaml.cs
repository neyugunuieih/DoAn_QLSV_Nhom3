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
    /// Interaction logic for QLMonHoc.xaml
    /// </summary>
    public partial class QLMonHoc : Window
    {
        public QLMonHoc()
        {
            InitializeComponent();
            Loaded += QLMonHoc_Loaded;
        }

        ViewModel.MonHocModelView monhocVM = new ViewModel.MonHocModelView();

        private void QLMonHoc_Loaded(object sender, RoutedEventArgs e)
        {
            monhocVM.LoadMonHoc(DG_MonHoc);
            DG_MonHoc.SelectionChanged += DG_MonHoc_SelectionChanged;
        }

        private void DG_MonHoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = DG_MonHoc.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                txt_MaMon.Text = data.MaMon;
                txt_TenMon.Text = data.TenMon;
                txt_SoTinChi.Text = data.SoTinChi.ToString();

                cb_Khoa.SelectedValue = data.MaKhoa;
            }
        }


        private void Btn_Luu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaMon.Text) || string.IsNullOrEmpty(txt_TenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                var mon = new Model.MONHOC
                {
                    MaMon = txt_MaMon.Text,
                    TenMon = txt_TenMon.Text,
                    SoTinChi = int.Parse(txt_SoTinChi.Text),
                    MaKhoa = cb_Khoa.Text
                };

                monhocVM.ThemHoacSuaMonHoc(mon);
                monhocVM.LoadMonHoc(DG_MonHoc);
                MessageBox.Show("Lưu môn học thành công!");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Btn_Sua_Click(object sender, RoutedEventArgs e)
        {
            if (DG_MonHoc.SelectedItem != null)
            {
                MessageBox.Show("Hãy chỉnh sửa thông tin trong form rồi nhấn Lưu để cập nhật!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học để sửa.");
            }
        }

        private void Btn_Xoa_Click(object sender, RoutedEventArgs e)
        {
            var row = DG_MonHoc.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                var result = MessageBox.Show($"Bạn có chắc muốn xóa môn học {data.TenMon}?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    monhocVM.XoaMonHoc(data.MaMon);
                    monhocVM.LoadMonHoc(DG_MonHoc);
                    MessageBox.Show("Xóa môn học thành công!");
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn môn học để xóa.");
            }
        }

        private void Btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txt_MaMon.Clear();
            txt_TenMon.Clear();
            txt_SoTinChi.Clear();
            cb_Khoa.SelectedIndex = -1;
            DG_MonHoc.UnselectAll();
        }
    }
}
