using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillController : MonoBehaviour
{
    public GameManager GameManager;
    public PLAYUIUX PLAYUIUX;

    public static bool EnemysCaunterJudege = false;

    int EnemySkillingNum = 0;//選択されたスキルを整数で管理


    
    public static bool EnemySkillSettioning = false;//相手のデータを受け取ったか
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
            if (EnemySkillingNum != 0)//相手情報を受け取って
            {
                
                GameManager.EnemySkillN = EnemySkillingNum;
                PLAYUIUX.SetEnemyReverseCard(true);
                EnemySkillSettioning = false;
            }
        }
       
         
    }
    //public void EnemySkillSettion(int EnemySkillingNum)
    //{
    //    EnemySkillSettioning = true;
    //}
    public void EnemySkillToGo()
    {
        StartCoroutine(EnemySkillTake());
        
        
    }
    public IEnumerator EnemySkillTake()
    {
        
        yield return new WaitForSeconds(2.0f);
        
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
