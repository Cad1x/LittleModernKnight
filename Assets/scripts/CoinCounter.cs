using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{

    public int currentCoins;

    public TMP_Text Text;


    public void Update()
    {
        Text.text = currentCoins.ToString();
    }


}
