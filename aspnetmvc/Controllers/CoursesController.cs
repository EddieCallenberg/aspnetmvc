using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace aspnetmvc.Controllers
{
    public class CoursesController : Controller
    {
        [Route("/courses")]
        public async Task<IActionResult> Courses()
        {
            using var http = new HttpClient();
            var response = await http.GetAsync("https://localhost:7233/api/courses");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);

            return View(data);
        }

        [Route("/courses/details/{id:int}")]
        public async Task<IActionResult> CourseDetails(int id)
        {
            using var http = new HttpClient();
            var response = await http.GetAsync($"https://localhost:7233/api/courses/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CourseEntity>(json);

            return View(data);
        }
    }
}
