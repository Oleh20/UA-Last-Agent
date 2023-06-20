using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameManager : MonoBehaviour
{
    private GameManager gameManager;

    public void OnMenuButtonClicked()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            Destroy(gameManager.gameObject);
        }
    }
}