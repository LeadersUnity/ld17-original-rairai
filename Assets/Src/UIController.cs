using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;

public class UIController : MonoBehaviour
{
    public Slider enemyHpSlider;//HPバー
    public Slider enemyRedSlider;
    public Text enemyHitValue;
    public static float resultEnemyHp;

    public Slider playerHpSlider;//最大数から割合を算出しバーの動きを表現できる
    public Slider playerRedSlider;
    public Text playerHitValue;
    public static float resultPlayerHp;

    public GameManager GameManager;
    public SkillUIManager SkillUIManager;
    public PLAYUIUX PLAYUIUX;

    public Text talkText; //ログを画面に表示させる
    public TextMeshProUGUI TarnNumText;//現在のターン
    public static int TarnNum;
    public static int EventNum=1;
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

        //enemySkillBool = false;
        //playerSkillBool = false;


    }

    // Update is called once per frame
    void Update()
    {
        TarnNumText.text = TarnNum.ToString() + "tarn";
        



    }
    public void EnemyTakeDamageUI(float Hitdamage)
    {
        
        float beforeHp = enemyHpSlider.value;//eX
        //damege = 攻撃される前の体力 - 攻撃後の残り体力
        float hp = beforeHp - Hitdamage;
        enemyHpSlider.value = hp;//スライダーに反映


        SetTalkText(Hitdamage + "の\nダメージを与えた！");

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

        SetTalkText(Hitdamage + "の\nダメージを受けた！");

        playerHitValue.text = "-" + Hitdamage.ToString();
        playerHitValue.color = damageColor;

        StartCoroutine(PlayerRedSlider(hp, beforeHp));//pX 遅い赤いバー
       
        
    }
    public void PlayerCureUI(float cure)
    {
        float hp = playerHpSlider.value + cure;
        playerHpSlider.value = hp;
        playerRedSlider.value = hp;//pX

        //SetTalkText(damage + "回復した！");

        playerHitValue.text = "+" + cure;
        playerHitValue.color = cureColor;  
    }
    public void EnemyCureUI(float cure)
    {
        float hp = enemyHpSlider.value + cure;
        enemyHpSlider.value = hp;
        enemyRedSlider.value = hp;

        //SetTalkText(damage + "回復した！");

        enemyHitValue.text = "+" + cure;
        enemyHitValue.color = cureColor;


    }


    public void PlayerGardFire(int DebuffN)
    {
        PlayerGardingTime += DebuffN;
    }
    public void EnemyGardFire(int DebuffN)
    {
        EnemyGardingTime += DebuffN;
    }

    public void PlayerAttackFire(int DebuffN)
    {
        PlayerFireingTime += DebuffN;
    }
    public void EnemyAttackFire(int DebuffN)
    {
        EnemyFireingTime += DebuffN;
    }


    //tarnFire
    public void TarnFire()
    {
        PlayerHitFire = 100;//プレイヤーが受ける
        EnemyHitFire = 100;//エネミーが受ける

        if(randomFireTarnN > 0)//ランダムイベント
        {
            PlayerHitFire = Random.Range(50,201);
            EnemyHitFire = Random.Range(50, 201);

            randomFireTarnN--;
        }

        if(PlayerGardingTime > 0)//プレイヤーのスキル
        {
            PlayerHitFire -= 50;//プレイヤーが受ける
            PlayerGardingTime--;
        }
        if(EnemyGardingTime > 0)
        {
            EnemyHitFire -= 50;
            EnemyGardingTime--;
        }
        if (PlayerFireingTime > 0)//プレイヤーのスキル
        {
            EnemyHitFire += 50;//エネミーが受ける
            PlayerFireingTime--;
        }
        if (EnemyFireingTime > 0)
        {
            PlayerHitFire += 50;
            EnemyFireingTime--;
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

            yield return new WaitForSeconds(0.002f);
            playerRedSlider.value = i;//スライダーに反映
        }
    }

    public IEnumerator WinnerOrLooserJudge()
    {
        if (playerHpSlider.value <= 0 || enemyHpSlider.value <= 0)
        {
            resultEnemyHp = enemyHpSlider.value;
            resultPlayerHp = playerHpSlider.value;
            SceneManager.LoadScene("Result", LoadSceneMode.Single);
        }
        else
        {
            if (EventNum == 5)//３ターン目が終えたら
            {
                PlayerCureUI(300f);
                EnemyCureUI(300f);

                int RandomEvent = Random.Range(1,5);
                RandomEvents(RandomEvent);
                EventNum = 0;
                yield return new WaitForSeconds(1f);
            }
            PLAYUIUX.SetActiveFalse();
            SkillUIManager.SkillCooling();

            TarnNum++;
            EventNum++;
            GameManager.Stoper = true;
            EnemySkillController.EnemySkillSettioning = true;
        }
    }
    public void RandomEvents(int RandomEventNum)
    {
        if(RandomEventNum == 1)//熱ダメージがランダムに
        {
            SetTalkText("イベント：熱ランダム");
            randomFireTarnN = 5;
            EventNum = 0;
        }
        else if (RandomEventNum == 2)//付与効果を全剥がし
        {
            SetTalkText("イベント：ロウリュウ");
            PlayerGardingTime = 0;  
            EnemyGardingTime = 0;
            PlayerFireingTime = 0;
            EnemyFireingTime = 0;
           
            EventNum = 0;
        }
        else if (RandomEventNum == 3)
        {
            SetTalkText("イベント：noEvent");
            EventNum = 0;
        }
        else if (RandomEventNum == 4)
        {
            SetTalkText("イベント：noEvent");
            EventNum = 0;
        }
       
    }
}
