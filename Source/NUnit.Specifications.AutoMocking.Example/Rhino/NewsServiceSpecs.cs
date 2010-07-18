namespace NUnit.Specifications.AutoMocking.Example.Rhino
{
    #region Using directives

    using System.Collections.Generic;

    using NUnit.Framework;
    using NUnit.Specifications.AutoMocking.Rhino;

    using SharpTestsEx;

    #endregion

    /// <summary>
    ///   Example specification for a class w[Test]public void It_h a contract that uses constructor based DI
    /// </summary>
    public abstract class context_for_news_service : Specification<INewsService, NewsService>
    {
        #region Methods

        protected override void EstablishContext()
        {
            var newsHeadlines = new List<string> { "Yesterday's headline", "Today's headline" };

            ProvideBasicConstructorArgument(newsHeadlines); // manually add a required simple constructor argument
        }

        #endregion
    }

    [TestFixture]
    public class when_the_news_service_is_asked_for_the_latest_headline : context_for_news_service
    {
        #region Constants and Fields

        private static string result;

        #endregion

        // subject is created automatically and returned as an INewsService so we are coding against the interface
        #region Public Methods

        [Test]
        public void It_should_return_the_latest_headline()
        {
            result.Should().Be("Today's headline");
        }

        #endregion

        #region Methods

        protected override void When()
        {
            result = subject.GetLatestHeadline();
        }

        #endregion
    }

    [TestFixture]
    public class when_the_news_service_is_asked_for_all_the_headlines : context_for_news_service
    {
        #region Constants and Fields

        private static List<string> result;

        #endregion

        #region Public Methods

        [Test]
        public void It_should_return_the_list_of_all_headlines()
        {
            result.Count.Should().Be(2);
        }

        #endregion

        #region Methods

        protected override void When()
        {
            result = subject.GetAllHeadlines();
        }

        #endregion
    }
}