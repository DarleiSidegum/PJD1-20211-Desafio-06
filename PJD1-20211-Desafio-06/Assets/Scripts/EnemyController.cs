using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Rigidbody2DBase, IPoolableObject
{
    public int MaxHp { get; protected set; }
    public int CurrentHp { get; protected set; }
    public int Damage = 10;
    

    private void Start()
    {
        MaxHp = Random.Range(100, 201);
        CurrentHp = MaxHp;
        
    }

    public bool ApplyDamage(int damage)
    {
        CurrentHp -= damage;
  
        GameEvents.EnemyHpEvent.Invoke(CurrentHp, MaxHp);
        GameEvents.EnemyDamageEvent.Invoke(damage);
        return CurrentHp <= 0;
    }

    public void Recycle()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
        Start();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.EnnemyDamageTrigger(this, collision);
    }
}
