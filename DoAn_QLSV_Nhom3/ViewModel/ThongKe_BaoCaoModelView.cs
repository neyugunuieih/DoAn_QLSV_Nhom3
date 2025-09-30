using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class ThongKe_BaoCaoModelView
    {
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        public List<object> ThongKe(string lop, string mon, string namHoc, int hocKy)
        {
            var query = from d in db.DIEM
                        join sv in db.SINHVIEN on d.MaSV equals sv.MaSV
                        join lh in db.LOP on sv.MaLop equals lh.MaLop
                        join mh in db.MONHOC on d.MaMon equals mh.MaMon
                        where lh.TenLop == lop
                              && mh.TenMon == mon

                        select new
                        {
                            sv.MaSV,
                            sv.HoTen,
                            Lop = lh.TenLop,
                            MonHoc = mh.TenMon,
                            DiemGK = d.DiemGK, 
                            DiemCK = d.DiemCK,
                            DiemTB = ((d.DiemGK ?? 0m) * 0.4m) + ((d.DiemCK ?? 0m) * 0.6m),
                            KetQua = (((d.DiemGK ?? 0m) * 0.4m + (d.DiemCK ?? 0m) * 0.6m) >= 5m) ? "Đạt" : "Không đạt"
                        };

            return query.ToList<object>();
        }
    }
}
