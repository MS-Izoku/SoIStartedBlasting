using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private static float health = 100;
    public static void Health(float value)
    {
        health -= value;
        CheckDead();
    }

    private static void CheckDead()
    {
        if(health < 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
