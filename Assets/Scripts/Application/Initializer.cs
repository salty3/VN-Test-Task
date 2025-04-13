using System;
using Naninovel;
using UnityEngine;

namespace Game.Scripts.Application
{
    public class Initializer : MonoBehaviour
    {
        private void Start()
        {
            RuntimeInitializer.InitializeAsync().Forget();
        }
    }
}