using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataUpdater : MonoBehaviour
{
    public int typeData;

    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        UpdateData();
    }

    public void Update()
    {
        UpdateData();
    }

    public void UpdateData()
    {
        switch(typeData)
        {
            case 0:
                text.text = PlayerManager._instance.GetComponent<PlayerData>().GetNumCurr().ToString();
                break;
            case 1:
                text.text = PlayerManager._instance.GetComponent<PlayerData>().GetNumLives().ToString();
                break;
            case 2:
                text.text = PlayerManager._instance.GetComponent<PlayerData>().GetNumExpos().ToString();
                break;
            case 3:
                text.text = PlayerManager._instance.GetComponent<PlayerData>().GetNumTele().ToString();
                break;
            case 4:
                text.text = ((int)(PlayerManager._instance.GetComponent<PlayerData>().GetNumBoost())).ToString();
                break;
            case 5:
                text.text = ((int)(PlayerManager._instance.GetComponent<PlayerData>().GetPercent() * 100)).ToString();
                break;
            default:
                break;
        }
    }

}
