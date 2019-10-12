using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		PlayerPrefs.SetInt("level", 6);
	}

    // Update is called once per frame
    void Update()
    {
		//print(Time.unscaledTime);
		if (Time.timeSinceLevelLoad >= 70f)
			game_control.Instance.toGame(0);
    }
}
