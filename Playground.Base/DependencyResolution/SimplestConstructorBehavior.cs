namespace Playground.Base.DependencyResolution
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class SimplestConstructorBehavior : SimpleInjector.Advanced.IConstructorResolutionBehavior
    {
        public ConstructorInfo GetConstructor(Type serviceType, Type implementationType)
        {
            return (
                from ctor in implementationType.GetConstructors()
                orderby ctor.GetParameters().Length ascending
                select ctor)
                .FirstOrDefault();
        }
    }
}