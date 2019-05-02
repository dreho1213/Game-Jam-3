using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChild : MonoBehaviour
{
    //childTypes stores prefabs for children; will toggle by entering map area
    public GameObject[] childTypes;
    //spawnPositions stores locations for spawning children
    public Transform[] spawnPositions;

    //typePos stores which prefab in childTypes will spawn; will toggle with map area
    [HideInInspector] public int typePos;
    //spawnPos stores the location in the children array where a child will be stored
    [HideInInspector] public int spawnPos;
    //children is the list of children; used to change player controller
    [HideInInspector] public GameObject[] children;
    [HideInInspector] public int maxSpawns;

    // Start is called before the first frame update
    void Start()
    {
        typePos = 0;
        spawnPos = 0;
        maxSpawns = 4;
        children = new GameObject[maxSpawns];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        bool isFull = true;
        for (int i = children.Length - 1; i >= 0; i--)
        {
            if(children[i] == null)
            {
                isFull = false;
                spawnPos = i;
            }
        }
        if (!isFull)
        {
            children[spawnPos] = Instantiate(childTypes[typePos], spawnPositions[0].position, new Quaternion(0, 0, 0, 0));
            children[spawnPos].GetComponent<ChangeController>().thisPos = 2 + spawnPos;
        }
    }

    public void DestroyChild(int childPos)
    {
        GameObject.FindWithTag("Player").GetComponent<ChangeController>().ChangeTo();

        Destroy(children[childPos]);
        children[childPos] = null;

    }

    /*
    private Vector3 ChoosePos()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            if (!hitToTest.collider.bounds.Contains(telePosition))
            {
                Debug.Log("point is inside collider");
            }
        }
    }
    */
}
