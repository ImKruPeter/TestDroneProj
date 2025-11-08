using System;
using TMPro;
using UnityEngine;

namespace Game
{
    public class UIPointsCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text blueCounterText;
        [SerializeField] private TMP_Text redCounterText;

        private int _blueCounter;
        private int _redCounter;

        public void SetUI(ref Action redCounterEvent, ref Action blueCounterEvent)
        {
            redCounterEvent += RedCounterEv;
            blueCounterEvent += BlueCounterEv;

            redCounterText.text = _redCounter.ToString();
            blueCounterText.text = _blueCounter.ToString();
        }

        public void UnSetUI(ref Action redCounterEvent, ref Action blueCounterEvent)
        {
            redCounterEvent -= RedCounterEv;
            blueCounterEvent -= BlueCounterEv;
        }

        private void RedCounterEv()
        {
            _redCounter++;
            redCounterText.text = _redCounter.ToString();
        }

        private void BlueCounterEv()
        {
            _blueCounter++;
            blueCounterText.text = _blueCounter.ToString();
        }
    }
}