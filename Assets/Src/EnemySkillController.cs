using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class EnemySkillController : MonoBehaviourPun
{
    public GameManager GameManager;
    public PLAYUIUX PLAYUIUX;
    public UIController UIController;

    public static bool EnemysCaunterJudege = false;

    int EnemySkillingNum = 0;//選択されたスキルを整数で管理


    
    public static bool EnemySkillSettioning = false;//相手のデータを受け取ったか
    public static bool EnemySkillingOK = false;//相手のスキルの発動タイミング

    void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    void Start()
    {
        EnemySkillSettioning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemySkillSettioning == true)//相手情報を受け取ったら
        {
            
            if (EnemySkillingNum != 0)//相手情報を表示
            {

                GameManager.EnemySkillN = EnemySkillingNum;
                PLAYUIUX.SetEnemyReverseCard(true);
                EnemySkillSettioning = false;
                
            }
        }
       
         
    }
    //受信
    void OnEvent(EventData photonEvent)
    {
       

       

        if (GameManager != null)
        {
            GameManager.EnemySKill = (int)photonEvent.CustomData;
        }

        if (photonEvent.Code == 1)
        {
            // 受信したスキル番号を保存
            EnemySkillingNum = (int)photonEvent.CustomData;
            Debug.Log("相手から受信したスキル番号: " + EnemySkillingNum);
            EnemySkillSettioning = true;

            
        }
        else if (photonEvent.Code == 2)
        {
            // 受信したスキル番号を保存
            EnemySkillingNum = (int)photonEvent.CustomData;
            Debug.Log("相手から受信したスキル番号: " + EnemySkillingNum);
            EnemySkillSettioning = true;


        }
        else if (photonEvent.Code == 3)
        {
            // 受信したスキル番号を保存
            EnemySkillingNum = (int)photonEvent.CustomData;
            Debug.Log("相手から受信したスキル番号: " + EnemySkillingNum);
            EnemySkillSettioning = true;


        }
        else if (photonEvent.Code == 4)
        {
            // 受信したスキル番号を保存
            EnemySkillingNum = (int)photonEvent.CustomData;
            Debug.Log("相手から受信したスキル番号: " + EnemySkillingNum);
            EnemySkillSettioning = true;


        }
        else if (photonEvent.Code == 5)
        {
            // 受信したスキル番号を保存
            EnemySkillingNum = (int)photonEvent.CustomData;
            Debug.Log("相手から受信したスキル番号: " + EnemySkillingNum);
            EnemySkillSettioning = true;


        }

        else
        {
            Debug.Log("相手から受信した" + photonEvent.Code);
        }
        
    }
    public void ReceiveSkill(int skillNum)
    {
        Debug.Log("EnemySkillController にスキル番号 " + skillNum + " が渡されました");
        // skillNum に応じた処理をここで実装
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
        
        UIController.SetTalkText("Enemyのターン");
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
