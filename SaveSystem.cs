using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem : MonoBehaviour {

    public static SaveSystem system;
    public int Piano_record;
    public int Quiz_Bio;
    public int Quiz_Phy;
    public int Quiz_Chem;

    
   void Awake()
   {
       if (system == null)
       {
           DontDestroyOnLoad(gameObject);
           system = this;
       }
       else if (system != this)
       {
           Destroy(gameObject);
       }
    }

    public void Save()
    {
        BinaryFormatter tr = new BinaryFormatter();
        Stream theFile = File.Create(Application.persistentDataPath + "/save.dat");
        AllInformation data = new AllInformation();
        
        // Inforaciq za savevane
        data.Piano_record = Piano_record;
        data.Quiz_Bio = Quiz_Bio;
        data.Quiz_Chem = Quiz_Chem;
        data.Quiz_Phy = Quiz_Phy;
        //
        tr.Serialize(theFile, data);
        theFile.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter tr = new BinaryFormatter();
            Stream theFile = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            AllInformation data = new AllInformation();
            data = (AllInformation)tr.Deserialize(theFile);
            theFile.Close();
            // Inforaciq za savevane
            Piano_record = data.Piano_record;
            Quiz_Bio = data.Quiz_Bio;
            Quiz_Chem = data.Quiz_Chem;
            Quiz_Phy = data.Quiz_Phy;
            //
        }
        else
        {
            Save();
        }
    }


}
[Serializable]
class AllInformation
{
    public int Piano_record;
    public int Quiz_Bio;
    public int Quiz_Phy;
    public int Quiz_Chem;
}
