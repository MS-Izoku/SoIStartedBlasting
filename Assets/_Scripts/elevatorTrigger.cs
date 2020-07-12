using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoLevel;
public class elevatorTrigger : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            anim.SetTrigger("Close");
        }
    }

    

    public void NextLevel()
    {
        LevelInfo.Loader.SetNextLevel();
    }
}
