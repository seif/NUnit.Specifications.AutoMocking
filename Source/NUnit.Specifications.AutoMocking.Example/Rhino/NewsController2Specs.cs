namespace NUnit.Specifications.AutoMocking.Example.Rhino
{
    #region Using directives

    using NUnit.Framework;
    using NUnit.Specifications.AutoMocking.Rhino;

    using global::Rhino.Mocks;

    using SharpTestsEx;

    #endregion

    /// <summary>
    ///   Example specification for a class w[Test]public void It_hout a contract that manually creates subject
    /// </summary>
    public abstract class context_for_news_controller_2 : Specification<NewsController2>
    {
        #region Constants and Fields

        private static INewsService newsService;

        #endregion

        #region Properties

        public static INewsService NewsService
        {
            get
            {
                return newsService ?? (newsService = An<INewsService>());
            }
        }

        #endregion

        #region Methods

        protected override NewsController2 CreateSubject()
        {
            return new NewsController2(NewsService); // the CreateSubject can be override if necessary
        }

        #endregion
    }

    [TestFixture]
    public class when_the_news_controller_2_is_told_to_display_the_default_view : context_for_news_controller_2
    {
        #region Constants and Fields

        private static string result;

        #endregion

        // the subject has been created for us automatically, w[Test]public void It_h all registered dependencies
        #region Public Methods

        [Test]
        public void It_should_ask_the_news_service_for_the_latest_headline()
        {
            NewsService.AssertWasCalled(x => x.GetLatestHeadline());
        }

        [Test]
        public void It_should_display_the_latest_headline()
        {
            result.Should().Be("The latest headline");
        }

        #endregion

        #region Methods

        protected override void EstablishContext()
        {
            NewsService.Stub(x => x.GetLatestHeadline()).Return("The latest headline");
        }

        protected override void When()
        {
            result = subject.Index();
        }

        #endregion
    }
}