using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : GroundMonster
{
    private void Start()
    {
        health *= 100; // Boss has higher health
    }
}

