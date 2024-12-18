using UnityEngine;
using Photon.Pun;

public class MultiplayManager : MonoBehaviourPun
{
    [SerializeField]
    private string gameVersion = "0.0.1";

    private const int MaxPlayerPerRoom = 2;

    #region Public Func

    /// <summary>
    /// 방에 접속중인 플레이어들에게 새로운 씬으로 가도록 함.
    /// </summary>
    /// <param name="_sceneName">로드할 씬 이름</param>
    public void LoadScene(string _sceneName)
    {
        PhotonNetwork.LoadLevel(_sceneName);
    }

    #endregion

    #region Private Func

    #endregion

    #region Unity Callback Func

    private void Awake()
    {
        // 게임 시작 시 두 플레이어는 항상 같은 씬에 있어야 한다.
        // 씬을 자동으로 동기화하도록 설정.
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    #endregion

    #region Photon Callback Func

    #endregion
}
