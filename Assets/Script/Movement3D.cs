using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement3D : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void Update()
    {
        // Verifica si se ha presionado la tecla Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Obtiene el índice de la escena actual
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Calcula el índice de la escena a la que se va a cambiar
            int nextSceneIndex = (currentSceneIndex == 0) ? 1 : 0;

            // Cambia a la siguiente escena
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}