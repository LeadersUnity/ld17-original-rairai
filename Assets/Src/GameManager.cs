using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UIController UIController;
    public PLAYUIUX PLAYUIUX;
    public SkillUIManager SkillUIManager;
    public EnemySkillController EnemySkillController;

    public static int PlayerSkillN = 0;
    public static int EnemySkillN = 0;
    public static bool PlayerOpenStart = false;
    public static bool EnemyOpenStart = false;

    public static bool Stoper = true;
    public static int EnemySKill = 0;
    public static int PlayerSKill = 0;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       if(PlayerSkillN != 0 && EnemySkillN != 0 && Stoper == true)
        {
            Stoper = false;
            
            PLAYUIUX.EnemyCardOpen(EnemySkillN);

            PlayerSkillN = 0;
            EnemySkillN = 0;

            OpenCardCoroutineTo();
        }
    }

    //PlayerSkills
    public void SkillGardFire()
    {
        int DebuffNum = 3;
        UIController.PlayerGardFire(DebuffNum);
        
        EnemySkillController.EnemySkillToGo();//相手の行動へ
    }
    public void SkillAttackFire()
    {
        int DebuffNum = 3;
        UIController.PlayerAttackFire(DebuffNum);
        
        EnemySkillController.EnemySkillToGo();//相手の行動へ
    }
    public void SkillDrain()
    {
        float damage = 70.0f;
        float cureP = 30.0f;
       
        UIController.EnemyTakeDamageUI(damage);
        UIController.PlayerCureUI(cureP);
        
        EnemySkillController.EnemySkillToGo();//相手の行動へ
    }
    public void SkillCaunter()
    {
        Debug.Log("vvv:" + EnemySKill);
        if(EnemySKill == 2 || EnemySKill == 3)//fire drain
        {
            UIController.EnemyTakeDamageUI(150.0f);

        }
        else if(EnemySKill == 1 || EnemySKill == 4 || EnemySKill == 5)
        {
            UIController.PlayerTakeDamageUI(50.0f);
        }
        else
        {
            Debug.Log("CaunterBUG");
        }
        
        EnemySkillController.EnemySkillToGo();//相手の行動へ
    }
    public void SkillHealGard()
    {
        int DebuffNum = 1;
        float cureP = 50.0f;
        UIController.PlayerGardFire(DebuffNum);
        UIController.PlayerCureUI(cureP);
       
        EnemySkillController.EnemySkillToGo();//相手の行動へ
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
        if (PlayerSKill == 2 || PlayerSKill == 3)//fire drain
        {
            UIController.PlayerTakeDamageUI(150.0f);

        }
        else if (PlayerSKill == 1 || PlayerSKill == 4 || PlayerSKill == 5)
        {
            
            UIController.EnemyTakeDamageUI(50.0f);
        }
        else
        {
            Debug.Log("CaunterBUG");
        }

        
        StartCoroutine(ToTarnFire());
    }
    public void EnemySkillHealGard()
    {
        int DebuffNum = 1;
        float cureP = 50.0f;
        UIController.EnemyGardFire(DebuffNum);
        UIController.EnemyCureUI(cureP);
        
        StartCoroutine(ToTarnFire());
    }


    IEnumerator ToTarnFire()
    {
        yield return new WaitForSeconds(2.0f);
        UIController.TarnFire();
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(UIController.WinnerOrLooserJudge());
    }
    public void OpenCardCoroutineTo()
    {
        StartCoroutine(OpenCardTime());
        
    }
    

    IEnumerator OpenCardTime()
    {
        yield return new WaitForSeconds(0.5f);

        PLAYUIUX.SetPlayerReverseCard(true);
        PLAYUIUX.SetEnemyReverseCard(true);

        yield return new WaitForSeconds(1.0f);

        PLAYUIUX.SetPlayerReverseCard(false);
        PLAYUIUX.SetEnemyReverseCard(false);

        yield return new WaitForSeconds(1.0f);

        
        SkillUIManager.SkillGoTo();
        

        
    }
}
