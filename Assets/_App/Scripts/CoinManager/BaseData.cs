﻿using System;
using UnityEngine;

[Serializable]
public class BaseData : MonoBehaviour {
    protected string prefString;

    public virtual void Init() {
        try {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(prefString), this);
        }
        catch (Exception e) {
            ResetData();
            Debug.LogError("Error On Load PlayerPrefs...");
            Debug.LogError("Error : " + e);
			
        }

        CheckAppendData();
    }

    public virtual void ResetData() { }
    protected virtual void CheckAppendData() { }

    protected void Save() {
        string json = JsonUtility.ToJson(this);
        // Debug.Log("json_______" + json);
        PlayerPrefs.SetString(prefString, json);
    }
}
