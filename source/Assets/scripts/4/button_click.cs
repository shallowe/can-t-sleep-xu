using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_click : MonoBehaviour
{
	//设置获取相关参数

	public Transform goParent;

	public GameObject itemImagePrefab;

	private Vector2 originSize;

	public Scrollbar keep;
	// Use this for initialization

	void Start()
	{

		//获取最初goParent的宽高

		originSize = goParent.GetComponent<RectTransform>().sizeDelta;

	}

	// Update is called once per frame

	void Update()
	{



		//按下空格键调用添加ItemImage

		if (Input.GetKeyDown(KeyCode.Space))
		{

			AddScrollItem(1);
            keep.value = 0;

		}
		

	}

	private void AddScrollItem(int count)
	{

		//生成ItemImage

		for (int i = 0; i < count; i++)
		{

			GameObject go = Instantiate(itemImagePrefab) as GameObject;
			go.transform.localScale=new Vector3(3.14f, 3.14f, 0);

			go.transform.SetParent(goParent);

		}

		//调整ScrollRect边框大小

		//获取当前的ItemImage的实际个数

		int itemImageCount = goParent.childCount;

		//计算当前实际生成ItemImage所需要的goParent的高度

		float ScrollRectY = itemImageCount * ((itemImagePrefab.GetComponent<RectTransform>().sizeDelta.y)

			+ goParent.GetComponent<VerticalLayoutGroup>().spacing);

		//比原先小则，保持原有尺寸不变，反之，高度设置为所需要的

		if (ScrollRectY <= originSize.y)

		{

			goParent.GetComponent<RectTransform>().sizeDelta = originSize;

		}

		else
		{

			goParent.GetComponent<RectTransform>().sizeDelta = new Vector2(originSize.x, ScrollRectY);

		}
	}


}
