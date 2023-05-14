using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InsideKey : MonoBehaviour
{
    bool allowInteraction = false;
    public GameObject interactInputText;
    public GameObject textobject;
    public bool upGate;
    public bool secretPassage;
    public bool prison;

    public bool guards;
    public bool doorRemove;
    public bool gateRemove;
    
    public GameObject openGate;
    public GameObject passageDoor;
    public GameObject prisonOpen;
    
    public GameObject guardRemove;
    public GameObject removeDoor;
    public GameObject removeGate;

    public bool text;
    
    
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
                if (upGate == true)
                {
                    openGate.SetActive(true);
                }
                if (secretPassage == true)
                {
                    passageDoor.SetActive(true);
                }
                if (guards == true)
                {
                    guardRemove.SetActive(false);
                }
                if (prison == true)
                {
                   prisonOpen.SetActive(true);
                }
                if (doorRemove == true)
                {
                    removeDoor.SetActive(false);
                }
                if (gateRemove == true)
                {
                    removeGate.SetActive(false);
                }
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowInteraction = true;
            interactInputText.SetActive(true); //activer l'UI feedback qui indique l'interaction possible
            if (text)
            {
                textobject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowInteraction = false;
            interactInputText.SetActive(false); //d�sactiver l'UI feedback qui indique l'interaction possible
            if (text)
            {
                textobject.SetActive(false);
            }
        }
    }
}
