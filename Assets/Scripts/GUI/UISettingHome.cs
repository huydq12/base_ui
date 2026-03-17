using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingHome : UIPopup
{
    [Header("Setting Buttons")]
    [SerializeField] private Button btnSFX;
    [SerializeField] private Button btnBGM;
    [SerializeField] private Button btnVibrate;
    [SerializeField] private Button btnClose;

    [Header("Button States")]
    [SerializeField] private GameObject soundOnIcon;
    [SerializeField] private GameObject soundOffIcon;
    [SerializeField] private GameObject musicOnIcon;
    [SerializeField] private GameObject musicOffIcon;
    [SerializeField] private GameObject vibrateOnIcon;
    [SerializeField] private GameObject vibrateOffIcon;

    private UserData userData;

    protected override void Start()
    {
        base.Start();
        userData = GameManager.Instance.userData;

        // Đăng ký sự kiện click cho các button
        btnSFX.onClick.AddListener(ToggleSound);
        btnBGM.onClick.AddListener(ToggleMusic);
        btnVibrate.onClick.AddListener(ToggleVibrate);
        btnClose.onClick.AddListener(ClosePopup);

        // Cập nhật UI theo trạng thái hiện tại
        UpdateUI();
    }

    private void ToggleSound()
    {
        userData.soundOn = !userData.soundOn;
        userData.Save();
        UpdateSoundUI();

        // TODO: Áp dụng thay đổi cho sound system
        // Ví dụ: SoundManager.Instance.SetSoundEnabled(userData.soundOn);
    }

    private void ToggleMusic()
    {
        userData.musicOn = !userData.musicOn;
        userData.Save();
        UpdateMusicUI();

        // TODO: Áp dụng thay đổi cho music system
        // Ví dụ: MusicManager.Instance.SetMusicEnabled(userData.musicOn);
    }

    private void ToggleVibrate()
    {
        userData.vibrateOn = !userData.vibrateOn;
        userData.Save();
        UpdateVibrateUI();
    }

    private void UpdateUI()
    {
        UpdateSoundUI();
        UpdateMusicUI();
        UpdateVibrateUI();
    }

    private void UpdateSoundUI()
    {
        if (soundOnIcon != null && soundOffIcon != null)
        {
            soundOnIcon.SetActive(userData.soundOn);
            soundOffIcon.SetActive(!userData.soundOn);
        }
    }

    private void UpdateMusicUI()
    {
        if (musicOnIcon != null && musicOffIcon != null)
        {
            musicOnIcon.SetActive(userData.musicOn);
            musicOffIcon.SetActive(!userData.musicOn);
        }
    }

    private void UpdateVibrateUI()
    {
        if (vibrateOnIcon != null && vibrateOffIcon != null)
        {
            vibrateOnIcon.SetActive(userData.vibrateOn);
            vibrateOffIcon.SetActive(!userData.vibrateOn);
        }
    }

    private void ClosePopup()
    {
        Hide();
    }
}
