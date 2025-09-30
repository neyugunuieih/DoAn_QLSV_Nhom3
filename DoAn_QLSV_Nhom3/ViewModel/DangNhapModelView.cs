using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLSV_Nhom3.ViewModel
{
    class DangNhapModelView
    {
        private readonly string taiKhoanMacDinh = "admin";
        private readonly string matKhauMacDinh = "123456";

        public bool KiemTraDangNhap(string TK, string MK)
        {
            if (string.IsNullOrWhiteSpace(TK) || string.IsNullOrWhiteSpace(MK))
                return false;

            return TK == taiKhoanMacDinh && MK == matKhauMacDinh;
        }
    }
}
