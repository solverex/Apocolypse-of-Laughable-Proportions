using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wavemanager : MonoBehaviour
{
    [System.Serializable]
    public class wave
    {
        public int numberofbasicenemy;
        public float spawnrate;
    }

    public wave[] waves;
    private GameObject[] enemies;

    [SerializeField] int currentwave;
    public int currentnumberofenemies;
    public float currentspawnrate;
    [SerializeField] float timebetweenwaves;

    public bool WaveActive;

    float timer;

    void Start()
    {
        currentwave = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies == null)
        {
            return;
        }

        if (currentnumberofenemies <= 0 && WaveActive)
        {
            if (currentwave != waves.Length)
            {
                timer = timebetweenwaves;

                currentwave += 1;

                WaveActive = false;
            }
        }

        if (timer <= 0 && !WaveActive)
        {
            if (currentwave != waves.Length)
            {
                currentnumberofenemies = waves[currentwave].numberofbasicenemy;
                currentspawnrate = waves[currentwave].spawnrate;
                WaveActive = true;
            }
        }

        if (currentwave == waves.Length)
        {
            if (enemies.Length == 0)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (WaveActive)
        {
            timer = 10000000000000000000000000000f;
        }
    }
}
