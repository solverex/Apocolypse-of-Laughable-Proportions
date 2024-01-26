using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] AudioSource aS;

    [SerializeField] TMP_Text waveTxt;
    [SerializeField] TMP_Text secretTxt;

    private float timerr;

    void Start()
    {
        currentwave = -1;
        WaveActive = true;
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

                aS.Play();

                currentwave += 1;

                if (currentwave != 10)
                {
                    waveTxt.text = "Wave " + (currentwave + 1);
                    secretTxt.text = "Aran is Comin...";
                }

                WaveActive = false;
            }
        }

        if (timer <= 0 && !WaveActive)
        {
            if (currentwave != waves.Length)
            {
                currentnumberofenemies = waves[currentwave].numberofbasicenemy;
                currentspawnrate = waves[currentwave].spawnrate;
                waveTxt.text = "";
                secretTxt.text = "";
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
