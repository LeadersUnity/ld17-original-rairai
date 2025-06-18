using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject winImage;
    public GameObject loseImage;
    public GameObject hikiwakeImage;
    void Start()
    {
        if(Judge.resultEnemyHp < Judge.resultPlayerHp)
        {
            winImage.gameObject.SetActive(true);
            loseImage.gameObject.SetActive(false);
            hikiwakeImage.gameObject.SetActive(false);
        }
        else if (Judge.resultEnemyHp > Judge.resultPlayerHp)
        {
            winImage.gameObject.SetActive(false);
            loseImage.gameObject.SetActive(true);
            hikiwakeImage.gameObject.SetActive(false);
        }
        else if (Judge.resultEnemyHp == Judge.resultPlayerHp)
        {
            winImage.gameObject.SetActive(false);
            loseImage.gameObject.SetActive(false);
            hikiwakeImage.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResultToHome()
    {
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
    }

}
