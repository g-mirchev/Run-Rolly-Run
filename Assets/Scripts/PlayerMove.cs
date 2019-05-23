using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
	public KeyCode mL;
	public KeyCode mR;
	
	public int lane = 2;
	public bool locked = false;
	
	public Transform explodeObj;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3 (0,0,GameMaster.speed);
		
		if (Input.GetKeyDown(KeyCode.A) && (lane > 1) && !locked)
		{
			StartCoroutine (stopSlide());
			lane -= 1;
			locked = true;
			transform.Translate(new Vector3(-1,0,0));
		}
		
		else if (Input.GetKeyDown(KeyCode.D) && (lane < 3) && !locked)
		{
			StartCoroutine (stopSlide());
			lane += 1;
			locked = true;
			transform.Translate(new Vector3(1,0,0));
		}
		
    }
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Lethal")
		{
			Destroy(gameObject);
			GameMaster.zSpeedAdj = 0;
			Instantiate(explodeObj, transform.position, explodeObj.rotation);
			GameMaster.lvlEnd = true;
		}
		if (other.gameObject.tag == "Pickup")
		{
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "Coin")
		{
			Destroy(other.gameObject);
			GameMaster.coins += 1;
		}
	}
	
	IEnumerator stopSlide()
	{
		yield return new WaitForSeconds (.1f);
		locked = false;
	}
}
