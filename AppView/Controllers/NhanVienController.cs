using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        public NhanVienController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> ShowAllNhanVien()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7240/api/NhanVienAPI/get-all-nhanvien";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<NhanVien>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NhanVien nv)
        {
            if (!ModelState.IsValid)
                return View(nv);

            var httpClient = new HttpClient();

            string apiURL = $"https://localhost:7240/api/NhanVienAPI/create-nhanvien?Ten={nv.Ten}&Tuoi={nv.Tuoi}&Role={nv.Role}&Email={nv.Email}&Salary={nv.Salary}&TrangThai={nv.TrangThai}";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNhanVien");
            }
            ModelState.AddModelError("", "Sai");

            return View(nv);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7240/api/NhanVienAPI/edit-nhavien/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NhanVien>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(NhanVien nv)
        {

            if (!ModelState.IsValid) return View(nv);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7240/api/NhanVienAPI/edit-nhavien?Id={nv.Id}&Ten={nv.Ten}&Tuoi={nv.Tuoi}&Role={nv.Role}&Email={nv.Email}&Salary={nv.Salary}&TrangThai={nv.TrangThai}";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNhanVien");
            }
            ModelState.AddModelError("", "sai roi");

            return View(nv);
        }

        public async Task<IActionResult> Delete(Guid id)
        {


            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7240/api/NhanVienAPI?Id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNhanVien");
            }
            ModelState.AddModelError("", "sai roi");
            return BadRequest();
        }
    }
}
