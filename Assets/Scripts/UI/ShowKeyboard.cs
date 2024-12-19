using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowKeyboard : MonoBehaviour
{
    private TMP_InputField inputField;

    public float distance = 0.3f;
    public float verticalOffset = -0.2f;

    public Transform positionSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(x => OpenKeyboard());
    }

    public void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(inputField.text);

        Vector3 direction = positionSource.forward;
        direction.y = 0;
        direction.Normalize();

        Vector3 targetPosition = positionSource.position + direction * distance + Vector3.up * verticalOffset;
        NonNativeKeyboard.Instance.RepositionKeyboard(targetPosition);
    }
}
