using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Track.Core.Models;
using Track.Core.Repository;
using PagedList;
using Track.Core.Helpers;

namespace Track.Web.Controllers
{
    public class LogsController : BaseController
    {

       
            MongoDbRepository<Event> objEventRepository = new MongoDbRepository<Event>();
        
        //
        // GET: /Logs/

            public ActionResult Index(int? page)
        {
           //var events = objEventRepository.GetAll();
           //return View(events);

            var events = objEventRepository.GetAllPaging(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var OnePageOfEvents = events.ToPagedList(pageNumber, UserDefinedPageSize.DefaultPageSize); // will only contain 10 products max because of the pageSize
            ViewBag.OnePageOfEvents = OnePageOfEvents;
            return View();
        }

        //
        // GET: /Logs/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Logs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Logs/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Logs/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Logs/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Logs/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Logs/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
