using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static string _word = "TEXT";
    public static UnityEvent onWordChange = new UnityEvent();

    public static string Word
    {
        get
        {
            return _word;
        }
        set
        {
            _word = value;
            onWordChange.Invoke();
        }
    }

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            //check if game manager exists, make one if not

            return _instance;
        }
    }
    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
