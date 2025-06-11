using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UIController UIController;
    
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //PlayerSkills
    public void SkillGardFire()
    {
        int DebuffNum = 3;
        UIController.PlayerGardFire(DebuffNum);
        EnemySkillController.EnemySkillingOK = true;
    }
    public void SkillAttackFire()
    {
        int DebuffNum = 3;
        UIController.PlayerAttackFire(DebuffNum);
        EnemySkillController.EnemySkillingOK = true;
    }
    public void SkillDrain()
    {
        float damage = 70.0f;
        float cureP = 30.0f;
       
        UIController.EnemyTakeDamageUI(damage);
        UIController.PlayerCureUI(cureP);
        EnemySkillController.EnemySkillingOK = true;
    }
    public void SkillCaunter()
    {

    }
    public void SkillHealGard()
    {
        int DebuffNum = 1;
        float cureP = 50.0f;
        UIController.PlayerGardFire(DebuffNum);
        UIController.PlayerCureUI(cureP);
        EnemySkillController.EnemySkillingOK = true;
    }


    //EnemySkills
    public void EnemySkillGardFire()
    {
        int DebuffNum = 3;
        UIController.EnemyGardFire(DebuffNum);
        StartCoroutine(ToTarnFire());
    }
    public void EnemySkillAttackFire()
    {
        int DebuffNum = 3;
        UIController.EnemyAttackFire(DebuffNum);
        StartCoroutine(ToTarnFire());
    }
    public void EnemySkillDrain()
    {
        float damage = 70.0f;
        float cureP = 30.0f;

        UIController.PlayerTakeDamageUI(damage);
        UIController.EnemyCureUI(cureP);
        StartCoroutine(ToTarnFire());
    }
    public void EnemySkillCaunter()
    {

    }
    public void EnemySkillHealGard()
    {
        int DebuffNum = 1;
        float cureP = 50.0f;
        UIController.EnemyGardFire(DebuffNum);
        UIController.EnemyCureUI(cureP);
    }


    IEnumerator ToTarnFire()
    {
        yield return new WaitForSeconds(2.0f);
        UIController.TarnFire();
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(UIController.WinnerOrLooserJudge());
    }
    
}
