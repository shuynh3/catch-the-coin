using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public static List<KeyCode> up { get; set; }
    public static List<KeyCode> down { get; set; }
    public static List<KeyCode> left { get; set; }
    public static List<KeyCode> right { get; set; }
    public static List<KeyCode> pause { get; set; }


    public static bool GetInput(List<KeyCode> keyCode)
    {
        if (PauseMenu.isPaused && keyCode != pause)
        {
            return false;
        }

        for (int i = 0; i < keyCode.Count; i++)
        {
            if (Input.GetKey(keyCode[i]))
            {
                return true;
            }
        }
        return false;
    }

    public static bool GetKeyDown(List<KeyCode> keyCode)
    {
        if (PauseMenu.isPaused && keyCode != pause)
        {
            return false;
        }

        for (int i = 0; i < keyCode.Count; i++)
        {
            if (Input.GetKeyDown(keyCode[i]))
            {
                return true;
            }
        }
        return false;
    }

    private void Awake()
    {
        Initialize();

        up = new List<KeyCode> { KeyCode.W, KeyCode.UpArrow, KeyCode.Space };
        down = new List<KeyCode> { KeyCode.S, KeyCode.DownArrow };
        left = new List<KeyCode> { KeyCode.A, KeyCode.LeftArrow };
        right = new List<KeyCode> { KeyCode.D, KeyCode.RightArrow };
        pause = new List<KeyCode> { KeyCode.Escape };
    }

    void Initialize()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
