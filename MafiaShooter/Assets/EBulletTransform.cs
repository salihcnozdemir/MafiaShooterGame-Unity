using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletTransform : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
