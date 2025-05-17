using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Technical_TestVDI.Models;

namespace Technical_TestVDI.Controllers
{
    public class AnagramController : Controller
    {
        [HttpGet]
        [HttpGet]
        public IActionResult Index() => View(new AnagramInput());
        [HttpPost]
        public IActionResult Index(AnagramInput input)
        {
            var result = new StringBuilder();
            var firstWords = input.FirstWords;
            var secondWords = input.SecondWords;
            if (firstWords.Count != secondWords.Count)
            {
                ModelState.AddModelError("", "Jumlah kata pada kedua kolom harus sama.");
                return View(input);
            }

            for (int i = 0; i < input.FirstWords.Count; i++)
            {
                result.Append(IsAnagram(input.FirstWords[i], input.SecondWords[i]) ? 1 : 0);
            }
            ViewBag.Result = result.ToString();
            return View(input);

        }
        private bool IsAnagram(string a, string b)
        {
            return string.Concat(a.OrderBy(c => c)) == string.Concat(b.OrderBy(c => c));
        }
    }
}
