using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    int health;
    TMP_Text HP;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = GetComponent<TMP_Text>();

        ChangeText();
        GameManager.onHealth.AddListener(ChangeText);
    }
    public void ChangeText()
    {
        HP.text = "Health: " + GameManager.PlayerHP;
    }
}
