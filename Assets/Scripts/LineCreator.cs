using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;
    public int maxLines = 5; // Maximum allowed lines

    private Line activeLine;
    private SpringJoint2D playerSpring;
    private PauseMenu pauseMenu; // Reference to the PauseMenu script
    private List<Line> createdLines = new List<Line>(); // List to store created lines

    private void Start()
    {
        playerSpring = GameObject.Find("Player").GetComponent<SpringJoint2D>();
        pauseMenu = FindObjectOfType<PauseMenu>(); // Find the PauseMenu script in the scene
    }

    private void Update()
    {
        if (playerSpring.enabled)
        {
            activeLine = null;
        }
        else if (Input.GetMouseButtonDown(0) && createdLines.Count < maxLines)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the mouse is over the player game object
            Collider2D[] colliders = Physics2D.OverlapPointAll(mousePos);
            bool mouseOverPlayer = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == playerSpring.gameObject)
                {
                    mouseOverPlayer = true;
                    break;
                }
            }

            if (mouseOverPlayer)
            {
                // Disable the mouse button down
                return;
            }

            // Mouse is not over the player game object, create a new line
            GameObject lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>();
            createdLines.Add(activeLine); // Add the created line to the list
        }
        else if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);

            // Check if the line goes over another game object
            Collider2D[] colliders = Physics2D.OverlapPointAll(mousePos);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != activeLine.gameObject)
                {
                    activeLine = null;
                    break;
                }
            }
        }
    }

    public void ClearLines()
    {
        foreach (Line line in createdLines)
        {
            Destroy(line.gameObject);
        }
        createdLines.Clear();
    }
}
