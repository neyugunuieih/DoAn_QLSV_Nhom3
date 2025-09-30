using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class DiemModelView
    {
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        public void LoadDiem(DataGrid dg)
        {
            var list = db.DIEM
                .Select(d => new
                {
                    d.MaSV,
                    TenSV = d.SINHVIEN.HoTen,
                    d.MaMon,
                    TenMH = d.MONHOC.TenMon,
                    d.DiemGK,
                    d.DiemCK,
                    d.DiemTK
                }).ToList();

            dg.ItemsSource = list;
        }

        public void ThemHoacSuaDiem(Model.DIEM diem)
        {
            var d = db.DIEM.Find(diem.MaSV, diem.MaMon);
            if (d == null)
            {
                db.DIEM.Add(diem);
            }
            else
            {
                d.DiemGK = diem.DiemGK;
                d.DiemCK = diem.DiemCK;
                d.DiemTK = diem.DiemTK;
            }
            db.SaveChanges();
        }

        public void XoaDiem(Model.DIEM diem)
        {
            var d = db.DIEM.Find(diem.MaSV, diem.MaMon);
            if (d != null)
            {
                db.DIEM.Remove(d);
                db.SaveChanges();
            }
        }
    }
}
