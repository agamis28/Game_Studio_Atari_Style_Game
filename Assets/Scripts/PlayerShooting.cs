using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[Header("** References **")]
	public GameObject bulletPrefab;

	[Header("** Stats **")]
	public float timeBetweenShots = 0.4f;
	private float currentShotsTimer = 0;
	//private bool canShoot;
	private bool shootButtonDown;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		// Get space button input
		shootButtonDown = Input.GetButton("Jump");

		// Update timer
		currentShotsTimer += Time.deltaTime;

		// If press shoot button
        if (shootButtonDown)
        {
			// Only shoot if its been more than time between shots
            if (currentShotsTimer >= timeBetweenShots)
            {
				// Spawn new bullet
				Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
				// Reset Timer
				currentShotsTimer = 0;
            }
        }

    }
}
