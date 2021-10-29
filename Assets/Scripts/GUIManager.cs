using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemyTwo");
        GameManager.EnemyCount = enemies.Length;

        GameManager.PlayerHP = GameObject.FindGameObjectWithTag("Kirito").GetComponent<Health>().CurrentHealth;
    }
}
