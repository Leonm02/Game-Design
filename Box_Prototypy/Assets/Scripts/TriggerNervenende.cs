using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerNervenende : MonoBehaviour
{
    public GameObject popupPunishmentTimePrefab;
    public Text timerText;
    public Text textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Timer_Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 

        // Beispiel: Position des Textobjekts abrufen und ausgeben
        Vector3 textPosition = textObject.transform.position;
        textPosition.x -= 0.8f;
        textPosition.y -= 0.8f;
        Timer.currentTime -= 5f;
        Instantiate(popupPunishmentTimePrefab, textPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Beispiel: Position des Textobjekts abrufen und ausgeben
        Vector3 textPosition = textObject.transform.position;
        textPosition.x -= 0.8f;
        textPosition.y -= 0.8f;
        Timer.currentTime -= 5f;
        Instantiate(popupPunishmentTimePrefab, textPosition , Quaternion.identity);
    }
}
