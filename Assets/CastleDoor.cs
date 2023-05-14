using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CastleDoor : MonoBehaviour
{
    bool allowInteraction = false;
    public GameObject interactInputText;
    public int sceneIndex;


    void Start()
    {

    }

    void Update()
    {
        if (allowInteraction == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(sceneIndex);
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