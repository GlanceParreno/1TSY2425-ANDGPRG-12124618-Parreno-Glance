using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScaler : MonoBehaviour
{
    public float difficultyMultiplier = 1.1f;

    public void ScaleMonster(Monster monster)
    {
        monster.health *= difficultyMultiplier;
        difficultyMultiplier += 0.1f;
    }
}

