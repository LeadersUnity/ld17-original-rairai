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
    }
    public void SkillAttackFire()
    {
        int DebuffNum = 3;
        UIController.PlayerAttackFire(DebuffNum);
    }
    public void SkillDrain()
    {
        float damage = 70.0f;
        float cureP = 30.0f;
       
        UIController.EnemyTakeDamageUI(damage);
        UIController.PlayerCureUI(cureP);
    }
    public void SkillCaunter()
    {

    }
    public void SkillHealGard()
    {

    }


    //EnemySkills
    public void EnemySkillGardFire()
    {
        int DebuffNum = 3;
        UIController.EnemyGardFire(DebuffNum);
    }
    public void EnemySkillAttackFire()
    {
        int DebuffNum = 3;
        UIController.EnemyAttackFire(DebuffNum);
    }
    public void EnemySkillDrain()
    {
        float damage = 70.0f;
        float cureP = 30.0f;

        UIController.PlayerTakeDamageUI(damage);
        UIController.EnemyCureUI(cureP);
    }
    public void EnemySkillCaunter()
    {

    }
    public void EnemySkillHealGard()
    {

    }

   
    
}
