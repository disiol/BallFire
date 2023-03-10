using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField]private GameObject shotBallPrefab;

    private bool isTapping;
    private float retainTime;
    private GameObject shotBall;
    private Rigidbody playerRigidbody;
    private Vector3 initialScale;
    private GameObject _player;
    private float _shotBallsize;
    private GameController _gameController;


    void Start()
    {
        // Get reference to the player ball object
        _player = GameObject.FindGameObjectWithTag("Player");
        _gameController = GameObject.Find("GameControler").GetComponent<GameController>();
        playerRigidbody = _player.GetComponent<Rigidbody>();

        // Store the initial scale of the player ball
        initialScale = playerRigidbody.transform.localScale;
    }
    private void Update()
    {
        _gameController.CheckBallSize();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isTapping = true;
                retainTime = 0f;
                shotBall = Instantiate(shotBallPrefab);
                Vector3 shotBallPosition =
                    transform.position + transform.forward * 2f; // position in front of the player
                shotBall.transform.position = shotBallPosition;
            }
            
                if (isTapping)
                {
                    retainTime += Time.deltaTime;
                    _shotBallsize = retainTime;
                    shotBall.transform.localScale = new Vector3(_shotBallsize, _shotBallsize, _shotBallsize);
                    transform.localScale = new Vector3(1f / _shotBallsize, 1f / _shotBallsize, 1f / _shotBallsize);
                    // Reduce the size of the player ball proportionally to the size of the shot ball
                    float playerSize = _player.transform.localScale.x - _shotBallsize;
                    _player.transform.localScale = new Vector3(playerSize, playerSize, playerSize);
                }
            
            else if (touch.phase == TouchPhase.Ended)
            {
                isTapping = false;
                Vector3 force = new Vector3(_shotBallsize, _shotBallsize, _shotBallsize);
                shotBall.GetComponent<Rigidbody>().AddForce(force);
            }
        }
    }
}