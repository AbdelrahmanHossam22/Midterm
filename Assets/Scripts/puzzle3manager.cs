using UnityEngine;
using TMPro;

public class Puzzle3KeypadManager : MonoBehaviour
{
    public GameObject door;
    public TextMeshProUGUI displayText;
    public AudioSource audioSource;

    private string currentInput = "";
    private string correctCode = "1234";
    private bool solved = false;

    private bool doorOpening = false;
    public float moveSpeed = 2f;
    public float moveHeight = 3f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        if (door != null)
        {
            startPosition = door.transform.position;
            targetPosition = startPosition + Vector3.up * moveHeight;
        }

        UpdateDisplay();
    }

    void Update()
    {
        if (doorOpening && door != null)
        {
            door.transform.position = Vector3.MoveTowards(
                door.transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
        }
    }

    public void Press1() { AddDigit("1"); }
    public void Press2() { AddDigit("2"); }
    public void Press3() { AddDigit("3"); }
    public void Press4() { AddDigit("4"); }
    public void Press5() { AddDigit("5"); }
    public void Press6() { AddDigit("6"); }
    public void Press7() { AddDigit("7"); }
    public void Press8() { AddDigit("8"); }
    public void Press9() { AddDigit("9"); }

    public void PressClear()
    {
        if (solved) return;

        PlayClickSound();
        currentInput = "";
        UpdateDisplay();
        Debug.Log("Cleared");
    }

    public void PressEnter()
    {
        if (solved) return;

        PlayClickSound();
        Debug.Log("Entered: " + currentInput);

        if (currentInput == correctCode)
        {
            solved = true;
            doorOpening = true;
            Debug.Log("Correct code! Door opening...");
        }
        else
        {
            Debug.Log("Wrong code!");
            currentInput = "";
            UpdateDisplay();
        }
    }

    private void AddDigit(string digit)
    {
        if (solved) return;

        PlayClickSound();

        if (currentInput.Length < correctCode.Length)
        {
            currentInput += digit;
            UpdateDisplay();
            Debug.Log("Input: " + currentInput);
        }
    }

    private void UpdateDisplay()
    {
        if (displayText != null)
        {
            if (currentInput == "")
            {
                displayText.text = "----";
            }
            else
            {
                displayText.text = currentInput;
            }
        }
    }

    private void PlayClickSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}