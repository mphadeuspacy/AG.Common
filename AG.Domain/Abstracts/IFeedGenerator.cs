namespace AG.Domain.Abstracts
{
  public interface IFeedGenerator
  {
    /// <summary>
    /// This generates the tweet feed output based on the user & tweet inputs.
    /// </summary>
    void SimulateFeed();
  }
}
