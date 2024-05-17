using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerNervenende : MonoBehaviour
{
    public GameObject popupPunishmentTimePrefab;
    public Text textObject;
    public Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Timer_Text").GetComponent<Text>();
        canvasTransform = GameObject.Find("In-Game UI").transform; 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Beispiel: Position des Textobjekts abrufen und ausgeben
        Vector3 textPosition = textObject.transform.position;
        textPosition.x -= 0.8f;
        textPosition.y -= 0.8f;
        Timer.currentTime -= 5f;

        // Popup erstellen und dem Canvas als Kind hinzufügen
        GameObject popup = Instantiate(popupPunishmentTimePrefab, textPosition, Quaternion.identity);
        popup.transform.SetParent(canvasTransform, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Beispiel: Position des Textobjekts abrufen und ausgeben
        Vector3 textPosition = textObject.transform.position;
        textPosition.x -= 0.8f;
        textPosition.y -= 0.8f;
        Timer.currentTime -= 5f;

        // Popup erstellen und dem Canvas als Kind hinzufügen
        GameObject popup = Instantiate(popupPunishmentTimePrefab, textPosition, Quaternion.identity);
        popup.transform.SetParent(canvasTransform, false);
    }
}
