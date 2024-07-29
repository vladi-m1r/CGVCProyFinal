using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{

    public Transform cameraT;
    private GameObject interactableObject;

    public GameObject prefabFloatingButton;
    private GameObject floatingButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        testRaycast();
        handleKeyboard();
    }

    void handleKeyboard()
    {
        if (interactableObject && Input.GetKeyDown(KeyCode.E))
        {
            startInteractableObjectAnimation();
        }
    }

    void testRaycast()
    {
        Ray ray = new Ray(cameraT.position, cameraT.TransformDirection (Vector3.forward));
        RaycastHit hitinfo;

        if (Physics.Raycast(ray, out hitinfo, 20f))
        {
            Debug.DrawRay(cameraT.position, cameraT.TransformDirection (Vector3.forward) * hitinfo.distance, Color.red);

            // Remove animation
            if (interactableObject && hitinfo.collider.gameObject != interactableObject)
            {
                interactableObject.GetComponent<Animator>().SetBool("isRotate", false);
                if (floatingButton)
                {
                    floatingButton.GetComponent<LookObject>().destroySlowy();
                    floatingButton = null;
                }
            }
            
            if (hitinfo.collider.gameObject.tag == "Interactable")
            {
                interactableObject = hitinfo.collider.gameObject;

                // Creating the floating button
                if (!floatingButton)
                {
                    floatingButton = Instantiate(prefabFloatingButton, interactableObject.transform.position, Quaternion.identity);
                    floatingButton.GetComponent<LookObject>().target = cameraT;
                }
            }

        }
        else
        {
            if (interactableObject)
            {
                interactableObject.GetComponent<Animator>().SetBool("isRotate", false);
            }

            if (floatingButton)
            {
                floatingButton.GetComponent<LookObject>().destroySlowy();
                floatingButton = null;
            }

            Debug.DrawRay(cameraT.position, cameraT.TransformDirection (Vector3.forward) * 20f, Color.red);
        }
    }

    void startInteractableObjectAnimation()
    {
        if (interactableObject)
        {
            interactableObject.GetComponent<Animator>().SetBool("isRotate", true);
        }
    }

}
