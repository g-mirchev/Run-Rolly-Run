using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
	public KeyCode mL;
	public KeyCode mR;
	
	public float sideSpeed = 0;
	public int lane = 2;
	public bool locked = false;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3 (sideSpeed,0,4);
		
		if (Input.GetKeyDown(KeyCode.A) && (lane > 1) && !locked)
		{
			sideSpeed = -2;
			StartCoroutine (stopSlide());
			lane -= 1;
			locked = true;
		}
		
		if (Input.GetKeyDown(KeyCode.D) && (lane < 3) && !locked)
		{
			sideSpeed = 2;
			StartCoroutine (stopSlide());
			lane += 1;
			locked = true;
		}
    }
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Lethal")
		{
			Destroy(gameObject);
			SceneManager.LoadScene("End");
		}
		if (other.gameObject.name == "Pickup")
		{
			Destroy(other.gameObject);
		}
		if (other.gameObject.name == "Coin")
		{
			Destroy(other.gameObject);
			GameMaster.coins += 1;
		}
	}
	
	IEnumerator stopSlide()
	{
		yield return new WaitForSeconds (.5f);
		sideSpeed = 0;
		locked = false;
	}
}
