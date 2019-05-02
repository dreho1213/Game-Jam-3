using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentController : MonoBehaviour
{
    public int current;
    public GameObject currentControl;

    // Start is called before the first frame update
    void Start()
    {
        current = 1;
        currentControl = GameObject.FindWithTag("Player");
    }


}
