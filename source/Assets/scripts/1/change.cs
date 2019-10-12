using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour
{
	// Start is called before the first frame update
	Transform star;
	public bool circle = true;
    void Start()
    {
		star = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		if (game_control.Instance.ifWin == false)
		{
		   star.Rotate(0, 0, game_control.Instance.speed);
		}
		
    }
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="bullet")
		{
			//print("hit!!!");
			Destroy(this.gameObject);
			Destroy(other.gameObject);
			stars_creater.Instance.star_killed();
			//print(stars_creater.Instance.curr_star);
			stars_creater.Instance.max_star += 1;
			game_control.Instance.score += 1;
			game_control.Instance.OnScoreChange();
		}
		
	}
}
