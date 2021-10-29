using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    GameObject[] enemies;
    int numEnemies;
    TMP_Text el;
    
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemyTwo");
        numEnemies = enemies.Length;
        el = GetComponent<TMP_Text>();

        ChangeText();
        GameManager.onEnemy.AddListener(ChangeText);
    }
    public void ChangeText()
    {
        el.text = "Enemies Left: " + GameManager.EnemyCount;
    }
}
