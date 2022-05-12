using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager _instance;

    //implemement the singleton pattern
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }

    //all buyer methods(used in shop)
    public bool BuyTele(int price)
    {
        bool bought = false;

        if(_instance.GetComponent<PlayerData>().GetNumCurr() > price)
        {
            _instance.GetComponent<PlayerData>().SetNumTele(_instance.GetComponent<PlayerData>().GetNumTele() + 1); //add a teleport
            _instance.GetComponent<PlayerData>().SetNumCurr(_instance.GetComponent<PlayerData>().GetNumCurr() - price); //subtract that many points

            bought = true;
        }

        return bought;
    }

    public bool BuyExpos(int price)
    {
        bool bought = false;

        if (_instance.GetComponent<PlayerData>().GetNumCurr() > price)
        {
            _instance.GetComponent<PlayerData>().SetNumExpos(_instance.GetComponent<PlayerData>().GetNumExpos() + 1); //add an explosion
            _instance.GetComponent<PlayerData>().SetNumCurr(_instance.GetComponent<PlayerData>().GetNumCurr() - price); //subtract that many points

            bought = true;
        }

        return bought;
    }

    public bool BuyBoost(int price)
    {
        bool bought = false;

        if (_instance.GetComponent<PlayerData>().GetNumCurr() > price)
        {
            _instance.GetComponent<PlayerData>().SetNumBoost(_instance.GetComponent<PlayerData>().GetNumBoost() + 10); //add boost
            _instance.GetComponent<PlayerData>().SetNumCurr(_instance.GetComponent<PlayerData>().GetNumCurr() - price); //subtract that many points

            bought = true;
        }

        return bought;
    }

    public bool BuyLife(int price)
    {
        bool bought = false;

        if (_instance.GetComponent<PlayerData>().GetNumCurr() > price)
        {
            _instance.GetComponent<PlayerData>().SetNumLives(_instance.GetComponent<PlayerData>().GetNumLives() + 1); //add a life
            _instance.GetComponent<PlayerData>().SetNumCurr(_instance.GetComponent<PlayerData>().GetNumCurr() - price); //subtract that many points

            bought = true;
        }

        return bought;
    }

}
