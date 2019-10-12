using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stars_creater : MonoBehaviour
{
	private static stars_creater _instance;
	public static stars_creater Instance
	{
		get
		{
			return _instance;
		}
	}
	// Start is called before the first frame update
	public int max_star = 3;
	public int curr_star = 0;
	public Sprite[] starSkin;
	public GameObject starPrefab;
	private Transform starHolder;

	public void star_killed()
	{
		--curr_star;
	}
	void Awake()
	{
		_instance = this;
	}
    void Start()
    {
		starHolder = GameObject.FindGameObjectWithTag("star_holder").transform;
		PlayerPrefs.SetInt("level", 1);


	}

    // Update is called once per frame
    void Update()
    {
		if (game_control.Instance.score >= 20)
			game_control.Instance.need_help();
		if (max_star > 8)
			max_star = 8;
        if(curr_star<max_star)
		{
			int index = Random.Range(0, 3);
			float pos_x = Random.Range(-350f, 374f);
			float pos_y = Random.Range(-144f, 166f);

			GameObject star = Instantiate(starPrefab);
			star.transform.SetParent(starHolder, false);
			++curr_star;

			star.GetComponent<Image>().sprite = starSkin[index];
			Vector3 curr = this.GetComponent<RectTransform>().position;
			star.transform.localPosition = new Vector3(pos_x,pos_y,0f);
		}
    }
}

