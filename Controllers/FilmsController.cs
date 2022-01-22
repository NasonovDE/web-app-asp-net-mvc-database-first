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
    public class FilmsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new KinoAfishaDFEntities();
            var films = MappingTeachers(db.Films.ToList());

            return View(films);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var film = new FilmViewModel();
            return View(film);
        }

        [HttpPost]
        public ActionResult Create(FilmViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new KinoAfishaDFEntities();


            var film = new Films();
            MappingTeacher(model, film,db);
            db.Films.Add(film);
            db.SaveChanges();

            return RedirectPermanent("/Films/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new KinoAfishaDFEntities();
            var film = db.Films.FirstOrDefault(x => x.Id == id);
            if (film == null)
                return RedirectPermanent("/Films/Index");

            db.Films.Remove(film);
            db.SaveChanges();

            return RedirectPermanent("/Films/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new KinoAfishaDFEntities();
            var film = MappingTeachers(db.Films.Where(x => x.Id == id).ToList()).FirstOrDefault(x => x.Id == id);
            if (film == null)
                return RedirectPermanent("/Films/Index");

            return View(film);
        }

        [HttpPost]
        public ActionResult Edit(FilmViewModel model)
        {
            var db = new KinoAfishaDFEntities();
            var film = db.Films.FirstOrDefault(x => x.Id == model.Id);
            if (film == null)
                ModelState.AddModelError("Id", "Фильм не найден");

            if (!ModelState.IsValid)
                return View(model);

            MappingTeacher(model, film, db);

            db.Entry(film).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Films/Index");
        }

        private void MappingTeacher(FilmViewModel sourse, Films destination, KinoAfishaDFEntities db)
        {
            destination.Name = sourse.Name;
            destination.FilmYears = (int)sourse.FilmYears;

            if (sourse.FilmImageFile != null)
            {
                var image = db.FilmImages.FirstOrDefault(x => x.Id == sourse.Id);
                if (image != null)
                    db.FilmImages.Remove(image);

                var data = new byte[sourse.FilmImageFile.ContentLength];
                sourse.FilmImageFile.InputStream.Read(data, 0, sourse.FilmImageFile.ContentLength);

                destination.FilmImages = new FilmImages()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = sourse.FilmImageFile.ContentType,
                    FileName = sourse.FilmImageFile.FileName
                };
            }
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

        private List<FilmViewModel> MappingTeachers(List<Films> films)
        {
            var result = films.Select(x => new FilmViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                FilmYears = (FilmYears)x.FilmYears,
                FilmImage = x.FilmImages
            }).ToList();

            return result;
        }
    }
}