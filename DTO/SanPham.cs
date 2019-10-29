using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int DungTich { get; set; }
        public int NongDo { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public string MaDanhMuc { get; set; }
        public string MaNCC { get; set; }
    }
}
