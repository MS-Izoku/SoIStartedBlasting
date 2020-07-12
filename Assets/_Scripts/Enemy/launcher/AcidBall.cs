using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBall : MonoBehaviour
{
    public float Damage = 10f;
    public float speed = 10f;
    public float heightChange = -5f;
    private float heightAdjust = 4;

    // Update is called once per frame
    void Update()
    {
        heightAdjust += heightChange * Time.deltaTime;
        Vector3 move = transform.forward * speed;
        move.y += heightAdjust;
        transform.position += move * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.layer)
        {
            
            case 9:
                PlayerHealth.Health(Damage);
                break;

            case 10:
                collision.gameObject.GetComponent<TakeDamage>().DealDamage(-Damage);
                break;
            default:
                Destroy(this.gameObject);
                break;
        }        
    }
}


