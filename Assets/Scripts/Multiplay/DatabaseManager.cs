using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

public class DatabaseManager : MonoBehaviour
{

    #region URI Paths
    private const string loginUri = "http://192.168.150.227/login.php";

    private const string connectTestUri = "http://192.168.150.227/connectTest.php";
    #endregion

    private void Start()
    {
        ConnectToDBTest();
    }


    /// <summary>
    /// DB와 잘 연결되었는지 확인하는 함수.
    /// 잘 연결되었다면 DB Connect Success! 유니티 로그를 출력.
    /// </summary>
    private void ConnectToDBTest()
    {
        StartCoroutine(ConnectToDBTestCoroutine());
    }

    /// <summary>
    /// Login
    /// </summary>
    private void LoginCheck(string _id, string _pw)
    {
        StartCoroutine(LoginCoroutine(_id, _pw));
    }

    /// <summary>
    /// 인자로 전달받은 UnityWebRequest 객체의 연결을 체크하는 함수.
    /// </summary>
    /// <param name="_www">확인할 UnityWebRequest 객체</param>
    /// <returns></returns>
    private bool CheckConnectError(UnityWebRequest _www)
    {
        return _www.result == UnityWebRequest.Result.ConnectionError ||
                _www.result == UnityWebRequest.Result.DataProcessingError;
    }

    #region SQL Coroutine
    private IEnumerator ConnectToDBTestCoroutine()
    {
        WWWForm form = new WWWForm();

        using(UnityWebRequest www = UnityWebRequest.Post(connectTestUri, form))
        {
            yield return www.SendWebRequest();

            if(CheckConnectError(www))
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("DB Connect Success!");
            }
        }

    }

    private IEnumerator LoginCoroutine(string _id, string _pw)
    {
        WWWForm form = new WWWForm();

        form.AddField("loginUser", _id);
        form.AddField("loginPass", _pw);

        using (UnityWebRequest www = UnityWebRequest.Post(loginUri, form))
        {
            yield return www.SendWebRequest();

            if (CheckConnectError(www))
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    #endregion
}
