using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillController : MonoBehaviour
{
    public GameManager GameManager;
    

    int EnemySkillingNum = 0;//選択されたスキルを整数で管理


    
    bool EnemySkillSettioning = false;
    public static bool EnemySkillingOK = false;
    void Start()
    {
        EnemySkillSettioning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemySkillSettioning == true)
        {
            if (EnemySkillingOK == true)
            {
                EnemySkillingNum = 3;
                EnemySkillToGo();
                EnemySkillingOK = false;
                //EnemySkillSettioning = false;
            }
        }
       
         
    }
    //public void EnemySkillSettion(int EnemySkillingNum)
    //{
    //    EnemySkillSettioning = true;
    //}
    private void EnemySkillToGo()
    {
        StartCoroutine(EnemySkillTake());

    }
    IEnumerator EnemySkillTake()
    {
        yield return new WaitForSeconds(2.0f);
        if (EnemySkillingNum != 0)//相手情報を受け取って
        {
            //相手情報を受け取って
            if (EnemySkillingNum == 1)
            {
                GameManager.EnemySkillGardFire();
            }
            else if (EnemySkillingNum == 2)
            {
                GameManager.EnemySkillAttackFire();
            }
            else if (EnemySkillingNum == 3)
            {
                GameManager.EnemySkillDrain();
            }
            else if (EnemySkillingNum == 4)
            {
                GameManager.EnemySkillCaunter();
            }
            else if (EnemySkillingNum == 5)
            {
                GameManager.EnemySkillHealGard();
            }
            
            EnemySkillingNum = 0;

        }
    }
    
}
