using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumanasLight : MonoBehaviour
{
    public enum LightType {
        radiant,
        guiding,
        blinding
    }

    public float maxRangeDistance;
    public LightType lightType;

    void OnDrawGizmos(){
        switch(lightType){
            case LightType.guiding:
                Gizmos.color = Color.green;
                break;
            case LightType.radiant:
                Gizmos.color = Color.yellow;
                break;
            case LightType.blinding:
                Gizmos.color = Color.red;
                break;
            default:
                break;
        }

        Vector3 targetPos = transform.position + transform.rotation * (transform.forward * maxRangeDistance);
        
    }
}
