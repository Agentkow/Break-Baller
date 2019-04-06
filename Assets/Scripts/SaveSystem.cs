using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScore(HighScoreHolder highScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/score.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Score scoreData = new Score(highScore);

        formatter.Serialize(stream, scoreData);
        stream.Close();
    }

    public static Score ScoreLoad()
    {
        string path = Application.persistentDataPath + "/score.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Score data = formatter.Deserialize(stream) as Score;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }

}
