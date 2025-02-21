using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleDI
{
    public class SimpleDIApi : MonoBehaviour
    {
        [Header("This component is required for SimpleDI Dependency Injection")]
        [SerializeField] private SimpleDIOptionsDataScriptable _options;
        public static SimpleDIApi instance;
        private SimpleDIOptionsData options;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(instance);
            }
            instance = this;

            if (_options != null)
            {
                options = _options.options;
            }
            else
            {
                options = SimpleDIOptionsData.GetDefault();
            }
        }

        public void ResolveFromParent(MonoBehaviour target, System.Reflection.FieldInfo field, bool isOptional = false)
        {
            Component component = null;
            var parent = target.transform.parent;

            if (parent != null)
            {
                component = parent.GetComponentInParent(field.FieldType);
            }

            if (component != null)
            {
                field.SetValue(target, component);
            }
            else
            {
                if (options.enableDebugging && !isOptional)
                {
                    Debug.LogWarning($"Could not resolve {field.FieldType.Name} from parent for {target.name}");
                }
            }
        }

        public void ResolveFromSelf(MonoBehaviour target, System.Reflection.FieldInfo field, bool isOptional = false)
        {
            Component component = target.GetComponent(field.FieldType);

            if (component != null)
            {
                field.SetValue(target, component);
            }
            else
            {
                if (options.enableDebugging && !isOptional)
                {
                    Debug.LogWarning($"Could not resolve {field.FieldType.Name} from self for {target.name}");
                }
            }
        }

        public void ResolveFromChild(MonoBehaviour target, System.Reflection.FieldInfo field, bool isOptional = false)
        {
            Component component = null;

            foreach (Transform transformChild in target.transform)
            {
                component = transformChild.GetComponentInChildren(field.FieldType);
                if (component != null)
                {
                    break;
                }
            }

            if (component != null)
            {
                field.SetValue(target, component);
            }
            else
            {
                if (options.enableDebugging && !isOptional)
                {
                    Debug.LogWarning($"Could not resolve {field.FieldType.Name} from child for {target.name}");
                }
            }
        }

        public void ResolveFromScene(MonoBehaviour target, System.Reflection.FieldInfo field, bool isOptional = false)
        {
            Component component = null;
            var sceneRoots = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var item in sceneRoots)
            {
                component = item.GetComponentInChildren(field.FieldType);
                if (component != null)
                {
                    break;
                }
            }

            if (component != null)
            {
                field.SetValue(target, component);
            }
            else
            {
                if (options.enableDebugging && !isOptional)
                {
                    Debug.LogWarning($"Could not resolve {field.FieldType.Name} from scene for {target.name}");
                }
            }
        }
    }
}