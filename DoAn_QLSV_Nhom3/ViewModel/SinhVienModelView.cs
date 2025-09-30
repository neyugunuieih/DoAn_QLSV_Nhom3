using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class SinhVienModelView
    {
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        public void ThemSV(Model.SINHVIEN sv)
        {
            db.SINHVIEN.Add(sv);
            db.SaveChanges();
        }

        public void SuaSV(Model.SINHVIEN svCapNhat)
        {
            Model.SINHVIEN sv = db.SINHVIEN.Find(svCapNhat.MaSV);
            if (sv != null)
            {
                sv.HoTen = svCapNhat.HoTen;
                sv.NgaySinh = svCapNhat.NgaySinh;
                sv.GioiTinh = svCapNhat.GioiTinh;
                sv.DiaChi = svCapNhat.DiaChi;
                sv.MaLop = svCapNhat.MaLop; 
                db.SaveChanges();
            }
        }

        public void XoaSV(Model.SINHVIEN svXoa)
        {
            Model.SINHVIEN sv = db.SINHVIEN.Find(svXoa.MaSV);
            if (sv != null)
            {
                db.SINHVIEN.Remove(sv);
                db.SaveChanges();
            }
        }

        public void LoadSV(DataGrid dg)
        {
            dg.ItemsSource = db.SINHVIEN.ToList();
        }
    }
}
