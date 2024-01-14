using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public float releaseTime = .15f;
    public float maxDragDistance = 1.5f;
    public bool isPressed = false;
    public bool isDragging = true;
    private SpringJoint2D playerSpring;
    private bool hasReleased = false;
    public int lives;
    private bool isColliding = false;
    private Coroutine releaseCoroutine;
    public bool isPaused = false;
    public Text livesText;
	public GameObject Cannon; // Reference to the sprite object
    public GameObject CannonBottom;
	private Vector3 CannonInitialPosition; // Added variable to store the initial position of the sprite
    private Vector3 CannonBottomInitialPosition;
	private bool isPlayerConnected = false; // Flag to track player connection status
	private Quaternion cannonInitialRotation; // Store the initial rotation of the Cannon
	private Quaternion releasedRotation = Quaternion.identity;
    public int Player_Speed;
    private Vector3 playerInitialPosition;
    private Quaternion playerInitialRotation;


    private void Start()
{
        lives = ES3.Load("lives", 0); // 0 is the default value if "lives" is not found
        UpdateLivesText();

    // Set the initial position of the Cannon sprite
   // CannonInitialPosition = transform.position;
   // Cannon.transform.position = CannonInitialPosition;

   //  Store the initial rotation of the Cannon sprite
  // cannonInitialRotation = Cannon.transform.rotation;


        playerInitialPosition = rb.position;

    }

private void Update()
{
    if (!isPaused)
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }

        // Check if the player is connected to the anchor
        if (GetComponent<SpringJoint2D>().connectedBody != null)
        {

            // Update the player connection status
            isPlayerConnected = true;
        }
    }
}



    private void LateUpdate()
{
    // Check if the player has been released from the SpringJoint2D
    if (!isPressed && isPlayerConnected)
    {
        // Reset the player connection status and disable the Cannon's rotation
        isPlayerConnected = false;
        rb.angularVelocity = 0f;
        rb.rotation = 0f;
    }

        // Rotate the Cannon sprite around the anchor if the player is connected

        if (isPlayerConnected)
        {
            // Get the direction from the anchor to the player
            Vector2 direction = rb.position - hook.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Store the current z position of the Cannon
            float currentZ = Cannon.transform.position.z;

            // Rotate the Cannon sprite around the anchor while maintaining the z position
            Cannon.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            CannonBottom.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Restore the original z position
            Vector3 newPosition = Cannon.transform.position;
            newPosition.z = currentZ;
            Cannon.transform.position = newPosition;


            // CannonBottom.transform.position = newPosition;

        }
        else
        {
            // Rotate the player sprite based on movement speed and direction
            float rotationSpeed = .3f; // Adjust the base rotation speed as desired

            // Get the movement direction on the x-axis
            float movementDirectionX = rb.velocity.x;

            // Declare and initialize the initial rotation angle
            float initialRotationAngle = transform.rotation.eulerAngles.z;

            // Check if the movement direction on the x-axis is non-zero
            float movementSpeedThreshold = 0.01f; // Adjust the threshold value as desired
            if (Mathf.Abs(movementDirectionX) > 0.01f && rb.velocity.magnitude > movementSpeedThreshold)
            {
                // Calculate the rotation angle based on the movement direction on the x-axis
                float rotationAngle = Mathf.Sign(movementDirectionX) * Mathf.Rad2Deg;

                // Store the current rotation angle
                float currentRotationAngle = transform.rotation.eulerAngles.z;

                // Calculate the movement speed factor to control rotation speed
                float movementSpeedFactor = Mathf.Clamp01(rb.velocity.magnitude / movementSpeedThreshold);

                // Calculate the final rotation speed based on movement speed and factor
                float finalRotationSpeed = rotationSpeed * movementSpeedFactor * Mathf.Abs(movementDirectionX);

                // Apply rotation to the player's sprite based on the current rotation angle
                transform.rotation = Quaternion.Euler(0f, 0f, currentRotationAngle - rotationAngle * finalRotationSpeed * Time.fixedDeltaTime);
            }
        }



    }


    public void PauseGame()
    {
        isPaused = true;
		isDragging = false;
        // Additional code to pause the game, e.g., time scale manipulation, UI display, etc.
    }
	
    public void ResumeGame()
    {
        isPaused = false;
		isDragging = true;
        // Additional code to resume the game, e.g., time scale manipulation, UI hiding, etc.
    }
	

    private void OnMouseDown()
    {
        if (!isPaused && !hasReleased && lives > 0)
        {
            // Enable line dragging when the game is not paused
            isPressed = true;
            rb.isKinematic = true;
            isDragging = true;
            // Store the initial position of the sprite
            CannonInitialPosition = Cannon.transform.position;
             CannonBottomInitialPosition = CannonBottom.transform.position;
        }
    
    else
    {
        // Check if the SpringJoint2D component is enabled
        if (!GetComponent<SpringJoint2D>().enabled)
        {
            return; // SpringJoint2D is not enabled, do nothing
        }

        // Reset the player's state and enable the spring joint
        hasReleased = false;
        isPressed = true;
        rb.isKinematic = true;
        isDragging = true;
        GetComponent<SpringJoint2D>().enabled = true;
    }
}

