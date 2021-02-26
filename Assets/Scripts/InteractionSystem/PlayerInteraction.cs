using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public float interactionDistance;
    public Text interactionText;
    Camera mainCam;

    void Start()
    {
        mainCam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool sucessfullHit = false;

        if (Physics.Raycast (ray, out hit, interactionDistance))
		{
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
			{
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                sucessfullHit = true;
			}
		}

        if (!sucessfullHit) interactionText.text = "";
    }

    void HandleInteraction(Interactable interactable)
	{
		switch (interactable.interactionType)
		{
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(interactionKey))
				{
                    interactable.Interact();
				}
                break;

            case Interactable.InteractionType.Hold:
                if (Input.GetKey(interactionKey))
                {
                    interactable.Interact();
                }
                break;

            case Interactable.InteractionType.Inspect:
                Debug.Log("Inspection...");
                break;

            default:
                throw new System.Exception("Unsupported type of interactable");

        }
    }
}
