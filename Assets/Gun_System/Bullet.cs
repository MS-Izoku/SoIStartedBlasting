using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Messaging;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [HideInInspector] public Transform originalParent;
    public FeedbackObject feedbackObj;
    public float lifeTime = 1f;
    public float bulletForce = 20f;
    public float bulletDamage = 1f;
    private bool firstEnable = true;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
    }

    private void OnEnable()
    {
        if (firstEnable)
        {
            firstEnable = false;
            return;
        }
        
        LaunchProjectile();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10) // layer 10 should be "Enemy"
        {
            collision.gameObject.GetComponent<TakeDamage>().DealDamage(bulletDamage);
        }

        if(collision.gameObject.tag != "Player")
        AmmoPool.Pull(this);

        Instantiate(feedbackObj, collision.contacts[0].point, Quaternion.identity, null);
    }

    private IEnumerator ReturnIfNotCollidedWith()
    {
        yield return new WaitForSeconds(lifeTime);
        AmmoPool.Pull(this);
        yield return null;
    }


    public virtual void LaunchProjectile()
    {
        rb.AddForce(ShootingController.mainCam.transform.rotation * Vector3.forward * bulletForce);
        StartCoroutine(ReturnIfNotCollidedWith());
    }
}
