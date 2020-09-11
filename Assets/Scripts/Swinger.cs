using UnityEngine;

public class Swinger : MonoBehaviour
{

    [SerializeField] private InputAccess input;

    [SerializeField] private float _maxDistance;
    [SerializeField] private float _straightPower;
    [SerializeField] private float _lobPower;
    [SerializeField] private Vector2 straigthDirection;
    [SerializeField] private Vector2 lobDirection;

    public float MaxDistance => _maxDistance;
    private float StraightPower => _straightPower;
    private float LobPower => _lobPower;
    private Vector3 StraightForce => (transform.forward * straigthDirection.normalized.x + Vector3.up * straigthDirection.normalized.y) * StraightPower;
    private Vector3 LobForce => (transform.forward * lobDirection.normalized.x + Vector3.up * lobDirection.normalized.y) * LobPower;

    private void Start()
    {
        input.ButtonDown += OnButtonDown;
        input.ButtonUp += OnButtonUp;
    }

    private void OnButtonDown(Buttons button)
    {
        bool hit = default;

        switch (button)
        {
            case Buttons.HitStraight:
                hit = GameManager.Instance.TrySwing(this, StraightForce);
                break;

            case Buttons.HitLob:
                hit = GameManager.Instance.TrySwing(this, LobForce);
                break;
        }

        PlayHitResult(hit);
    }

    private void OnButtonUp(Buttons button)
    {
        switch (button)
        {
            case Buttons.HitStraight:
                break;

            case Buttons.HitLob:
                break;
        }
    }

    private void PlayHitResult(bool hit)
    {
        if (hit)
        {
            Debug.Log("Hit!");
        }
        else
        {
            Debug.Log("Miss!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, MaxDistance);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + StraightForce.normalized * 2);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + LobForce.normalized * 2);
    }

}
