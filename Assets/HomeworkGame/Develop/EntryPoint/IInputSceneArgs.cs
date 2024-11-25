using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputSceneArgs 
{
   
}

public class GameplayInputArgs : IInputSceneArgs
{
    public GameplayInputArgs(int levelNummer)
    {
        LevelNumber = levelNummer;
    }

    public int LevelNumber { get; }
}

public class MainMenuInputArgs : IInputSceneArgs
{

}
