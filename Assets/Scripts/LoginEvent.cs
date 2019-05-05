using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginEvent : MonoBehaviour {
	public Text Text_account, Text_password;
	public GameObject Panel_hint;
	public static string account;
	private bool isLogin;

	// Use this for initialization
	void Start () {
		isLogin = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clickRegister() {
		string newAccount = Text_account.text;
		string newPassword = Text_password.text;
		// 如果使用者有欄位沒有輸入
		if (newAccount == "" || newPassword == "") {
			Panel_hint.SetActive(true);
			Panel_hint.transform.GetChild(0).GetComponent<Text>().text = "有欄位沒有填寫喔！";
		} else {
			StartCoroutine(userRegister(newAccount, newPassword));
		}
	}

	IEnumerator userRegister(string newAccount, string newPassword) {
		string URL = "http://localhost/unity_190519/api/UserController.php";
		
		WWWForm form = new WWWForm();
		form.AddField("newAccount", newAccount);
		form.AddField("newPassword", newPassword);

		using(UnityWebRequest www = UnityWebRequest.Post(URL, form)){
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError) {
            	print(www.error);
        	} else {
        		print(www.downloadHandler.text);
        		Panel_hint.SetActive(true);
        		if (www.downloadHandler.text == "register successfully!") {
        			Panel_hint.transform.GetChild(0).GetComponent<Text>().text = "註冊成功！";
        			account = newAccount;
        			isLogin = true;
        		} else if (www.downloadHandler.text == "account existed!") {
        			Panel_hint.transform.GetChild(0).GetComponent<Text>().text = "此帳號已被註冊！";
        		}
        	}
        }
	}

	public void clickLogin() {
		string userAccount = Text_account.text;
		string userPassword = Text_password.text;
		// 如果使用者有欄位沒有輸入
		if (userAccount == "" || userPassword == "") {
			Panel_hint.SetActive(true);
			Panel_hint.transform.GetChild(0).GetComponent<Text>().text = "有欄位沒有填寫喔！";
		} else {
			StartCoroutine(userLogin(userAccount, userPassword));
		}
	}

	IEnumerator userLogin(string userAccount, string userPassword) {
		string URL = "http://localhost/unity_190519/api/UserController.php";

		WWWForm form = new WWWForm();
		form.AddField("userAccount", userAccount);
		form.AddField("userPassword", userPassword);

		using(UnityWebRequest www = UnityWebRequest.Post(URL, form)){
            yield return www.SendWebRequest();
            
            if(www.isNetworkError || www.isHttpError) {
            	print(www.error);
        	} else {
        		print(www.downloadHandler.text);
        		Panel_hint.SetActive(true);
        		if (www.downloadHandler.text == "login successfully!") {
        			Panel_hint.transform.GetChild(0).GetComponent<Text>().text = "登入成功！";
        			account = userAccount;
        			isLogin = true;
        		} else if (www.downloadHandler.text == "wrong password!") {
        			Panel_hint.transform.GetChild(0).GetComponent<Text>().text = "密碼錯誤！";
        		} else if (www.downloadHandler.text == "No register!") {
        			Panel_hint.transform.GetChild(0).GetComponent<Text>().text = "尚未註冊！";
        		}
        	}
        }
	}

	public void clickConfirm() {
		if (isLogin)
			SceneManager.LoadScene("menu");
	}
}
