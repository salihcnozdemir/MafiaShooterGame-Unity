using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatFollow : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ExampleCoroutine()
    {
        m_Rigidbody.velocity = transform.forward * 40;
        yield return new WaitForSeconds(1);


    }
}
