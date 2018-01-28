using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private const double GROWTHRATEPERSECOND = 5;

        private const double TAPESTOPPEDGRACEPERIODINSECONDS = 4;
        private const double POLICEGRACEPERIODINSECONDS = 10;
        private const double DEADAIRDEDUCTIONRATEPERSECOND = 2;

        private const double RADIOINTERFERENCEGRACEPERIODINSECONDS = 0;
        private const double RADIOINTERFERENCEDEDUCTIONRATEPERSECOND = 6;


        private DateTime _startTime;
        private DateTime _previousUpdateTime;
        
        public double CurrentScore { get; set; }
        public TimeSpan CurrentGameTime { get; set; }
        public double CurrentScoreRate { get; set; }

        private bool _tapePlayerPlaying;
        private DateTime _tapePlayerOffTime;
        public bool TapePlayerPlaying { get { return _tapePlayerPlaying; } set { if (_tapePlayerPlaying && !value) { _tapePlayerOffTime = DateTime.Now; } _tapePlayerPlaying = value; } }

        public void PlayTape(string name)
        {
            TapePlayerPlaying = true;
        }

        public void TapeStopped()
        {
            TapePlayerPlaying = false;
        }

        private bool _radioInterference;
        private DateTime _radioInterferenceTime;
        public bool RadioInterference { get { return _radioInterference; } set { if (!_radioInterference && value) { _radioInterferenceTime = DateTime.Now; } _radioInterference = value; } }

        private DateTime _policeOffTime;
        private bool _aerialExtended;
        public bool AerialExtended
        {
            get { return _aerialExtended; }
            set {
                if (_powerSwitchOn && _aerialExtended && !value)
                {
                    _policeOffTime = DateTime.Now;
                }
                _aerialExtended = value;
            }
        }
        private bool _powerSwitchOn;
        public bool PowerSwitchOn
        {
            get { return _powerSwitchOn; }
            set
            {
                if (_powerSwitchOn && _aerialExtended && !value)
                {
                    _policeOffTime = DateTime.Now;
                }
                _powerSwitchOn = value;
            }
        }
        
        public ScoreManager(){
            Reset();
        }

        public void Reset()
        {
            TapePlayerPlaying = false;
            
            RadioInterference = false;

            AerialExtended = true;
            PowerSwitchOn = true;

            CurrentScore = 0;
            CurrentScoreRate = 0;
            _startTime = DateTime.Now;
            _previousUpdateTime = DateTime.Now;
        }

        public void Start()
        {
            _startTime = DateTime.Now;
            _previousUpdateTime = DateTime.Now;
        }

        public void Update()
        {
            CalculateCurrentScore();
        }

        private void CalculateCurrentScore()
        {
            var now = DateTime.Now;
            var diff = now - _previousUpdateTime;
            var previousScore = CurrentScore;

            // Are we transmitting?
            if (PowerSwitchOn && AerialExtended && TapePlayerPlaying)
            {
                CurrentScore += diff.TotalSeconds * GROWTHRATEPERSECOND;
                
                // Interference detractors - slow growth
                if (_radioInterference && (now - _radioInterferenceTime).TotalSeconds > RADIOINTERFERENCEGRACEPERIODINSECONDS)
                {
                    CurrentScore += diff.TotalSeconds * (RADIOINTERFERENCEDEDUCTIONRATEPERSECOND * -1);
                }

                // Same old music detractors - slow growth
                // TODO:
            }
            else
            {
                // police detractors/ Dead air/tape-off detractors - loose listeners if it has been too long
                if (((!PowerSwitchOn || !AerialExtended) && (now - _policeOffTime).TotalSeconds > POLICEGRACEPERIODINSECONDS) 
                    || (!TapePlayerPlaying && (now - _tapePlayerOffTime).TotalSeconds > TAPESTOPPEDGRACEPERIODINSECONDS))
                {
                    CurrentScore += diff.TotalSeconds * (DEADAIRDEDUCTIONRATEPERSECOND * -1);
                }
            }

            // Figure out rate
            CurrentScoreRate = CurrentScore - previousScore;

            // Can't have minus listeners
            if(CurrentScore < 0)
            {
                CurrentScore = 0;
                CurrentScoreRate = 0;
            }

            // Update times
            _previousUpdateTime = now;
            CurrentGameTime = now - _startTime;
        }
}
