﻿namespace NUnit.Specifications.AutoMocking.Rhino
{
    #region Using directives

    using System;

    using Machine.Specifications.AutoMocking;
    using Machine.Specifications.AutoMocking.Rhino;

    using NUnit.Framework;

    #endregion

    public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
    {
    }

    public abstract class Specification<TContract, TSubject> : Specification<TContract, TSubject, RhinoMocksMockFactory>
        where TSubject : TContract
    {
        #region Properties

        protected Exception ExceptionThrown { get; private set; }

        #endregion

        #region Public Methods

        [SetUp]
        public void Setup()
        {
            this.EstablishContext();

            try
            {
                this.When();
            }
            catch (Exception exc)
            {
                this.ExceptionThrown = exc;
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