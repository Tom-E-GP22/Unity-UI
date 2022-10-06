using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinScript : MonoBehaviour
{
    public static int coinCount;
    TextMeshProUGUI coinCountText;

    void Start()
    {
        //Coins stay over previous plays for future addition of eventual shop
        coinCountText = GameObject.Find("CoinCountValue").GetComponent<TextMeshProUGUI>(); 
        coinCountText.text = coinCount.ToString();
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("Player"))
        {
            Debug.Log("hit");
            coinCount++;
            coinCountText.text = coinCount.ToString();
            Destroy(this.gameObject);
        }
    }
}
