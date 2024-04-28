using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    private static GameMaster instance;
    public static Vector2 lastCheckPointPos = new Vector2 (-8,-2);

    void Awake()
    {
        isGameOver = false;

        // Finde alle GameObjects mit dem Tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Setze die Position aller gefundenen Player-Objekte auf den letzten Checkpoint
        foreach (GameObject player in players)
        {
            player.transform.position = lastCheckPointPos;
        }

        Debug.Log("GameMaster Awake method called.");
        Debug.Log("Last checkpoint position: " + lastCheckPointPos);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}