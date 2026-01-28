using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoomSwitcher : MonoBehaviour
{
    [Header("Room GameObjects")]
    public GameObject room1; // Diner
    public GameObject room2; // Bathroom
    public GameObject room3; // Kitchen

    [Header("Camera Settings")]
    public Camera mainCamera;
    public float cameraZPosition = -10f;

    [Header("Navigation Buttons")]
    public Button buttonToDiner;
    public Button buttonToBathroom;
    public Button buttonToKitchen;

    [Header("Fade Settings")]
    public Image fadePanel;
    public float fadeDuration = 0.5f; // How long fade takes (in seconds)

    private int currentRoom = 1;
    private bool isTransitioning = false;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // Make sure fade panel starts invisible
        if (fadePanel != null)
        {
            Color c = fadePanel.color;
            c.a = 0f;
            fadePanel.color = c;
        }

        ShowRoom1(); // Start in Diner
    }

    public void ShowRoom1() // Diner
    {
        if (!isTransitioning)
            StartCoroutine(TransitionToRoom(1));
    }

    public void ShowRoom2() // Bathroom
    {
        if (!isTransitioning)
            StartCoroutine(TransitionToRoom(2));
    }

    public void ShowRoom3() // Kitchen
    {
        if (!isTransitioning)
            StartCoroutine(TransitionToRoom(3));
    }

    IEnumerator TransitionToRoom(int roomNumber)
    {
        isTransitioning = true;

        // Fade to black
        yield return StartCoroutine(FadeToBlack());

        // Switch room and move camera while screen is black
        currentRoom = roomNumber;
        
        if (roomNumber == 1)
        {
            room1.SetActive(true);
            room2.SetActive(false);
            room3.SetActive(false);
            mainCamera.transform.position = new Vector3(room1.transform.position.x, room1.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 2)
        {
            room1.SetActive(false);
            room2.SetActive(true);
            room3.SetActive(false);
            mainCamera.transform.position = new Vector3(room2.transform.position.x, room2.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 3)
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(true);
            mainCamera.transform.position = new Vector3(room3.transform.position.x, room3.transform.position.y, cameraZPosition);
        }

        UpdateButtons();

        // Fade back from black
        yield return StartCoroutine(FadeFromBlack());

        isTransitioning = false;
    }

    IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        Color c = fadePanel.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadePanel.color = c;
            yield return null;
        }

        c.a = 1f;
        fadePanel.color = c;
    }

    IEnumerator FadeFromBlack()
    {
        float elapsedTime = 0f;
        Color c = fadePanel.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadePanel.color = c;
            yield return null;
        }

        c.a = 0f;
        fadePanel.color = c;
    }

    void UpdateButtons()
    {
        // Hide all buttons first
        if (buttonToDiner != null) buttonToDiner.gameObject.SetActive(false);
        if (buttonToBathroom != null) buttonToBathroom.gameObject.SetActive(false);
        if (buttonToKitchen != null) buttonToKitchen.gameObject.SetActive(false);

        // Show buttons based on current room
        if (currentRoom == 1) // In Diner (hub)
        {
            if (buttonToBathroom != null) buttonToBathroom.gameObject.SetActive(true);
            if (buttonToKitchen != null) buttonToKitchen.gameObject.SetActive(true);
        }
        else if (currentRoom == 2) // In Bathroom
        {
            if (buttonToDiner != null) buttonToDiner.gameObject.SetActive(true);
        }
        else if (currentRoom == 3) // In Kitchen
        {
            if (buttonToDiner != null) buttonToDiner.gameObject.SetActive(true);
        }
    }
}