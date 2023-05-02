using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    int endCP;
    public List<GameObject> Checkpoints = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        endCP = Checkpoints.Count;
    }

    // Update is called once per frame
    void Update()
    {
        //for(i=0, i<Checkpoints.Count, i++)
    }
}
