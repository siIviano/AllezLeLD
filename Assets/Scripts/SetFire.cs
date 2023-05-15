using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFire : MonoBehaviour
{
    bool allowInteraction = false;
    public GameObject interactInputText;

    public GameObject guardToDestroy1;
    public GameObject guardToDestroy2;
    public GameObject fireEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (allowInteraction == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interaction Done");
                //Faire disparaitre les gardes de l'entrée et jouer un effet de feu sur l'église
                Destroy(guardToDestroy1);
                Destroy(guardToDestroy2);
                fireEffect.SetActive(true);
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
            interactInputText.SetActive(false); //désactiver l'UI feedback qui indique l'interaction possible
        }
    }
}
