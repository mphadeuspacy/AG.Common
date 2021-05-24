using System.Collections.Generic;

namespace AG.Domain.Abstracts
{
    public interface IFeedGenerator
  {
    /// <summary>
    /// This generates the tweet feed output based on the user & tweet inputs.
    /// </summary>
    List<string> SimulateFeed(string UserFilePath, string TweetFilePath);
  }
}
