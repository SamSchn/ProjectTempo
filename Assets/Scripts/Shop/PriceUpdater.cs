using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceUpdater : MonoBehaviour
{
    private TMP_Text text;
    public PriceManager price;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        UpdatePrice();
    }

    public void UpdatePrice()
    {
        text.text = price.GetPrice().ToString();
    }
}
