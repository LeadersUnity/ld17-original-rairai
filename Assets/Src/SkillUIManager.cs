using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;


public class SkillUIManager : MonoBehaviourPun
{
    public GameManager GameManager;
    public PLAYUIUX PLAYUIUX;
    public EnemySkillController EnemySkillController;
    //public EnemySkillController EnemySkillController;

    int SkillingNum = 0;//選択されたスキルを整数で管理
    bool SkillOK = false;//スキルが完全に選択されたかを確認
    
   
    public Button SkillGardFireCard;
    public Button SkillAttackFireCard;
    public Button SkillDrainCard;
    public Button SkillCaunterCard;
    public Button SkillHealGardCard;

    public TextMeshProUGUI GardFireText;
    public TextMeshProUGUI AttackFireText;
    public TextMeshProUGUI DrainText;
    public TextMeshProUGUI CaunterText;
    public TextMeshProUGUI HealGardText;

    public Image GardFireImage;
    public Image AttackFireImage;
    public Image DrainImage;
    public Image CaunterImage;
    public Image HealGardImage;


    int AcardN=0,BcardN=0,CcardN=0;

    Vector3 AcardPos = new Vector3(92f, -403f, 0f);
    Vector3 BcardPos = new Vector3(298f, -403f, 0f);
    Vector3 CcardPos = new Vector3(504f, -403f, 0f);

    Player opponent;


    int[] skillCoolTarn = { 0, 0, 0, 0, 0 };
    int[] skillCoolNum = { 2, 2, 1, 1, 1 };
    bool[] skillCoolBool = { false, false, false, false, false };
    void Start()
    {
        SetActiveFalse();

        AcardN = HomeToBattle.AcardNum;
        BcardN = HomeToBattle.BcardNum;
        CcardN = HomeToBattle.CcardNum;

        RectTransform GardFireRt = SkillGardFireCard.GetComponent<RectTransform>();
        RectTransform AttackFireRt = SkillAttackFireCard.GetComponent<RectTransform>();
        RectTransform DrainRt = SkillDrainCard.GetComponent<RectTransform>();
        RectTransform CaunterRt = SkillCaunterCard.GetComponent<RectTransform>();
        RectTransform HealGardRt = SkillHealGardCard.GetComponent<RectTransform>();

        // 相手プレイヤーを取得
        //opponent = PhotonNetwork.PlayerListOthers[0]; // 自分以外のプレイヤー
        

        if (AcardN != 0)
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
        // opponent が未設定の場合、プレイヤーが参加済みか確認して取得
        if (opponent == null && PhotonNetwork.PlayerListOthers.Length > 0)
        {
            opponent = PhotonNetwork.PlayerListOthers[0];
            Debug.Log("Opponent を取得しました：" + opponent.NickName);
        }
        // opponent が null のままだったら何もしない
        if (opponent == null) return;


        if (SkillingNum != 0)//スキル選択
        {
            if(SkillOK == true)//OKbutton
            {
                SetActiveFalse();
                GameManager.PlayerSkillN = SkillingNum;

                //相手に送る
                RaiseEventOptions options = new RaiseEventOptions
                {
                    TargetActors = new int[] { opponent.ActorNumber }
                };
                PhotonNetwork.RaiseEvent(1, SkillingNum, options, SendOptions.SendReliable);


                SkillOK = false;
            }
        }
    }


    public void SkillGoTo()
    {
        SkillGo(SkillingNum);
        SkillingNum = 0;
        
        
    }
    
    public void SkillGo(int SkillingN)
    {
        GameManager.PlayerSKill = SkillingN;
        //GameManagerに選択されたスキル情報を呼び出し
        if (SkillingN == 1)
        {
            
            GameManager.SkillGardFire();
            skillCoolBool[0] = true;
            processing();//進行中はカードをふれられない
        }
        else if (SkillingN == 2)
        {
            
            GameManager.SkillAttackFire();
            skillCoolBool[1] = true;
            processing();
        }
        else if (SkillingN == 3)
        {
           
            GameManager.SkillDrain();
            skillCoolBool[2] = true;
            processing();
        }
        else if (SkillingN == 4)
        {
           
            GameManager.SkillCaunter();
            skillCoolBool[3] = true;
            processing();
        }
        else if (SkillingN == 5)
        {
            
            GameManager.SkillHealGard();
            skillCoolBool[4] = true;
            processing();
        }
    }

