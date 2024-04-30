using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Checkpoint triggered!");
    if (collision.CompareTag("Player"))
    {
        GameMaster.lastCheckPointPos = transform.position;
    }
}

}
