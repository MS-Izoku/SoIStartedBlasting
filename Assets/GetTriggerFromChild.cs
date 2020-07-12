using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used in tandem with TriggerParentEffect
public class GetTriggerFromChild : MonoBehaviour
{
    public virtual void DoEffect(Collider other)
    {
        Debug.Log("Doing an Effect!");
    }
}
