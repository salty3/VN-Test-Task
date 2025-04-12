using System.Linq;
using Naninovel;
using UnityEngine.SceneManagement;

namespace Tools.SceneManagement.Runtime
{
    public static class SceneAssetExtensions
    {
        public static T GetRootObject<T> (this SceneReference sceneReference)
        {
            var targetObject = sceneReference.Scene
                .GetRootGameObjects()
                .FirstOrDefault(go => go.TryGetComponent<T>(out _));
            
            return targetObject != null ? targetObject.GetComponent<T>() : default;
        }
        
        public static T GetAnyObject<T> (this SceneReference sceneReference)
        {
            return sceneReference.Scene
                .GetRootGameObjects()
                .SelectMany(go => go.GetComponentsInChildren<T>())
                .FirstOrDefault();
        }
        
        public static async UniTask LoadSceneAsync(this SceneReference sceneReference, LoadSceneMode mode)
        {
            await SceneManager.LoadSceneAsync(sceneReference.SceneName, mode);
        }
        
        public static async UniTask UnloadSceneAsync(this SceneReference sceneReference)
        {
            await SceneManager.UnloadSceneAsync(sceneReference.SceneName);
        }
    }
}