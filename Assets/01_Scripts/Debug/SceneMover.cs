using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * 디버깅 또는 테스트를 위한 씬 이동 매니저 클래스
 */
public class SceneMover : MonoBehaviour
{
    public static SceneMover Instance { get; private set; }
    public Coroutine work;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveScene(string sceneName)
    {
        if (work != null) return;
        work = StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        var curScene = SceneManager.GetSceneAt(0);
        var sceneLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        if (sceneLoad == null)
        {
            Debug.LogError("씬을 불러오는 중에 에러가 발생했습니다");
            yield break;
        }

        // 씬이 불러와질 때까지 대기
        while (!sceneLoad.isDone) yield return null;

        var sceneUnload = SceneManager.UnloadSceneAsync(curScene);
        
        if (sceneUnload == null)
        {
            Debug.LogError("씬을 내리는 도중에 에러가 발생했습니다");
            yield break;
        }
        
        // 씬이 내려갈 때까지 대기
        while (!sceneUnload.isDone) yield return null;

        work = null;
    }
}
