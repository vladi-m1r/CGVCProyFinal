using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListLight : MonoBehaviour
{
    // Arrastra los objetos que quieres activar/desactivar en el inspector
    public List<GameObject> objectsToToggle;

    // Método llamado cuando otro objeto entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que el objeto que entra es el que quieres (por ejemplo, el jugador)
        if (other.CompareTag("Player"))
        {
            // Activa todos los objetos en la lista
            foreach (GameObject obj in objectsToToggle)
            {
                obj.SetActive(true);
            }
        }
    }

    // Método llamado cuando otro objeto sale del trigger
    private void OnTriggerExit(Collider other)
    {
        // Asegúrate de que el objeto que sale es el que quieres (por ejemplo, el jugador)
        if (other.CompareTag("Player"))
        {
            // Desactiva todos los objetos en la lista
            foreach (GameObject obj in objectsToToggle)
            {
                obj.SetActive(false);
            }
        }
    }
}
