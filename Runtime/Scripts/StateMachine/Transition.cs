using System;
using UnityEngine;

namespace DanPie.Framework.StateMachine
{
    public abstract class Transition : MonoBehaviour
    {
        public event Action<IState> OnTransited;

        public abstract void Enter();
    }
}
