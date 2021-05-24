using AG.Data.Abstracts;
using AG.Data.Models;
using System.Net;
using System.Web.Mvc;

namespace FeedSimulator.Controllers
{
    public class TweetsController : Controller
    {
        private ITweetDataRepository _tweetDataRepository;
        public IUserDataRepository _userDataRepository;

        public TweetsController(ITweetDataRepository tweetDataRepository, IUserDataRepository userDataRepository)
        {
            _tweetDataRepository = tweetDataRepository;
            _userDataRepository = userDataRepository;
        }

        public ActionResult Index()
        {
            return View(_tweetDataRepository.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = _tweetDataRepository.FindById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(_userDataRepository.GetAll(), "userId", "userName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tweetId,message,userId")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                _tweetDataRepository.Add(tweet);
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(_userDataRepository.GetAll(), "userId", "userName");
            return View(tweet);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = _tweetDataRepository.FindById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(_tweetDataRepository.GetAll(), "userId", "userName", tweet.userId);
            return View(tweet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tweetId,message,userId")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                _tweetDataRepository.Edit(tweet);
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(_tweetDataRepository.GetAll(), "userId", "userName", tweet.userId);
            return View(tweet);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = _tweetDataRepository.FindById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _tweetDataRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
