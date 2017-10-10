using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rigidBody;
    private Transform tf;

    public int damage = 20;
    public float speed = 1000.0f;
    
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        tf = GetComponent<Transform>();
        audioSource.Play();

        rigidBody.AddForce(tf.forward * speed , ForceMode.Impulse);

       
        
    }

    public void OnCollisionEnter(Collision collision)
    {
       // Destroy(gameObject);
    }

}
