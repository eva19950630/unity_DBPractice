using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using UnityEngine.EventSystems;

public class UserRecord : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("Text_account").GetComponent<Text>().text = LoginEvent.account;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// public void clickBtn() {
	// 	string account, action, target, scene, behaviorLog;
	// 	account = LoginEvent.account;
	// 	action = "click";
	// 	target = EventSystem.current.currentSelectedGameObject.name;
	// 	scene = SceneManager.GetActiveScene().name;
	// 	behaviorLog = account + "#" + action + "#" + target + "#" + scene;

	// 	StartCoroutine(uploadBehavior(behaviorLog));
	// }

	// IEnumerator uploadBehavior(string behaviorLog) {
	// 	string URL = "http://163.21.245.192/PigSaviorAPP/teach_unity/behaviorUpload.php";
	// 	WWWForm form = new WWWForm();
	// 	Dictionary<string, string> data = new Dictionary<string, string>();
	// 	data.Add("log", behaviorLog);
	// 	foreach (KeyValuePair<string, string> post in data) {
	// 		form.AddField(post.Key, post.Value);
	// 	}
	// 	WWW www = new WWW(URL, form);
	// 	yield return www;
	// 	print(www.text);
	// }
}
