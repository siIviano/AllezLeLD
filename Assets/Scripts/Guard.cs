using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public List<Transform> points = new List<Transform>(); // La liste de points à atteindre
    public float speed = 5.0f; // La vitesse de déplacement
    private int currentPoint = 0; // Le point actuel dans la liste

    void Update()
    {
        // Si la liste de points est vide, ne rien faire
        if (points.Count == 0)
        {
            return;
        }

        // Calculer la distance entre l'objet et le point actuel
        float distance = Vector3.Distance(transform.position, points[currentPoint].position);

        // Si la distance est très petite, passer au point suivant
        if (distance < 0.1f)
        {
            currentPoint++;
            if (currentPoint >= points.Count)
            {
                currentPoint = 0;
            }
        }

        // Calculer la direction vers le point actuel
        Vector3 direction = points[currentPoint].position - transform.position;
        direction.Normalize();

        // Déplacer l'objet vers le point actuel
        transform.position += direction * speed * Time.deltaTime;
    }
}
