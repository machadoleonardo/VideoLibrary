using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoLibrary.Context;
using VideoLibrary.Entities;
using Repositories;
using Repositories.Services;

namespace VideoLibrary.Controllers
{
    public class GenresController : Controller
    {
        private GenresService genresService = new GenresService();

        // GET: Genres
        public ActionResult Index()
        {
            var listGenres = genresService.GetAllActives();
           return View(listGenres);
        }

        // GET: Genres/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Genre genre = genresService.GetGenreById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,NameGenre,CreationDateGenre,Active")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                if (genresService.CreateGenre(genre) != null)
                    return Json(new { Success = true });
                else
                    return Json(new { Success = false, Text = "Gênero já cadastrado!" });
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = genresService.GetGenreById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameGenre,CreationDateGenre,Active")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                var genreReturned = genresService.UpdateGenre(genre);
                if (genreReturned != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Json(new { Success = false, Text = "Gênero já cadastrado!" });
                }
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = genresService.GetGenreById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var moviesAssociatedGenre = genresService.LogicalRemovalGenreById(id);
            if (moviesAssociatedGenre == null)
            {
                return RedirectToAction("Index");
            }
             return Json(new { Success = false, Text = "Gênero associado ao(s) filme(s) abaixo:", MoviesAssociatedGenre = moviesAssociatedGenre });
        }

        // POST: Movies/DeleteLogical/5
        [HttpPost]
        public JsonResult LogicalRemovalGenresByIds(Guid[] listIdsForDelete)
        {
            if (listIdsForDelete == null || listIdsForDelete.Count() == 0)
                return Json(new { Success = false, Text = "Selecione ao menos um Gênero para ser removido" });
            List<Movie> moviesAssociatedGenres = genresService.LogicalRemovalGenresByIds(listIdsForDelete);
            if (moviesAssociatedGenres == null || !moviesAssociatedGenres.Any())
            {
                genresService.LogicalRemovalGenresByIds(listIdsForDelete);
                return Json(new { Success = true, Text = "Gêneros(s) removido(s) com sucesso" });
            }
            else
            {
                return Json(new { Success = false, Text = "Gêneros possuem filmes associados.", MoviesAssociatedGenres = moviesAssociatedGenres });
            }
        }
    }
}
