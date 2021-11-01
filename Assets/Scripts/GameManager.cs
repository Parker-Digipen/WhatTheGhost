using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static string _word = "YEET";
    private static string _typed = "";
    private static int _enemiesLeft = 0;
    private static int _playerHealth = 1;

    public static string[] possible = {"ABRA", "KADABRA", "ZOOP", "SHOOM", "POP", "PEW", "WHAM", "KAZAM", "BLAM", "ZAP", "BLAM", "KACHOW", "ZEW"};
    public static UnityEvent onWordChange = new UnityEvent();
    public static UnityEvent onTyped = new UnityEvent();
    public static UnityEvent onEnemy = new UnityEvent();
    public static UnityEvent onHealth = new UnityEvent();

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

    public static string Typed
    {
        get
        {
            return _typed;
        }
        set
        {
            _typed = value;
            onTyped.Invoke();
        }
    }

    public static int PlayerHP
    {
        get
        {
            return _playerHealth;
        }
        set
        {
            _playerHealth = value;
            onHealth.Invoke();
        }
    }

    public static int EnemyCount
    {
        get
        {
            return _enemiesLeft;
        }
        set
        {
            _enemiesLeft = value;
            onEnemy.Invoke();
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
