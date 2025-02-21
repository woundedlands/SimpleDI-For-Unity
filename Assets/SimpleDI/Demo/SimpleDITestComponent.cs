using UnityEngine;

namespace SimpleDI
{
    public class SimpleDITestComponent : MonoBehaviour
    {
        [HideInInspector][ResolveFromParent(true)] public SimpleDITestComponent parent;
        [HideInInspector][ResolveFromChild(true)] public SimpleDITestComponent child;
        [HideInInspector][ResolveFromScene] public SimpleDITestComponent scene;
        [HideInInspector][ResolveFromSelf] public Collider self;

        void Start()
        {
            // Resolve method can be called when you need: Start, Awake, etc
            this.ResolveDependencies();

            Debug.Log($"Runner: {gameObject.name}. Component from parent: {ComponentToString(parent)}");
            Debug.Log($"Runner: {gameObject.name}. Component from child: {ComponentToString(child)}");
            Debug.Log($"Runner: {gameObject.name}. Component from scene: {ComponentToString(scene)}");
            Debug.Log($"Runner: {gameObject.name}. Component from self: {ComponentToString(self)}");
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
}