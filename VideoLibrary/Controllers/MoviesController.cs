using Repositories.Services;
using Services;
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

namespace Repositories.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesService moviesService = new MoviesService();
        private GenresService genresService = new GenresService();

        // GET: Movies
        public ActionResult Index()
        {
            return View(moviesService.GetAllAtivos());
        }

        // GET: Movies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = moviesService.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var listGenres = genresService.GetAllActives();
            ViewBag.GenreId = new SelectList(listGenres, "Id", "NameGenre");

            return View();
        }
       
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var movieCreated = moviesService.CreateMovie(movie);
                return Json(new { Success = movieCreated, Text = "Filme já cadastrado!" });
            }
            ViewBag.GenreId = new SelectList(genresService.GetAllActives(), "Id", "NameGenre", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = moviesService.GetMovieById(id);
            if (movie == null)
                return HttpNotFound();
            ViewBag.GeneroId = new SelectList(genresService.GetAllActives(), "Id", "NameGenre", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameMovie,CreationDateMovie,Active,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (moviesService.UpdateMovie(movie) != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Json(new { Success = false, Text = "Filme já cadastrado!" });
                }
            }
            ViewBag.GenreId = ViewBag.GeneroId = new SelectList(genresService.GetAllActives(), "Id", "NameGenre", movie.GenreId); ;
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = moviesService.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            moviesService.LogicalRemovalMovieById(id);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public JsonResult LogicalRemovalMoviesByIds(Guid[] listIdsForDelete)
        {
            if (listIdsForDelete == null || listIdsForDelete.Count() == 0)
                return Json(new { Success = false, Text = "Selecione ao menos um filme para ser removido" });
            moviesService.LogicalRemovalMoviesByIds(listIdsForDelete);
            return Json(new { Success = true, Text = "Gêneros(s) removido(s) com sucesso" });
        }
    }
}
