using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DemoMVC112.Controllers
{
    public class DemoController : Controller
    {
        // 1️⃣ ViewResult - trả về 1 View (HTML)
        public IActionResult Index()
        {
            return View(); // sẽ gọi View có tên Index.cshtml
        }

        // 2️⃣ RedirectResult - chuyển hướng sang 1 URL khác
        public IActionResult RedirectExample()
        {
            return Redirect("https://www.google.com");
        }

        // 3️⃣ RedirectToActionResult - chuyển hướng sang 1 action khác trong cùng controller hoặc khác controller
        public IActionResult RedirectToActionExample()
        {
            // Chuyển hướng đến action "Index" trong controller "Home"
            return RedirectToAction("Index", "Home");
        }

        // 4️⃣ JsonResult - trả về dữ liệu JSON (thường dùng cho API)
        public IActionResult JsonExample()
        {
            var data = new
            {
                Name = "Marguerite Franklin",
                Project = "DemoMVC112",
                Message = "Hello from JsonResult!"
            };
            return Json(data);
        }

        // 5️⃣ FileResult - trả về 1 tệp tin (ví dụ: text, pdf, image,...)
        public IActionResult FileExample()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "sample.txt");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "text/plain", "sample.txt");
        }

        // 6️⃣ StatusCodeResult - trả về mã trạng thái HTTP (404, 500, 200,...)
        public IActionResult StatusExample()
        {
            return StatusCode(404, "Page not found - custom message from StatusCodeResult!");
        }
    }
}
