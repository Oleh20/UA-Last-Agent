using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class LevelTransition : MonoBehaviour
{

    [SerializeField] private int numberOfScene;
    public void changeScene()
    {
        SceneManager.LoadScene(numberOfScene);
    }
}
