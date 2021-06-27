using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHudController : MonoBehaviour
{
    public Image EnemyHp;
    public Text Damage;

    public Color EnemyHpMax;
    public Color EnemyHpMin;
    public GameObject floatingPoints;

    private void Awake()
    {
        EnemyHp.fillAmount = 1f;
        EnemyHp.color = EnemyHpMax;
        Damage.enabled = false;

    }

    private void Start()
    {
        GameEvents.EnemyHpEvent.AddListener(HandleEnemyHp);
        GameEvents.EnemyDamageEvent.AddListener(HandleDamage);
    }

    protected void HandleEnemyHp(int currentHp, int maxHp)
    {
        EnemyHp.fillAmount = (float)currentHp / (float)maxHp;
        EnemyHp.color = Color.Lerp(EnemyHpMin, EnemyHpMax, (float)currentHp / (float)maxHp);

    }

    protected void HandleDamage(int damage)
    {
        StartCoroutine(TakeDamage(damage));
    }
   protected IEnumerator TakeDamage(int damage)
    {
        Damage.enabled = true;
        Damage.text = string.Format("{0}", damage);
        yield return new WaitForSeconds(0.2f);
        Damage.enabled = false;
        
    }

    private void Update()
    {
        

    }
}
