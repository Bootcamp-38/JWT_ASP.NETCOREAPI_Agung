using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JWT_ASPNetCore_Agung.Models;
using JWT_ASPNetCore_Agung.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JWT_WebClien_Agung.Controllers
{
    public class LoginController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44319")
        };
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Get(User user)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44319");
        //        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
        //        client.DefaultRequestHeaders.Accept.Add(contentType);
        //        string data = JsonConvert.SerializeObject(user);
        //        var contentData = new StringContent(data, Encoding.UTF8, "application/json");
        //        var response = client.PostAsync("/api/accounts/Login", contentData).Result;
        //        //ViewBag.Message = response.Content.ReadAsStringAsync().Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return Json(response.Content.ReadAsStringAsync().Result.ToString());
        //        }
        //        else
        //        {
        //            return Content("GAGAL");
        //        }

        //    }

        //}


        [HttpPost]
        public ActionResult Get(UserRoleVM userRoleVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44319/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(userRoleVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/Accounts/Login", contentData).Result;
                //ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(response.Content.ReadAsStringAsync().Result.ToString());
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content("GAGAL");
                }

            }

        }



        //try
        //{


        //    HttpContent content = new StringContent("email" + user.Email + "password" + user.Password);
        //    HttpResponseMessage response = await client.PostAsync("api/Accounts/", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("About", "Home");
        //    }
        //    return Content(" Internal Server Error" + response.StatusCode);
        //}
        //catch
        //{
        //    return Content("Error");
        //}
    }
    
}
