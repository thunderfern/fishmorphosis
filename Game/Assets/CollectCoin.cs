using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour {

    private int coins = 0;

    [SerializeField] private Text coinsText;

    private void Start() {
        coinsText.text = "Coins: " + coins + "/3";
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Coin")) {
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins + "/3";
        }
    }
    
}
