using UnityEngine;
using UnityEngine.Events;
public class PlayerManager : MonoBehaviour
{
    private float moveSpeed = 60f; // �̵� �ӵ�
    private Vector3 HeadVector3 = Vector3.zero; // ��� ����
    private MovementManager movementManager; // ���� �Ŵ��� ����
    private Camera playerCamera; // ī�޶� ���� (��� ���� ���ϱ��);
    private void Awake()
    {
        movementManager = GetComponentInChildren<MovementManager>();
        playerCamera = GetComponentInChildren<Camera>();
    }
    #region �̵� ����
    public void MoveFoward()
    {
        HeadVector3 = playerCamera.transform.forward;
        movementManager.MoveFoward(HeadVector3,moveSpeed);
    }

    public void StopMove()
    {
        movementManager.Stop();
    }
    #endregion
}
