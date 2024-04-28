using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    Vector2 checkpointPos;
    
    void Start()
    {
        checkpointPos = transform.position;
    }

    public void UpdateCheckpoint(Vector2 pos){
        checkpointPos = pos;
    }

}
