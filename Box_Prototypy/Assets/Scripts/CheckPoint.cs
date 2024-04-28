using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision){
    if (collision.transform.tag == "Player"){
        GameMaster.lastCheckPointPos = transform.position;
    }
   }
}
