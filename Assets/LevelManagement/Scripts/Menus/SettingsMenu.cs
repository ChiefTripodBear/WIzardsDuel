using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class SettingsMenu : Menu<SettingsMenu>
    {
        // UI Sliders
        [SerializeField]
        private Slider _masterVolumeSlider;

        [SerializeField]
        private Slider _sfxVolumeSlider;

        [SerializeField]
        private Slider _musicVolumeSlider;

        // reference to DataManager
        private DataManager _dataManager;

        // initialize Menu
		protected override void Awake()
		{
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
		}

        // load the save data from disk and set the sliders based on persistent data
		private void Start()
		{
            LoadData();
		}

        // sets the master volume from slider
		public void OnMasterVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MasterVolume = volume;
            }

        }

        // sets the sfx volume from slider
        public void OnSFXVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.SfxVolume = volume;
            }

        }

        // sets the music volume from slider
        public void OnMusicVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MusicVolume = volume;
            }
        }

        // saves the data when we press Back
        public override void OnBackPressed()
        {
            base.OnBackPressed();

            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }

        // loads the data from disk and sets the slider values
        public void LoadData()
        {
            if (_dataManager != null)
            {
                _dataManager.Load();
            }

            _masterVolumeSlider.value = _dataManager.MasterVolume;
            _sfxVolumeSlider.value = _dataManager.SfxVolume;
            _musicVolumeSlider.value = _dataManager.MusicVolume;
        }
    }
}