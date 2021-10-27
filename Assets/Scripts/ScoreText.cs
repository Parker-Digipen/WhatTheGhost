using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TMP_Text word;

    // Start is called before the first frame update
    void Start()
    {
        word = GetComponent<TMP_Text>();
        ChangeText();
        GameManager.onWordChange.AddListener(ChangeText);
    }

    public void ChangeText()
    {
        word.text = GameManager.Word;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
