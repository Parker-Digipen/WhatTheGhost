using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighlightText : MonoBehaviour
{
    TMP_Text word;

    // Start is called before the first frame update
    void Start()
    {
        word = GetComponent<TMP_Text>();
        ChangeText();
        GameManager.onTyped.AddListener(ChangeText);
    }

    public void ChangeText()
    {
        word.text = GameManager.Typed;
    }
}
