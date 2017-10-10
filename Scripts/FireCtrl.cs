using UnityEngine;
using System.Collections;

public class FireCtrl : MonoBehaviour
{
    public bool isEnemy = false;

    public AudioSource fireAudio;
    public GameObject fireEffect;
    public Animator weaponAnimator;
    public Transform firePos;

    public float weaponRange = 200f;
    public float fireRate = 0.5f;
    private float curTime = 0.0f;

    private int debugCounter = 0;

    RaycastHit hit;

    void Start()
    {
        fireEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if( (Input.GetButton("Fire1") || Input.GetAxis("Fire1") < 0) && !isEnemy) //Right Trigger
        {
            if(TimeCheck())
            {
                Fire();
            }
        }
        else
        {
            fireEffect.SetActive(false);
        }
    }


    void Fire()
    {
        FireRay();
        fireEffect.SetActive(true);
        //weaponAnimator.SetTrigger("GunShot");
        fireAudio.Play();
    }

    public void FireRay()
    {
        Physics.Raycast(firePos.position, firePos.forward, out hit, weaponRange);

        if(hit.collider)
        {
            if (hit.collider.tag == "ENEMY")
            {
                hit.collider.gameObject.GetComponent<AudioSource>().Play();
            }
        }

    }
  

    bool TimeCheck()
    {
        curTime += Time.deltaTime;

        if(curTime >= fireRate)
        {
            curTime = 0.0f;
            return true;
        }

        return false;
    }
}
