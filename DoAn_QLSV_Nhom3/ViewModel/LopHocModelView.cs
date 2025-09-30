using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class LopHocModelView
    {
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        // Load danh sách lớp
        public void LoadLop(DataGrid dg)
        {
            var list = (from l in db.LOP
                        join k in db.KHOA on l.MaKhoa equals k.MaKhoa into k_join
                        from k in k_join.DefaultIfEmpty()
                        join gv in db.GIANGVIEN on l.CoVanHocTap equals gv.MaGV into gv_join
                        from gv in gv_join.DefaultIfEmpty()
                        select new
                        {
                            l.MaLop,
                            l.TenLop,
                            l.KhoaHoc,
                            l.MaKhoa,
                            TenKhoa = k != null ? k.TenKhoa : "",
                            l.CoVanHocTap,
                            TenGV = gv != null ? gv.HoTen : "",
                            l.SiSo,
                            l.NamHoc,
                            l.TrangThai
                        }).ToList();

            dg.ItemsSource = list;
        }


        public void ThemHoacSuaLop(Model.LOP lop)
        {
            var l = db.LOP.Find(lop.MaLop);
            if (l == null)
            {
                db.LOP.Add(lop);
            }
            else
            {
                l.TenLop = lop.TenLop;
                l.MaKhoa = lop.MaKhoa;
                l.KhoaHoc = lop.KhoaHoc;
                l.CoVanHocTap = lop.CoVanHocTap;
                l.SiSo = lop.SiSo;
                l.NamHoc = lop.NamHoc;
                l.TrangThai = lop.TrangThai;
            }
            db.SaveChanges();
        }

        public void XoaLop(string maLop)
        {
            var l = db.LOP.Find(maLop);
            if (l != null)
            {
                db.LOP.Remove(l);
                db.SaveChanges();
            }
        }
    }
}
