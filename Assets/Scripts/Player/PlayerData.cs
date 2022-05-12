using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //a class to control the inventory of the player
    private int numTele; //num of teleports
    private float numBoost; //amount of boost
    private int numExpos; //amount of explosions
    private int numCurr; //the amount of curreny the player currently have
    private int lives;  //number of lives
    private float lastPercent;

    private bool won;  //has rthe player beaten the level yet

    public void Awake()
    {
        numCurr = 0;
        numExpos = 0;
        numTele = 0;
        numBoost = 0f;
        lives = 1;

        won = false;
    }

    //all getter methods
    public int GetNumTele()
    {
        return numTele;
    }

    public float GetNumBoost()
    {
        return numBoost;
    }

    public int GetNumExpos()
    {
        return numExpos;
    }

    public int GetNumCurr()
    {
        return numCurr;
    }

    public int GetNumLives()
    {
        return lives;
    }

    //all setter methods
    public void SetNumTele(int numberTele)
    {
        numTele = numberTele;
    }

    public void SetNumBoost(float numberBoost)
    {
        numBoost = numberBoost;
    }

    public void SetNumExpos(int numberExpos)
    {
        numExpos = numberExpos;
    }

    public void SetNumCurr(int numberCurr)
    {
        numCurr = numberCurr;
    }

    public void SetNumLives(int numberLives)
    {
        lives = numberLives;
    }

    //set the flag to mark that the player had won
    public void PlayerWon()
    {
        won = true;
    }

    //returns whether or not the player won
    public bool DidWin()
    {
        return won;
    }

    public void LatestPercent(float percent)
    {
        lastPercent = percent;
    }

    public float GetPercent()
    {
        return lastPercent;
    }
}
