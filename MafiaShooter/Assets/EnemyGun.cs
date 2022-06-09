using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject Gun;
    public GameObject GunPrefab;
    public void Playy()
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        
        yield return new WaitForSeconds(0.2f);
        Gun.SetActive(false);
        GameObject sa = Instantiate(GunPrefab, this.transform.position, this.transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
