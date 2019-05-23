using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (gameObject.tag == "Pickup")
			transform.Rotate(0,0,1);
		if (gameObject.tag == "Coin")
			transform.Rotate(0,0,2);
    }
}
