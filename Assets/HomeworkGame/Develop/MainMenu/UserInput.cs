using UnityEngine;

public class UserInput
{
    public bool UserSelect(KeyCode keycode)
    {
        if (Input.GetKeyDown(keycode))
        {
            return true;
        }

        return false;
    }
}