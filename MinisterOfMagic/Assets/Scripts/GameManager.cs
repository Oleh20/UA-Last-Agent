using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectsNotDestroy;
    void Start()
    {

        foreach (GameObject gameObject in gameObjectsNotDestroy)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
            if (objs.Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
