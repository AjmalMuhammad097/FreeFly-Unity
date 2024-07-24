using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public const int CurrentPlayerDataVersion = 1;


    public class Score
    {
        public const float SCORE_FACTOR = 15f;

        public const string DISTANCE_MEASURE_UNIT = "m";
    }

    public class PlayerPrefsKeys
    {
        public const string GAME_PROGRESS_PLAYERPREFS = "GameProgress";
        public const string GAME_CONFIGURATION_PLAYERPREFS = "PlayerData";
        public const string CONTROLS_INTRO_PLAYERPREFS = "ControlsIntro";
    }

    public class AnimationKeys
    {
        public const string HIT_TRIGGER_ANIMATION = "Hit";

        public const string PLAYER_JUMP_TRIGGER_ANIMATION = "JUMP";

        public const string PLAYER_MOUTH_INT_ANIMATION = "VALUE";
        public class MouthAnimationValues
        {
            public const int PLAYER_MOUTH_NORMAL = 0;
            public const int PLAYER_MOUTH_FALL = 1;
            public const int PLAYER_MOUTH_HAPPY = 2;
        }
    }

    public class RemoteConfigKeys
    {

        public const string HIT_TRIGGER_ANIMATION = "Hit";

        public const string GAME_PROGRESS_PLAYERPREFS = "GameProgress";
        public const string GAME_CONFIGURATION_PLAYERPREFS = "PlayerData";
        public const float SCORE_FACTOR = 15f;

        public const string DISTANCE_MEASURE_UNIT = "m";


    }
    public class AudioConstants
    {
        public const string MUSIC_1 = "music1";
        public const string MUSIC_2 = "music2";

        public const string SFX_POSITIVE_BUTTON_1 = "sfx1";
        public const string SFX_POSITIVE_BUTTON_2 = "sfx2";
        public const string SFX_POSITIVE_BUTTON_3 = "sfx3";
        public const string SFX_NEGATIVE_BUTTON_1 = "sfx4";
        public const string SFX_NEGATIVE_BUTTON_2 = "sfx5";
        public const string SFX_NEGATIVE_BUTTON_3 = "sfx6";

        public const string SFX_BOUNCE_EVENT = "event1";
    }
}
