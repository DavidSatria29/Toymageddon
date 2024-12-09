using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class SceneObjectController : MonoBehaviour
    {
        public GameObject backgroundAudioManager; // Referensi ke GameObject BackgroundAudioManager

        private void OnEnable()
        {
            // Nonaktifkan BackgroundAudioManager saat objek ini diaktifkan
            if (backgroundAudioManager != null)
            {
                backgroundAudioManager.SetActive(false);
            }
        }

        private void OnDisable()
        {
            // Aktifkan kembali BackgroundAudioManager saat objek ini dinonaktifkan
            if (backgroundAudioManager != null)
            {
                backgroundAudioManager.SetActive(true);
            }
        }
    }
}
