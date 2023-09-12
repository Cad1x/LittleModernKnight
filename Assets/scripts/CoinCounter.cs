using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    
    public int currentCoins;

    public TMP_Text Text;


    public void Update()
    {
        Text.text =  currentCoins.ToString();
    }


}
