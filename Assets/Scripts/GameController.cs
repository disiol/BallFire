using UnityEngine;

public class GameController : MonoBehaviour
{
    // Public variables for controlling the game difficulty
    [SerializeField] private GameObject PanelGameOwer;
    [SerializeField] private float initialBallSize = 1.0f;
    [SerializeField] private float sizeMargin = 0.2f;
    [SerializeField] private float doorDistance = 5.0f;

    // Private variables for tracking game state
    private bool gameWon = false;
    private bool gameOver = false;
    private bool doorOpened = false;
    private GameObject playerBall;
    private GameObject door;

    private void Start()
    {
        // Get references to the player ball and door objects
        playerBall = GameObject.FindWithTag("Player");
        door = GameObject.FindWithTag("Door");

        // Set the initial size of the player ball
        playerBall.transform.localScale = new Vector3(initialBallSize, initialBallSize, initialBallSize);
    }

    private void Update()
    {
        // Check if the door should open
        if (Vector3.Distance(playerBall.transform.position, door.transform.position) <= doorDistance && !doorOpened)
        {
            OpenDoor();
        }

        // Check if the game has been won or lost
        if (gameWon)
        {
            WinGame();
        }
        else if (gameOver)
        {
            EndGame();
        }
    }

    public void CheckBallSize()
    {
        //TODO
        // Calculate the minimum size the ball needs to be to pass through the door
        float doorSize = door.GetComponent<Collider>().bounds.size.magnitude;
        float minBallSize = doorSize * (1.0f + sizeMargin);

        // Check if the player ball is large enough to pass through the door
        if (playerBall.transform.localScale.x >= minBallSize)
        {
            // If so, the player wins the game
            gameWon = true;
        }
        else if (playerBall.transform.localScale.x <= 0)
        {
            // If not, the player loses the game
            gameOver = true;
        }
    }

    private void WinGame()
    {
        // TODO: Implement win game logic (e.g. show a victory screen)
    }

    private void EndGame()
    {
        // TODO: Implement end game logic (e.g. show a game over screen)
    }

    private void OpenDoor()
    {
        // TODO: Implement door opening logic (e.g. play an animation, remove a barrier, etc.)
        doorOpened = true;
    }
}