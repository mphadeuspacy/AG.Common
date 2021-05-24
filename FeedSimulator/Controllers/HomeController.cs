using AG.Domain.Abstracts;
using System.Web.Mvc;

namespace FeedSimulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeedGenerator _tweetFeedGenerator;

        public HomeController(IFeedGenerator tweetFeedGenerator)
        {
            _tweetFeedGenerator = tweetFeedGenerator;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Feed(string userFilePath, string tweetFilePath)
        {
            string serverAppDataPath = Server.MapPath("~/App_Data/");

            string usersAbsolutePath = System.IO.Path.Combine(serverAppDataPath, userFilePath);

            string tweetsAbsolutePath = System.IO.Path.Combine(serverAppDataPath, tweetFilePath);

            return View(_tweetFeedGenerator.SimulateFeed(usersAbsolutePath, tweetsAbsolutePath));
        }
    }
}