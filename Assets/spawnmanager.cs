using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    [SerializeField] Transform[] SpawnPoints;
    [SerializeField] GameObject basicenemy;

    wavemanager _Waves;

    [SerializeField] int rng;
    [SerializeField] float spawntimer;


    void Start()
    {
        _Waves = GetComponent<wavemanager>();
        SpawnPoints = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Waves.WaveActive)
        {
            spawntimer -= Time.deltaTime;

            if (spawntimer <= 0)
            {
                rng = Random.Range(1, SpawnPoints.Length);

                GameObject t = Instantiate(basicenemy, SpawnPoints[rng].transform.position, Quaternion.identity);

                _Waves.currentnumberofenemies -= 1;

                spawntimer = _Waves.currentspawnrate;
            }
        }
    }
}
