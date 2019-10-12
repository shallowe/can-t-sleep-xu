using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move : MonoBehaviour
{
	// Start is called before the first frame update
	private Transform bullet;
	public float speed = 2.0f;
    void Start()
    {
		bullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		bullet.position = new Vector3(bullet.position.x, bullet.position.y+0.1f*speed, bullet.position.z);
    }
}
