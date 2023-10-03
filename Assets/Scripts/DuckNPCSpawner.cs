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

    [Header("** Spawn Amount **")]
    public float spawnAmount = 1;
    public float amountMaxTime = 90;
    public float amountTimer;

    [Header("** Spawn At Start **")]
    [SerializeField]
    private bool spawnAtStart = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNPC();
    }

    // Update is called once per frame
    void Update()
    {
        // Setting timers
        speedTimer += Time.deltaTime;
        amountTimer += Time.deltaTime;

       
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
}
