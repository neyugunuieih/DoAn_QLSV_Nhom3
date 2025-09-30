using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class GiangDayModelView
    {
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        public void LoadGiangDay(DataGrid dg)
        {
            var list = db.GIANGDAY
                .Select(g => new
                {
                    g.MaGV,
                    TenGV = g.GIANGVIEN.HoTen,
                    g.MaLop,
                    TenLop = g.LOP.TenLop,
                    g.MaMon,
                    TenMH = g.MONHOC.TenMon
                }).ToList();

            dg.ItemsSource = list;
        }

        public void ThemHoacSuaGiangDay(Model.GIANGDAY gd)
        {
            var g = db.GIANGDAY.Find(gd.MaGV, gd.MaLop, gd.MaMon);
            if (g == null)
            {
                db.GIANGDAY.Add(gd);
            }
            else
            {
                g.MaGV = gd.MaGV;
                g.MaLop = gd.MaLop;
                g.MaMon = gd.MaMon;
            }
            db.SaveChanges();
        }

        public void XoaGiangDay(Model.GIANGDAY gd)
        {
            var g = db.GIANGDAY.Find(gd.MaGV, gd.MaLop, gd.MaMon);
            if (g != null)
            {
                db.GIANGDAY.Remove(g);
                db.SaveChanges();
            }
        }
    }
}
