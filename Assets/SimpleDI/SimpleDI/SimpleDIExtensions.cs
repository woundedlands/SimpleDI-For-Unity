using UnityEngine;
using System.Reflection;

namespace SimpleDI
{
    public static class SimpleDIExtensions
    {
        public static void ResolveDependencies(this MonoBehaviour target)
        {
            if (target == null) return;

            var fields = target.GetType().GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            foreach (var field in fields)
            {
                var attributes = field.GetCustomAttributes();

                foreach (var attribute in attributes)
                {
                    if (attribute is IDependencyResolver resolverAttribute)
                    {
                        resolverAttribute.Resolve(target, field);
                    }
                }
            }
        }
    }
}