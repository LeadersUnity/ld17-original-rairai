using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Unity.VisualScripting;
//using static System.Net.Mime.MediaTypeNames;

public class UIController : MonoBehaviourPunCallbacks
{
    public Text PHPT;
    public Text EHPT;
    public Slider enemyHpSlider;//HPバー
    public Slider enemyRedSlider;
    public Text enemyHitValue;
    

    public Slider playerHpSlider;//最大数から割合を算出しバーの動きを表現できる
    public Slider playerRedSlider;
    public Text playerHitValue;
    

    public GameManager GameManager;
    public SkillUIManager SkillUIManager;
    public PLAYUIUX PLAYUIUX;
    public BattleSEbg BattleSEbg;

    public Text talkText; //ログを画面に表示させる
    public TextMeshProUGUI TarnNumText;//現在のターン
    public static int TarnNum;
    public static int EventNum = 1;

    public Image EventUI1;
    public Image EventUI2;
    public Image PfireHuyo;
    public Image EfireHuyo;
    public Image PgardHuyo;
    public Image EgardHuyo;
    const byte EVENT_RANDOM_EVENT = 100; // イベント発生用

    //bool enemySkillBool;
    //bool playerSkillBool;


    public Color damageColor; //ダメージと回復でtextの色を変える
    public Color cureColor;

    float playerHp = 1000.0f;
    float enemyHp = 1000.0f;

    int PlayerHitFire = 50;
    int EnemyHitFire = 50;

    float PlayerGardingTime = 0;
    float EnemyGardingTime = 0;

    float PlayerFireingTime = 0;
    float EnemyFireingTime = 0;

    int randomFireTarnN = 0;

    int PcurePlus = 0;
    int EcurePlus = 0;
    void Start()
    {
        playerHpSlider.maxValue = playerHp;
        playerHpSlider.value = playerHp;
        playerRedSlider.maxValue = playerHp;
        playerRedSlider.value = playerHp;

        enemyHpSlider.maxValue = enemyHp;
        enemyHpSlider.value = enemyHp;
        enemyRedSlider.maxValue = enemyHp;
        enemyRedSlider.value = enemyHp;

        TarnNum = 1;
        
        EventUI1.gameObject.SetActive(false);
        EventUI2.gameObject.SetActive(false);

        PfireHuyo.gameObject.SetActive(false);
        EfireHuyo.gameObject.SetActive(false);
        PgardHuyo.gameObject.SetActive(false);
        EgardHuyo.gameObject.SetActive(false);
        //enemySkillBool = false;
        //playerSkillBool = false;


    }

    // Update is called once per frame
    void Update()
    {
        TarnNumText.text = TarnNum.ToString() + "tarn";

        PHPT.text = playerHpSlider.value.ToString();
        EHPT.text = enemyHpSlider.value.ToString();



    }
    public void EnemyTakeDamageUI(float Hitdamage)
    {

        float beforeHp = enemyHpSlider.value;//eX
        //damege = 攻撃される前の体力 - 攻撃後の残り体力
        float hp = beforeHp - Hitdamage;
        enemyHpSlider.value = hp;//スライダーに反映


        BattleSEbg.damageSE();

        enemyHitValue.text = "-" + Hitdamage.ToString();//表示するダメージ「-damage」
        enemyHitValue.color = damageColor;

        StartCoroutine(EnemyRedSlider(hp, beforeHp));//eX 敵の遅い赤いバー


        // StartCoroutine(TarnToNextTien(SkillOrFire));//遅延


    }
    public void PlayerTakeDamageUI(float Hitdamage)
    {


        float beforeHp = playerHpSlider.value;//pX
        float hp = beforeHp - Hitdamage;
        playerHpSlider.value = hp;

        BattleSEbg.damageSE();

        playerHitValue.text = "-" + Hitdamage.ToString();
        playerHitValue.color = damageColor;

        StartCoroutine(PlayerRedSlider(hp, beforeHp));//pX 遅い赤いバー


    }
    public void PlayerCureUI(float cure)
    {
        float hp = playerHpSlider.value + cure;

         if(hp > 1000)
        {
            PcurePlus += (int)hp - 1000;
        }

        BattleSEbg.healSE();

        playerHpSlider.value = hp;
        playerRedSlider.value = hp;//pX

       
        //SetTalkText(damage + "回復した！");

        playerHitValue.text = "+" + cure;
        playerHitValue.color = cureColor;
    }
    public void EnemyCureUI(float cure)
    {
        float hp = enemyHpSlider.value + cure;
        if(hp > 1000)
        {
            EcurePlus += (int)hp - 1000;
        }

        BattleSEbg.healSE();

        enemyHpSlider.value = hp;
        enemyRedSlider.value = hp;

        //SetTalkText(damage + "回復した！");

        enemyHitValue.text = "+" + cure;
        enemyHitValue.color = cureColor;


    }