private void OnMouseUp()
{
    Vector2 Spring_force = CannonInitialPosition - Cannon.transform.position;
    isPressed = false;
    rb.isKinematic = false;
    isDragging = false;
        GetComponent<Rigidbody2D>().AddForce(Player_Speed * Spring_force);

    if (releaseCoroutine != null)
        StopCoroutine(releaseCoroutine);

    releaseCoroutine = StartCoroutine(Release());

}


    public void Hit()
    {
        if (!isColliding)
        {
            lives++; // Increase the player's lives
            UpdateLivesText();
            ES3.Save("lives", lives);


            if (lives < 0)
                Respawn();
            else
                GameOver();

            isColliding = true; // Set the flag to prevent multiple collision events
            StartCoroutine(ResetCollisionFlag());
            
        }
    }

    public void RespawnButton()
    {

        {
            lives++; // Increase the player's lives
            UpdateLivesText();
            ES3.Save("lives", lives);

            if (lives <= 0) // Check if the player has zero lives
                return;

           // StartCoroutine(RespawnOnDeath.RespawnCoroutine());

        }
    }

    private void Respawn()
    {
        if (lives <= 0)
            return;

        hasReleased = false;
        isPressed = false;
        rb.isKinematic = false;
        rb.position = playerInitialPosition;

        GetComponent<SpringJoint2D>().enabled = true;
    }


    // public void Death()
    // {
    //     GameManager.Instance.ResetLevel(3f);
    //     hasReleased = false;
    //     isPressed = false;
    //     rb.isKinematic = false;
    //     GetComponent<SpringJoint2D>().enabled = true;
    //     lives = 3; // Reset the player's lives to 3
    //     UpdateLivesText();
    // }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // Perform any additional game over actions or logic here
    }



    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        hasReleased = true;
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = lives.ToString();
        }
    }

    public int GetLives()
    {
        return lives;
    }

    private IEnumerator ResetCollisionFlag()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false; // Reset the collision flag after all collisions have been processed in the frame
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision events here
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }
}
//
//
//
//
////using System.Collections;
////using UnityEngine;
////using UnityEngine.UI;
////
////public class Player : MonoBehaviour
////{
////    public GameObject _Player;
////    public Rigidbody2D rb;
////    public Rigidbody2D hook;
////    public float releaseTime = .15f;
////    public float maxDragDistance = 2f;
////    public bool isPressed = false;
////    public bool IsDragging = true;
////    private SpringJoint2D _PlayerSpring;
////    private bool hasReleased = false;
////    private int lives = 3; // Start with 3 lives
////    private bool isColliding = false; // Flag to prevent multiple collisions in the same frame
////    private Coroutine releaseCoroutine; // Added to store the coroutine reference
////
////    public Text livesText; // Reference to the UI Text component for displaying lives
////
////    private void Start()
////    {
////        UpdateLivesText(); // Update the Lives Text when the game starts
////    }
////
////    void Update()
////    {
////        if (isPressed)
////        {
////            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
////
////            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
////                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
////            else
////                rb.position = mousePos;
////        }
////    }
////
////    void OnMouseDown()
////    {
////        if (!hasReleased && lives > 0) // Check if the player has remaining lives
////        {
////            isPressed = true;
////            rb.isKinematic = true;
////            IsDragging = true;
////        }
////        else
////        {
////            // Check if the SpringJoint2D component is enabled
////            if (!GetComponent<SpringJoint2D>().enabled)
////            {
////                return; // SpringJoint2D is not enabled, do nothing
////            }
////
////            // Reset the player's state and enable the spring joint
////            hasReleased = false;
////            isPressed = true;
////            rb.isKinematic = true;
////            IsDragging = true;
////            GetComponent<SpringJoint2D>().enabled = true;
////        }
////    }
////
////    void OnMouseUp()
////    {
////        isPressed = false;
////        rb.isKinematic = false;
////        IsDragging = false;
////
////        if (releaseCoroutine != null)
////            StopCoroutine(releaseCoroutine);
////
////        releaseCoroutine = StartCoroutine(Release());
////    }
////
////    public void Hit()
////    {
////        if (!isColliding)
////        {
////            lives--; // Reduce the player's remaining lives
////            UpdateLivesText();
////
////            if (lives > 0)
////                Respawn();
////            else
////                GameOver();
////
////            isColliding = true; // Set the flag to prevent multiple collision events
////            StartCoroutine(ResetCollisionFlag());
////        }
////    }
////
////    private void Respawn()
////    {
////        hasReleased = false;
////        isPressed = false;
////        rb.isKinematic = false;
////        GetComponent<SpringJoint2D>().enabled = true;
////    }
////
////    public void Death()
////    {
////        GameManager.Instance.ResetLevel(3f);
////        hasReleased = false;
////        isPressed = false;
////        rb.isKinematic = false;
////        GetComponent<SpringJoint2D>().enabled = true;
////        lives = 3; // Reset the player's lives to 3
////        UpdateLivesText();
////    }
////
////    public void GameOver()
////    {
////        Debug.Log("Game Over");
////        // Perform any additional game over actions or logic here
////    }
////
////    IEnumerator Release()
////    {
////        yield return new WaitForSeconds(releaseTime);
////
////        GetComponent<SpringJoint2D>().enabled = false;
////        hasReleased = true;
////    }
////
////    private void UpdateLivesText()
////    {
////        if (livesText != null)
////        {
////            livesText.text = "Lives: " + lives.ToString();
////        }
////    }
////
////    public int GetLives()
////    {
////        return lives;
////    }
////
////    private IEnumerator ResetCollisionFlag()
////    {
////        yield return new WaitForEndOfFrame();
////        isColliding = false; // Reset the collision flag after all collisions have been processed in the frame
////    }
////}
