using UnityEngine;

public class BallShotCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // "Infect" obstacles within the radius of the shot ball by calling a method on their scripts to destroy them
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, transform.localScale.magnitude * 2);
        foreach (Collider hitCollider in hitColliders)
        {
            Obstacle obstacle = hitCollider.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                obstacle.DestroyObstacle();
            }
        }

        // Destroy the shot ball and spring joint
        Destroy(gameObject);
    }
}