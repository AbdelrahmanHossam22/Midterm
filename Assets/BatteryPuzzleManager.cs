using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BatteryPuzzleManager : MonoBehaviour
{
    public XRSocketInteractor socket1;
    public XRSocketInteractor socket2;
    public XRSocketInteractor socket3;

    public GameObject panelLight;

    private bool activated = false;

    void Update()
    {
        if (activated) return;

        if (socket1.hasSelection &&
            socket2.hasSelection &&
            socket3.hasSelection)
        {
            activated = true;

            Debug.Log("POWER ON!");

            if (panelLight != null)
            {
                panelLight.SetActive(true);
            }
        }
    }
}