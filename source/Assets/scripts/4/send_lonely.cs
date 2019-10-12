using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class send_lonely : MonoBehaviour
{
	public GameObject person;
	public GameObject close;

	private float win_time = 10f;
	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if(close.activeSelf==true)
		{
			win_time -= Time.deltaTime;
			if (win_time < 0)
				game_control.Instance.WinGame4();
		}
    }
	public void close_phone()
	{
		if (close.activeSelf == true)
			close.SetActive(false);
		else
			close.SetActive(true);
	}
	public void send_alone()
	{
		person.SetActive(false);
	}
	public void person_detail()
	{
		person.SetActive(true);
	}
}
