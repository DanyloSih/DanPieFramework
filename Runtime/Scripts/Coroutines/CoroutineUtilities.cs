using System;
using System.Collections;
using DanPie.Framework.Pause;
using UnityEngine;

namespace DanPie.Framework.Coroutines
{
    public static class CoroutineUtilities
    {
        public static IEnumerator PausableWaitForSeconds(
            float seconds,
            IPauseStateProvider pauseStateProvider,
            Action callback)
        {
            yield return new PausableWaitForSeconds(seconds, pauseStateProvider);
            callback();
        }

        public static IEnumerator WaitForSeconds(float seconds, Action callback)
        {
            yield return new WaitForSeconds(seconds);
            callback();
        }
    }
}