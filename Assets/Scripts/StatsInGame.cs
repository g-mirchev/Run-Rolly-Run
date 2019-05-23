using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsInGame : MonoBehaviour
{
   	
	public Text coinsTxt;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsTxt.text = "Coins: " + GameMaster.coins;
    }
}
