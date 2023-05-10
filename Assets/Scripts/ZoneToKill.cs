using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneToKill : MonoBehaviour
{
    bool allowKill = false;
    public GameObject killInputText;
    public GameObject thisGuard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (allowKill == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GuardKill");
                Destroy(thisGuard);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowKill = true;
            killInputText.SetActive(true); //activer l'UI feedback qui indique l'interaction possible
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowKill = false;
            killInputText.SetActive(false); //désactiver l'UI feedback qui indique l'interaction possible
        }
    }
}
