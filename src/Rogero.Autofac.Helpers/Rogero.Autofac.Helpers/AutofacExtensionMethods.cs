using System;
using Autofac;
using Autofac.Builder;

namespace Rogero.Autofac.Helpers
{
    public static class AutofacExtensionMethods
    {
        public static IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterSelf<T>(this ContainerBuilder builder)
        {
            return builder.RegisterType<T>().AsSelf();
        }

        public static IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterDefaultInterface<T>(this ContainerBuilder builder)
        {
            var concreteTypeName = typeof(T).Name;
            var expectedInterfaceName = $"I{concreteTypeName}";
            var typeOfInterface = typeof(T).GetInterface(expectedInterfaceName, ignoreCase: false);
            if (typeOfInterface == null)
                throw new InvalidOperationException($"Could not find the expected interface, {expectedInterfaceName}, attached to the concrete type provided, {concreteTypeName}");

            var closedRegistrationBuilder = builder.RegisterType<T>();
            return closedRegistrationBuilder.As(typeOfInterface);
        }

        public static IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterSingleton<T>(this ContainerBuilder builder)
        {
            return builder.RegisterType<T>().AsSelf().SingleInstance();
        }

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterSingleton<T>(this ContainerBuilder builder, T instance) where T : class
        {
            return builder.RegisterInstance(instance).SingleInstance();
        }
    }
}
