using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighlightText : MonoBehaviour
{
    public TMP_Text word;
    private BaseText baseWord;

    // Start is called before the first frame update
    void Start()
    {
        word = GetComponent<TMP_Text>();
        baseWord = FindObjectOfType<BaseText>();
        ChangeText();
        GameManager.onTyped.AddListener(ChangeText);
    }

    public void ChangeText()
    {
        word.text = GameManager.Typed;
        word.rectTransform.sizeDelta = baseWord.word.rectTransform.sizeDelta;
        //word.rectTransform.anchoredPosition = new Vector2(0-word.rectTransform.sizeDelta.x/2, 50);
    }
}