    public void SkillOKCaunter()
    {
        SkillOK = true;
        
    }

    public void SkillGardFireCaunt()
    {
        SetActiveFalse();
        GardFireImage.gameObject.SetActive(true);
        SkillingNum = 1;
        
    }
    public void SkillAttackFireCaunt()
    {
        SetActiveFalse();
        AttackFireImage.gameObject.SetActive(true);
        SkillingNum = 2;
    }
    public void SkillDrainCaunt()
    {
        SetActiveFalse();
        DrainImage.gameObject.SetActive(true);
        SkillingNum = 3;
    }
    public void SkillCaunterCaunt()
    {
        SetActiveFalse();
        CaunterImage.gameObject.SetActive(true);
        SkillingNum = 4;
    }
    public void SkillHealGardCaunt()
    {
        SetActiveFalse();
        HealGardImage.gameObject.SetActive(true);
        SkillingNum = 5;
    }

    public void SkillCooling()
    {
        
        for (int i=0;i<5;i++)
        {
            
            if (skillCoolTarn[i] > 0)
            {
                skillCoolTarn[i]--;
            }

        }
        GardFireText.text = skillCoolTarn[0].ToString();
        AttackFireText.text = skillCoolTarn[1].ToString();
        DrainText.text = skillCoolTarn[2].ToString();
        CaunterText.text = skillCoolTarn[3].ToString();
        HealGardText.text = skillCoolTarn[4].ToString();
        for (int j = 0; j < 5; j++)
        {
            if (skillCoolTarn[j] == 0)
            {
                if (j == 0)
                {
                    SkillGardFireCard.enabled = true;
                    GardFireText.text = "";
                }
                else if (j == 1)
                {
                    SkillAttackFireCard.enabled = true;
                    AttackFireText.text = "";
                }
                else if (j == 2)
                {
                    SkillDrainCard.enabled = true;
                    DrainText.text = "";
                }
                else if (j == 3)
                {
                    SkillCaunterCard.enabled = true;
                    CaunterText.text = "";
                }
                else if (j == 4)
                {
                    SkillHealGardCard.enabled = true;
                    HealGardText.text = "";
                }
            }
            if (skillCoolBool[j] == true)
            {
                skillCoolTarn[j] += skillCoolNum[j];
                
                if(j==0)
                {
                    SkillGardFireCard.enabled = false;
                    GardFireText.text = skillCoolTarn[j].ToString();
                }
                else if(j==1)
                {
                    SkillAttackFireCard.enabled = false;
                    AttackFireText.text = skillCoolTarn[j].ToString();
                }
                else if (j == 2)
                {
                    SkillDrainCard.enabled = false;
                    DrainText.text = skillCoolTarn[j].ToString();
                }
                else if (j == 3)
                {
                    SkillCaunterCard.enabled = false;
                    CaunterText.text = skillCoolTarn[j].ToString();
                }
                else if (j == 4)
                {
                    SkillHealGardCard.enabled = false;
                    HealGardText.text = skillCoolTarn[j].ToString();
                }
                skillCoolBool[j] = false;
            }
        }

    }
    public void processing()//進行中はカードをふれられない
    {
        SkillGardFireCard.enabled = false;
        SkillAttackFireCard.enabled = false;
        SkillDrainCard.enabled = false;
        SkillCaunterCard.enabled = false;
        SkillHealGardCard.enabled = false;
    }

    public void SetActiveFalse()
    {
        GardFireImage.gameObject.SetActive(false);
        AttackFireImage.gameObject.SetActive(false);
        DrainImage.gameObject.SetActive(false);
        CaunterImage.gameObject.SetActive(false);
        HealGardImage.gameObject.SetActive(false);
    }
}
