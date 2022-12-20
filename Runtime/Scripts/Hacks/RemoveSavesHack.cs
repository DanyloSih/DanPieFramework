using DanPie.Framework.Common;
using DanPie.Framework.Parameters;
using UnityEngine;

namespace DanPie.Framework.Hacks
{
    public class RemoveSavesHack : TriggerableParameter
    {
        public override string Name { get; set; }

        private IResettable[] _resettableObjects;

        public RemoveSavesHack(string parameterName, IResettable[] resettableObjects)
        {
            Name = parameterName;
            _resettableObjects = resettableObjects;
        }

        protected override void OnTrigger()
        {
            PlayerPrefs.DeleteAll();
            foreach (IResettable resettableObject in _resettableObjects)
            {
                resettableObject.ResetObject();
            }
        }
    }
}
