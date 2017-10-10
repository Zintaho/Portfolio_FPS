using UnityEngine;
using System.Collections;

public class KnifeCtrl : MonoBehaviour
{
    public int damage = 0;

    private Animator knifeAnimator;
    //private AudioSource knifeAudio;
    private float fireRate = 1f;
    private float curTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        knifeAnimator = GetComponent<Animator>();
        //knifeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            if (TimeCheck())
            {
                Attack();
            }
        }
    }


    void Attack()
    {
        knifeAnimator.SetTrigger("Attack");
    }
    

    bool TimeCheck()
    {
        curTime += Time.deltaTime;

        if (curTime >= fireRate)
        {
            curTime = 0.0f;

            damage = 1;
            return true;
        }
        damage = 0;
        return false;
    }
}
