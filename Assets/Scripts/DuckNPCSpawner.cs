using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DuckNPCSpawner : MonoBehaviour
{
    [Header("** NPC Prefab **")]
    public GameObject npcDuck;

    [Header("** Spawn Area Width **")]
    public float spawnWidth;

    [Header("** Spawn Speed **")]
    public float spawnSpeed = 8;
    public float speedMaxTime = 15;
    public float spawnSpeedDecrement = .1f;
    public float speedTimer;

    public float spawnTimer;

    [Header("** Spawn Amount **")]
    public float spawnAmount = 1;
    public float amountMaxTime = 90;
    //public float spawnAmountIncrement = 1;
    public float amountTimer;

    [Header("** Spawn At Start **")]
    [SerializeField]
    private bool spawnAtStart = false;

    // Start is called before the first frame update
    void Start()
    {
        // If 'spawnAtStart' is true spawn in an NPC
        if (spawnAtStart)
        {
            SpawnNPC();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Setting timers
        spawnTimer += Time.deltaTime;
        speedTimer += Time.deltaTime;
        amountTimer += Time.deltaTime;

        // When 'spawnTimer' reaches 'spawnSpeed' spawn in 'spawnAmount' of NPCs
       if(spawnTimer >= spawnSpeed)
        {
            // Runs the spawn method 'spawnAmount' times
            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnNPC();
            }
            
            // Reset 'spawnTimer'
            spawnTimer = 0;
        }

       // Increase the speed the NPCs are spawned in when reached 'speedMaxTime'
       if(speedTimer >= speedMaxTime)
        {
            spawnSpeed -= spawnSpeedDecrement;

            // Reset 'speedTimer'
            speedTimer = 0;
        }

       // Increase the amount spawned in when reached 'amountMaxTime'
       if(amountTimer > amountMaxTime)
        {
            spawnAmount++;

            // Reset 'amountTimer'
            amountTimer = 0;
        }

        VisualizeWidth();
    }

    // Get new random position within width and then spawn a NPC prefab
    public void SpawnNPC()
    {
        // Random position within width
        Vector3 randomNPCPosition = new Vector3 (Random.Range(-spawnWidth / 2, spawnWidth / 2), transform.position.y, 0);
        Debug.Log("Range :"+ -spawnWidth/2 + ":" + spawnWidth/2);

        if (npcDuck != null)
        {
            Instantiate(npcDuck, randomNPCPosition, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Needs a Duck Prefab");
        }
    }

    public void VisualizeWidth()
    {
        Debug.DrawLine(new Vector3(-spawnWidth / 2, transform.position.y, 0), new Vector3(spawnWidth / 2, transform.position.y, 0), Color.red);
    }
}
