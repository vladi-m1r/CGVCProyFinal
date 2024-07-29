using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithRaycast : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float minDistance = 1f; // Distancia mínima para el tamaño máximo
    public float maxDistance = 10f; // Distancia máxima para el tamaño mínimo
    public float minScale = 0.5f; // Tamaño mínimo del objeto
    public float maxScale = 2f; // Tamaño máximo del objeto

    void Update()
    {
        // Calcular la distancia entre el jugador y el objeto
        float distance = Vector3.Distance(player.position, transform.position);

        // Calcular la proporción de escala basada en la distancia
        float scale = Mathf.Lerp(maxScale, minScale, Mathf.InverseLerp(minDistance, maxDistance, distance));

        // Aplicar la escala al objeto
        transform.localScale = new Vector3(scale, scale, scale);
    }
}