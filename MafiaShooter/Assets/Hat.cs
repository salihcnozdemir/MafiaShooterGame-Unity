using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public GameObject H1,H2;
    public Transform Enemy;
    bool death,kont = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!death)
        {
            this.transform.position = Enemy.transform.position;
            this.transform.rotation = Enemy.transform.rotation;
        }
      
    }

    public void dead()
    {
        
        if (!death&& !kont)
        {
            GameObject sa = Instantiate(H2, this.transform.position, this.transform.rotation);
            H1.SetActive(false);
            kont = true;
            
        }
        
    }
  
}
