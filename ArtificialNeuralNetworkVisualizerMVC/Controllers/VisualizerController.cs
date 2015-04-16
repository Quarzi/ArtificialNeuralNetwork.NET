using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.Core;
using Syncfusion.MVC.EJ;
using System.Web.Mvc.Html;
using ArtificialNeuralNetworkVisualizerMVC.Models;


namespace ArtificialNeuralNetworkVisualizerMVC.Controllers
{
    public class VisualizerController : Controller
    {
        // GET: VisualizerViewModel
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ToolBox()
        {
            return View(new VisualizerSettings());
        }
        public ActionResult GrafView()
        {
            return View();
        }

        // GET: VisualizerViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisualizerViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisualizerViewModel/Create
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

        // GET: VisualizerViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VisualizerViewModel/Edit/5
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

        // GET: VisualizerViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VisualizerViewModel/Delete/5
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
