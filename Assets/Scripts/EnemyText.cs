using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyText : MonoBehaviour
{
    TMP_Text el;
    
    // Start is called before the first frame update
    void Start()
    {
        el = GetComponent<TMP_Text>();

        ChangeText();
        GameManager.onEnemy.AddListener(ChangeText);
    }
    public void ChangeText()
    {
        el.text = "Enemies Left: " + GameManager.EnemyCount;
    }
}
