using UnityEngine;
using System.Collections;
public class MovementManager : MonoBehaviour
{
    private CharacterController characterController; //ĳ���� ��Ʈ�ѷ�
    private Coroutine moveCoroutine; // �ڷ�ƾ�� ������ ����

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    #region �̵�, ����
    public void MoveFoward(Vector3 _Dir, float _moveSpeed) // ���� �̵�
    {
        // �̹� ���� ���� �ڷ�ƾ�� �ִٸ� ���� ���߰�, ���ο� �ڷ�ƾ ����
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveFowardCo(_Dir, _moveSpeed));
    }
    public void Stop() // ����
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null; // �ڷ�ƾ�� ���� ��, ������ null�� �ʱ�ȭ
        }
    }


    private IEnumerator MoveFowardCo(Vector3 _Dir, float _moveSpeed) //PlayerManager���� ��ȣ�� ������ ���� ��ų �ڷ�ƾ ���� �̵�
    {
        while (true)
        {
            characterController.SimpleMove(_Dir * _moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
    #endregion
    public void L_Rotate90()
    {
        transform.Rotate(-Vector3.up * 90f, Space.Self);
    }
    public void R_Rotate90()
    {
        transform.Rotate(Vector3.up * 90f, Space.Self);
    }
}
