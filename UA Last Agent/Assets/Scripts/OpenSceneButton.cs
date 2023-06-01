using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneButton : MonoBehaviour
{
    public string GlobalMap;

    public void OpenScene()
    {
        SceneManager.LoadScene(GlobalMap);
    }
}
