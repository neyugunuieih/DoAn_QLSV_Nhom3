using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class KhoaModelView
    {
        Model.QLSinhVienEntities db = new Model.QLSinhVienEntities();

        public void LoadKhoa(DataGrid dg)
        {
            var list = db.KHOA
                .Select(k => new
                {
                    k.MaKhoa,
                    k.TenKhoa,
                    k.TruongKhoa,
                    k.SoDienThoai,
                    k.Email,
                    k.NgayThanhLap
                }).ToList();

            dg.ItemsSource = list;
        }

        public void ThemHoacSuaKhoa(Model.KHOA khoa)
        {
            var k = db.KHOA.Find(khoa.MaKhoa);
            if (k == null)
            {
                db.KHOA.Add(khoa);
            }
            else
            {
                k.TenKhoa = khoa.TenKhoa;
                k.TruongKhoa = khoa.TruongKhoa;
                k.SoDienThoai = khoa.SoDienThoai;
                k.Email = khoa.Email;
                k.NgayThanhLap = khoa.NgayThanhLap;
            }
            db.SaveChanges();
        }

        public void XoaKhoa(string maKhoa)
        {
            var k = db.KHOA.Find(maKhoa);
            if (k != null)
            {
                db.KHOA.Remove(k);
                db.SaveChanges();
            }
        }
    }
}
