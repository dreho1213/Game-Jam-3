using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string level;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        Application.LoadLevel(level);
    }
}
