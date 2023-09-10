using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sirket.Models;
using System.Text;

namespace Sirket.Controllers
{
    public class PersonelController : Controller
    {
        [Authorize(Roles = "Müdür,Yönetici,Personel")]
        public async Task<IActionResult> Personel()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7229/api/Personel/GetPersonelWithRole");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<PersonelModel>>(jsonString);
            return View(values);
        }

        [Authorize(Roles = "Müdür")]
        public IActionResult AddPersonel()
        {
            return View();
        }

        [Authorize(Roles = "Müdür")]
        [HttpPost]
        public async Task<IActionResult> AddPersonel(PersonelModel p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7229/api/Personel/AddPersonel", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Personel");
            }
            return View(p);
        }

        [Authorize(Roles = "Müdür")]
        [HttpGet]
        public async Task<IActionResult> UpdatePersonel(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7229/api/Personel/GetByIdPersonel/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<PersonelModel>(jsonEmployee);
                return View(value);
            }
            return RedirectToAction("Personel");
        }

        [Authorize(Roles = "Müdür")]
        [HttpPost]
        public async Task<IActionResult> UpdatePersonel(PersonelModel p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7229/api/Personel/UpdatePersonel", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Personel");
            }
            return View(p);
        }

        [Authorize(Roles = "Müdür,Yönetici")]
        public async Task<IActionResult> UpdatePersonelRole(int id,string roleAdi)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7229/api/Personel/GetByIdPersonel/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseMessageRole = await httpClient.GetAsync("https://localhost:7229/api/Role/GetByNameRole/" + roleAdi);

                if (responseMessageRole.IsSuccessStatusCode)
                {
                    var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<PersonelModel>(jsonEmployee);
                    var jsonEmployeeRole = await responseMessageRole.Content.ReadAsStringAsync();
                    var valueRole = JsonConvert.DeserializeObject<RoleModel>(jsonEmployeeRole);
                    value.RoleId = valueRole.Id;
                    var jsonEmployeeUpdate = JsonConvert.SerializeObject(value);
                    var content = new StringContent(jsonEmployeeUpdate, Encoding.UTF8, "application/json");
                    var responseMessageUpdate = await httpClient.PutAsync("https://localhost:7229/api/Personel/UpdatePersonel", content);
                }
                
            }

            return RedirectToAction("Personel");
        }

        [Authorize(Roles = "Müdür")]
        public async Task<IActionResult> DeletePersonel(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7229/api/Personel/DeletePersonel/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Personel");
            }
            return View();
        }

    }
}
