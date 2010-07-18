namespace NUnit.Specifications.AutoMocking.Example
{
    #region Using directives

    using System.Collections.Generic;

    #endregion

    public interface INewsService
    {
        #region Public Methods

        List<string> GetAllHeadlines();

        string GetLatestHeadline();

        #endregion
    }
}