using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCtrl : MonoBehaviour
{
    AudioSource audioSource;
    Transform tf;
    Transform tfPlayer;
    NavMeshAgent nvAgent;

    public int MAX_HP = 5;
    public float checkRate = 0.5f;

    private int CUR_HP;
    private float curTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        tf = GetComponent<Transform>();
        tfPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = GetComponent<NavMeshAgent>();

        CUR_HP = MAX_HP;

        nvAgent.destination = tfPlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeCheck())
        {
            nvAgent.destination = tfPlayer.position;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        int damage = 1;

        if (collision.collider.tag == "BULLET")
        {
            audioSource.Play();

            damage = collision.collider.GetComponent<Bullet>().damage;

        }
        else if(collision.collider.tag == "KNIFE")
        {
            damage = collision.collider.GetComponent<KnifeCtrl>().damage;
            if(damage > 0)
            {
                collision.collider.GetComponent<KnifeCtrl>().GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            damage = 0;
        }

        float chunk = damage * 1.0f;

        CUR_HP -= damage;

        if (chunk > MAX_HP)
        {
            chunk = MAX_HP;
        }

        if (CUR_HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    bool TimeCheck()
    {
        curTime += Time.deltaTime;

        if (curTime >= checkRate)
        {
            curTime = 0.0f;
            return true;
        }

        return false;
    }
}
