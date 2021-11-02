using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    GameObject[] enemies;
    public string playerTag = "Kirito";
    public string enemyTag = "EnemyTwo";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameManager.EnemyCount = enemies.Length;
        if(GameObject.FindGameObjectWithTag(playerTag) != null)
            GameManager.PlayerHP = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Health>().CurrentHealth;
    }
}
