using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObject : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Dirección hacia el objetivo
            Vector3 direction = target.position - transform.position;
            // Rotación deseada hacia la dirección del objetivo
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Interpolación de la rotación actual hacia la rotación deseada
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void destroySlowy()
    {
        Destroy(this.gameObject);
    }
}
