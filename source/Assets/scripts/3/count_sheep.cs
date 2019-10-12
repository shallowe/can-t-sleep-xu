using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class count_sheep : MonoBehaviour
{
	public InputField to_count;
	public InputField now_count;
	public InputField sheep_count;
	public GameObject sheepPrefab;
	public Transform sheep_holder;
	// Start is called before the first frame update
	void Start()
    {
		to_count.text = "10";
		now_count.text = "0";
		sheep_count.text = "羊";
    }

    // Update is called once per frame
    void Update()
    {
	}
	private bool isSheep(string message)
	{
		bool judge = false;
		if (message == "sheep"||message=="SHEEP")
			judge = true;
		if (message == "水饺" || message == "鲲" || message == "香水")
			judge = true;

		return judge;
	}
	public void OnJumpPress()
	{
		/*
		GameObject sheeps = GameObject.Instantiate(sheepPrefab);
		sheeps.transform.SetParent(sheep_holder);
		sheeps.transform.localPosition = new Vector3(307,39,0);
		sheeps.transform.localScale = new Vector3(1, 1, 1);
		*/
		//Destroy(sheeps, 6f);

		if (isSheep(sheep_count.text))
			game_control.Instance.WinGame3();
		else
		{
			int count_now = (int)float.Parse(now_count.text);
			int count_to = (int)float.Parse(to_count.text);

			if (count_now > 100)
				game_control.Instance.need_help();
			if (count_now >= 99999)
			{
				now_count.text = "0";
				to_count.text = "10";
				count_now = 0;
				count_to = 10;
			}
			if (count_now + 1 >= count_to)
			{
				count_to = toChange(count_now);
				to_count.text = count_to.ToString();
				++count_now;
				now_count.text = count_now.ToString();
			}
			else
			{
				++count_now;
				now_count.text = count_now.ToString();
			}
		}
	}
	private int toChange(int num)
	{
		int now = num;
		while (now % 10 != 0)
			++now;
		now += 10;
		return now;
	}
}
