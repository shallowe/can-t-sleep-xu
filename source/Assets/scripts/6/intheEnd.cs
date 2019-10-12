using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class intheEnd : MonoBehaviour
{
	public Text tell;
	public Text answer;
	private string[] my_words = { "终于...","在阿豪仰望过无数星空","换过无数的睡姿","数过无数的羊","和自己说了无数的话","听厌无数的歌之后", "他终于明白了","真正让他睡不着觉的原因","其实并不是精力过剩或者是睡姿不对之类的","真正的原因是...." };
	private string[] past = { "但是", "过去的已经过去", "即使在床上烦恼着也无法改变", "不如就从现在开始改变", "去消灭那些悔恨", "去做自己觉得正确的事情", "祝你晚上能安然入眠！","   ","      END" };
	private string[] now = { "但是", "困难总有解决的办法", "躺在床上皱眉也想不出来", "与其折磨自己的精神", "不如冷静下来理清现在的情况", "然后果断采取行动", "发现问题，然后解决问题", "也试着去问问家人，朋友", "祝你晚上能安然入眠！" ,"   ","      END"};
	private string[] future = { "但是", "生活的意义就是在生活中寻找的", "与其带着迷茫不如带着希望", "去寻找，去尝试，去努力", "相信一定能找到那个最理想的生活方式", "祝你晚上能安然入眠！","   ","    END" };
	private Sequence mySequence;
	private Sequence mySequence2;
	public GameObject choose;

	private float first_time;
	private float second_time;

	private bool showBefore=false;
	// Start is called before the first frame update
	void Start()
    {
		/*    //木大
		game_control.Instance.currentLevel = 5;
		foreach(string say in my_words)
		{
			tell.DOText(say, say.Length);
		}
		*/
		PlayerPrefs.SetInt("level", 5);
		mySequence = DOTween.Sequence();
		message_show(my_words, ref mySequence, tell,out first_time);
		
		Destroy(tell, first_time + 1f);

		/*   //为封装的方法
		mySequence = DOTween.Sequence()
			.Append(tell.DOText(my_words[0], 5f))
			.Append(tell.DOText("", 0f)) //清除当前对话
			.Append(tell.DOText(my_words[1], 2f))
			.Append(tell.DOText("", 0f)) //清除当前对话
			.Append(tell.DOText(my_words[2], 3f))
			.Append(tell.DOText("", 0f)) //清除当前对话
			.Append(tell.DOText(my_words[3], 4f))
			.Append(tell.DOText("", 0f)) //清除当前对话
			.Append(tell.DOText(my_words[4], 1f));
		*/
	}

    // Update is called once per frame
    void Update()
    {
		if(Time.timeSinceLevelLoad>=first_time+1f&&showBefore==false)
		{
			choose.SetActive(true);
			showBefore = true;
		}
		//GameObject.Instantiate(choose);
    }
	private void message_show(string[] message,ref Sequence mySequence,Text text,out float time)
	{
		time = 0f;
		if (message.Length == 0)
			return ;
		for(int i=0;i<message.Length;++i)
		{
			mySequence.Append(text.DOText(message[i], (float)message[i].Length / 4)).Append(text.DOText("", 0f));
			time += (float)message[i].Length / 4;
		}
	}
	
	IEnumerator stop_some_time(float time)
	{
		yield return new WaitForSeconds(time);
		game_control.Instance.next_level();
	}
	
	public void on_past()
	{
		choose.SetActive(false);
		mySequence2 = DOTween.Sequence();
		message_show(past, ref mySequence2, answer,out second_time);

		StartCoroutine(stop_some_time(second_time+5f));
	}
	public void on__now()
	{
		choose.SetActive(false);
		mySequence2 = DOTween.Sequence();
		message_show(now, ref mySequence2, answer, out second_time);

		StartCoroutine(stop_some_time(second_time+5f));
	}
	public void on_future()
	{
		choose.SetActive(false);
		mySequence2 = DOTween.Sequence();
		message_show(future, ref mySequence2, answer, out second_time);

		StartCoroutine(stop_some_time(second_time+5f));

	}
}