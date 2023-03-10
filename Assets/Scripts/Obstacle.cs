using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // method to destroy the obstacle
    public void DestroyObstacle()
    {
        Destroy(gameObject); // destroy the obstacle game object
    }
}