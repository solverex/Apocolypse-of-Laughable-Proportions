using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavemanager : MonoBehaviour
{
    [System.Serializable]
    public class wave
    {
        public int numberofbasicenemy;
        public float spawnrate;
    }

    public wave[] waves;

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

        if (currentnumberofenemies <= 0 && WaveActive)
        {
            timer = timebetweenwaves;

            currentwave += 1;

            WaveActive = false;
        }

        if (timer <= 0 && !WaveActive)
        {
            currentnumberofenemies = waves[currentwave].numberofbasicenemy;
            currentspawnrate = waves[currentwave].spawnrate;
            WaveActive = true;
        }

        if (WaveActive)
        {
            timer = 10000000000000000000000000000f;
        }
    }
}
