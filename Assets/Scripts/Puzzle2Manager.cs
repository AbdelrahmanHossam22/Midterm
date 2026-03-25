using UnityEngine;

public class Puzzle2Manager : MonoBehaviour
{
    public GameObject successLight;

    private string[] correctOrder = { "Blue", "Red", "Green" };
    private int currentIndex = 0;
    private bool solved = false;

    public void PressButton(string buttonID)
    {
        if (solved) return;

        if (buttonID == correctOrder[currentIndex])
        {
            currentIndex++;
            Debug.Log("Correct button: " + buttonID);

            if (currentIndex >= correctOrder.Length)
            {
                solved = true;
                Debug.Log("Puzzle 2 Solved!");

                if (successLight != null)
                {
                    successLight.SetActive(true);
                }
            }
        }
        else
        {
            Debug.Log("Wrong order! Resetting puzzle.");
            currentIndex = 0;
        }
    }

    public void PressBlue()
    {
        PressButton("Blue");
    }

    public void PressRed()
    {
        PressButton("Red");
    }

    public void PressGreen()
    {
        PressButton("Green");
    }
}