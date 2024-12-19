using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField idInput = null;
    [SerializeField] private TMP_InputField passwordInput = null;
    [SerializeField] private TextMeshProUGUI loginStatus = null;

    //[SerializeField] private Button LoginButton = null;

    private const string loginUri = "http://127.0.0.1/login.php";

    //�ӽ� ����� ID�� �н����� (PlayerPrefs�� ����)
    private string savedUsername = "id1234";
    private string savedPassword = "pw5678";
    private void Start()
    {
        //�ӽ��ڵ�
        PlayerPrefs.SetString("Username", savedUsername);
        PlayerPrefs.SetString("Password", savedPassword);

        //LoginButton.onClick.AddListener(() =>
        //{
        //    StartCoroutine(LoginCoroutine(idInput.text, passwordInput.text));
        //    PlayerPrefs.SetString("ID",idInput.text);
        //});
    }

    private IEnumerator LoginCoroutine(string id, string password)
    {
        
        WWWForm form = new WWWForm();
        form.AddField("loginID", id);
        form.AddField("loginPW", password);
        // WWW
        // Sync, Async
        using (UnityWebRequest www =
            UnityWebRequest.Post(loginUri, form))
        {
            string wu = www.downloadHandler.text;
            yield return www.SendWebRequest();
            Debug.Log(www.downloadHandler.text);
            if(www.downloadHandler.text == "OK")
            {
                loginStatus.text = "Login Success!";
                //SceneManager.LoadScene("MainScene");
            }

            else if (www.result ==
                UnityWebRequest.Result.ConnectionError ||
                www.result ==
                UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log(www.error);
            }
            else
            {
                loginStatus.text = "ID or password is incorrect.";
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    //�ӽ� �ڵ�
    public void OnLoginButtonClicked()
    {
        string enteredUsername = idInput.text;
        string enteredPassword = passwordInput.text;

        // ����� ���� ��
        if (enteredUsername == PlayerPrefs.GetString("Username") && enteredPassword == PlayerPrefs.GetString("Password"))
        {
            loginStatus.text = "Login Success!";
        }
        else
        {
            Debug.Log(idInput.text);
            Debug.Log(passwordInput.text);
            Debug.Log("enterid: " + enteredUsername);
            Debug.Log("enterpw: " + enteredPassword);
            loginStatus.text = "ID or password is incorrect.";
        }
    }

}

