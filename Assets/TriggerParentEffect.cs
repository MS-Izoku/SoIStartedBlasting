using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used in tandem with GetTriggerFromChild
public class TriggerParentEffect : MonoBehaviour
{
    public string tagName = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == (tagName == "" ? "Player" : tagName) ) {
            transform.parent.GetComponent<GetTriggerFromChild>().DoEffect(other);
        }
    }
}
