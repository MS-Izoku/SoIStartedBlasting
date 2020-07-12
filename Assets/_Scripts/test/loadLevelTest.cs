using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoLevel;

public class loadLevelTest : MonoBehaviour
{
    public GameObject[] loader;
    private GameObject currentLevel;
    public GameObject elevator;

    private void Awake()
    {
        LevelInfo.Loader = this;
        int rand = Random.Range(0, loader.Length);
        currentLevel = Instantiate(loader[rand], Vector3.zero, Quaternion.identity);
        elevator.SetActive(false);
    }

    public void SetNextLevel()
    {
        int rand = Random.Range(0, loader.Length);
        Destroy(currentLevel);
        currentLevel = Instantiate(loader[rand], Vector3.zero, Quaternion.identity);
        elevator.SetActive(false);
    }

    public void BringElevator()
    {
        elevator.SetActive(true);
        elevator.transform.position = Vector3.up * 1;
        elevator.GetComponent<elevatorTrigger>().anim.SetTrigger("open");
    }
}
