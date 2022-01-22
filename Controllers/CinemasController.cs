using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using web_app_asp_net_mvc_database_first.Models;
using web_app_asp_net_mvc_database_first.Models.Entities;

namespace web_app_asp_net_mvc_database_first.Controllers
{
    public class CinemasController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new KinoAfishaDFEntities();
            var cinemas = MappingGroups(db.Cinemas.ToList());

            return View(cinemas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var cinema = new CinemaViewModel();

            return View(cinema);
        }

        [HttpPost]
        public ActionResult Create(CinemaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var db = new KinoAfishaDFEntities();
            var cinema = new Cinemas();
            MappingGroup(model, cinema);
           

            db.Cinemas.Add(cinema);
            db.SaveChanges();


            return RedirectPermanent("/Cinemas/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new KinoAfishaDFEntities();
            var cinema = db.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinema == null)
                return RedirectPermanent("/Cinemas/Index");

            db.Cinemas.Remove(cinema);
            db.SaveChanges();

            return RedirectPermanent("/Cinemas/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new KinoAfishaDFEntities();
            var cinema = MappingGroups(db.Cinemas.Where(x=>x.Id==id).ToList()).FirstOrDefault(x => x.Id == id);
            if (cinema == null)
                return RedirectPermanent("/Cinemas/Index");

            return View(cinema);
        }

        [HttpPost]
        public ActionResult Edit(CinemaViewModel model)
        {

            var db = new KinoAfishaDFEntities();
            var cinema = db.Cinemas.FirstOrDefault(x => x.Id == model.Id);
            if (cinema == null)
            {
                ModelState.AddModelError("Id", "Кинотеатр не найдена");
            }
            if (!ModelState.IsValid)
                return View(model);

            MappingGroup(model, cinema);


            db.Entry(cinema).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectPermanent("/Cinemas/Index");
        }

        private void MappingGroup(CinemaViewModel sourse, Cinemas destination)
        {
           
            destination.CinemaName = sourse.CinemaName;
            destination.NumberOfPlaces = sourse.NumberOfPlaces;
            
        }


        private List<CinemaViewModel> MappingGroups(List<Cinemas> cinemas)
        {
            var result = cinemas.Select(x => new CinemaViewModel()
            {
                Id = x.Id,
                CinemaName = x.CinemaName,
                NumberOfPlaces = x.NumberOfPlaces
            }).ToList();

            return result;
        }
    }
}