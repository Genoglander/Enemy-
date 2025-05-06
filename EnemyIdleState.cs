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
        Debug.Log("敌人进入Idle状态");
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
        Debug.Log("敌人离开Idle状态");
    }
}
