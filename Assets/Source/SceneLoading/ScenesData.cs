using UnityEngine;

namespace SceneLoading
{
    [CreateAssetMenu(fileName =nameof(ScenesData))]
    public class ScenesData : ScriptableObject
    {
        [field:SerializeField] public Scene Menu { get; private set; }
        [field:SerializeField] public Scene MainLelvel { get; private set; }
    }
}
