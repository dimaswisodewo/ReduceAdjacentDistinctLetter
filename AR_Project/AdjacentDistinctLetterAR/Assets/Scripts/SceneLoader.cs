using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    [HideInInspector] public string validatedInput;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void LoadScene(SCENE enumScene)
    {
        string sceneName = "";

        switch (enumScene)
        {
            case SCENE.MAIN:
                sceneName = Config.MAIN_SCENE;
                break;

            case SCENE.MENU:
                sceneName = Config.MENU_SCENE;
                break;
        }

        SceneManager.LoadScene(sceneName);
    }
}

public enum SCENE
{
    MENU,
    MAIN
}