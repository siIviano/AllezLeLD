using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guard : MonoBehaviour
{
    public List<Transform> points = new List<Transform>(); // La liste de points à atteindre
    public Transform player;
    public float speed = 5.0f; // La vitesse de déplacement
    public float speedMultiplier = 2f; //Le multiplicateur de la vitesse quand le garde repère le joueur pour le poursuivre
    public float rotationSpeed = 10.0f;
    private int currentPoint = 0; // Le point actuel dans la liste

    public string sceneToReaload;
    bool routineOrHunt = true;
    
    void Update()
    {
        // Si la liste de points est vide, ne rien faire
        if (points.Count == 0)
        {
            return;
        }

        if(routineOrHunt==true)
        {
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

            // Tourner l'objet vers le point actuel
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            // Déplacer l'objet vers le point actuel
            transform.position += direction * speed * Time.deltaTime;
        } else
        {
            //Calculer la distance entre l'objet et le player
            float distance = Vector3.Distance(transform.position, player.position);

            // Si la distance est très petite, passer au point suivant
            if (distance < 0.25f)
            {
                Debug.Log("Attrapé et mort !");
                SceneManager.LoadScene(sceneToReaload);
                //Faire le gameover (fondu au noir avec texte disant qu'on s'est fait attrapper par un garde et un bouton pour recommencer (respawn au dernier savepoint))
            }

            // Calculer la direction vers le point actuel
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Tourner l'objet vers le point actuel
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            // Déplacer l'objet vers le point actuel
            transform.position += direction * speed*speedMultiplier * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            routineOrHunt = false;
        }
    }
}
