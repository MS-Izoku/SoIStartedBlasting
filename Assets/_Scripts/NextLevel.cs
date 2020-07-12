using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public static void ClearLevel()
    {
        
        GameObject[] remove = FindObjectsOfType<GameObject>();
        foreach (var rid in remove)
        {
            if(rid.tag == "Boom" || rid.tag == "Launcher" || rid.tag == "Blocker")
            {
                rid.GetComponent<BackToPool>().ReturnToPool();
            }
        }
    }
}
