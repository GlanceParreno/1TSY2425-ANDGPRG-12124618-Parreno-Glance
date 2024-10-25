using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0;
    public GameObject groundMonsterPrefab;
    public GameObject flyingMonsterPrefab;
    public GameObject bossMonsterPrefab;

    public void StartNextWave()
    {
        currentWave++;
        // Spawn monsters based on wave count
    }
}
