using UnityEngine;

public class EnemyPatrolState : IState
{
    private readonly EnemyStateMachine enemy;
    private Vector3 patrolTarget;
    private float moveSpeed = 2f;

    public EnemyPatrolState(EnemyStateMachine enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        Debug.Log("���˽���Ѳ��״̬");
        // �����Ŀ��㣨����Ի���·���㣩
        patrolTarget = enemy.transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }

    public void OnUpdate()
    {
        var target = enemy.Vision.DetectTarget();
        if (target != null)
        {
            enemy.Target = target;
            enemy.ChangeState(new EnemyChaseState(enemy));
            return;
        }

        Vector3 direction = (patrolTarget - enemy.transform.position).normalized;
        enemy.transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(enemy.transform.position, patrolTarget) < 0.5f)
        {
            enemy.ChangeState(new EnemyIdleState(enemy));
        }
    }

    public void OnExit()
    {
        Debug.Log("����ֹͣѲ��");
    }
}
