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
    /// Interaction logic for QLThongKe_BaoCao.xaml
    /// </summary>
    public partial class QLThongKe_BaoCao : Window
    {
        public QLThongKe_BaoCao()
        {
            InitializeComponent();
            Loaded += QLThongKe_BaoCao_Loaded;
        }

        ViewModel.ThongKe_BaoCaoModelView model = new ViewModel.ThongKe_BaoCaoModelView();
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        private void QLThongKe_BaoCao_Loaded(object sender, RoutedEventArgs e)
        {
            cb_Lop.ItemsSource = db.LOP.Select(l => l.TenLop).Distinct().ToList();
            cb_Mon.ItemsSource = db.MONHOC.Select(m => m.TenMon).Distinct().ToList();

            cb_Lop.SelectedIndex = -1;
            cb_Mon.SelectedIndex = -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lop = cb_Lop.SelectedItem as string;
                string mon = cb_Mon.SelectedItem as string;
                string namHoc = cb_NamHoc.SelectedItem as string;
                string hocKyStr = cb_HocKy.SelectedItem as string;

                if (string.IsNullOrEmpty(lop) || string.IsNullOrEmpty(mon) || string.IsNullOrEmpty(namHoc) || string.IsNullOrEmpty(hocKyStr))
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int hocKy = int.Parse(hocKyStr);

                var data = model.ThongKe(lop, mon, namHoc, hocKy);
                DG_Report.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Xuất Excel đang phát triển...");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng In báo cáo đang phát triển...");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
