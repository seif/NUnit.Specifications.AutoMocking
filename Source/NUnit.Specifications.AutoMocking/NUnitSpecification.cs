using Machine.Specifications.AutoMocking.Core;
using System;
using Machine.Specifications.AutoMocking;
using NUnit.Framework;

namespace NUnit.Specifications.AutoMocking
{
    #region Using directives

    

    #endregion

    public abstract class NUnitSpecification<TContract, TSubject, TFactory> : Specification<TContract, TSubject, TFactory>
        where TSubject : TContract 
        where TFactory : IMockFactory,new()
    {
        #region Properties

        protected Exception ExceptionThrown { get; private set; }

        #endregion

        #region Public Methods

        [SetUp]
        public void Setup()
        {
            EstablishContext();

            try
            {
                When();
            }
            catch (Exception exc)
            {
                ExceptionThrown = exc;
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
        }

        #endregion

        #region Methods

        protected abstract void EstablishContext();

        protected abstract void When();

        #endregion
    }
}