    public void PlayerGardFire(int DebuffN)
    {
        BattleSEbg.gardSE();
        PlayerGardingTime += DebuffN;
        PgardHuyo.gameObject.SetActive(true);
    }
    public void EnemyGardFire(int DebuffN)
    {
        BattleSEbg.gardSE();
        EnemyGardingTime += DebuffN;
        EgardHuyo.gameObject.SetActive(true);
    }

    public void PlayerAttackFire(int DebuffN)
    {
        BattleSEbg.fireSE();
        PlayerFireingTime += DebuffN;
        EfireHuyo.gameObject.SetActive(true);
    }
    public void EnemyAttackFire(int DebuffN)
    {
        BattleSEbg.fireSE();
        EnemyFireingTime += DebuffN;
        PfireHuyo.gameObject.SetActive(true);
    }


    //tarnFire
    public void TarnFire()
    {
        PlayerHitFire = 100;//プレイヤーが受ける
        EnemyHitFire = 100;//エネミーが受ける
        SetTalkText("熱ダメージ発生");
        if (randomFireTarnN > 0)//ランダムイベント
        {
            if (PhotonNetwork.IsMasterClient)
            {
                int player1hit = Random.Range(50, 201);
                int player2hit = Random.Range(50, 201);

                object[] dmgData = new object[] { player1hit, player2hit };

                PhotonNetwork.RaiseEvent(101, dmgData, new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.All
                }, SendOptions.SendReliable);
            }
            

            randomFireTarnN--;
        }


        if (PlayerGardingTime > 0)//プレイヤーのスキル
        {
            PlayerHitFire -= 50;//プレイヤーが受ける
            PlayerGardingTime--;
        }
        if(PlayerGardingTime <= 0)
        {
            PgardHuyo.gameObject.SetActive(false);
        }

        if (EnemyGardingTime > 0)
        {
            EnemyHitFire -= 50;
            EnemyGardingTime--;
        }
        if (EnemyGardingTime <= 0)
        {
            EgardHuyo.gameObject.SetActive(false);
        }

        if (PlayerFireingTime > 0)//プレイヤーのスキル
        {
            EnemyHitFire += 50;//エネミーが受ける
            PlayerFireingTime--;
        }
        if (PlayerFireingTime <= 0)//プレイヤーのスキル
        {
            EfireHuyo.gameObject.SetActive(false);
        }

        if (EnemyFireingTime > 0)
        {
            PlayerHitFire += 50;
            EnemyFireingTime--;
        }
        if (EnemyFireingTime <= 0)
        {
            PfireHuyo.gameObject.SetActive(false);
        }

        if(PcurePlus > 0)
        {
            if(PlayerHitFire < PcurePlus)
            {
               PcurePlus -= PlayerHitFire;
               PlayerHitFire = 0;
               
            }
            else if(PlayerHitFire >= PcurePlus)
            {
               PlayerHitFire = PlayerHitFire - PcurePlus;
               PcurePlus = 0;
            }
            
        }
        if(EcurePlus > 0)
        {
            if(EnemyHitFire < EcurePlus)
            {
               EcurePlus -= EnemyHitFire;
               EnemyHitFire = 0;
               
            }
            else if(EnemyHitFire >= EcurePlus)
            {
               EnemyHitFire = EnemyHitFire - EcurePlus;
               EcurePlus = 0;
            }
            
        }

