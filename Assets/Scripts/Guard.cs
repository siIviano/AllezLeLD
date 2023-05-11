using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guard : MonoBehaviour
{
    public List<Transform> points = new List<Transform>(); // La liste de points à atteindre
    public Transform player;
    public Transform raycastSource;
    public float speed = 5.0f; // La vitesse de déplacement
    public float speedMultiplier = 2f; // Le multiplicateur de la vitesse quand le garde repère le joueur pour le poursuivre
    public float rotationSpeed = 10.0f;
    public float visionAngle = 60f; // L'angle de vision du garde
    public float visionRange = 10f; // La portée de vision du garde
    private int currentPoint = 0; // Le point actuel dans la liste

    public string sceneToReload;
    private bool routineOrHunt = true;

    void Update()
    {
        // Si la liste de points est vide, ne rien faire
        if (points.Count == 0)
        {
            return;
        }

        if (routineOrHunt)
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



            // Calculer la direction vers le joueur
            Vector3 playerDirection = player.position - transform.position;

            // Calculer l'angle entre la direction vers le joueur et la direction de regard du garde
            float angle = Vector3.Angle(playerDirection, transform.forward);

            // Si le joueur est dans le champ de vision du garde et à portée
            if (angle <= visionAngle && playerDirection.magnitude <= visionRange)
            {
                // Effectuer un raycast pour vérifier les obstacles entre le joueur et le garde
                RaycastHit hit;
                if (Physics.Raycast(raycastSource.position, playerDirection, out hit))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.Log("Player détecté");
                        routineOrHunt = false;
                        /*// Pas d'obstacle entre le joueur et le garde
                        // Tourner l'objet vers le joueur
                        Quaternion playerRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                        transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, Time.deltaTime * rotationSpeed);

                        // Déplacer l'objet vers le joueur
                        transform.position += playerDirection * speed * speedMultiplier * Time.deltaTime;*/
                    } else
                    {
                        Debug.Log("Player pas visible");
                    }
                }

                // Dessiner le raycast dans la scène
                Debug.DrawRay(raycastSource.position, playerDirection, Color.red);

                /*//Calculer la distance entre l'objet et le player
                float distanceWithPlayer = Vector3.Distance(transform.position, player.position);

                // Si la distance est très petite, joueur attrapé
                if (distanceWithPlayer < 0.25f)
                {
                    Debug.Log("Attrapé et mort !");
                    SceneManager.LoadScene(sceneToReload);
                    //Faire le gameover (fondu au noir avec texte disant qu'on s'est fait attrapper par un garde et un bouton pour recommencer (respawn au dernier savepoint))
                }*/
            }
        }
        else
        {
            // Calculer la direction vers le joueur
            Vector3 playerDirection = player.position - transform.position;

            // Pas d'obstacle entre le joueur et le garde
            // Tourner l'objet vers le joueur
            Quaternion playerRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, Time.deltaTime * rotationSpeed);

            // Déplacer l'objet vers le joueur
            transform.position += playerDirection * speed * speedMultiplier * Time.deltaTime;

            //Calculer la distance entre l'objet et le player
            float distanceWithPlayer = Vector3.Distance(transform.position, player.position);

            // Si la distance est très petite, joueur attrapé
            if (distanceWithPlayer < 0.25f)
            {
                Debug.Log("Attrapé et mort !");
                SceneManager.LoadScene(sceneToReload);
                //Faire le gameover (fondu au noir avec texte disant qu'on s'est fait attrapper par un garde et un bouton pour recommencer (respawn au dernier savepoint))
            }



            // Calculer l'angle entre la direction vers le joueur et la direction de regard du garde
            float angle = Vector3.Angle(playerDirection, transform.forward);

            // Si le joueur est dans le champ de vision du garde et à portée
            if (angle <= visionAngle && playerDirection.magnitude <= visionRange)
            {
                // Effectuer un raycast pour vérifier les obstacles entre le joueur et le garde
                RaycastHit hit;
                if (Physics.Raycast(raycastSource.position, playerDirection, out hit))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.Log("Player détecté"); //ne rien changer
                    }
                    else
                    {
                        Debug.Log("Player pas visible");
                        routineOrHunt = true;
                    }
                }
            } else
            {
                routineOrHunt = true;
            }

            // Dessiner le raycast dans la scène
            Debug.DrawRay(raycastSource.position, playerDirection, Color.red);
        }
    }
}


