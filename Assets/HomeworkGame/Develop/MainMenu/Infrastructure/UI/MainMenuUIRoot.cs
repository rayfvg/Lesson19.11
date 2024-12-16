using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIRoot : MonoBehaviour
{
    //[field: SerializeField] public IconsWithTextListView WalletView { get; private set; }
    //[field: SerializeField] public ActionButton OpenLevelsMenuButton { get; private set; }
    [field: SerializeField] public IconWithText _currencyView;

    [field: SerializeField] public TextWithValue _counterWinView;

    [field: SerializeField] public TextWithValue _counterLoseView;

    [field: SerializeField] public Button _deleteSaveButton;

    [field: SerializeField] public Transform HUDLayer { get; private set; }
    [field: SerializeField] public Transform PopupsLayer { get; private set; }
    [field: SerializeField] public Transform VFXLayer { get; private set; }
}
