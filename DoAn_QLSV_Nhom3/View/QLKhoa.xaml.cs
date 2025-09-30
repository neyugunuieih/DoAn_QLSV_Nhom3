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
    /// Interaction logic for QLKhoa.xaml
    /// </summary>
    public partial class QLKhoa : Window
    {
        public QLKhoa()
        {
            InitializeComponent();
            Loaded += QLKhoa_Loaded;
        }

        ViewModel.KhoaModelView khoaVM = new ViewModel.KhoaModelView();

        private void QLKhoa_Loaded(object sender, RoutedEventArgs e)
        {
            khoaVM.LoadKhoa(DG_Khoa);
            DG_Khoa.SelectionChanged += DG_Khoa_SelectionChanged;
        }

        private void DG_Khoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = DG_Khoa.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                txt_MaKhoa.Text = data.MaKhoa;
                txt_TenKhoa.Text = data.TenKhoa;
                txt_TruongKhoa.Text = data.TruongKhoa;
                txt_SDT.Text = data.SoDienThoai;   
                txt_Email.Text = data.Email;
                dt_NgayThanhLap.SelectedDate = data.NgayThanhLap;
            }
        }


        private void Btn_Luu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaKhoa.Text) || string.IsNullOrEmpty(txt_TenKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var khoa = new Model.KHOA
            {
                MaKhoa = txt_MaKhoa.Text,
                TenKhoa = txt_TenKhoa.Text,
                TruongKhoa = txt_TruongKhoa.Text,
                SoDienThoai = txt_SDT.Text,
                Email = txt_Email.Text,
                NgayThanhLap = dt_NgayThanhLap.SelectedDate ?? DateTime.Now
            };

            khoaVM.ThemHoacSuaKhoa(khoa);
            khoaVM.LoadKhoa(DG_Khoa);
            MessageBox.Show("Lưu khoa thành công!");
            ClearForm();
        }

        private void Btn_Sua_Click(object sender, RoutedEventArgs e)
        {
            var row = DG_Khoa.SelectedItem;
            if (row != null)
            {
                MessageBox.Show("Chỉnh sửa thông tin và nhấn Lưu.");
            }
            else
            {
                MessageBox.Show("Hãy chọn khoa để sửa.");
            }
        }

        private void Btn_Xoa_Click(object sender, RoutedEventArgs e)
        {
            var row = DG_Khoa.SelectedItem;
            if (row != null)
            {
                dynamic data = row;
                var result = MessageBox.Show($"Bạn có chắc muốn xóa khoa {data.TenKhoa}?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    khoaVM.XoaKhoa(data.MaKhoa);
                    khoaVM.LoadKhoa(DG_Khoa);
                    MessageBox.Show("Xóa khoa thành công!");
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn khoa để xóa.");
            }
        }

        private void Btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txt_MaKhoa.Clear();
            txt_TenKhoa.Clear();
            txt_TruongKhoa.Clear();
            txt_SDT.Clear();
            txt_Email.Clear();
            dt_NgayThanhLap.SelectedDate = null;
            DG_Khoa.UnselectAll();
        }
    }
}
