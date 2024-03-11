using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform[] waypoints;  // Define waypoints for the NPC to patrol
    public float moveSpeed = 2f;    // Adjust the movement speed as needed
    public float waitTime = 2f;     // Adjust the time the NPC waits at each waypoint

    private int currentWaypointIndex = 0;
    private bool isWaiting = false;

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to the AIController!");
        }
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!isWaiting)
        {
            Vector2 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isWaiting = true;
                Invoke("WaitAtWaypoint", waitTime);
            }
        }
    }

    void WaitAtWaypoint()
    {
        isWaiting = false;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}
