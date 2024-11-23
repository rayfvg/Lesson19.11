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
        LevelNummer = levelNummer;
    }

    public int LevelNummer { get; }
}

public class MainMenuInputArgs : IInputSceneArgs
{

}
