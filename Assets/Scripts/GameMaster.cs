using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
	public static float coins = 0;
	public static float time = 0;
	public static float zSpeedAdj = 1;
	public static float loadWait = 0;
	public static float speed = 4f;
	
	public float zScenePos = 18;
	
	public static bool lvlEnd = false;
	
	public Transform buildBlock;
	public Transform obstacle;
	public Transform coin;
	public Transform pickup;
	
	public GameObject player;
	
	public int ranOne;
	public int ranTwo;
	
    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("accelerate", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
		
		if (lvlEnd)
			loadWait += Time.deltaTime;
		
		if (loadWait > 1)
			SceneManager.LoadScene("End");
		
		if(zScenePos < (120 + player.transform.position.z))
		{
			ranOne = Random.Range(0,10);
			ranTwo = Random.Range(1,4);
			if(ranOne < 4)
				Instantiate(coin, new Vector3(ranTwo - 2,1,zScenePos), coin.rotation);
			
			if(ranOne > 4)
				Instantiate(obstacle, new Vector3(ranTwo - 2,1,zScenePos), obstacle.rotation);
			
			if(ranOne == 4)
				Instantiate(pickup, new Vector3(ranTwo - 2,1,zScenePos), pickup.rotation);
			
			
			
			Instantiate(buildBlock, new Vector3(0,0,zScenePos), buildBlock.rotation);
			zScenePos += 4;
			
		}
		
    }
	
	void accelerate()
	{
		speed += 1f;
	}
}
