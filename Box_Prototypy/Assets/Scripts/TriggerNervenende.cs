using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNervenende : MonoBehaviour
{
    public GameObject popupPunishmentTimePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Timer.currentTime -= 5f;
        Instantiate(popupPunishmentTimePrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Timer.currentTime -= 5f;
        Instantiate(popupPunishmentTimePrefab, transform.position, Quaternion.identity);
    }
}
