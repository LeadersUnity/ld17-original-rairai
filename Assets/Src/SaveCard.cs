using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCard : MonoBehaviour
{
    public static SaveCard Instance;


    public static int AcardN; // 数値で保持したい値
    public static int BcardN; // 数値で保持したい値
    public static int CcardN; // 数値で保持したい値
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // gameObject を保持
        }
        else
        {
            Destroy(gameObject); // 重複防止
        }
    }
}
