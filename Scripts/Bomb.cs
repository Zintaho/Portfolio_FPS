using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject poisonEffect;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ENEMY")
        {
            GameObject effect = (GameObject)Instantiate(poisonEffect);
            effect.transform.SetParent(collision.collider.transform, false);

            Destroy(gameObject);

        }
        else
        {
            Destroy(gameObject, 2f);
        }
    
    }
}
