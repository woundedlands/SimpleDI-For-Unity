using UnityEngine;

namespace SimpleDI
{
    public class SimpleDITestComponent : MonoBehaviour, ISimpleDITestComponent
    {
        [HideInInspector][ResolveFromParent(true)] private SimpleDITestComponent parentClass;
        [HideInInspector][ResolveFromChild(true)] private SimpleDITestComponent childClass;
        [HideInInspector][ResolveFromScene] private SimpleDITestComponent sceneClass;
        [HideInInspector][ResolveFromParent(true)] private ISimpleDITestComponent parentInterface;
        [HideInInspector][ResolveFromChild(true)] private ISimpleDITestComponent childInterface;
        [HideInInspector][ResolveFromScene] private ISimpleDITestComponent sceneInterface;
        [HideInInspector][ResolveFromSelf] private Collider self;

        void Start()
        {
            // Resolve method can be called when you need: Start, Awake, etc
            this.ResolveDependencies();

            Debug.Log($"Resolver: {gameObject.name}. Component from parent class: {ComponentToString(parentClass)}");
            Debug.Log($"Resolver: {gameObject.name}. Component from parent interface: {ComponentToString(parentInterface?.GetComponent())}");
            Debug.Log($"Resolver: {gameObject.name}. Component from child class: {ComponentToString(childClass)}");
            Debug.Log($"Resolver: {gameObject.name}. Component from child interface: {ComponentToString(childInterface?.GetComponent())}");
            Debug.Log($"Resolver: {gameObject.name}. Component from scene class: {ComponentToString(sceneClass)}");
            Debug.Log($"Resolver: {gameObject.name}. Component from scene interface: {ComponentToString(sceneInterface?.GetComponent())}");
            Debug.Log($"Resolver: {gameObject.name}. Component from self: {ComponentToString(self)}");
        }

        public Component GetComponent()
        {
            return this;
        }

        private string ComponentToString(Component component)
        {
            if (component == null)
            {
                return "null";
            }
            return $"{component.gameObject.name} [{component.GetType().Name}]";
        }
    }

    public interface ISimpleDITestComponent
    {
        Component GetComponent();
    }
}