using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithRaycast : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float minDistance = 1f; // Distancia m�nima para el tama�o m�ximo
    public float maxDistance = 10f; // Distancia m�xima para el tama�o m�nimo
    public float minScale = 0.5f; // Tama�o m�nimo del objeto
    public float maxScale = 2f; // Tama�o m�ximo del objeto

    void Update()
    {
        // Calcular la distancia entre el jugador y el objeto
        float distance = Vector3.Distance(player.position, transform.position);

        // Calcular la proporci�n de escala basada en la distancia
        float scale = Mathf.Lerp(maxScale, minScale, Mathf.InverseLerp(minDistance, maxDistance, distance));

        // Aplicar la escala al objeto
        transform.localScale = new Vector3(scale, scale, scale);
    }
}