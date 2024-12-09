using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class BackgroundAudioManager : MonoBehaviour
    {
        public static BackgroundAudioManager Instance; // Singleton instance
        public AudioSource backgroundMusic; // AudioSource untuk musik latar

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
    }
}
