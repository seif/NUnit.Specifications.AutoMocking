namespace NUnit.Specifications.AutoMocking.Example
{
    public class NewsController3
    {
        #region Properties

        public INewsService NewsService { get; set; }

        #endregion

        #region Public Methods

        public string Index()
        {
            return this.NewsService.GetLatestHeadline();
        }

        #endregion
    }
}