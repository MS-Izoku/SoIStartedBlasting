using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoLevel;

public class TakeDamage : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        if (anim != null)
        {
            health = anim.GetFloat("MaxHealth");
        }
        else
            health = 100f;
    }
    private void OnEnable()
    {
        health = 100;
    }


    public void DealDamage(float damage)
    {
        if(anim != null)
        {
            anim.SetFloat("Health", anim.GetFloat("Health") - damage);
        }
        else
        {
            health -= damage;
            if (health < 0)
            {
               if(LevelInfo.AdjustSpawners(-1))
                {
                    NextLevel.ClearLevel();
                    LevelInfo.CurrentLevel += 1;
                    LevelInfo.Spawners = 4;
                    LevelInfo.Loader.BringElevator();
                }
                this.gameObject.SetActive(false);
            }
        }
    }

}
