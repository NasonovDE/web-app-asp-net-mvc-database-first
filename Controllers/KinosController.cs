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
    public class KinosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new KinoAfishaDFEntities();
            var kinos = MappingLessons(db.Kinos.ToList());

            return View(kinos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var kino = new KinoViewModel();
            return View(kino);
        }

        [HttpPost]
        public ActionResult Create(KinoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
           
            var db = new KinoAfishaDFEntities();
            var kino = new Kinos();
            MappingLesson(model, kino, db);

           

            db.Kinos.Add(kino);
            db.SaveChanges();

            return RedirectPermanent("/Kinos/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new KinoAfishaDFEntities();
            var kino = db.Kinos.FirstOrDefault(x => x.Id == id);
            if (kino == null)
                return RedirectPermanent("/Kinos/Index");

            db.Kinos.Remove(kino);
            db.SaveChanges();

            return RedirectPermanent("/Kinos/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new KinoAfishaDFEntities();
            var kino = MappingLessons(db.Kinos.Where(x=>x.Id == id).ToList()).FirstOrDefault(x => x.Id == id);
            if (kino == null)
                return RedirectPermanent("/Kinos/Index");

            return View(kino);
        }

        [HttpPost]
        public ActionResult Edit(KinoViewModel model)
        {
            var db = new KinoAfishaDFEntities();
            var kino = db.Kinos.FirstOrDefault(x => x.Id == model.Id);
            if (kino == null)
                ModelState.AddModelError("Id", "Кино не найдено");

            if (!ModelState.IsValid)
                return View(model);

            MappingLesson(model, kino, db);

            db.Entry(kino).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Kinos/Index");
        }

        private void MappingLesson(KinoViewModel sourse, Kinos destination, KinoAfishaDFEntities db)
        {
            destination.KinoDate = sourse.KinoDate;
            destination.KinoTime = sourse.KinoTime;
            destination.FilmId = sourse.FilmId;
            destination.Films = sourse.Films;
            //destination.CinemaId = sourse.CinemaIds;
            //destination.Cinemas = sourse.Cinemas;

            if (destination.Cinemas != null)
                destination.Cinemas.Clear();

            if (sourse.CinemaIds != null && sourse.CinemaIds.Any())
                destination.Cinemas = db.Cinemas.Where(s => sourse.CinemaIds.Contains(s.Id)).ToList();



        }

        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var db = new KinoAfishaDFEntities();
            var image = db.FilmImages.FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                FileStream fs = System.IO.File.OpenRead(Server.MapPath(@"~/Content/Images/not-foto.png"));
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                fs.Close();

                return File(new MemoryStream(fileData), "image/jpeg");
            }

            return File(new MemoryStream(image.Data), image.ContentType);
        }

        private List<KinoViewModel> MappingLessons(List<Kinos> kinos)
        {
            var result = kinos.Select(x => new KinoViewModel()
            {
                Id = x.Id,
                KinoDate = x.KinoDate,
                KinoTime = x.KinoTime,
               Cinemas = x.Cinemas,
                Films = x.Films,
                

            }).ToList();

            return result;
        }

       
    }
}