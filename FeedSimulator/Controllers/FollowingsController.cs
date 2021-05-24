using AG.Data.Abstracts;
using AG.Data.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FeedSimulator.Controllers
{
    public class FollowingsController : Controller
    {
        private IFollowingRepository _followingRepository;
        private IUserDataRepository _userDataRepository;

        public FollowingsController(IFollowingRepository followingRepository, IUserDataRepository userDataRepository)
        {
            _followingRepository = followingRepository;
            _userDataRepository = userDataRepository;
        }

        public ActionResult Index()
        {
            return View(_followingRepository.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Following following = _followingRepository.FindById(id);
            if (following == null)
            {
                return HttpNotFound();
            }
            return View(following);
        }
        
        public ActionResult Create()
        {
            ViewBag.followeeuserId = new SelectList(_userDataRepository.GetAll(), "userId", "userName");
            ViewBag.followerUserId = new SelectList(_userDataRepository.GetAll(), "userId", "userName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "follwingId,followerUserId,followeeuserId")] Following following)
        {

            if (_followingRepository.GetAll().Any(x => x.followerUserId == following.followerUserId && x.followeeuserId == following.followeeuserId))
            {
                string followerUsername = _userDataRepository.FindById(following.followerUserId).userName;
                string followeeUsername = _userDataRepository.FindById(following.followeeuserId).userName;
                ModelState.AddModelError("", followerUsername + " already follows " + followeeUsername);
            }

            if (following.followerUserId == following.followeeuserId)
            {
                ModelState.AddModelError("", "A user cannot follow him/herself");
            }

            if (ModelState.IsValid)
            {  
                _followingRepository.Add(following);
                return RedirectToAction("Index");
            }

            ViewBag.followeeuserId = new SelectList(_userDataRepository.GetAll(), "userId", "userName");
            ViewBag.followerUserId = new SelectList(_userDataRepository.GetAll(), "userId", "userName");
            return View(following);
        }

        // GET: Followings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Following following = _followingRepository.FindById(id);
            if (following == null)
            {
                return HttpNotFound();
            }
            ViewBag.followeeuserId = new SelectList(_userDataRepository.GetAll(), "userId", "userName", following.followeeuserId);
            ViewBag.followerUserId = new SelectList(_userDataRepository.GetAll(), "userId", "userName", following.followerUserId);
            return View(following);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "follwingId,followerUserId,followeeuserId")] Following following)
        {
            if (_followingRepository.GetAll().Any(x => x.followerUserId == following.followerUserId && x.followeeuserId == following.followeeuserId))
            {
                string followerUsername = _userDataRepository.FindById(following.followerUserId).userName;
                string followeeUsername = _userDataRepository.FindById(following.followeeuserId).userName;
                ModelState.AddModelError("", followerUsername + " already follows " + followeeUsername);
            }

            if (following.followerUserId == following.followeeuserId)
            {
                ModelState.AddModelError("", "A user cannot follow him/herself");
            }

            if (ModelState.IsValid)
            {
                _followingRepository.Edit(following);
                return RedirectToAction("Index");
            }
            ViewBag.followeeuserId = new SelectList(_userDataRepository.GetAll(), "userId", "userName", following.followeeuserId);
            ViewBag.followerUserId = new SelectList(_userDataRepository.GetAll(), "userId", "userName", following.followerUserId);
            return View(following);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Following following = _followingRepository.FindById(id);
            if (following == null)
            {
                return HttpNotFound();
            }
            return View(following);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Following following = _followingRepository.FindById(id);
            _followingRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
