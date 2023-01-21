using DanPie.Framework.Common;
using DanPie.Framework.Parameters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DanPie.Framework.Hacks
{
    public class ResetHack : TriggerableParameter
    {
        public override string Name { get; set; }

        private IResettable[] _resettableObjects;

        public ResetHack(string parameterName, IResettable[] resettableObjects)
        {
            Name = parameterName;
            _resettableObjects = resettableObjects;
        }

        protected override void OnTrigger()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
            foreach (IResettable resettableObject in _resettableObjects)
            {
                resettableObject.ResetObject();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
