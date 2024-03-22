using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Character"); //  player
    }

    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0, player.transform.position.z - 1000);
    }
}
