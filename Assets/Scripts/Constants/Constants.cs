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
    }

    public class AnimationKeys
    {
        public const string HIT_TRIGGER_ANIMATION = "Hit";

        public const string PLAYER_JUMP_TRIGGER_ANIMATION = "JUMP";

        public const string PLAYER_MOUTH_INT_ANIMATION = "VALUE";
        public class MouthAnimationValues
        {
            public const int PLAYER_MOUTH_NORMAL = 0;
            public const int PLAYER_MOUTH_JUMP = 1;
            public const int PLAYER_MOUTH_HAPPY = 2;
        }
    }

    public class RemoteConfigKeys
    {

    }
}
