using UnityEngine;

public class EnemyIdleState : IState
{
    private readonly EnemyStateMachine enemy;
    private float timer;
    private float idleDuration = 2f;

    public EnemyIdleState(EnemyStateMachine enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        Debug.Log("���˽���Idle״̬");
        timer = 0;
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;

        var target = enemy.Vision.DetectTarget();
        if (target != null)
        {
            enemy.Target = target;
            enemy.ChangeState(new EnemyChaseState(enemy));
            return;
        }

        if (timer >= idleDuration)
        {
            enemy.ChangeState(new EnemyPatrolState(enemy));
        }
    }

    public void OnExit()
    {
        Debug.Log("�����뿪Idle״̬");
    }
}
