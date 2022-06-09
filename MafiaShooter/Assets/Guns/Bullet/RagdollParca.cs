using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollParca : MonoBehaviour
{
    public GameObject b;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dead()
    {
        Enemy enemy = b.transform.GetComponent<Enemy>();
        enemy.damage(100);
    }
}
