using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public int price;
    public float increaseRate;
    private PlayerManager player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    public void BuyLife()
    {
        //buy the life
        if (player.BuyLife(price))
            price = (int)(price * increaseRate); //if they bought increase the price
    }

    public void BuyBoost()
    {
        //buy the Boost
        if (player.BuyBoost(price))
            price = (int)(price * increaseRate); //if they bought increase the price
    }

    public void BuyExplosion()
    {
        //buy the explosion
        if (player.BuyExpos(price))
            price = (int)(price * increaseRate); //if they bought increase the price
    }

    public void BuyTeleport()
    {
        //buy the Boost
        if (player.BuyTele(price))
            price = (int)(price * increaseRate); //if they bought increase the price
    }

    public int GetPrice()
    {
        return price;
    }


}
