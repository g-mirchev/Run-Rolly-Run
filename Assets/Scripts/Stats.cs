﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
	
	public Text coinsTxt;
	public Text timeTxt;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsTxt.text = "Coins collected: " + GameMaster.coins;
		timeTxt.text = "Total time: " + (GameMaster.time - GameMaster.loadWait);
		
    }
}
