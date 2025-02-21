using UnityEngine;

namespace SimpleDI
{
    [CreateAssetMenu(fileName = "SimpleDIOptions", menuName = "SimpleDIOptions")]
    public class SimpleDIOptionsDataScriptable : ScriptableObject
    {
        public SimpleDIOptionsData options;
    }
}
