using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setVisibilityObject : MonoBehaviour
{
    public void changeActive(int number)
    {
        bool value;
        if (number == 0)
        {
            value = false;
        }
        else
        {
            value = true;
        }
        gameObject.SetActive(value);
    }
}


