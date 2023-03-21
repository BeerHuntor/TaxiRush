using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private bool hasPassenger;
    [SerializeField] private bool isPassengerWaiting;
    private bool startOfGame; 
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void InitGame()
    {
        hasPassenger = false;
        isPassengerWaiting = false;
        startOfGame = true;
    }
    public bool HasPassenger
    {
        get
        {
            return hasPassenger;
        }
        set
        {
            hasPassenger = value;
        }

    }
    public bool PassengerWaiting
    {
        get
        {
            return isPassengerWaiting;
        }
        set
        {
            isPassengerWaiting = value;
        }
    }
    public bool StartOfGame
    {
        get
        {
            return startOfGame; 
        }
        set
        {
            startOfGame = value;
        }
    }

}
