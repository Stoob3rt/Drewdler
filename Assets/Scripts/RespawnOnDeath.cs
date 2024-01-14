

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using HutongGames.Utility;

public class RespawnOnDeath : MonoBehaviour
{
    public Transform startPoint; // The transform of the start point in the level
    public float respawnDelay = 0.1f; // Delay before respawning
    private SpringJoint2D springJoint; // Reference to the SpringJoint2D component
    private bool hasCollided = false; // Flag to track collision with death zone
    private List<GameObject> dynamicallyAddedObjects = new List<GameObject>(); // List to store dynamically added objects
	public TextMeshProUGUI gameOverText;
    private LineCreator lineCreator; // Reference to the LineCreator script
    private Player player;
    [SerializeField] ParticleSystem SparkParticle = null;
    // [SerializeField] ParticleSystem RespawnParticle = null;


    private void Start()
    {
        // Get the reference to the SpringJoint2D component
        springJoint = GetComponent<SpringJoint2D>();
        player = GameObject.FindObjectOfType<Player>();
        lineCreator = FindObjectOfType<LineCreator>(); // Find the LineCreator script in the scene
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            if (!hasCollided)
            {
                hasCollided = true;
                TriggerSparkParticle();
                // TriggerRespawnParticle();
                StartCoroutine(RespawnCoroutine());
            }
        }
    }
    public void RespawnButton()
    {
        TriggerSparkParticle();
        StartCoroutine(RespawnCoroutine());
    }

    private void TriggerSparkParticle()
    {
        // Instantiate the SparkParticle prefab
        SparkParticle.transform.position = player.transform.position;
        SparkParticle.Play();



        // Optionally, you can set the sparkParticle to self-destruct after a certain time
        // Destroy(SparkParticle, 2f); // Replace 2f with the duration you want
    }

    // private void TriggerRespawnParticle()
    // {
        // Set the RespawnParticle's position to match the player's position
    //    RespawnParticle.transform.position = player.transform.position;

        // Play the RespawnParticle
    //    RespawnParticle.Play();
   // }

    private IEnumerator RespawnCoroutine()
{
    // Disable the player's movement
    Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();
    playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

    // Reduce the player's lives by 1
    Player player = GetComponent<Player>();
    if (player != null)
    {
        player.Hit();
        if (player.GetLives() <= 0)
        {
            hasCollided = false; // Reset the collision flag
            yield break; // Exit the coroutine if the player has zero lives
        }
    }

    // If the player still has lives, continue with normal respawn process

    // Disable the SpringJoint2D component to release the player
    springJoint.enabled = false;

    // Wait for the specified delay
    yield return new WaitForSeconds(respawnDelay);

        // Reset the player's position and rotation to the start point
        Vector3 newPosition = new Vector3(startPoint.position.x, startPoint.position.y, transform.position.z);
        transform.position = newPosition;
        // transform.rotation = startPoint.rotation;

        // Remove dynamically added objects
        foreach (GameObject obj in dynamicallyAddedObjects)
    {
        Destroy(obj);
    }
    dynamicallyAddedObjects.Clear();

    // Clear the lines created by LineCreator
    lineCreator.ClearLines();

    // Enable the SpringJoint2D component again
    springJoint.enabled = true;

    // Allow the player's movement after the delay
    playerRigidbody.constraints = RigidbodyConstraints2D.None;

    hasCollided = false; // Reset the collision flag
}


    public void AddDynamicallyAddedObject(GameObject obj)
    {
        dynamicallyAddedObjects.Add(obj);
    }
}







//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class RespawnOnDeath : MonoBehaviour
//{
//    public Transform startPoint; // The transform of the start point in the level
//    public float respawnDelay = 0.1f; // Delay before respawning
//    private SpringJoint2D springJoint; // Reference to the SpringJoint2D component
//    private bool hasCollided = false; // Flag to track collision with death zone
//    private List<GameObject> dynamicallyAddedObjects = new List<GameObject>(); // List to store dynamically added objects
//	public GameObject gameOverText;
//	
//	
//
//    private LineCreator lineCreator; // Reference to the LineCreator script
//
//    private void Start()
//    {
//        // Get the reference to the SpringJoint2D component
//        springJoint = GetComponent<SpringJoint2D>();
//
//        lineCreator = FindObjectOfType<LineCreator>(); // Find the LineCreator script in the scene
//    }
//
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("DeathZone"))
//        {
//            if (!hasCollided)
//            {
//                hasCollided = true;
//                StartCoroutine(RespawnCoroutine());
//            }
//        }
//    }
//
//    private IEnumerator RespawnCoroutine()
//    {
//        // Disable the player's movement
//        Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();
//        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
//
//        // Reduce the player's lives by 1
//        Player player = GetComponent<Player>();
//        if (player != null)
//        {
//            player.Hit();
//            if (player.GetLives() <= 0)
//            {
//                player.GameOver();
//				gameOverText.SetText("GAME OVER!");
//                yield break;
//            }
//        }
//
//        // Disable the SpringJoint2D component to release the player
//        springJoint.enabled = false;
//
//        // Wait for the specified delay
//        yield return new WaitForSeconds(respawnDelay);
//
//        // Reset the player's position and rotation to the start point
//        transform.position = startPoint.position;
//        transform.rotation = startPoint.rotation;
//
//        // Remove dynamically added objects
//        foreach (GameObject obj in dynamicallyAddedObjects)
//        {
//            Destroy(obj);
//        }
//        dynamicallyAddedObjects.Clear();
//
//        // Clear the lines created by LineCreator
//        lineCreator.ClearLines();
//
//        // Enable the SpringJoint2D component again
//        springJoint.enabled = true;
//
//        // Allow the player's movement after the delay
//        playerRigidbody.constraints = RigidbodyConstraints2D.None;
//
//        hasCollided = false; // Reset the collision flag
//    }
//
//    public void AddDynamicallyAddedObject(GameObject obj)
//    {
//        dynamicallyAddedObjects.Add(obj);
//    }
//}
