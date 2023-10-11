using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DuckNPCSpawner : MonoBehaviour
{
	[Header("** NPC Prefab **")]
	public GameObject npcDuck;

	[Header("** Spawn Area Width **")]
    [SerializeField] private float spawnWidth;

	[Header("** Spawn Speed **")]
	[SerializeField] private float spawnSpeed = 8;
    [SerializeField] private float speedMaxTime = 15;
	[SerializeField] private float spawnSpeedDecrement = .1f;
	[SerializeField] private float speedTimer;

	[Header("** Spawning **")]
	private Vector3 randomNPCPosition;
    [SerializeField] private float spawnTimer;

	[Header("** Spawn Amount **")]
    [SerializeField] private float spawnAmount = 1;
    [SerializeField] private float amountMaxTime = 90;
    //public float spawnAmountIncrement = 1;
    [SerializeField] private float amountTimer;

	[Header("** Options **")]
	[SerializeField] private bool spawnAtStart = false;
	[SerializeField] private bool showSpawnLine = false;
	[SerializeField] private bool spawnVertically;

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

		// Spawn in an NPC when conditions and timers are met
		CheckSpawningConditions();

		// If 'showWidthLine option is on show debug lines
		VisualiseWidth();
	}

	// Get new random position within width and then spawn a NPC prefab
	public void SpawnNPC()
	{
		// Chooses random position horizontally when 'spawnVertically' is false
		if (!spawnVertically)
		{
            // Chooses random position within width
            randomNPCPosition = new Vector3(Random.Range(-spawnWidth / 2, spawnWidth / 2), transform.position.y, 0);
		}
		else
		{
			// Chooses random position vertically when 'spawnVertically' is true
			randomNPCPosition = new Vector3(transform.position.x, Random.Range(-spawnWidth / 2, spawnWidth / 2), 0);
		}

		if (npcDuck != null)
		{
            Instantiate(npcDuck, randomNPCPosition, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Needs a Duck Prefab");
        }
			
	}

	// Spawn in an NPC when conditions and timers are met
	public void CheckSpawningConditions()
	{
		// When 'spawnTimer' reaches 'spawnSpeed' spawn in 'spawnAmount' of NPCs
		if (spawnTimer >= spawnSpeed)
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
		if (speedTimer >= speedMaxTime)
		{
			spawnSpeed -= spawnSpeedDecrement;

			// Reset 'speedTimer'
			speedTimer = 0;
		}

		// Increase the amount spawned in when reached 'amountMaxTime'
		if (amountTimer > amountMaxTime)
		{
			spawnAmount++;

			// Reset 'amountTimer'
			amountTimer = 0;
		}
	}

	// Visualise the width line with a debug line
	public void VisualiseWidth()
	{
		// Draw a debug line when showSpawnLine is true
		if (showSpawnLine)
		{
			if (!spawnVertically)
			{
                Debug.DrawLine(new Vector3(-spawnWidth / 2, transform.position.y, 0), new Vector3(spawnWidth / 2, transform.position.y, 0), Color.red);
            }
			else
			{
                Debug.DrawLine(new Vector3(transform.position.x, -spawnWidth / 2, 0), new Vector3(transform.position.x, spawnWidth / 2, 0), Color.red);
            }
		}
	}
}
