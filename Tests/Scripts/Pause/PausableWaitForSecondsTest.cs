using System;
using System.Collections;
using UnityEngine;

namespace DanPie.Framework.Pause.Test
{
    public class PausableWaitForSecondsTest : MonoBehaviour
    {
        [SerializeField] private PauseTimer _pauseTimer;

        private void OnEnable()
        {
            StartCoroutine(Test(2));
        }

        private IEnumerator Test(float testTime)
        {
            DateTime startTime = DateTime.Now;
            yield return new WaitForSeconds(testTime);
            Debug.Log($"|| Standard WaitForSectonds instruction ended in: {(DateTime.Now - startTime).TotalSeconds} seconds.");
            startTime = DateTime.Now;
            _pauseTimer.StartTimer();
            yield return new PausableWaitForSeconds(testTime, _pauseTimer);
            Debug.Log($"= Pausable WaitForSectonds instruction ended in: {(DateTime.Now - startTime).TotalSeconds} seconds.");
        }
    } 
}
