using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class PlayerStats : MonoBehaviour
{
    public int level;

    public Transform character;


    


    private void Start()
    {
        if (character != null)
        {
            Load();
        }
    }

    public void Save()
    {
        PlayerBinary.SavePlayerData(character, this);
    }

    public void Load()
    {
        PlayerData playerdata = PlayerBinary.LoadPlayerData(character, this);
       //playerdata.LoadPlayerData(transform, this);
    }

    public void DeleteFile()
    {
        File.Delete(Application.dataPath + "/mysave.save");
    }


}

[System.Serializable]
public class PlayerData
{
    public int level;

    public float[] position;
    public float[] rotation;


    public PlayerData(Transform playerTransform, PlayerStats playerStats)
    {
        level = playerStats.level;

        position = new float[] { playerTransform.position.x, playerTransform.position.y, playerTransform.position.z };

        rotation = new float[] { playerTransform.rotation.x, playerTransform.rotation.y, playerTransform.rotation.z, playerTransform.rotation.w };
    }

    public void LoadPlayerData(Transform playerTransform, PlayerStats playerStats)
    {
        playerStats.level = level;

        playerTransform.position = new Vector3(position[0], position[1], position[2]);
        playerTransform.rotation = new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3]);
    }
}



public static class PlayerBinary
{
    public static void SavePlayerData(Transform playerTransform, PlayerStats playerStats)
    {
        //We create the path to the file
        string path = Application.dataPath + "/mysave.save";
        //we open the file or create the file
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        //converts classes into something we can write to a file.
        //(serialize)
        BinaryFormatter formatter = new BinaryFormatter();


        //data we want to save to the file
        PlayerData data = new PlayerData(playerTransform, playerStats);

      

        //do the thing: serializing the data into the file
        formatter.Serialize(stream, data);

        //close the file
        stream.Close();
    }

    public static PlayerData LoadPlayerData(Transform playerTransform, PlayerStats playerStats)
    {
        string path = Application.dataPath + "/mysave.save";

        //does the file exist
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();

            data.LoadPlayerData(playerTransform, playerStats);
            //return the data
            return data;
        }
        else
        {
            //dont load anything
            return null;
        }
    }

}




