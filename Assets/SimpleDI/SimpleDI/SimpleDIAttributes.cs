using UnityEngine;

namespace SimpleDI
{
    public interface IDependencyResolver
    {
        void Resolve(MonoBehaviour component, System.Reflection.FieldInfo field);
    }

    public class ResolveFromParentAttribute : PropertyAttribute, IDependencyResolver
    {
        private bool isOptional;
        public ResolveFromParentAttribute(bool isOptional = false)
        {
            this.isOptional = isOptional;
        }

        public void Resolve(MonoBehaviour component, System.Reflection.FieldInfo field)
        {
            SimpleDIApi.instance.ResolveFromParent(component, field, isOptional);
        }
    }

    public class ResolveFromSelfAttribute : PropertyAttribute, IDependencyResolver
    {
        private bool isOptional;
        public ResolveFromSelfAttribute(bool isOptional = false)
        {
            this.isOptional = isOptional;
        }
        public void Resolve(MonoBehaviour component, System.Reflection.FieldInfo field)
        {
            SimpleDIApi.instance.ResolveFromSelf(component, field, isOptional);
        }
    }

    public class ResolveFromChildAttribute : PropertyAttribute, IDependencyResolver
    {
        private bool isOptional;
        public ResolveFromChildAttribute(bool isOptional = false)
        {
            this.isOptional = isOptional;
        }
        public void Resolve(MonoBehaviour component, System.Reflection.FieldInfo field)
        {
            SimpleDIApi.instance.ResolveFromChild(component, field, isOptional);
        }
    }

    public class ResolveFromSceneAttribute : PropertyAttribute, IDependencyResolver
    {
        private bool isOptional;
        public ResolveFromSceneAttribute(bool isOptional = false)
        {
            this.isOptional = isOptional;
        }

        public void Resolve(MonoBehaviour component, System.Reflection.FieldInfo field)
        {
            SimpleDIApi.instance.ResolveFromScene(component, field, isOptional);
        }
    }
}