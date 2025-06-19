using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeToBattle : MonoBehaviour
{//カードセレクトもここでやっているのでmanagerな感じ
    public Button CardSelectReturnHomeB;

    public Button ACardSelectB;
    public Button BCardSelectB;
    public Button CCardSelectB;
    public Button ReturnSelectB;

    public Button GardFireB;
    public Button AttackFireB;
    public Button DrainB;
    public Button CaunterB;
    public Button HealGardB;

    public Image GardFireImage;
    public Image AttackFireImage;
    public Image DrainImage;
    public Image CaunterImage;
    public Image HealGardImage;

    public Image CardSelectBack;

    public Image GardFireMyCard;
    public Image AttackFireMyCard;
    public Image DrainMyCard;
    public Image CaunterMyCard;
    public Image HealGardMyCard;



    Vector3 GardFireChangePos;
    Vector3 AttackFireChangePos;
    Vector3 DrainChangePos;
    Vector3 CaunterChangePos;
    Vector3 HealGardChangePos;

    Vector3 AcardPos = new Vector3(-91f, -405f, 0f);
    Vector3 BcardPos = new Vector3(149f, -405f, 0f);
    Vector3 CcardPos = new Vector3(390f, -405f, 0f);

    int CardSeter = 0;

    public static int AcardNum = 0;
    public static int BcardNum = 0;
    public static int CcardNum = 0;
    int beforeAcardN = 0;
    int beforeBcardN = 0;
    int beforeCcardN = 0;
    void Start()
    {
        
        CardSelectReturnHomeB.gameObject.SetActive(false);
        CardSelectBack.gameObject.SetActive(false);

        ACardSelectB.gameObject.SetActive(false);
        BCardSelectB.gameObject.SetActive(false);
        CCardSelectB.gameObject.SetActive(false);
        ReturnSelectB.gameObject.SetActive(false);

        GardFireB.gameObject.SetActive(false);
        AttackFireB.gameObject.SetActive(false);
        DrainB.gameObject.SetActive(false);
        CaunterB.gameObject.SetActive(false);
        HealGardB.gameObject.SetActive(false);

        
        GardFireImage.gameObject.SetActive(false);
        AttackFireImage.gameObject.SetActive(false);
        DrainImage.gameObject.SetActive(false);
        CaunterImage.gameObject.SetActive(false);
        HealGardImage.gameObject.SetActive(false);

        CardStartPos();
        //cardの初期位置を記録して、カードセレクトでカードを入れ替えた時に戻すカードを初期位置に戻すため


        if(SaveCard.AcardN != 0 || SaveCard.BcardN != 0 && SaveCard.CcardN != 0)
        {
            AcardNum = SaveCard.AcardN;
            BcardNum = SaveCard.BcardN;
            CcardNum = SaveCard.CcardN;

            ReloadCardDeki(AcardNum, BcardNum, CcardNum);

        }

    }
    void ReloadCardDeki(int Anum, int Bnum, int Cnum)//選択したカード情報を記録再生
    {
        switch (Anum)
        {
            case 1:
                GardFireMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                break;
            case 2:
                AttackFireMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                break;
            case 3:
                DrainMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                break;
            case 4:
                CaunterMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                break;
            case 5:
                HealGardMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                break;
            default:
                break;
        }
        switch (Bnum)
        {
            case 1:
                GardFireMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                break;
            case 2:
                AttackFireMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                break;
            case 3:
                DrainMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                break;
            case 4:
                CaunterMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                break;
            case 5:
                HealGardMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                break;
            default:
                break;
        }
        switch (Cnum)
        {
            case 1:
                GardFireMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                break;
            case 2:
                AttackFireMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                break;
            case 3:
                DrainMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                break;
            case 4:
                CaunterMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                break;
            case 5:
                HealGardMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                break;
            default:
                break;
        }
    }
    void CardStartPos()
    {
        GardFireChangePos = GardFireMyCard.rectTransform.anchoredPosition;
        AttackFireChangePos = AttackFireMyCard.rectTransform.anchoredPosition;
        DrainChangePos = DrainMyCard.rectTransform.anchoredPosition;
        CaunterChangePos = CaunterMyCard.rectTransform.anchoredPosition;
        HealGardChangePos = HealGardMyCard.rectTransform.anchoredPosition;
    }
    // Update is called once per frame
    void Update()
    {
       
            
        
    }
    public void LoadBattle()
    {
        Debug.Log(AcardNum + BcardNum + CcardNum);
        if(AcardNum != 0 && BcardNum != 0 && CcardNum != 0)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
       
    }

    public void CardToSectionButton()
    {
        CardSelectReturnHomeB.gameObject.SetActive(true);
        CardSelectBack.gameObject.SetActive(true);

        GardFireB.gameObject.SetActive(true);
        AttackFireB.gameObject.SetActive(true);
        DrainB.gameObject.SetActive(true);
        CaunterB.gameObject.SetActive(true);
        HealGardB.gameObject.SetActive(true);

    }
    public void ReturnCardSectionToHome()
    {
        CardSelectReturnHomeB.gameObject.SetActive(false);
        CardSelectBack.gameObject.SetActive(false);

        ACardSelectB.gameObject.SetActive(false);
        BCardSelectB.gameObject.SetActive(false);
        CCardSelectB.gameObject.SetActive(false);
        ReturnSelectB.gameObject.SetActive(false);

        GardFireB.gameObject.SetActive(false);
        AttackFireB.gameObject.SetActive(false);
        DrainB.gameObject.SetActive(false);
        CaunterB.gameObject.SetActive(false);
        HealGardB.gameObject.SetActive(false);


        GardFireImage.gameObject.SetActive(false);
        AttackFireImage.gameObject.SetActive(false);
        DrainImage.gameObject.SetActive(false);
        CaunterImage.gameObject.SetActive(false);
        HealGardImage.gameObject.SetActive(false);

        SaveCard.AcardN = AcardNum;
        SaveCard.BcardN = BcardNum;
        SaveCard.CcardN = CcardNum;
    }

    public void GardFireBtoImage()
    {
        GardFireImage.gameObject.SetActive(true);
        AttackFireImage.gameObject.SetActive(false);
        DrainImage.gameObject.SetActive(false);
        CaunterImage.gameObject.SetActive(false);
        HealGardImage.gameObject.SetActive(false);

        ACardSelectB.gameObject.SetActive(true);
        BCardSelectB.gameObject.SetActive(true);
        CCardSelectB.gameObject.SetActive(true);
        ReturnSelectB.gameObject.SetActive(true);

        CardSeter = 1;
    }
    public void AttackFireBtoImage()
    {
        GardFireImage.gameObject.SetActive(false);
        AttackFireImage.gameObject.SetActive(true);
        DrainImage.gameObject.SetActive(false);
        CaunterImage.gameObject.SetActive(false);
        HealGardImage.gameObject.SetActive(false);

        ACardSelectB.gameObject.SetActive(true);
        BCardSelectB.gameObject.SetActive(true);
        CCardSelectB.gameObject.SetActive(true);
        ReturnSelectB.gameObject.SetActive(true);

        CardSeter = 2;
    }
    public void DrainBtoImage()
    {
        GardFireImage.gameObject.SetActive(false);
        AttackFireImage.gameObject.SetActive(false);
        DrainImage.gameObject.SetActive(true);
        CaunterImage.gameObject.SetActive(false);
        HealGardImage.gameObject.SetActive(false);

        ACardSelectB.gameObject.SetActive(true);
        BCardSelectB.gameObject.SetActive(true);
        CCardSelectB.gameObject.SetActive(true);
        ReturnSelectB.gameObject.SetActive(true);

        CardSeter = 3;
    }
    public void CaunterBtoImage()
    {
        GardFireImage.gameObject.SetActive(false);
        AttackFireImage.gameObject.SetActive(false);
        DrainImage.gameObject.SetActive(false);
        CaunterImage.gameObject.SetActive(true);
        HealGardImage.gameObject.SetActive(false);

        ACardSelectB.gameObject.SetActive(true);
        BCardSelectB.gameObject.SetActive(true);
        CCardSelectB.gameObject.SetActive(true);
        ReturnSelectB.gameObject.SetActive(true);

        CardSeter = 4;
    }
    public void HealGardBtoImage()
    {
        GardFireImage.gameObject.SetActive(false);
        AttackFireImage.gameObject.SetActive(false);
        DrainImage.gameObject.SetActive(false);
        CaunterImage.gameObject.SetActive(false);
        HealGardImage.gameObject.SetActive(true);

        ACardSelectB.gameObject.SetActive(true);
        BCardSelectB.gameObject.SetActive(true);
        CCardSelectB.gameObject.SetActive(true);
        ReturnSelectB.gameObject.SetActive(true);

        CardSeter = 5;
    }

    public void AcardSelectButton()
    {
        if(CardSeter != 0 )
        {
            beforeAcardN = AcardNum;
            if(CardSeter == 1 && BcardNum!=1 && CcardNum!=1)
            {
                GardFireMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                AcardNum = 1;

                if(beforeAcardN != AcardNum)
                {
                    CardchangePos(beforeAcardN);
                }
            }
            else if (CardSeter == 2 && BcardNum != 2 && CcardNum != 2)
            {
                AttackFireMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                AcardNum = 2;
                if (beforeAcardN != AcardNum)
                {
                    CardchangePos(beforeAcardN);
                }
            }
            else if (CardSeter == 3 && BcardNum != 3 && CcardNum != 3)
            {
                DrainMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                AcardNum = 3;
                if (beforeAcardN != AcardNum)
                {
                    CardchangePos(beforeAcardN);
                }
            }
            else if (CardSeter == 4 && BcardNum != 4 && CcardNum != 4)
            {
                CaunterMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                AcardNum = 4;
                if (beforeAcardN != AcardNum)
                {
                    CardchangePos(beforeAcardN);
                }
            }
            else if (CardSeter == 5 && BcardNum != 5 && CcardNum != 5)
            {
                HealGardMyCard.rectTransform.anchoredPosition = new Vector2(AcardPos.x, AcardPos.y);
                AcardNum = 5;
                if (beforeAcardN != AcardNum)
                {
                    CardchangePos(beforeAcardN);
                }
            }
        }
    }
    
    public void BcardSelectButton()
    {
        if (CardSeter != 0)
        {
            beforeBcardN = BcardNum;
            if (CardSeter == 1 && AcardNum != 1 && CcardNum != 1)
            {
                GardFireMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                BcardNum = 1;
                if (beforeBcardN != BcardNum)
                {
                    CardchangePos(beforeBcardN);
                }
            }
            else if (CardSeter == 2 && AcardNum != 2 && CcardNum != 2)
            {
                AttackFireMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                BcardNum = 2;
                if (beforeBcardN != BcardNum)
                {
                    CardchangePos(beforeBcardN);
                }
            }
            else if (CardSeter == 3 && AcardNum != 3 && CcardNum != 3)
            {
                DrainMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                BcardNum = 3;
                if (beforeBcardN != BcardNum)
                {
                    CardchangePos(beforeBcardN);
                }
            }
            else if (CardSeter == 4 && AcardNum != 4 && CcardNum != 4)
            {
                CaunterMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                BcardNum = 4;
                if (beforeBcardN != BcardNum)
                {
                    CardchangePos(beforeBcardN);
                }
            }
            else if (CardSeter == 5 && AcardNum != 5 && CcardNum != 5)
            {
                HealGardMyCard.rectTransform.anchoredPosition = new Vector2(BcardPos.x, BcardPos.y);
                BcardNum = 5;
                if (beforeBcardN != BcardNum)
                {
                    CardchangePos(beforeBcardN);
                }
            }
        }
    }
    public void CcardSelectButton()
    {
        if (CardSeter != 0)
        {
            beforeCcardN = CcardNum;
            if (CardSeter == 1 && AcardNum != 1 && BcardNum != 1)
            {
                GardFireMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                CcardNum = 1;
                if (beforeCcardN != CcardNum)
                {
                    CardchangePos(beforeCcardN);
                }
            }
            else if (CardSeter == 2 && AcardNum != 2 && BcardNum != 2)
            {
                AttackFireMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                CcardNum = 2;
                if (beforeCcardN != CcardNum)
                {
                    CardchangePos(beforeCcardN);
                }
            }
            else if (CardSeter == 3 && AcardNum != 3 && BcardNum != 3)
            {
                DrainMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                CcardNum = 3;
                if (beforeCcardN != CcardNum)
                {
                    CardchangePos(beforeCcardN);
                }
            }
            else if (CardSeter == 4 && AcardNum != 4 && BcardNum != 4)
            {
                CaunterMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                CcardNum = 4;
                if (beforeCcardN != CcardNum)
                {
                    CardchangePos(beforeCcardN);
                }
            }
            else if (CardSeter == 5 && AcardNum != 5 && BcardNum != 5)
            {
                HealGardMyCard.rectTransform.anchoredPosition = new Vector2(CcardPos.x, CcardPos.y);
                CcardNum = 5;
                if (beforeCcardN != CcardNum)
                {
                    CardchangePos(beforeCcardN);
                }
            }
        }
    }

    void CardchangePos(int beforeCardNum)//セレクトでカードをチェンジした時元あったカードを初期位置に戻す
    {
        if(beforeCardNum != 0)
        {
            if (beforeCardNum == 1)
            {
                GardFireMyCard.rectTransform.anchoredPosition = new Vector2(GardFireChangePos.x, GardFireChangePos.y);

            }
            else if (beforeCardNum == 2)
            {
                AttackFireMyCard.rectTransform.anchoredPosition = new Vector2(AttackFireChangePos.x, AttackFireChangePos.y);
            }
            else if (beforeCardNum == 3)
            {
                DrainMyCard.rectTransform.anchoredPosition = new Vector2(DrainChangePos.x, DrainChangePos.y);
            }
            else if (beforeCardNum == 4)
            {
                CaunterMyCard.rectTransform.anchoredPosition = new Vector2(CaunterChangePos.x, CaunterChangePos.y);
            }
            else if (beforeCardNum == 5)
            {
                HealGardMyCard.rectTransform.anchoredPosition = new Vector2(HealGardChangePos.x, HealGardChangePos.y);

            }
        }
    }

    public void CardReturnButton()
    {
        ACardSelectB.gameObject.SetActive(false);
        BCardSelectB.gameObject.SetActive(false);
        CCardSelectB.gameObject.SetActive(false);
        ReturnSelectB.gameObject.SetActive(false);

        GardFireImage.gameObject.SetActive(false);
        AttackFireImage.gameObject.SetActive(false);
        DrainImage.gameObject.SetActive(false);
        CaunterImage.gameObject.SetActive(false);
        HealGardImage.gameObject.SetActive(false);
    }
}
