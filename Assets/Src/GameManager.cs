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

    public void SkillGardFire()
    {
       
    }
    public void SkillAttackFire()
    {
        float damage = 30.0f;
        bool SkillOrFireBool = true;
        UIController.EnemyTakeDamageUI(damage, SkillOrFireBool);
    }
    public void SkillDrain()
    {

    }
    public void SkillCaunter()
    {

    }
    public void SkillHealGard()
    {

    }
    public void TarnFire()
    {
        float damage = 50.0f;
        bool SkillOrFireBool = false;
        UIController.EnemyTakeDamageUI(damage, SkillOrFireBool);
        UIController.PlayerTakeDamageUI(damage, SkillOrFireBool);

    }
    
}
