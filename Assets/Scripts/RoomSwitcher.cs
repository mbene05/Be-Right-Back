using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;

public class RoomSwitcher : MonoBehaviour
{
    [Header("Room GameObjects")]
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject bar;
    public GameObject kitchenBackroom;
    public GameObject coatRoom;
    public GameObject foyer;

    [Header("Camera Settings")]
    public Camera mainCamera;
    public float cameraZPosition = -10f;

    [Header("Map")]
    public MapManager mapManager;

    [Header("Fade Settings")]
    public Image fadePanel;
    public float fadeDuration = 0.5f;

    public int currentRoom = 1;
    public static bool IsTransitioning = false;

    [Header("Audio")]
    private Coroutine bathroomEventRoutine;

    public AudioClip walkingSound;
    public AudioClip Ambiance;
    public AudioClip music;
    public AudioClip musicEvent;
    public AudioClip glassClink;
    public AudioClip conveyorBelt;
    public AudioClip robotArmMovement;
    public AudioClip windows95;
    public AudioClip bellDing;
    public AudioClip waterDrip;
    public AudioClip squeakydoor;

    private AudioSource audioSource;
    private AudioSource backgroundAmbiance;
    private AudioSource dinerMusic;
    private AudioSource events;


    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

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

        SetRoomImmediate(1);
        UpdateButtons();
    }

    void SetRoomImmediate(int roomNumber)
    {
        currentRoom = roomNumber;

        UpdateMusicForRoom();

        room1.SetActive(false);
        room2.SetActive(false);
        room3.SetActive(false);
        bar.SetActive(false);
        kitchenBackroom.SetActive(false);
        coatRoom.SetActive(false);
        foyer.SetActive(false);

        if (roomNumber == 1)
        {
            room1.SetActive(true);
            mainCamera.transform.position = new Vector3(room1.transform.position.x, room1.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 2)
        {
            room2.SetActive(true);
            mainCamera.transform.position = new Vector3(room2.transform.position.x, room2.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 3)
        {
            room3.SetActive(true);
            mainCamera.transform.position = new Vector3(room3.transform.position.x, room3.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 4)
        {
            bar.SetActive(true);
            mainCamera.transform.position = new Vector3(-25f, bar.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 6)
        {
            kitchenBackroom.SetActive(true);
            mainCamera.transform.position = new Vector3(kitchenBackroom.transform.position.x, kitchenBackroom.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 7)
        {
            coatRoom.SetActive(true);
            mainCamera.transform.position = new Vector3(coatRoom.transform.position.x, coatRoom.transform.position.y, cameraZPosition);
        }
        else if (roomNumber == 8)
        {
            foyer.SetActive(true);
            mainCamera.transform.position = new Vector3(foyer.transform.position.x, foyer.transform.position.y, cameraZPosition);
        }

    }

    public void GoToRoom(int roomNumber)
    {
        if (!IsTransitioning)
            StartCoroutine(TransitionToRoom(roomNumber));
    }

    public void ShowRoom1()
    {
        if (!IsTransitioning)
            StartCoroutine(TransitionToRoom(1));
    }

    public void ShowRoom2()
    {
        if (!IsTransitioning)
            StartCoroutine(TransitionToRoom(2));
    }

    public void ShowRoom3()
    {
        if (!IsTransitioning)
            StartCoroutine(TransitionToRoom(3));
    }

    public void ShowKitchenBackroom()
    {
        if (!IsTransitioning)
            StartCoroutine(TransitionToRoom(6));
    }

    public void ShowCoatRoom()
    {
        if (!IsTransitioning)
            StartCoroutine(TransitionToRoom(7));
    }

    public void ShowFoyer()
    {
        if (!IsTransitioning)
            StartCoroutine(TransitionToRoom(8));
    }

    public void ShowBar()
    {
        if (!IsTransitioning)
            StartCoroutine(TransitionToRoom(4));
    }

    void UpdateMusicForRoom()
    {
        switch (currentRoom)
        {
            case 1:
                backgroundAmbiance.volume = 0.03f;
                dinerMusic.volume = 0.04f;
                break;

            case 4:
                backgroundAmbiance.volume = 0.02f;
                dinerMusic.volume = 0.03f;
                break;

            case 2:
                backgroundAmbiance.volume = 0.01f;
                dinerMusic.volume = 0.01f;
                break;

            case 3:
                backgroundAmbiance.volume = 0.03f;
                dinerMusic.volume = 0.03f;
                break;

            case 6: //background
                backgroundAmbiance.volume = 0.03f;
                dinerMusic.volume = 0.02f;
                break;

            case 7:
                backgroundAmbiance.volume = 0.02f;
                dinerMusic.volume = 0.02f;
                break;

            case 8:
                backgroundAmbiance.volume = 0.02f;
                dinerMusic.volume = 0.02f;
                break;
        }
    }


    IEnumerator TransitionToRoom(int roomNumber)
    {
        IsTransitioning = true;

        audioSource.PlayOneShot(walkingSound);

        yield return StartCoroutine(FadeToBlack());

        currentRoom = roomNumber;

        if (bathroomEventRoutine != null && currentRoom != 2)
        {
            StopCoroutine(bathroomEventRoutine);
            bathroomEventRoutine = null;
        }

        UpdateMusicForRoom();

        if (roomNumber == 1)//main dinning
        {
            room1.SetActive(true);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(false);
            kitchenBackroom.SetActive(false);
            coatRoom.SetActive(false);
            foyer.SetActive(false);
            mainCamera.transform.position = new Vector3(room1.transform.position.x, room1.transform.position.y, cameraZPosition);

        }
        else if (roomNumber == 2)//bathroom
        {
            room1.SetActive(false);
            room2.SetActive(true);
            room3.SetActive(false);
            bar.SetActive(false);
            kitchenBackroom.SetActive(false);
            coatRoom.SetActive(false);
            foyer.SetActive(false);
            mainCamera.transform.position = new Vector3(room2.transform.position.x, room2.transform.position.y, cameraZPosition);


            events.PlayOneShot(musicEvent);

            //if (bathroomEventRoutine == null)
                //bathroomEventRoutine = StartCoroutine(BathroomEventLoop());
        }
        else if (roomNumber == 3) //kitchen
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(true);
            bar.SetActive(false);
            kitchenBackroom.SetActive(false);
            coatRoom.SetActive(false);
            foyer.SetActive(false);
            mainCamera.transform.position = new Vector3(room3.transform.position.x, room3.transform.position.y, cameraZPosition);

            backgroundAmbiance.Pause();
            dinerMusic.Pause();

            backgroundAmbiance.clip = Ambiance;
            dinerMusic.clip = music;

            backgroundAmbiance.Play();
            dinerMusic.Play();

            events.PlayOneShot(waterDrip);

        }
        else if (roomNumber == 4)//bar
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(true);
            kitchenBackroom.SetActive(false);
            coatRoom.SetActive(false);
            foyer.SetActive(false);
            mainCamera.transform.position = new Vector3(-25f, bar.transform.position.y, cameraZPosition);


            events.PlayOneShot(glassClink);
        }
        else if (roomNumber == 6) //backroom
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(false);
            kitchenBackroom.SetActive(true);
            coatRoom.SetActive(false);
            foyer.SetActive(false);
            mainCamera.transform.position = new Vector3(kitchenBackroom.transform.position.x, kitchenBackroom.transform.position.y, cameraZPosition);

            backgroundAmbiance.Pause();
            dinerMusic.Pause();

            dinerMusic.clip = conveyorBelt;
            backgroundAmbiance.clip = robotArmMovement;

            dinerMusic.Play();
            backgroundAmbiance.Play();

            events.PlayDelayed(2f);
            events.PlayOneShot(windows95);


        }
        else if (roomNumber == 7)//coat room
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(false);
            kitchenBackroom.SetActive(false);
            coatRoom.SetActive(true);
            foyer.SetActive(false);
            mainCamera.transform.position = new Vector3(coatRoom.transform.position.x, coatRoom.transform.position.y, cameraZPosition);

            events.PlayOneShot(squeakydoor);

        }
        else if (roomNumber == 8)//foyer
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(false);
            bar.SetActive(false);
            kitchenBackroom.SetActive(false);
            coatRoom.SetActive(false);
            foyer.SetActive(true);
            mainCamera.transform.position = new Vector3(foyer.transform.position.x, foyer.transform.position.y, cameraZPosition);

            events.PlayOneShot(bellDing);


        }

        UpdateButtons();

        yield return StartCoroutine(FadeFromBlack());

        IsTransitioning = false;
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
        if (mapManager != null) mapManager.RefreshMap();
    }
}
