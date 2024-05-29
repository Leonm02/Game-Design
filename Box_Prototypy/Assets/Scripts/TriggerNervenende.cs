using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TriggerNervenende : MonoBehaviour
{
    public GameObject popupPunishmentTimePrefab;
    public Text textObject;
    public Transform canvasTransform;
    public GameObject alarmScreen;
    public AudioClip collisionSound;  // Reference to the AudioClip for collision sound

    private AudioSource audioSource;  // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Timer_Text").GetComponent<Text>();
        canvasTransform = GameObject.Find("In-Game UI").transform;
        audioSource = GetComponent<AudioSource>();  // Get the AudioSource component

        // Debugging: Check if the AudioSource is assigned
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
        }

        alarmScreen.SetActive(false); // Ensure the alarm screen is initially inactive
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollisionOrTrigger();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollisionOrTrigger();
    }

    private void HandleCollisionOrTrigger()
    {
        // Play the collision sound
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }

        else
        {
            if (audioSource == null)
            {
                Debug.LogError("audioSource is null.");
            }
            if (collisionSound == null)
            {
                Debug.LogError("collisionSound is not assigned.");
            }
        }

        // Example: Get and output the position of the text object
        Vector3 textPosition = textObject.transform.position;
        textPosition.x -= 0.8f;
        textPosition.y -= 0.8f;
        Timer.currentTime -= 5f;

        // Create and add the popup to the canvas as a child
        GameObject popup = Instantiate(popupPunishmentTimePrefab, textPosition, Quaternion.identity);
        popup.transform.SetParent(canvasTransform, false);

        // Start the coroutine to blink the alarm screen
        StartCoroutine(BlinkAlarmScreen(3, 0.2f));
    }

    private IEnumerator BlinkAlarmScreen(int blinkCount, float blinkDuration)
    {
        for (int i = 0; i < blinkCount; i++)
        {
            alarmScreen.SetActive(true);
            yield return new WaitForSeconds(blinkDuration);
            alarmScreen.SetActive(false);
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
