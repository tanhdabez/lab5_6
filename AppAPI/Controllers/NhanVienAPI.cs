using AppData.DbContexxt;
using AppData.IRepository;
using AppData.Models;
using AppData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienAPI : ControllerBase
    {
        INhanVienRepositories<NhanVien> _repository;
        Lab_DbContext Context = new Lab_DbContext();
        public NhanVienAPI()
        {
            NhanVienRepositories<NhanVien> repos = new NhanVienRepositories<NhanVien>(Context, Context.NhanViens);
            _repository = repos;

        }

        // GET: api/<Nhanvien>
        [HttpGet("get-all-nhanvien")]
        public IEnumerable<NhanVien> GetAll()
        {
            return _repository.GetAllItem();
        }

        [HttpPost("create-nhanvien")]
        public bool Create(string ten, int tuoi, int role, string email, int salary, bool trangthai)
        {
            NhanVien NV = new NhanVien();
            NV.Id = Guid.NewGuid(); // ID tự sinh
            NV.Ten = ten;
            NV.Tuoi = tuoi;
            NV.Role = role;
            NV.Email = email;
            NV.Salary = salary;
            NV.TrangThai = trangthai;
            return _repository.CreateItem(NV);

        }

        // PUT api/<Nhanvien>/5
        [HttpPut("edit-nhavien")]
        public bool Edit(Guid id, string ten, int tuoi, int role, string email, int salary, bool trangthai)
        {
            NhanVien NV = _repository.GetAllItem().First(p => p.Id == id);
            // MauSac color = new MauSac();
            NV.Id = id;
            NV.Ten = ten;
            NV.Tuoi = tuoi;
            NV.Role = role;
            NV.Email = email;
            NV.Salary = salary;
            NV.TrangThai = trangthai;
            return _repository.UpdateItem(NV);
        }

        // DELETE api/<Nhanvien>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            NhanVien NV = _repository.GetAllItem().First(p => p.Id == id);
            return _repository.DeleteItem(NV);
        }
        [HttpGet("tinh-BMI")]
        public float BMINhanVien(float weight, float height)
        {
            float bmi = 0;
            return weight / (height * height);
        }
    }
}