        EnemyTakeDamageUI(EnemyHitFire);
        PlayerTakeDamageUI(PlayerHitFire);
        
        
    }
    public void SetTalkText(string text)
    {
        talkText.text = text;
        StartCoroutine(ResetTalkText());//ダメージ、回復テキストを一定時間で消す
    }



    IEnumerator ResetTalkText()
    {
        yield return new WaitForSeconds(1.0f);
        enemyHitValue.text = "";
        playerHitValue.text = "";
    }
    //赤い遅いバー eX
    IEnumerator EnemyRedSlider(float hitP, float beforeHitP)
    {
        yield return new WaitForSeconds(1.0f);
        //enemyRedSlider.value = hitP;//スライダーに反映
        for (float i = beforeHitP; i > hitP; i--)
        {

            yield return new WaitForSeconds(0.002f);
            enemyRedSlider.value = i;//スライダーに反映
        }
    }
    //pX
    IEnumerator PlayerRedSlider(float hitP, float beforeHitP)
    {
        yield return new WaitForSeconds(1.0f);
        //enemyRedSlider.value = hitP;//スライダーに反映
        for (float i = beforeHitP; i > hitP; i--)
        {

            yield return new WaitForSeconds(0.001f);
            playerRedSlider.value = i;//スライダーに反映
        }
    }

    public IEnumerator WinnerOrLooserJudge()
    {
        if (playerHpSlider.value <= 0 || enemyHpSlider.value <= 0)
        {
            Judge.resultEnemyHp = enemyHpSlider.value;
            Judge.resultPlayerHp = playerHpSlider.value;
            PhotonNetwork.LeaveRoom();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Result", LoadSceneMode.Single);
            
            
        }
        else
        {
            if (EventNum == 5)//5ターン目が終えたら
            {

                RandomEvents();
                EventNum = 0;
                yield return new WaitForSeconds(1f);
            }
            PLAYUIUX.SetActiveFalse();
            SkillUIManager.SkillCooling();

            TarnNum++;
            EventNum++;

            GameManager.PlayerSKill = 0;
            GameManager.EnemySKill = 0;

            GameManager.Stoper = true;
            EnemySkillController.EnemySkillSettioning = true;
        }
    }
    public override void OnLeftRoom()
    {
        Debug.Log("ルームを離脱しました。結果画面に遷移します");
        
    }

    public void RandomEvents()
    {

        if (PhotonNetwork.IsMasterClient)
        {
            int randomEventNum = Random.Range(1, 3); // 1〜3のイベント
            PhotonNetwork.RaiseEvent(EVENT_RANDOM_EVENT, randomEventNum, new RaiseEventOptions
            {
                Receivers = ReceiverGroup.All
            }, SendOptions.SendReliable);
        }



    }



    void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    void OnEvent(EventData photonEvent)
    {
        if(SceneManager.GetActiveScene().name == "Result") return;
         // ★ GameManager や UIController が消えてる可能性をケア
        
        if (photonEvent.Code == EVENT_RANDOM_EVENT)
        {
            int eventNum = (int)photonEvent.CustomData;
            HandleEvent(eventNum); // 同期処理へ
        }

        if (photonEvent.Code == 101)
        {
            object[] dmgData = (object[])photonEvent.CustomData;

            int receivedPlayerDmg = (int)dmgData[0];
            int receivedEnemyDmg = (int)dmgData[1];

           
            if (PhotonNetwork.IsMasterClient)
            {
                // MasterClient → そのまま
                PlayerHitFire = receivedPlayerDmg;
                EnemyHitFire = receivedEnemyDmg;
            }
            else
            {
                // 相手側 → 反転
                PlayerHitFire = receivedEnemyDmg;
                EnemyHitFire = receivedPlayerDmg;
            }

            Debug.Log("自分のダメージ: " + PlayerHitFire);
            Debug.Log("相手のダメージ: " + EnemyHitFire);

            
        }
    }

    void HandleEvent(int eventNum)
    {
        StartCoroutine(EventUI(eventNum));
        PlayerCureUI(200f);
        EnemyCureUI(200f);
        if (eventNum == 1)//熱ダメージがランダムに
        {

            SetTalkText("イベント：熱ランダム");
            randomFireTarnN = 5;
            EventNum = 0;
        }
        else if (eventNum == 2)//付与効果を全剥がし
        {
            SetTalkText("イベント：ロウリュウ");
            PlayerGardingTime = 0;
            EnemyGardingTime = 0;
            PlayerFireingTime = 0;
            EnemyFireingTime = 0;

            EventNum = 0;
        }
        else if (eventNum == 3)
        {
            SetTalkText("イベント：noEvent");
            EventNum = 0;
        }
    }

    IEnumerator EventUI(int eventN)
    {
        if(eventN == 1)
        {
            EventUI1.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.8f);
            EventUI1.gameObject.SetActive(false);
        }
        else if(eventN == 2)
        {
            EventUI2.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.8f);
            EventUI2.gameObject.SetActive(false);
        }
    }

}
