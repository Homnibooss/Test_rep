using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : GameState
    {
        public GameState gamePlayState;
        public LevelController levelController;
        public TMP_Text scoreText;

        public void PlayGame()

        {
            Exit();
            gamePlayState.Enter();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            scoreText.text = $"HScore : {levelController.highScore}";

        }
    }
}
