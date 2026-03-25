using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    // List of objects you want to disable
    [SerializeField]
    private List<GameObject> objectsToDisable = new List<GameObject>();

    // Function to disable all objects in the list
    public void DisableAllObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null) // Safety check to avoid errors
            {
                obj.SetActive(false);

                // This helps you debug what's being disabled
                Debug.Log($"Disabled: {obj.name}");
            }
            else
            {
                Debug.LogWarning("One of the objects in the list is null!");
            }
        }
    }
}