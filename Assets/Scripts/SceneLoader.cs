using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace ProjectVulkan
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private CanvasGroup loadingScreenGroup;

        private AsyncOperation loadingOperation;

        public void LoadScene(string sceneToLoad)
        {
            StartCoroutine(LoadSceneAsync(sceneToLoad));
        }
    
        IEnumerator LoadSceneAsync (string sceneToLoad)
        {
            loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
            loadingScreenGroup.alpha = 1f;
            while (!loadingOperation.isDone)
            {
                yield return null;
            }
        }
    }
}