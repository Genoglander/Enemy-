using UnityEngine;

public class EnemyChaseState : IState
{
    private readonly EnemyStateMachine enemy;
    private float chaseSpeed = 3.5f;

    public EnemyChaseState(EnemyStateMachine enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        Debug.Log("µÐÈË½øÈë×·»÷×´Ì¬");
    }

    public void OnUpdate()
    {
        if (enemy.Target == null)
        {
            enemy.ChangeState(new EnemyIdleState(enemy));
            return;
        }

        Vector3 direction = (enemy.Target.position - enemy.transform.position).normalized;
        enemy.transform.position += direction * chaseSpeed * Time.deltaTime;

        float distance = Vector3.Distance(enemy.transform.position, enemy.Target.position);
        if (distance > enemy.Vision.detectionRadius * 1.5f)
        {
            enemy.ChangeState(new EnemyIdleState(enemy));
        }
    }

    public void OnExit()
    {
        Debug.Log("µÐÈËÍ£Ö¹×·»÷");
    }
}
