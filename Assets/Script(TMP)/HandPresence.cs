using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();//�Է���ġ ����Ʈ ����
        //InputDevices.GetDevices(devices); // ��� ��Ʈ�ѷ� ����Ʈ�� �ֱ�
        InputDeviceCharacteristics rightControllercharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllercharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics); // Log�� ������ �̸�, ������ ǥ��
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue); //primaryButton(bool�������ε�)�� ������ ���� �α� ��
        if (primaryButtonValue)
        {
            Debug.Log("Pressing Priamry Button");
        }
    }
}
