using System.Web.Mvc;
using ArtificialNeuralNetworkVisualizerMVC.Models;

namespace ArtificialNeuralNetworkVisualizerMVC.Controllers
{
    public class VisualizerController : Controller
    {
        // GET: Visualizer
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
    }
}