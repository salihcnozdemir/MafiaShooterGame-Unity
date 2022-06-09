using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des : MonoBehaviour
{
    public float sn;
    void Start()
    {
        Destroy(gameObject, sn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
