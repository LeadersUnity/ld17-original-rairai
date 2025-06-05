using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeToBattle : MonoBehaviour
{
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
    void Start()
    {
        CardSelectReturnHomeB.gameObject.SetActive(false);

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

        CardSelectBack.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadBattle()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    public void CardSectionButton()
    {

    }
}
