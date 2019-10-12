using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_control : MonoBehaviour
{
	// Start is called before the first frame update
	RectTransform player;
	public GameObject bulltets;
	public float speed = 0.2f;
	private int i = 0;
	private Transform bullet_holder;
	private float win_time = 5f;
	void Start()
	{
		player = GetComponent<RectTransform>();
		bullet_holder = GameObject.FindGameObjectWithTag("shoot").GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
		i -= 1;
		if(game_control.Instance.ifWin==false)
		{

			float v = Input.GetAxis("Vertical");
			float h = Input.GetAxis("Horizontal");
			player.position = new Vector3(player.position.x + h * speed, player.position.y + v * speed, player.position.z);

			float bullet = Input.GetAxis("shoot");
			if (bullet != 0 && i < 0)
			{
				GameObject bulles = GameObject.Instantiate(bulltets);
				bulles.transform.SetParent(bullet_holder, false);
				bulles.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
				Destroy(bulles, 10f);
				i = 10;
			}

			if (transform.localPosition.x < -208f || transform.localPosition.x > 637 || transform.localPosition.y < -316 || transform.localPosition.y > 294)
			{
				win_time -= Time.deltaTime;
				game_control.Instance.speed -= Time.deltaTime * 0.7f;
				if (win_time <= 0)
					game_control.Instance.WinGame();
			}
			else
			{
               win_time = 5f;
				game_control.Instance.speed = 5f;
			}
				
		}
    }
}
