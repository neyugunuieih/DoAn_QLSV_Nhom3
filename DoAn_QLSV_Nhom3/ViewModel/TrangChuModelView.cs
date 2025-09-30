using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class TrangChuModelView
    {
        public void QLSinhVien()
        {
            View.QLSinhVien qlsv = new View.QLSinhVien();
            qlsv.ShowDialog();
        }

        public void QLLop()
        {
            View.QLLopHoc qllop = new View.QLLopHoc();
            qllop.ShowDialog();
        }

        public void QLMonHoc()
        {
            View.QLMonHoc qlmonhoc = new View.QLMonHoc();
            qlmonhoc.ShowDialog();
        }

        public void QLDiem()
        {
            View.QLDiem qldiem = new View.QLDiem();
            qldiem.ShowDialog();
        }

        public void QLGiangVien()
        {
            View.QLGiangVien qlgv = new View.QLGiangVien();
            qlgv.ShowDialog();
        }

        public void QLKhoa()
        {
            View.QLKhoa qlkhoa = new View.QLKhoa();
            qlkhoa.ShowDialog();
        }

        public void QLGiangDay()
        {
            View.QLGiangDay qlgd = new View.QLGiangDay();
            qlgd.ShowDialog();
        }

        public void ThongKe_BaoCao()
        {
            View.QLThongKe_BaoCao tk = new View.QLThongKe_BaoCao();
            tk.ShowDialog();
        }
    }
}
