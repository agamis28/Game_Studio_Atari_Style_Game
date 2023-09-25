using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
	[Header("** References **")]
	public GameObject bulletPrefab;
	public GameObject player;

	[Header("** Stats **")]
	public float timeBetweenShots = 0.4f;
	private float currentShotsTimer = 0;
	//private bool canShoot;
	private bool shootButtonDown;

	[Header("** Points **")]
	public int pointCount = 0;
	public Text displayedPointCount;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		// Get space button input
		shootButtonDown = Input.GetButton("Jump");

		// Update timer
		currentShotsTimer += Time.deltaTime;

		ShootIfDown();
		DisplayScore();
    }

	public void ShootIfDown()
	{
        // If press shoot button
        if (shootButtonDown)
        {
            // Only shoot if its been more than time between shots
            if (currentShotsTimer >= timeBetweenShots)
            {
                // Spawn new bullet
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                // Set rotation of the bullet to the players rotation at moment of shot
                bullet.transform.rotation = player.transform.rotation;
                bullet.GetComponent<PooCollison>().playerShooting = this;
                // Reset Timer
                currentShotsTimer = 0;
            }
        }
    }

	public void DisplayScore()
	{
		displayedPointCount.text = pointCount.ToString();
	}
}
