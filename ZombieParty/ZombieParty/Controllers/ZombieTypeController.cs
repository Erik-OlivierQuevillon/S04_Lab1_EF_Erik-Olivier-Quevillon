using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        private ZombiePartyDbContext _baseDonnees { get; set; }

        public ZombieTypeController(ZombiePartyDbContext baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            List<ZombieType> zombieTypesList = _baseDonnees.ZombieTypes.ToList();

            return View(zombieTypesList);
        }

        public IActionResult Details(int id)
        {
            var zombies = _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id).ToList();

            ZombieTypeVM zombieTypeVM = new()
            {
                ZombieType = _baseDonnees.ZombieTypes.FirstOrDefault( x => x.Id == id),
                ZombiesList = zombies,
                ZombiesCount = zombies.Count(),
                PointsAverage = zombies.Count > 0 ? zombies.Average(p => p.Point): 0
            };

            zombieTypeVM.ZombieType = _baseDonnees.ZombieTypes.FirstOrDefault(zt => zt.Id == id);
            return View(zombieTypeVM);
        }


        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                _baseDonnees.ZombieTypes.Add(zombieType);
                _baseDonnees.SaveChanges();
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return this.RedirectToAction("Index");
            }

            return this.View(zombieType);
        }

    }
}
