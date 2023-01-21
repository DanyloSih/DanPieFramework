#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DanPie.Framework.PlayerPrefs
{
    public static class PlayerPrefsSavesRemover
    {
#if UNITY_EDITOR
        [MenuItem(itemName: "Tools/DanPie/PlayerPrefs/Remove Saves")]
        public static void RemoveSaves()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
        }
#endif
    }
}
