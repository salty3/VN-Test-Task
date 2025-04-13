using System.Threading;
using Naninovel;
using UnityEngine;

namespace Game.Scripts.Application
{
    public class Initializer : MonoBehaviour
    {
        private async void Start()
        {
            await RuntimeInitializer.InitializeAsync();
        }
    }
}