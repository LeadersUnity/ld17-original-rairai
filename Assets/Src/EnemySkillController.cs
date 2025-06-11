using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillController : MonoBehaviour
{
    public GameManager GameManager;
    public PLAYUIUX PLAYUIUX;

    public static bool EnemysCaunterJudege = false;

    int EnemySkillingNum = 0;//選択されたスキルを整数で管理


    
    bool EnemySkillSettioning = false;//相手のデータを受け取ったか
    public static bool EnemySkillingOK = false;//相手のスキルの発動タイミング
    void Start()
    {
        EnemySkillSettioning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemySkillSettioning == true)//相手情報を受け取って
        {
            EnemySkillingNum = 3;//受け取った

            if (EnemySkillingOK == true)
            {
                
                EnemySkillToGo();//行動へ
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
                PLAYUIUX.EnemyCardOpen(EnemySkillingNum);
                GameManager.EnemySkillGardFire();
                
            }
            else if (EnemySkillingNum == 2)
            {
                PLAYUIUX.EnemyCardOpen(EnemySkillingNum);
                GameManager.EnemySkillAttackFire();
            }
            else if (EnemySkillingNum == 3)
            {
                PLAYUIUX.EnemyCardOpen(EnemySkillingNum);
                GameManager.EnemySkillDrain();
            }
            else if (EnemySkillingNum == 4)
            {
                PLAYUIUX.EnemyCardOpen(EnemySkillingNum);
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
