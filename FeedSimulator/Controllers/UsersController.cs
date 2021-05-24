using AG.Data.Abstracts;
using AG.Data.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FeedSimulator.Controllers
{
    public class UsersController : Controller
    {
        private IUserDataRepository _userDataRepository;

        public UsersController(IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        public ActionResult Index()
        {
            return View(_userDataRepository.GetAll());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userDataRepository.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,userName")] User user)
        {
            if (_userDataRepository.GetAll().Any(x => x.userName == user.userName))
            {
                ModelState.AddModelError("", user.userName + " already exists.");
            }

            if (ModelState.IsValid)
            {
                _userDataRepository.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userDataRepository.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,userName")] User user)
        {
            if (_userDataRepository.GetAll().Any(x => x.userName == user.userName))
            {
                ModelState.AddModelError("", user.userName + " already exists.");
            }

            if (ModelState.IsValid)
            {
                _userDataRepository.Edit(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userDataRepository.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _userDataRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
