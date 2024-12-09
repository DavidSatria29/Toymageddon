using UnityEngine;
using TMPro;
using UnityEngine.Localization;

namespace Vampire
{
    public class GameOverDialog : DialogBox
    {
        [SerializeField] private TextMeshProUGUI statusText;
        [SerializeField] private TextMeshProUGUI coinsGained;
        [SerializeField] private TextMeshProUGUI enemiesRouted;
        [SerializeField] private TextMeshProUGUI damageDealt;
        [SerializeField] private TextMeshProUGUI damageTaken;
        [SerializeField] private GameObject background;
        [SerializeField] private LocalizedString levelPassedLocalization, levelLostLocalization;
        [SerializeField] private AudioSource backgroundAudio; // Background music AudioSource
        [SerializeField] private AudioSource levelPassedAudioSource; // AudioSource untuk level passed
        [SerializeField] private AudioSource levelLostAudioSource; // AudioSource untuk level lost

        public void Open(bool levelPassed, StatsManager statsManager)
        {
            // Mengatur teks status
            statusText.text = levelPassed ? levelPassedLocalization.GetLocalizedString() : levelLostLocalization.GetLocalizedString();

            // Mengatur statistik
            coinsGained.text = "+" + statsManager.CoinsGained;
            enemiesRouted.text = statsManager.MonstersKilled.ToString();
            damageDealt.text = statsManager.DamageDealt.ToString();
            damageTaken.text = statsManager.DamageTaken.ToString();

            // Pause background audio
            if (backgroundAudio != null)
            {
                backgroundAudio.Pause();
            }

            // Memainkan audio berdasarkan hasil level
            if (levelPassed && levelPassedAudioSource != null)
            {
                levelPassedAudioSource.Play();
            }
            else if (!levelPassed && levelLostAudioSource != null)
            {
                levelLostAudioSource.Play();
            }

            // Menampilkan latar belakang
            background.SetActive(true);
            base.Open();
        }

        public override void Close()
        {
            base.Close();

            // Resume background audio
            if (backgroundAudio != null)
            {
                backgroundAudio.UnPause();
            }

            background.SetActive(false);
        }
    }
}
