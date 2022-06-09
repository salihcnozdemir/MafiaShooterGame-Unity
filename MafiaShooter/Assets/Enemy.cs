using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator myAnim;
    List<Rigidbody> ragdollRigids;
    public GameObject hat,h,gun;
    bool dead;


    public Transform target;
    public GameObject bullet;
    public GameObject Player;
    public Transform Gun;
    public float health = 100f;
    public void damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    public bool Attackb= false;
    int randomAttack = 0;
    bool fs=false;



    void Death()
    {
        dead = true;

        Hat H = h.transform.GetComponent<Hat>();
        H.dead();
        EnemyGun G = gun.transform.GetComponent<EnemyGun>();
        G.Playy();

        if (hat !=null)
            hat.SetActive(false);



        activateRagdoll();
        

    }

    //Update

    void Start()
    {
        myAnim = GetComponent<Animator>();
        ragdollRigids = new List<Rigidbody>(transform.GetComponentsInChildren<Rigidbody>());
        ragdollRigids.Remove(GetComponent<Rigidbody>());
        DeactivateRagdoll();
        

    }


    void Update()
    {
        if(!fs)
            fs = GameObject.Find("Player").GetComponent<SnipperButton>().firstShoot;


        if (!dead && fs)
            LookTarget();


    }
    public void LookTarget()
    {
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
        Attack();
    }
    public void Attack()
    {
        myAnim.SetBool("Attack", true);
        if (Attackb)
        {
            StartCoroutine(ExampleCoroutine());
            Attackb = false;
        }
      
    }
    IEnumerator ExampleCoroutine()
    {

        int randnum = Random.Range(1, 6);
        yield return new WaitForSeconds(randnum);
        if (!dead)
        {
            GameObject ssaa = Instantiate(bullet, Gun.transform.position, Gun.transform.rotation);

        }
        Attackb = false;
        int randnumm = Random.Range(1, 6);
        yield return new WaitForSeconds(randnumm);
        Attackb = true;
        
    }
    //Ragdoll dependencies.

    public void activateRagdoll()
    {
        myAnim.enabled = false;
        for (int i = 0; i < ragdollRigids.Count; i++)
        {
            ragdollRigids[i].useGravity = true;
            ragdollRigids[i].isKinematic = false;
        }
    }

    public void DeactivateRagdoll()
    {
        myAnim.enabled = true;
        for (int i = 0; i < ragdollRigids.Count; i++)
        {
            ragdollRigids[i].useGravity = false;
            ragdollRigids[i].isKinematic = true;
        }
    }
}
