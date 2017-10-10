using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    public GameObject particle;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "BULLET")
        {
            GameObject spark = (GameObject) Instantiate(particle, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

            Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);
        }
    }
}
