using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class GiangVienModelView
    {
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        public void LoadGiangVien(DataGrid dg)
        {
            var list = db.GIANGVIEN
                .Select(g => new
                {
                    g.MaGV,
                    g.HoTen,
                    g.NgaySinh,
                    GioiTinh = g.GioiTinh,
                    g.DiaChi,
                    g.BoMon
                }).ToList();

            dg.ItemsSource = list;
        }

        public void ThemHoacSuaGiangVien(Model.GIANGVIEN gv)
        {
            var g = db.GIANGVIEN.Find(gv.MaGV);
            if (g == null)
            {
                db.GIANGVIEN.Add(gv);
            }
            else
            {
                g.HoTen = gv.HoTen;
                g.NgaySinh = gv.NgaySinh;
                g.GioiTinh = gv.GioiTinh;
                g.DiaChi = gv.DiaChi;
                g.BoMon = gv.BoMon;
            }
            db.SaveChanges();
        }

        public void XoaGiangVien(string maGV)
        {
            var g = db.GIANGVIEN.Find(maGV);
            if (g != null)
            {
                db.GIANGVIEN.Remove(g);
                db.SaveChanges();
            }
        }
    }
}
