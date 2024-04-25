using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 lastCheckpointPos;

    void Start()
    {
        // Setze den Start-Checkpoint
        lastCheckpointPos = transform.position;
    }

    public void SetCheckpoint(Vector3 checkpointPos)
    {
        // Setze den neuen Checkpoint
        lastCheckpointPos = checkpointPos;
    }

    public Vector3 GetLastCheckpoint()
    {
        // Gib die Position des letzten Checkpoints zurück
        return lastCheckpointPos;
    }
}
