using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{

    [SerializeField] GameObject loadingUI;
    [SerializeField] RectTransform loadingBar;
    [SerializeField] Text loadingText;

    /*public static SceneHandler inst
    {
        get;
        private set;
    }*/

    string currScene;
    public string CurrScene
    {
        get
        {
            return currScene;
        }
    }

    private void Awake()
    {
        /*if (inst != null && inst != this)
        {
            Destroy(this.gameObject);
        } else
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }*/
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLeve(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(sceneName);
        currScene = sceneName;

        while (!loadScene.isDone)
        {
            float progress = Mathf.Clamp01(loadScene.progress / 0.9f);

            yield return null;
        }
    }
}
