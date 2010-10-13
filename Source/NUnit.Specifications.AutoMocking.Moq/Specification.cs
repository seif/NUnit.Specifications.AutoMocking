namespace NUnit.Specifications.AutoMocking.Moq
{
    #region Using directives

    using System;

    using Machine.Specifications.AutoMocking;
    using Machine.Specifications.AutoMocking.Moq;

    using NUnit.Framework;

    #endregion

    public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
    {
    }

    public abstract class Specification<TContract, TSubject> : NUnitSpecification<TContract, TSubject, MoqMocksMockFactory>
        where TSubject : TContract
    {
    }
}