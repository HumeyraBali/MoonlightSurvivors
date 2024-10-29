using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPersistentUprades
{
   Hp,
   Damage
}

[Serializable]
public class PlayerUpgrades
{
   public PlayerPersistentUprades playerPersistentUprades;
   public int level = 0;
   public int maxLevel = 10;
   public int costToUpgrade = 100;
}


[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
   public int coins;

   public List<bool> stageCompletion;
   public List<PlayerUpgrades> upgrades;

   public PlayerData selectedPlayer;
   public string selectedStage; 

   public void StageComplete(int i)
   {
      stageCompletion[i] = true;
   }

   public int GetUpgradeLevel(PlayerPersistentUprades persistentUprade)
   {
        return upgrades[(int)persistentUprade].level;
   }

   public void SetSelectedPlayer(PlayerData player)
   {
      selectedPlayer = player;
   }

   public void SelectStage(string stageToPlay)
   {
      selectedStage = stageToPlay; 
   }
}
