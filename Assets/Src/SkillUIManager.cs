using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIManager : MonoBehaviour
{
    public GameManager GameManager;
    public UIController UIController;
    int SkillingNum = 0;//選択されたスキルを整数で管理
    bool SkillOK = false;//スキルが完全に選択されたかを確認

   
    public GameObject SkillGardFireCard;
    public GameObject SkillAttackFireCard;
    public GameObject SkillDrainCard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SkillingNum != 0)//スキル選択
        {
            if(SkillOK == true)//OKbutton
            {
                //GameManagerに選択されたスキル情報を呼び出し
                if(SkillingNum == 1)
                {
                    GameManager.SkillGardFire();
                    StartCoroutine(ToTarnFire());
                }
                else if (SkillingNum == 2)
                {
                    GameManager.SkillAttackFire();
                    StartCoroutine(ToTarnFire());
                }
                else if (SkillingNum == 3)
                {
                    GameManager.SkillDrain();
                    StartCoroutine(ToTarnFire());
                }
                else if (SkillingNum == 4)
                {
                    GameManager.SkillCaunter();
                    StartCoroutine(ToTarnFire());
                }
                else if (SkillingNum == 5)
                {
                    GameManager.SkillHealGard();
                    StartCoroutine(ToTarnFire());
                }
                SkillingNum = 0;
                SkillOK = false;
            }
        }
    }

    public void SkillOKCaunter()
    {
        SkillOK = true;

    }

    public void SkillGardFireCaunt()
    {
        
        SkillingNum = 1;
    }
    public void SkillAttackFireCaunt()
    {
        SkillingNum = 2;
    }
    public void SkillDrainCaunt()
    {
        SkillingNum = 3;
    }
    public void SkillCaunterCaunt()
    {
        SkillingNum = 4;
    }
    public void SkillHealGardCaunt()
    {
        SkillingNum = 5;
    }

    IEnumerator ToTarnFire()
    {
        yield return new WaitForSeconds(2.0f);
        UIController.TarnFire();
        yield return new WaitForSeconds(2.0f);
        UIController.TarnNum += 1;
    }
}
