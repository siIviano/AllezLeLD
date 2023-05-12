using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject key;
    public GameObject doorOpen;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (key.GetComponent<Key>().tookKey == true)
        {
            doorOpen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
