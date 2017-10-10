using UnityEngine;
using System.Collections;

public class GunTest : MonoBehaviour
{
    public float explosionForce;
    public Transform explosionPoint;
    public float explosionRadius;
    public float upwardsModifier;


    private Rigidbody rbGun;
    // Use this for initialization
    void Start()
    {
        rbGun = GetComponent<Rigidbody>();

        rbGun.AddExplosionForce(explosionForce, explosionPoint.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
    }
}
