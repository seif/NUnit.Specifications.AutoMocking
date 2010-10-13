namespace NUnit.Specifications.AutoMocking.Rhino
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

    public abstract class Specification<TContract, TSubject> : NUnitSpecification<TContract, TSubject, RhinoMocksMockFactory>
        where TSubject : TContract
    {
    }
}