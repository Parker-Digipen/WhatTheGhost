using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject enemy;
    public float timer = 2f;
    float timerperm = 0;
    public int wave = 3;
    public bool startwave = false;
    // Start is called before the first frame update
    void Start()
    {
        timerperm = timer;
        startwave = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            for (int i = 0; i < wave; i++)
            {
                if (startwave == true)
                {
                    SpawnWave(i);
                }
                timer = timerperm;
            }
        }
    }

    public void SpawnWave(int amount)
    {
            Vector3 spawnpos = new Vector3(Random.Range(1,10),Random.Range(1,10),0);
            Instantiate(enemy,spawnpos,transform.rotation);
    }
}
