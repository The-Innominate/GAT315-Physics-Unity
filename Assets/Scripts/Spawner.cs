using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //a game object variable is set to assign the prefab in the inspector
    [SerializeField] GameObject prefab;
    [SerializeField] KeyCode key = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
