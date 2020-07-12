using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPool : MonoBehaviour
{
    public void ReturnToPool()
    {
        ObjectPooler.Instance.AddBackToPool(this.gameObject, this.gameObject.tag.ToString());
        this.gameObject.GetComponent<Animator>().SetFloat("Health", this.gameObject.GetComponent<Animator>().GetFloat("MaxHealth"));

    }
}
