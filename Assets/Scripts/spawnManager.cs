using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    [Header("** Spawners **")]
    [SerializeField] private DuckNPCSpawner spawnerLeft;
    [SerializeField] private DuckNPCSpawner spawnerRight;

    private float currentSpawnerTimer;
    private float leftSpawnerTime = 150;
    private float rightSpawnerTime = 250;

    void Update()
    {
        // Grabs the game run time
        currentSpawnerTimer = Time.time;

        // Checks if we have both spawners set
        if(spawnerLeft != null && spawnerRight != null)
        {
            if(currentSpawnerTimer >  leftSpawnerTime)
            {
                // When timer reaches 'leftSpawnerTime' turn on the left spawner
                spawnerLeft.enabled = true;
            }

            if(currentSpawnerTimer > rightSpawnerTime)
            {
                // When timer reaches 'rightSpawnerTime' turn on the right spawner
                spawnerRight.enabled = true;
            }
        }
        else
        {
            // Protects game from crashing if spawners aren't assigned
            Debug.LogWarning("Assign spawners for Spawn Manager");
        }
    }
}
