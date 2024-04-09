using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   
   private static GameMaster instance;
   public Vector2 lastCheckPointPos;

   void Awake(){

  Debug.Log("GameMaster Awake method called.");
  Debug.Log("Last checkpoint position: " + lastCheckPointPos);

    if(instance == null){
        instance = this;
        DontDestroyOnLoad(instance);
    }else{
        Destroy(gameObject);
    }
   }

  
}
