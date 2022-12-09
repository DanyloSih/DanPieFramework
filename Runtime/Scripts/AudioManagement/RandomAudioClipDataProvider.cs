using System;
using System.Collections.Generic;
using DanPie.Framework.Randomnicity;
using UnityEngine;

namespace DanPie.Framework.AudioManagement
{
    [CreateAssetMenu(fileName = "RandomClipProvider", menuName = "AudioManagement/new RandomClipProvider")]
    public class RandomAudioClipDataProvider : AudioClipDataProvider
    {
        [Serializable]
        private class SelectableAudioClipData : IRandomSelectableItem
        {
            [field: SerializeField] public int SelectionChance { get; }
            [field: SerializeField] public AudioClipData ClipData { get; }
        }

        [SerializeField] private List<SelectableAudioClipData> _clips;

        private RandomItemSelector<SelectableAudioClipData> _selector;

        public override AudioClipData GetClipData()
        {
            return _selector.GetRandomItem().ClipData;
        }

        protected void Awake()
        {
            _selector = new RandomItemSelector<SelectableAudioClipData>(_clips);
        }
    }
}
