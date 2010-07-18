namespace NUnit.Specifications.AutoMocking.Example.Rhino
{
    #region Using directives

    using NUnit.Framework;
    using NUnit.Specifications.AutoMocking.Rhino;

    using global::Rhino.Mocks;

    #endregion

    /// <summary>
    ///   Example specification for a class w[Test]public void It_hout a contract that uses property based DI
    /// </summary>
    public abstract class context_for_news_controller_3 : Specification<NewsController3>
    {
        #region Constants and Fields

        protected static INewsService newsService;

        #endregion

        #region Methods

        protected override void EstablishContext()
        {
            newsService = An<INewsService>(); // An<> provides easy way to create a mock instance
            subject.NewsService = newsService;
                
                // subject is created automatically the first time [Test]public void It_is accessed so properties can easily be set
        }

        #endregion
    }

    [TestFixture]
    public class when_the_news_controller_3_is_told_to_display_the_default_view : context_for_news_controller_3
    {
        #region Constants and Fields

        private static string result;

        #endregion

        #region Public Methods

        [Test]
        public void It_should_ask_the_news_service_for_the_latest_headline()
        {
            newsService.AssertWasCalled(x => x.GetLatestHeadline());
        }

        [Test]
        public void It_should_display_the_latest_headline()
        {
            Assert.AreEqual(result, "The latest headline");
        }

        #endregion

        #region Methods

        protected override void EstablishContext()
        {
            base.EstablishContext();
            newsService.Stub(x => x.GetLatestHeadline()).Return("The latest headline");
        }

        protected override void When()
        {
            result = subject.Index();
        }

        #endregion
    }
}