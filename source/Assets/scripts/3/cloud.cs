using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class cloud : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject[] the_cloud;
	public int cloud_num=0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		int num = Random.Range(1, 50);
		if(num==5)
		{
			int index = Random.Range(0, 3);
			float y = Random.Range(3.5f, 5.2f);
			float time = Random.Range(10f, 20f);
			GameObject cloud= GameObject.Instantiate(the_cloud[index],new Vector3(10,y,0	),Quaternion.identity);
			cloud.transform.DOMoveX(-10f, time);
			Destroy(cloud, 22f);
		}
    }
}
