using System;

[Serializable]
public class GameData
{
    private int lastScore;

    public int LastScore
    {
        get { return lastScore; }
        set
        {
            lastScore = value;
            CalculateBestScore(value);
        }
    }
    public int BestScore { get; private set; }
    public int TotalScore { get; private set; }

    public GameData()
    {
        LoadGameData();
    }


    private void LoadGameData()
    {
        var loadedData = MyPlayerPrefs.GetJson<GameData>(ConstantValues.GAMEDATA_PLAYERPREFS);
        if (loadedData != null)
        {
            LastScore = loadedData.LastScore;
            BestScore = loadedData.BestScore;
            TotalScore = loadedData.TotalScore;
        }
    }

    private void CalculateBestScore(int lastScore)
    {
        TotalScore += lastScore;
        this.lastScore = lastScore;

        if (lastScore > BestScore)
        {
            BestScore = lastScore;
        }

        MyPlayerPrefs.SetJson<GameData>(ConstantValues.GAMEDATA_PLAYERPREFS, this);
    }
}
