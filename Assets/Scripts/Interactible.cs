using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactible : MonoBehaviour
{
    bool allowInteraction = false;
    public GameObject interactInput;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(allowInteraction==true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interaction Done");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowInteraction = true;
            interactInput.SetActive(true); //activer l'UI feedback qui indique l'interaction possible
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowInteraction = false;
            interactInput.SetActive(false); //désactiver l'UI feedback qui indique l'interaction possible
        }
    }
}
