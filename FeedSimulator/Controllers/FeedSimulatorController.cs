using AG.Data.Abstracts;
using System.Linq;
using System.Web.Mvc;

namespace FeedSimulator.Controllers
{
    public class FeedSimulatorController : Controller
    {
        // GET: Feed
        private IUserDataRepository _userDataRepository;

        public FeedSimulatorController(IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        public ActionResult TweetFeed()
        {
            return View(_userDataRepository.GetAll().OrderBy(x => x.userName));
        }
    }
}