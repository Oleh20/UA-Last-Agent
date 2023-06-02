using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerInitializer : MonoBehaviour
{
    public GameObject gameManagerPrefab;

    private void Awake()
    {
        if (GameObject.FindObjectOfType<GameManager>() == null)
        {
            Instantiate(gameManagerPrefab);
        }
    }
}
