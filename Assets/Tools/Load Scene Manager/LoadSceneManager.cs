using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        LoadScenePro(sceneName);
    }

    public void ReloadScene()
    {
        var curSceneName = SceneManager.GetActiveScene().name;
        LoadScenePro(curSceneName);
    }
    
    public void LoadScenePro(string sceneName)
    {
        StartCoroutine(IELoadScene(sceneName));
    }

    public IEnumerator IELoadScene(string sceneName)
    {
        TransitionFx.Instance.StartLoadScene();
        yield return new WaitForSeconds(1f);
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        TransitionFx.Instance.EndLoadScene();
    }
}