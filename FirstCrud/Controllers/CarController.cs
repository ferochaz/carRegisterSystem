using FirstCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCrud.Controllers
{
    public class CarController : Controller
    {

        private readonly Context _context;

        public CarController(Context context)
        {

            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Cars.ToList());
        }

        [HttpGet]
        public IActionResult NewCar() {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostCar(Car car)
        {

            if (ModelState.IsValid) {

                _context.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);

        }

        public IActionResult detailsCar(int? id)
        {

            if (id == null) {

                return NotFound();
            }

            var car = _context.Cars.FirstOrDefault(x => x.CarId == id);

            return View(car);


        }

        [HttpGet]
        public IActionResult updateCar(int? id) {

            if (id == null)
            {

                return NotFound();
            }
            else {

                var car = _context.Cars.Find(id);
                return View(car);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult updateCar(int? id, Car car)
        {
            if (id == null) {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        [HttpGet]
        public IActionResult deleteCar(int? id)
        {

            if (id == null) {

                return NotFound();

            }

            var car = _context.Cars.FirstOrDefault(x => x.CarId == id);

            return View(car);

        }

        [HttpPost, ActionName("deleteCar")]
        [ValidateAntiForgeryToken]
        public IActionResult delete(int? id) {

            if (id == null) {

                return NotFound();
            }

            var car = _context.Cars.FirstOrDefault(x=> x.CarId == id);
            _context.Remove(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}
