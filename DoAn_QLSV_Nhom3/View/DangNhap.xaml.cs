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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        ViewModel.DangNhapModelView dnmd = new ViewModel.DangNhapModelView();
        private void Btn_DangNhap_Click(object sender, RoutedEventArgs e)
        {
            string TK = txt_TK.Text.Trim();
            string MK = txt_MK.Password;

            if (dnmd.KiemTraDangNhap(TK, MK))
            {
                MessageBox.Show("Đăng nhập thành công!");
                TrangChu trangChu = new TrangChu();
                trangChu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
