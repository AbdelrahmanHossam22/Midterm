using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRButtonPress : MonoBehaviour
{
    public string buttonID;
    public Puzzle2Manager manager;

    private XRSimpleInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(OnPressed);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnPressed);
    }

    private void OnPressed(SelectEnterEventArgs args)
    {
        Debug.Log("Pressed button: " + buttonID);

        if (manager != null)
        {
            manager.PressButton(buttonID);
        }
        else
        {
            Debug.Log("Manager is missing!");
        }
    }
}