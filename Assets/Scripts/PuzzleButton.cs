using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public string buttonID;
    public Puzzle2Manager manager;

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            manager.PressButton(buttonID);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            playerNearby = false;
        }
    }
}