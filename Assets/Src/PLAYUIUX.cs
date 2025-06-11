using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLAYUIUX : MonoBehaviour
{
    
    public Image GardFireMine;
    public Image AttackFireMine;
    public Image DrainMine;
    public Image CaunterMine;
    public Image HealGardMine;

    public Image GardFireEnemy;
    public Image AttackFireEnemy;
    public Image DrainEnemy;
    public Image CaunterEnemy;
    public Image HealGardEnemy;

    
    void Start()
    {
        GardFireMine.gameObject.SetActive(false);
        AttackFireMine.gameObject.SetActive(false);
        DrainMine.gameObject.SetActive(false);
        CaunterMine.gameObject.SetActive(false);
        HealGardMine.gameObject.SetActive(false);

        GardFireEnemy.gameObject.SetActive(false);
        AttackFireEnemy.gameObject.SetActive(false);
        DrainEnemy.gameObject.SetActive(false);
        CaunterEnemy.gameObject.SetActive(false);
        HealGardEnemy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerCardOpen(int PlyerOpenCardNum)
    {
        if(PlyerOpenCardNum == 1)
        {
            GardFireMine.gameObject.SetActive(true);
        }
        else if (PlyerOpenCardNum == 2)
        {
            AttackFireMine.gameObject.SetActive(true);
        }
        else if (PlyerOpenCardNum == 3)
        {
            DrainMine.gameObject.SetActive(true);
        }
        else if (PlyerOpenCardNum == 4)
        {
            CaunterMine.gameObject.SetActive(true);
        }
        else if (PlyerOpenCardNum == 5)
        {
            HealGardMine.gameObject.SetActive(true);
        }

    }
    public void EnemyCardOpen(int EnemyOpenCardNum)
    {
        if (EnemyOpenCardNum == 1)
        {
            GardFireEnemy.gameObject.SetActive(true);
        }
        else if (EnemyOpenCardNum == 2)
        {
            AttackFireEnemy.gameObject.SetActive(true);
        }
        else if (EnemyOpenCardNum == 3)
        {
            DrainEnemy.gameObject.SetActive(true);
        }
        else if (EnemyOpenCardNum == 4)
        {
            CaunterEnemy.gameObject.SetActive(true);
        }
        else if (EnemyOpenCardNum == 5)
        {
            HealGardEnemy.gameObject.SetActive(true);
        }
    }

    public void SetActiveFalse()
    {
        GardFireMine.gameObject.SetActive(false);
        AttackFireMine.gameObject.SetActive(false);
        DrainMine.gameObject.SetActive(false);
        CaunterMine.gameObject.SetActive(false);
        HealGardMine.gameObject.SetActive(false);

        GardFireEnemy.gameObject.SetActive(false);
        AttackFireEnemy.gameObject.SetActive(false);
        DrainEnemy.gameObject.SetActive(false);
        CaunterEnemy.gameObject.SetActive(false);
        HealGardEnemy.gameObject.SetActive(false);
    }
}
