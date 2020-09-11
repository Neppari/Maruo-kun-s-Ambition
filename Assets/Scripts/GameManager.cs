using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var gameObj = new GameObject(nameof(GameManager));
                _instance = (GameManager)gameObj.AddComponent(typeof(GameManager));
            }

            return _instance;
        }
        set
        {
            if (_instance == null)
            {
                _instance = value;
            }
        }
    }

    #endregion

    [SerializeField] private GameObject prefab_Ball = default;

    private Ball _ball;
    private Ball Ball
    {
        get => _ball;
        set
        {
            if (_ball == value) return;

            if (_ball != null) _ball.BallHitObject -= HandleBallHit;

            _ball = value;

            if (_ball != null) _ball.BallHitObject += HandleBallHit;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.Log("Too many GameManagers, deleting this");
            GameObject.Destroy(gameObject);
        }
    }

    private void Start()
    {
        Ball = GameObject.Instantiate(prefab_Ball).GetComponent<Ball>();
        Ball.transform.position = new Vector3(0, 2, -12);
        Ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 4, 15), ForceMode.Impulse);
    }

    private void HandleBallHit(GameObject other)
    {
        //Debug.Log($"Ball hit {other.name}");
    }

    public bool TrySwing(Swinger swinger, Vector3 force)
    {
        var distance = Vector3.Distance(swinger.transform.position, Ball.transform.position);
        if (distance < swinger.MaxDistance)
        {
            Ball.AddForce(force);
            return true;
        }
        else return false;
    }

}
