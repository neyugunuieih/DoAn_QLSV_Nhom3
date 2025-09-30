using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class MonHocModelView
    {
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        public void LoadMonHoc(DataGrid dg)
        {
            var list = (from m in db.MONHOC
                        join k in db.KHOA on m.MaKhoa equals k.MaKhoa
                        select new
                        {
                            m.MaMon,
                            m.TenMon,
                            m.SoTinChi,
                            m.MaKhoa,
                            TenKhoa = k.TenKhoa
                        }).ToList();

            dg.ItemsSource = list;
        }


        public void ThemHoacSuaMonHoc(Model.MONHOC mon)
        {
            var m = db.MONHOC.Find(mon.MaMon);
            if (m == null)
            {
                db.MONHOC.Add(mon);
            }
            else
            {
                m.TenMon = mon.TenMon;
                m.SoTinChi = mon.SoTinChi;
                m.MaKhoa = mon.MaKhoa;
            }
            db.SaveChanges();
        }

        public void XoaMonHoc(string maMon)
        {
            var m = db.MONHOC.Find(maMon);
            if (m != null)
            {
                db.MONHOC.Remove(m);
                db.SaveChanges();
            }
        }
    }
}
