using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;
public class speechtest : MonoBehaviour {


	//关键词识别器

    //______________________________________________________________________________
	KeywordRecognizer keywordRecognizer;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		// 如果识别到关键词就调用
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();

			Debug.Log ("args text is"+args.text);
		}
	}
	void Start () {

		Debug.Log ("script _ processing");


		//初始化指令集

		keywords.Add("我想要一个红色的方块", () =>{
				Debug.Log("red");
			
			});
		keywords.Add("我想要一个蓝色的方块", () =>{
				Debug.Log("bule");
			
			});
		keywords.Add ("你好", () => {
			Debug.Log ("你好");
	     	});
        /*
         * 
         keywords.Add ("keyword", () => {
			//action
	     	});
         */






		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		//开始识别
		keywordRecognizer.Start();
	
	}

}
