public class Constants
{
    public const int CurrentProgressVersion = 1;
    public const int CurrentConfigurationVersion = 1;

    public class AnalyticsEvents
    {
        public class Events
        {
            public const string GAMEOPENED_EVENT = "game_open";
            public const string GAMESTART_EVENT = "game_start";
            public const string GAMEOVER_EVENT = "game_over";
            public const string GAMECLOSE_EVENT = "game_close";
        }

        public class ParameterName
        {
            public const string SCORE = "score";
        }

        public class ButtonName
        {
            //Main Menu
            public const string START_MAINMENU = "start_mainmenu";
            public const string SETTINGS_MAINMENU = "settings_mainmenu";
            public const string PRIVACY_OR_TERMS_LINK = "privacy_or_terms_link";

            //Settings Menu
            public const string CLOSE_SETTINGS_MAINMENU = "close_settings_mainmenu";
            public const string MUSIC_SETTINGS_MAINMENU = "music_settings_mainmenu";
            public const string SOUND_SETTINGS_MAINMENU = "sound_settings_mainmenu";
            public const string SOCIAL_SETTINGS_MAINMENU = "social_settings_mainmenu";
            public const string CREDITS_SETTINGS_MAINMENU = "credits_settings_mainmenu";

            //Credits Menu
            public const string CLOSE_CREDITS_MAINMENU = "close_credits_mainmenu";

            //Social Menu
            public const string CLOSE_SOCIAL_MAINMENU = "close_social_mainmenu";
            public const string LINK1_SOCIAL_MAINMENU = "link1_social_mainmenu";
            public const string LINK2_SOCIAL_MAINMENU = "link2_social_mainmenu";
            public const string LINK3_SOCIAL_MAINMENU = "link3_social_mainmenu";

            //Game Menu
            public const string PAUSE_GAMEMENU = "pause_gamemenu";

            //Pause Menu
            public const string RESUME_PAUSE_GAMEMENU = "resume_pause_gamemenu";
            public const string RESTART_PAUSE_GAMEMENU = "restart_pause_gamemenu";
            public const string SOUND_PAUSE_GAMEMENU = "sound_pause_gamemenu";
            public const string MUSIC_PAUSE_GAMEMENU = "music_pause_gamemenu";
            public const string HOME_PAUSE_GAMEMENU = "home_pause_gamemenu";

            //GameOver Menu
            public const string RESTART_GAMEOVER_GAMEMENU = "restart_gameover_gamemenu";
            public const string HOME_GAMEOVER_GAMEMENU = "home_gameover_gamemenu";

            //Intro Panel
            public const string CLOSE_CONTROLINTRO_GAMEMENU = "close_controlintro_gamemenu";
        }
    }

    public class SpawnerData
    {
        public const int INITIAL_PLATFORM_COUNT = 10;
        public const float MIN_VERTICAL_DISTANCE = 1.5f;
        public const float MAX_VERTICAL_DISTANCE = 2f;
        public const float SUPER_PLATFORM_RANDOMNESS = 1f;
    }

    public class PlatformData
    {
        public const float PUSH_FORCE = 15;
        public const float WIDTH = 1;
    }

    public class RocketData
    {
        public const float MOVEMENT_SPEED = 3;
    }

    public class ScoreData
    {
        public const float FACTOR = 15f;
        public const string MEASURE_UNIT = "m";
    }

    public class UrlData
    {
        public const string SOCIAL_1 = "https://youtube.com/c/JustyPie";    //Youtube
        public const string SOCIAL_2 = "https://www.instagram.com/justy_pie/";    //Instagram
        public const string SOCIAL_3 = "https://youtube.com/c/JustyPie";     //Google Try me Luck
    }

    public class TextsData
    {
        public const string CREDITS =
            "Created By:" +
            "\r\nAjmal" +
            "\r\n" +
            "\r\nSprites and Icons made by:" +
            "\r\nThen who? me only..";
    }

    public class AudioSettingsData
    {
        public const float MUSIC_VOLUME = 0.6f;
        public const float SOUND_VOLUME = 1f;
    }
    public class RemoteConfigKeys
    {
        public const string GAME_CONFIGURATION_PLAYERPREFS = "config_data";
    }

    public class PlayerPrefsKeys
    {
        public const string GAME_PROGRESS_PLAYERPREFS = "game_progress";
        public const string CONTROLS_INTRO_PLAYERPREFS = "controls_intro";
        public const string PRIVACY_TERMS_PLAYERPREFS = "privacy_terms";

        public const string IS_SOUND_ON = "is_sound_on";
        public const string IS_MUSIC_ON = "is_music_on";
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
