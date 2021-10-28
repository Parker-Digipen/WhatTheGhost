using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseText : MonoBehaviour
{
    public TMP_Text word;

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
        word.rectTransform.sizeDelta = new Vector2(word.preferredWidth, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
