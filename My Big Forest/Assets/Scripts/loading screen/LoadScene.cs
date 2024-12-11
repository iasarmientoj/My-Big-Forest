using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Image loadbar;
    [SerializeField] private int sceneIndex;

    private void Start()
    {
        Invoke(nameof(SceneLoad),0.5f);
    }

    private void SceneLoad()
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    private IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncOperation.isDone)
        {
            Debug.Log(asyncOperation.progress);
            loadbar.fillAmount = asyncOperation.progress / 0.9f;
            yield return null;
        }
    }

}
