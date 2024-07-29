using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    // Arrastra el objeto que quieres activar/desactivar en el inspector
    public GameObject objectToToggle;

    // Método llamado cuando otro objeto entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que el objeto que entra es el que quieres (por ejemplo, el jugador)
        if (other.CompareTag("Player"))
        {
            // Activa el objeto
            objectToToggle.SetActive(true);
        }
    }

    // Método llamado cuando otro objeto sale del trigger
    private void OnTriggerExit(Collider other)
    {
        // Asegúrate de que el objeto que sale es el que quieres (por ejemplo, el jugador)
        if (other.CompareTag("Player"))
        {
            // Desactiva el objeto
            objectToToggle.SetActive(false);
        }
    }
}
