using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : Rigidbody2DBase, IPoolableObject
{
    public int MaxHp { get; protected set; }
    public int Hp { get; protected set; }
    public int Damage = 10;

    public Image HUDhp;
    public Text HUDdamage;

    private void Start()
    {

        Hp = MaxHp = Random.Range(100, 201);
        HUDhp = GetComponentInChildren<Image>();
        HUDdamage = GetComponentInChildren<Text>();
        
    }


    public bool ApplyDamage(int damage)
    {
        GameEvents.EnemyHpEvent.Invoke(Hp, MaxHp, HUDhp);
        GameEvents.EnemyDamageEvent.Invoke(damage, HUDdamage);

        Hp -= damage;
        return Hp <= 0;
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
