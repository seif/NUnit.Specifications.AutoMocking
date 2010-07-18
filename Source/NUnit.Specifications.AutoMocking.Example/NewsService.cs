namespace NUnit.Specifications.AutoMocking.Example
{
    #region Using directives

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class NewsService : INewsService
    {
        #region Constants and Fields

        private readonly List<string> headlines;

        #endregion

        #region Constructors and Destructors

        public NewsService(List<string> headlines)
        {
            this.headlines = headlines;
        }

        #endregion

        #region Implemented Interfaces

        #region INewsService

        public List<string> GetAllHeadlines()
        {
            return this.headlines;
        }

        public string GetLatestHeadline()
        {
            return this.headlines.Last();
        }

        #endregion

        #endregion
    }
}