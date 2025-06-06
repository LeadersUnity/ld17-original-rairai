using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIManager : MonoBehaviour
{
    public GameManager GameManager;
    
    int SkillingNum = 0;//選択されたスキルを整数で管理
    bool SkillOK = false;//スキルが完全に選択されたかを確認
    
   
    public Button SkillGardFireCard;
    public Button SkillAttackFireCard;
    public Button SkillDrainCard;
    public Button SkillCaunterCard;
    public Button SkillHealGardCard;

    int AcardN=0,BcardN=0,CcardN=0;

    Vector3 AcardPos = new Vector3(92f, -403f, 0f);
    Vector3 BcardPos = new Vector3(298f, -403f, 0f);
    Vector3 CcardPos = new Vector3(504f, -403f, 0f);

    void Start()
    {
        AcardN = HomeToBattle.AcardNum;
        BcardN = HomeToBattle.BcardNum;
        CcardN = HomeToBattle.CcardNum;

        RectTransform GardFireRt = SkillGardFireCard.GetComponent<RectTransform>();
        RectTransform AttackFireRt = SkillAttackFireCard.GetComponent<RectTransform>();
        RectTransform DrainRt = SkillDrainCard.GetComponent<RectTransform>();
        RectTransform CaunterRt = SkillCaunterCard.GetComponent<RectTransform>();
        RectTransform HealGardRt = SkillHealGardCard.GetComponent<RectTransform>();

        if(AcardN != 0)
        {
            if(AcardN == 1)
            {
                GardFireRt.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
            }
            else if(AcardN == 2)
            {
                AttackFireRt.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
            }
            else if (AcardN == 3)
            {
                DrainRt.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
            }
            else if (AcardN == 4)
            {
                CaunterRt.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
            }
            else if (AcardN == 5)
            {
                HealGardRt.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
            }
        }
        if (BcardN != 0)
        {
            if (BcardN == 1)
            {
                GardFireRt.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
            }
            else if (BcardN == 2)
            {
                AttackFireRt.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
            }
            else if (BcardN == 3)
            {
                DrainRt.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
            }
            else if (BcardN == 4)
            {
                CaunterRt.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
            }
            else if (BcardN == 5)
            {
                HealGardRt.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
            }
        }
        if (CcardN != 0)
        {
            if (CcardN == 1)
            {
                GardFireRt.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
            }
            else if (CcardN == 2)
            {
                AttackFireRt.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
            }
            else if (CcardN == 3)
            {
                DrainRt.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
            }
            else if (CcardN == 4)
            {
                CaunterRt.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
            }
            else if (CcardN == 5)
            {
                HealGardRt.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
            }
        }
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
                
                }
                else if (SkillingNum == 2)
                {
                    GameManager.SkillAttackFire();
                    
                }
                else if (SkillingNum == 3)
                {
                    GameManager.SkillDrain();
               
                }
                else if (SkillingNum == 4)
                {
                    GameManager.SkillCaunter();
                
                }
                else if (SkillingNum == 5)
                {
                    GameManager.SkillHealGard();
              
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

    
}
