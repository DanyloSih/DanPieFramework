using UnityEngine;

namespace DanPie.Framework.AudioManagement.Demo
{
    public class DemoSoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClipData[] _clips;
        [SerializeField] private AudioSourceControllerProvider _sourceProvider;

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _sourceProvider.GetAudioSourceUser().Play(_clips[Random.Range(0, _clips.Length)]);
            }
        }
    }
}
