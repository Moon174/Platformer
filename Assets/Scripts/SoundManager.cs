using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
    public static bool isSoundEnabled = true;
    public Image soundButtonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    public void ToggleSound()
    {
        isSoundEnabled = !isSoundEnabled;

        if (isSoundEnabled)
        {
            AudioListener.volume = 1f;
            PlayerPrefs.SetInt("SoundEnabled", 1);
            soundButtonImage.sprite = soundOnSprite;
        }
        else
        {
            AudioListener.volume = 0f;
            PlayerPrefs.SetInt("SoundEnabled", 0);
            soundButtonImage.sprite = soundOffSprite;
        }
    }

    void Start()
    {
        // �������� ����������� ��������� ����� �� PlayerPrefs
        SoundManager.isSoundEnabled = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;

        // ������������� ���������� �������� ������ �����
        if (isSoundEnabled)
        {
            soundButtonImage.sprite = soundOnSprite;
        }
        else
        {
            soundButtonImage.sprite = soundOffSprite;
        }

        // ������������� ���������� ���������
        AudioListener.volume = isSoundEnabled ? 1f : 0f;
    }

}