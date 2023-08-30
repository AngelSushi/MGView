using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public static void LoadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public static void Load3DView()
    {
        string sceneName = FindObjectOfType<Room>().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneName).GetRootGameObjects()) {
            obj.SetActive(true);
        }
    }
}
