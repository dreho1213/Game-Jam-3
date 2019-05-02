using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehavior : MonoBehaviour
{
    //Whether or not player can travel through the door
    public bool isOpen;
    public Sprite Opened;

    //The name of the scene that the door takes the player to
    public string destination;

    private bool isNear;

    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (isNear)
            {
                SceneManager.LoadScene(destination);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Only the player (not the children) can go through the door when it is opened
        int thisPos = other.GetComponent<ChangeController>().thisPos;
        if (isOpen && thisPos == 1)
        {
            isNear = true;
            Debug.Log("Close");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Only the player (not the children) can go through the door when it is opened
        int thisPos = other.GetComponent<ChangeController>().thisPos;
        if (isOpen && thisPos == 1)
        {
            isNear = false;
            Debug.Log("Not close");
        }
    }

    public void Open()
    {
        isOpen = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = Opened;
        Debug.Log("open");
    }
}

