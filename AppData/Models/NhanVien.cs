using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class NhanVien
    {
        public Guid Id { get; set; }
        [StringLength(30,ErrorMessage ="Tối đa 30 kí tự nha con vợ")]
        public string Ten { get; set; }
        [Range(18,50,ErrorMessage ="tuổi phải nhập từ 18 đến 50")]
        public int Tuoi { get; set; }
        [Required(ErrorMessage ="role ko để trống nha")]
        public int Role { get; set; }
        [EmailAddress(ErrorMessage ="đuôi gmail đâu")]
        public string Email { get; set; }
        [Range(5000000,30000000, ErrorMessage ="lương từ 5 củ đến 30 củ ko hơn ko kém nhá")]
        public int Salary { get; set; }
        [Required(ErrorMessage ="trạng thái ko để trống")]
        public bool TrangThai { get; set; }
    }
}
