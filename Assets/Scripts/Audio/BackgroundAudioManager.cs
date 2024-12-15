using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class BackgroundAudioManager : MonoBehaviour
    {
        public static BackgroundAudioManager Instance; // Singleton instance

        [SerializeField] private AudioSource playModeAudio; // AudioSource untuk Play Mode
        [SerializeField] private AudioSource bossModeAudio; // AudioSource untuk Boss Mode
        [SerializeField] private GameObject bossPrefab; // Prefab Boss yang akan dipantau

        private GameObject activeBossObject; // Referensi ke instance aktif dari prefab Boss
        private bool isGameFinished = false; // Status apakah game sudah selesai

        private void Awake()
        {
            // Implementasi Singleton
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Agar tetap ada saat pindah scene
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // Mulai dengan memutar Play Mode audio
            if (!playModeAudio.isPlaying)
            {
                playModeAudio.Play();
            }

            // Pastikan Boss Mode audio dimatikan di awal
            if (bossModeAudio.isPlaying)
            {
                bossModeAudio.Stop();
            }
        }

        private void Update()
        {
            // Jika game selesai, pastikan semua audio dimatikan
            if (isGameFinished)
            {
                StopAllAudio();
                return;
            }

            // Pantau keberadaan prefab Boss di scene
            if (IsBossActive())
            {
                // Jika Boss Mode muncul, ganti audio ke Boss Mode
                SwitchToBossMode();
            }
            else
            {
                // Jika Boss Mode hilang, kembalikan audio ke Play Mode
                SwitchToPlayMode();
            }
        }

        private bool IsBossActive()
        {
            // Cek apakah ada instance aktif dari prefab Boss
            activeBossObject = GameObject.Find(bossPrefab.name + "(Clone)");
            return activeBossObject != null;
        }

        private void SwitchToPlayMode()
        {
            if (bossModeAudio.isPlaying)
            {
                bossModeAudio.Stop();
            }

            if (!playModeAudio.isPlaying)
            {
                playModeAudio.Play();
            }
        }

        private void SwitchToBossMode()
        {
            if (playModeAudio.isPlaying)
            {
                playModeAudio.Stop();
            }

            if (!bossModeAudio.isPlaying)
            {
                bossModeAudio.Play();
            }
        }

        public void StopAllAudio()
        {
            // Fungsi untuk menghentikan semua audio
            if (playModeAudio.isPlaying)
            {
                playModeAudio.Stop();
            }

            if (bossModeAudio.isPlaying)
            {
                bossModeAudio.Stop();
            }
        }

        public void SetGameFinished(bool isFinished)
        {
            // Setter untuk menentukan apakah game telah selesai
            isGameFinished = isFinished;
        }
    }
}
