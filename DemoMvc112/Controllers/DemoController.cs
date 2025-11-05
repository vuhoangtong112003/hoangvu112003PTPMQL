using Microsoft.AspNetCore.Mvc;
using DemoMVC112.Models; // nhớ import namespace của Model
using System;

namespace DemoMVC112.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // ==============================
        // 1️⃣ ViewBag - ViewData - TempData
        // ==============================
        public IActionResult ShowData()
        {
            // Gửi dữ liệu sang View
            ViewBag.Message = "Xin chào từ ViewBag!";
            ViewData["Course"] = "Khóa học ASP.NET Core MVC";
            TempData["Notice"] = "Dữ liệu TempData chỉ tồn tại trong 1 request tiếp theo.";

            return View(); // Views/Demo/ShowData.cshtml
        }

        public IActionResult NextPage()
        {
            // Nhận lại dữ liệu từ TempData (nếu còn)
            var notice = TempData["Notice"];
            return Content($"TempData nhận được: {notice}");
        }

        // ==============================
        // 2️⃣ Gửi dữ liệu trực tiếp Controller → View
        // ==============================
        public IActionResult SimpleData()
        {
            string message = "Đây là dữ liệu gửi từ Controller sang View!";
            DateTime now = DateTime.Now;

            // Dùng Tuple để gửi nhiều dữ liệu (có thể dùng ViewModel)
            var data = (message, now);
            return View(data); // Views/Demo/SimpleData.cshtml
        }

        // ==============================
        // 3️⃣ Gửi – nhận dữ liệu giữa Model ↔ View ↔ Controller
        // ==============================

        // Hiển thị form nhập
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View(); // Views/Demo/CreateStudent.cshtml
        }

        // Nhận dữ liệu từ form gửi lên (POST)
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                // Sau khi nhận dữ liệu thành công -> gửi sang view kết quả
                return View("ResultStudent", student);
            }

            // Nếu dữ liệu không hợp lệ, hiển thị lại form
            return View();
        }
    }
}
