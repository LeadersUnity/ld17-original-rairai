using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillController : MonoBehaviour
{
    public GameManager GameManager;
    int SkillingNum = 0;//選択されたスキルを整数で管理
    


    public GameObject SkillGardFireCard;
    public GameObject SkillAttackFireCard;
    public GameObject SkillDrainCard;

    int EnemySkilling;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
         if(EnemySkilling != 0)//相手情報を受け取って
        {
            //相手情報を受け取って
            if (SkillingNum == 1)
            {
                GameManager.EnemySkillGardFire();
            }
            else if (SkillingNum == 2)
            {
                GameManager.EnemySkillAttackFire();
            }
            else if (SkillingNum == 3)
            {
                GameManager.EnemySkillDrain();
            }
            else if (SkillingNum == 4)
            {
                GameManager.EnemySkillCaunter();
            }
            else if (SkillingNum == 5)
            {
                GameManager.EnemySkillHealGard();
            }
            SkillingNum = 0;
            
        }
         
    }
}
