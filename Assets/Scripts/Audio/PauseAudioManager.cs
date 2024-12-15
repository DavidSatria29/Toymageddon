using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class PauseAudioManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;       // Objek Pause Menu
        [SerializeField] private GameObject backgroundAudio; // GameObject untuk background audio

        void Update()
        {
            // Cek apakah Pause Menu aktif
            if (pauseMenu != null && backgroundAudio != null)
            {
                if (pauseMenu.activeSelf)
                {
                    // Jika Pause Menu aktif, nonaktifkan background audio
                    if (backgroundAudio.activeSelf)
                    {
                        backgroundAudio.SetActive(false);
                    }
                }
                else
                {
                    // Jika Pause Menu tidak aktif, aktifkan kembali background audio
                    if (!backgroundAudio.activeSelf)
                    {
                        backgroundAudio.SetActive(true);
                    }
                }
            }
        }
    }
}
