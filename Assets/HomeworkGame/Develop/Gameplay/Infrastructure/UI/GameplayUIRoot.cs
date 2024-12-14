using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIRoot : MonoBehaviour
{
   // [field: SerializeField] public TextWithValue _counterWinView;
    
    [field: SerializeField] public TextWithValue _inputUserView;
    [field: SerializeField] public Transform HUDLayer { get; private set; }
    [field: SerializeField] public Transform PopupsLayer { get; private set; }
    [field: SerializeField] public Transform VFXLayer { get; private set; }
}
