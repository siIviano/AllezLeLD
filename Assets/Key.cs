using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    bool allowInteraction = false;
    public GameObject interactInputText;
    public bool tookKey = false;

    
    void Start()
    {
        
    }
    
    void Update()
    {
        if(allowInteraction==true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                tookKey = true;
                Debug.Log("Got Key");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowInteraction = true;
            interactInputText.SetActive(true); //activer l'UI feedback qui indique l'interaction possible
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowInteraction = false;
            interactInputText.SetActive(false); //d�sactiver l'UI feedback qui indique l'interaction possible
        }
    }
}