using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target; // Le GameObject à regarder

    void Update()
    {
        if (target != null)
        {
            // Calculer la direction vers le GameObject cible
            Vector3 direction = target.position - transform.position;
            direction.y = 0f; // Si vous voulez que l'objet ne regarde pas en hauteur

            // Tourner l'objet pour regarder vers le GameObject cible
            transform.rotation = Quaternion.LookRotation(-direction);
        }
    }
}
