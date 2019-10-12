using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_control : MonoBehaviour
{
	public Slider energy;
	public Text changeTime;

	private Animator player;
	private Slider blood;

	public Image face;
	public Sprite[] image;

	public float delete_speed = 0.004f;
	public float delete_a = 0.00005f;
	public float comfor_time = 5f;
	private int current_state = 5;
	public float increase_speed = 1f;

	// Start is called before the first frame update
	void Start()
	{
		player = GetComponent<Animator>();
		blood = GameObject.FindGameObjectWithTag("score").GetComponent<Slider>();
		PlayerPrefs.SetInt("level", 2);
	}
    // Update is called once per frame
    void Update()
    {
		int change;
		if (increase_speed == 1f) change = 3; else if (increase_speed >= 0.3) change = 2; else if (increase_speed >= 0.07) change = 1; else change = 0;

		energy.value = comfor_time / 5;
		changeTime.text = change.ToString();

		if (blood.value < 0.4f) face.sprite = image[0];
		else if (blood.value < 0.7f) face.sprite = image[1];
		else face.sprite = image[2];

		float ho = Input.GetAxis("Horizontal");
		float ve = Input.GetAxis("Vertical");
		//print(current_state);

		bool w, a, s, d;
		w = a = s = d = false;
		if (ho != 0)
		{
			if (ho > 0.1f) d= true;
			if (ho < -0.1f) a = true;
		}
		if (ve != 0)
			if (ve > 0) w = true; else s = true;

		player.SetBool("w", w);
		player.SetBool("s", s);
		player.SetBool("a", a);
		player.SetBool("d", d);

		//print(current_state);
		if(!w&&!a&&!s&&!d)
		{
			game_control.Instance.OnStill();
		}
		if(game_control.Instance.score>=1500)
		{
			game_control.Instance.WinGame2();
		}

		if (comfor_time <= 2f&&blood.value<=0.8f)
			increase_speed = 1f;
		if (increase_speed <= 0.06f)
		{
            blood.value = 0.5f;
			increase_speed = 1f;
			game_control.Instance.need_help();
		}
			
		if (comfor_time <= 0)
		{
			game_control.Instance.helpful.text = "";
			blood.value -= delete_speed;
			if (delete_speed > 0)
				delete_speed -= delete_a;
			else
				delete_speed = 0.0005f;
		}
		if(w&&current_state>=4)
		{
			current_state -= 3;
			blood.value = Mathf.Lerp(blood.value, blood.value + 0.3f*increase_speed,0.5f);
			comfor_time = 5f;
			delete_speed = 0.004f;
			increase_speed /= 2;
			game_control.Instance.OnMove();
		}
		else if(a&&current_state!=1&&current_state!=4)
		{
			current_state -= 1;
			blood.value = Mathf.Lerp(blood.value, blood.value+increase_speed* 0.1f, 0.6f);
			comfor_time =5f;
			delete_speed = 0.004f;
			increase_speed /= 2;
			game_control.Instance.OnMove();
		}
		else if(s&&current_state<=3)
		{
			current_state += 3;
			blood.value = Mathf.Lerp(blood.value, blood.value +increase_speed * 0.2f, 0.8f);
			comfor_time =5f;
			delete_speed = 0.004f;
			increase_speed /= 2;
			game_control.Instance.OnMove();
		}
		else if(d&&current_state!=3&&current_state!=6)
		{
			current_state += 1;
			blood.value = Mathf.Lerp(blood.value, blood.value +increase_speed * 0.1f,1f);
			comfor_time =5f;
			delete_speed = 0.004f;
			increase_speed /= 2;
			game_control.Instance.OnMove();
		}
		comfor_time -= Time.deltaTime;

	}
}
