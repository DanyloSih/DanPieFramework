using UnityEditor;
using UnityEngine;

namespace DanPie.Framework.PlayerPrefs
{
    public static class PlayerPrefsSavesRemover
    {
        [MenuItem(itemName: "Tools/DanPie/PlayerPrefs/Remove Saves")]
        public static void RemoveSaves()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
        }
    }
}
