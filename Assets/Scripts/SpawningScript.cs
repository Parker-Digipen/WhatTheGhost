using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject enemy;
    public float timer = 2f;
    float timerperm = 0;
    public int wave = 3;
    // Start is called before the first frame update
    void Start()
    {
        timerperm = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            for (int i = wave; i < wave; i++)
            {
                SpawnWave(i);
                timer = timerperm;
            }
        }
    }

    public void SpawnWave(int amount)
    {
            Vector3 spawnpos = Vector3.zero;
            Instantiate(enemy,spawnpos,transform.rotation);
    }
}
