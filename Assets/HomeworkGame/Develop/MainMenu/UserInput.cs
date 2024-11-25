using UnityEngine;

public class UserInput
{
    private UserInput _userInput;

    public bool UserSelect(KeyCode keycode)
    {
        if (Input.GetKeyDown(keycode))
        {
            return true;
        }

        return false;
    }
}