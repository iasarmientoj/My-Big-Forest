using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Slider loadbar;
    [SerializeField] private int sceneIndex;

    AsyncOperation asyncOperation;
    bool sceneActivated = false;

    public void SceneLoad(float barLimitDown, float barLimitUp)
    {
        StartCoroutine(LoadAsync(barLimitDown, barLimitUp));
    }

    private IEnumerator LoadAsync(float barLimitDown, float barLimitUp)
    {

        asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;



        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log(progress);

            //loadbar.value = progress;
            loadbar.value = Mathf.Lerp(barLimitDown, barLimitUp, progress /0.1f);

            if (progress >= 0.9f)
            {
                if (!sceneActivated)
                {
                    Invoke(nameof(ActivateScene), 0.5f);
                    sceneActivated = true;
                }
            }

            yield return null;
        }


    }

    private void ActivateScene()
    {
        asyncOperation.allowSceneActivation = true;

    }

}
