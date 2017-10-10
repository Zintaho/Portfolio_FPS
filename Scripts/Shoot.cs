using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject Bullet;
    public float Range;

    public float fireDelta = 0.5f;
    public float bulletSpeed = 5f;

    private Vector3 TargetPosition;
    private Vector3 LeftPosition;
    private Vector3 RightPosition;
    
    private GameObject bulletInstance;
    private Rigidbody rbBullet;

    private float curTime = 0.0f;
    private float nextFire = 0.5f;

    // Use this for initialization
    void Start()
    {
       TargetPosition = new Vector3();

        LeftPosition = LeftHand.transform.position;
        RightPosition = RightHand.transform.position;

        Bullet.transform.position = RightPosition;
        Bullet.transform.rotation = RightHand.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        LeftPosition = LeftHand.transform.position;
        RightPosition = RightHand.transform.position;
        TargetPosition
            = new Vector3
            (
                (LeftPosition.x + RightPosition.x) / 2,
                (LeftPosition.y + RightPosition.y) / 2,
                (LeftPosition.z + RightPosition.z) / 2 + Range
            );

        curTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && curTime > nextFire)
        {
            nextFire = curTime + fireDelta;
            bulletInstance = Instantiate(Bullet, RightPosition, RightHand.transform.rotation) as GameObject;
            rbBullet = bulletInstance.GetComponent<Rigidbody>();
            rbBullet.AddForce(TargetPosition * bulletSpeed);

           // create code here that animates the newProjectile        

            nextFire = nextFire - curTime;
            curTime = 0.0F;
        }
          
    }
}
