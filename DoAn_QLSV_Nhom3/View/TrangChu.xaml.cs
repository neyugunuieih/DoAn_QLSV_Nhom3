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
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : Window
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        ViewModel.TrangChuModelView tcmd = new ViewModel.TrangChuModelView();

        private void Btn_QLSinhVien_Click(object sender, RoutedEventArgs e)
        {
            tcmd.QLSinhVien();
        }

        private void Btn_QLLop_Click(object sender, RoutedEventArgs e)
        {
            tcmd.QLLop();
        }

        private void Btn_QLMonHoc_Click(object sender, RoutedEventArgs e)
        {
            tcmd.QLMonHoc();
        }

        private void Btn_QLDiem_Click(object sender, RoutedEventArgs e)
        {
            tcmd.QLDiem();
        }

        private void Btn_QLGiangVien_Click(object sender, RoutedEventArgs e)
        {
            tcmd.QLGiangVien();
        }

        private void Btn_QLKhoa_Click(object sender, RoutedEventArgs e)
        {
            tcmd.QLKhoa();
        }

        private void Btn_QLGiangDay_Click(object sender, RoutedEventArgs e)
        {
            tcmd.QLGiangDay();
        }

        private void Btn_TKeBCao_Click(object sender, RoutedEventArgs e)
        {
            tcmd.ThongKe_BaoCao();
        }

        private void Btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
