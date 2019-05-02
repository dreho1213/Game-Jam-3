using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetPosReset : MonoBehaviour
{
    public string currentLevel;

    void Update()
    {
        if(gameObject.transform.position.y <= -12)
        {
            Application.LoadLevelAsync(currentLevel);
        }
    }
}
