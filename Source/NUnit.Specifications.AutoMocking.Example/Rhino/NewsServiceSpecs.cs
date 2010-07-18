namespace NUnit.Specifications.AutoMocking.Example.Rhino
{
    using System.Collections.Generic;

    using NUnit.Framework;
    using NUnit.Specifications.AutoMocking.Rhino;

    using SharpTestsEx;

    /// <summary>
    ///   Example specification for a class with a contract that uses constructor based DI
    /// </summary>
    public abstract class context_for_news_service : Specification<INewsService, NewsService>
    {
        protected override void EstablishContext()
        {
            var newsHeadlines = new List<string> { "Yesterday's headline", "Today's headline" };

            ProvideBasicConstructorArgument(newsHeadlines); // manually add a required simple constructor argument
        }
    }

    [TestFixture]
    public class when_the_news_service_is_asked_for_the_latest_headline : context_for_news_service
    {
        private static string result;

        // subject is created automatically and returned as an INewsService so we are coding against the interface

        [Test]
        public void It_should_return_the_latest_headline()
        {
            result.Should().Be("Today's headline");
        }

        protected override void When()
        {
            result = subject.GetLatestHeadline();
        }
    }

    [TestFixture]
    public class when_the_news_service_is_asked_for_all_the_headlines : context_for_news_service
    {
        private static List<string> result;

        [Test]
        public void It_should_return_the_list_of_all_headlines()
        {
            result.Count.Should().Be(2);
        }

        protected override void When()
        {
            result = subject.GetAllHeadlines();
        }
    }
}