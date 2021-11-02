using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public string scene = "End Screen";
    ParticleSystem t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<ParticleSystem>();
        t.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.EnemyCount <= 0) {
            t.Play();
        }
        else {
            t.Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(GameManager.EnemyCount <= 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
