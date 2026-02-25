using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoomSwitcher : MonoBehaviour
{
    [Header("Room GameObjects")]
    public GameObject room1; // Diner
    public GameObject room2; // Bathroom
    public GameObject room3; // Kitchen
    public GameObject bar; // Bar

    [Header("Camera Settings")]
    public Camera mainCamera;
    public float cameraZPosition = -10f;

    [Header("Navigation Buttons")]
    public Button buttonToDiner;
    public Button buttonToBathroom;
    public Button buttonToKitchen;
    public Button buttonToBar;

    [Header("Fade Settings")]
    public Image fadePanel;
    public float fadeDuration = 0.5f; // How long fade takes (in seconds)

    public int currentRoom = 1;
    private bool isTransitioning = false;
    

    [Header("Audio")]
	private Coroutine bathroomEventRoutine;

	public AudioClip walkingSound;
    public AudioClip Ambiance;
    public AudioClip music;
    public AudioClip musicEvent;
    public AudioClip bathroomEvent;
    public AudioClip glassClink;

	private AudioSource audioSource;
    private AudioSource backgroundAmbiance;
    private AudioSource dinerMusic;
    private AudioSource events;

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

        AudioSource[] sources = GetComponents<AudioSource>();
        audioSource = sources[0];
        backgroundAmbiance = sources[1];
        dinerMusic = sources[2];
		events = sources[3];


		backgroundAmbiance.clip = Ambiance;
        backgroundAmbiance.loop = true;
        backgroundAmbiance.Play();

        dinerMusic.clip = music;
        dinerMusic.loop = true;
        dinerMusic.Play();

        
		// Start immediately in the Diner without fading.
		SetRoomImmediate(1);
        UpdateButtons();
    }

    // Sets the active room and camera immediately without any fade.
    void SetRoomImmediate(int roomNumber)
    {
        currentRoom = roomNumber;

        UpdateMusicForRoom();

        if (roomNumber == 1)
        {
            room1.SetActive(true);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(false);
            mainCamera.transform.position = new Vector3(room1.transform.position.x, room1.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 2)
        {
            room1.SetActive(false);
            room2.SetActive(true);
            room3.SetActive(false);
            bar.SetActive(false);
            mainCamera.transform.position = new Vector3(room2.transform.position.x, room2.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 3)
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(true);
            bar.SetActive(false);
            mainCamera.transform.position = new Vector3(room3.transform.position.x, room3.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 4)
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(true);
            mainCamera.transform.position = new Vector3(-25f, bar.transform.position.y, cameraZPosition);
        }

		if (bathroomEventRoutine != null && currentRoom != 2)
		{
			StopCoroutine(bathroomEventRoutine);
			bathroomEventRoutine = null;
		}
		if (currentRoom == 2 && bathroomEventRoutine == null)
		{
			bathroomEventRoutine = StartCoroutine(BathroomEventLoop());
		}

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

    public void ShowBar() // Bar
    {
        if (!isTransitioning)
            StartCoroutine(TransitionToRoom(4));
    }

    void UpdateMusicForRoom()
{
    switch (currentRoom)
    {
        case 1: // Diner
            dinerMusic.volume = 0.2f;
            backgroundAmbiance.volume = 0.3f;
            break;

        case 4: // Bar
            backgroundAmbiance.volume = 0.2f;
            dinerMusic.volume = 0.13f;
				break;

        case 2: // Bathroom
            backgroundAmbiance.volume = 0.14f;
            dinerMusic.volume = 0.09f;
			break;

        case 3: // Kitchen
            backgroundAmbiance.volume = 0.15f;
            dinerMusic.volume = 0.09f;
			break;
    }
}

	IEnumerator BathroomEventLoop()
	{
		while (currentRoom == 2)
		{
			float wait = Random.Range(9,16);
			yield return new WaitForSeconds(wait);

			if (currentRoom != 2) break;

			events.PlayOneShot(bathroomEvent);
		}

		bathroomEventRoutine = null;
	}

	IEnumerator TransitionToRoom(int roomNumber)
    {
        isTransitioning = true;

        audioSource.PlayOneShot(walkingSound);

        // Fade to black
        yield return StartCoroutine(FadeToBlack());

        // Switch room and move camera while screen is black
        currentRoom = roomNumber;

		if (bathroomEventRoutine != null && currentRoom != 2)
		{
			StopCoroutine(bathroomEventRoutine);
			bathroomEventRoutine = null;
		}

		UpdateMusicForRoom();
        
        if (roomNumber == 1)
        {
            room1.SetActive(true);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(false);
            mainCamera.transform.position = new Vector3(room1.transform.position.x, room1.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 2)
        {
            room1.SetActive(false);
            room2.SetActive(true);
            room3.SetActive(false);
            bar.SetActive(false);
            mainCamera.transform.position = new Vector3(room2.transform.position.x, room2.transform.position.y, cameraZPosition);

            events.PlayOneShot(musicEvent);

			if (bathroomEventRoutine == null)
			    bathroomEventRoutine = StartCoroutine(BathroomEventLoop());

		}
		else if (roomNumber == 3)
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(true);
            bar.SetActive(false);
            mainCamera.transform.position = new Vector3(room3.transform.position.x, room3.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 4)
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(true);
            mainCamera.transform.position = new Vector3(-25f, bar.transform.position.y, cameraZPosition);

            events.PlayOneShot(glassClink);

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
        if (buttonToBar != null) buttonToBar.gameObject.SetActive(false);

        // Show buttons based on current room
        if (currentRoom == 1) // In Diner (hub)
        {
            if (buttonToBathroom != null) buttonToBathroom.gameObject.SetActive(true);
            if (buttonToKitchen != null) buttonToKitchen.gameObject.SetActive(true);
            if (buttonToBar != null) buttonToBar.gameObject.SetActive(true);


        }
        else if (currentRoom == 2) // In Bathroom
        {
            if (buttonToDiner != null) buttonToDiner.gameObject.SetActive(true);
        }
        else if (currentRoom == 3) // In Kitchen
        {
            if (buttonToDiner != null) buttonToDiner.gameObject.SetActive(true);
        }
        else if (currentRoom == 4) // In Bar
        {
            if (buttonToDiner != null) buttonToDiner.gameObject.SetActive(true);
        }
    }
}