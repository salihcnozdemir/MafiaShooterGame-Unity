using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnipperButton : MonoBehaviour
{
    public GameObject MCamera;
    public bool ZoomCamera = false;
    private float waitTime=0;
    public GameObject bir;
    public GameObject iki;
    public Image image;
    float newAlpha;

    Animator anim;
    Animator MainCameraAnim;

    public bool strt,takeAim = false;
    float reloadBulletTime = 1;
    public GameObject bulletTrack;
    public GameObject a;
    public GameObject b,d;
    public GameObject c;
    public bool firstShoot = false;



    int bullets = 4;
    public Image BulletsImage;
    float reloadMagTime = 2.5f;
    public GameObject reloadMagSound;
    bool reloadd = false;
    void Start()
    {
        MCamera = GameObject.Find("Main Camera");
        anim = gameObject.GetComponent<Animator>();
        MainCameraAnim = MCamera.GetComponent<Animator>();
        //int a = GameObject.Find(targetCameraName).GetComponent<PlayerCont>().GunValue;
    }
    private void FixedUpdate()
    {
        
        if(bullets < 1)
        {
            reload();
        }
    }
    void Update()
    {
        BulletsImage.fillAmount = bullets * 0.25f;
        if (ZoomCamera)
        {
            reloadBulletTime += Time.deltaTime;
            waitTime = 0;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 30, 8 * Time.deltaTime);
            image.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            iki.SetActive(true);
            anim.SetBool("CharTurn", true);
            
            if (Camera.main.fieldOfView <= 31 && Camera.main.fieldOfView >= 29 && !takeAim)
            {
                strt = true;
                ZoomCamera = false;
            }
        }
        else
        {
            waitTime += Time.deltaTime;

            reloadBulletTime += Time.deltaTime;
            if (strt && reloadBulletTime >= 1 && bullets > 0)
            {
                
                SniperShoot();
            }
                

            if (waitTime > 0.8f && !takeAim)
            {
                iki.SetActive(false);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 80, 8 * Time.deltaTime);
                image.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                anim.SetBool("CharTurn", false);
            }
        }
    }
    public void SniperShoot()
    {
        StartCoroutine(ExampleCoroutine());

        strt = false;
    }
    IEnumerator ExampleCoroutine()
    {
        reloadBulletTime = 0;
        MainCameraAnim.SetBool("Shoot", true);
        Fire();
        yield return new WaitForSeconds(0.5f);
        MainCameraAnim.SetBool("Shoot", false);
    }

    void Fire()
    {
        firstShoot = true;
        GameObject fire = Instantiate(bulletTrack, MCamera.transform.position, MCamera.transform.rotation);
        bullets -= 1;
        RaycastHit hit;
        if (Physics.Raycast(MCamera.transform.position, MCamera.transform.forward, out hit, 30))
        {
            Debug.Log(hit.transform.name);

            RagdollParca P = hit.transform.GetComponent<RagdollParca>();
            Hat H = hit.transform.GetComponent<Hat>();
            //Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (hit.transform.tag == "P")
            {
                GameObject sa = Instantiate(a, hit.transform.position, c.transform.rotation);
            }
            if (hit.transform.tag == "Kafa")
            {
                GameObject sa = Instantiate(b, hit.transform.position, c.transform.rotation);
                
            }
            if (hit.transform.tag == "Hat")
            {
                GameObject sa = Instantiate(d, hit.transform.position, c.transform.rotation);

            }
            if (P != null)
            {
                P.dead();
            }
            if (H != null)
            {
                H.dead();
            }
        }
    }
    public void BtnDown()
    {
        if (!reloadd)
        {
            ZoomCamera = true;
            takeAim = true;
        }
     
    }
    public void BtnUp()
    {
        takeAim = false;
    }
    public void reload()
    {
        anim.SetBool("reload", true);
        reloadd = true;
        reloadMagSound.SetActive(true);
        reloadMagTime -= Time.deltaTime;
        if(reloadMagTime <= 0)
        {
            anim.SetBool("reload", false);
            reloadMagSound.SetActive(false);
            bullets = 4;
            reloadMagTime = 2.5f;
            reloadd = false;
        }
    }
  
}
