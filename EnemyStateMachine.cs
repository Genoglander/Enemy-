using UnityEngine;

public interface IState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}
using UnityEngine;

[RequireComponent(typeof(EnemyVision))]
public class EnemyStateMachine : MonoBehaviour
{
    private IState currentState;

    public EnemyVision Vision { get; private set; }
    public Transform Target { get; set; }

    private void Awake()
    {
        Vision = GetComponent<EnemyVision>();
    }

    private void Start()
    {
        ChangeState(new EnemyIdleState(this));
    }

    private void Update()
    {
        currentState?.OnUpdate();
    }

    public void ChangeState(IState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }
}