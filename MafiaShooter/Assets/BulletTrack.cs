using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrack : MonoBehaviour
{
    Rigidbody m_Rigidbody;
  
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
      
       
        m_Rigidbody.velocity = transform.forward * 100;
    }
}
