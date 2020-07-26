using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This whole script contains all rules of game used by scripts
/// </summary>
public class GameRules : MonoBehaviour
{
    #region >>> Statics <<<
    public static float bottomHeight;
    public static Vector2 wallsPositions;
    public static float playerSpeed;
    public static float obstacleSpawnMultiplier;
    public static float obstacleTerminationLine;
    public static float obstacleSpawnDistance;

    public static int numberOfPlayers;

    public static int playerHPCap;
    public static int playerSoftArmorCap;
    public static int playerHardArmorCap;
    public static int playerShieldCap;
    public static float playerShieldDistancePerStack;
    public static int playerStunFrames;
    #endregion

    [Header("Gamerules:")]
    public float bottomHeight_ = 0f;
    public Vector2 wallsPositions_ = new Vector2(-250f, 250f);
    public float playerSpeed_ = 100;
    public float obstacleSpawnMultiplier_ = 1f;
    [Tooltip("The z coordinate after which all obstacles are terminated (note that variable is set at Start() of obstacle and is not changed after that)")]
    public float obstacleTerminationLine_ = -500f;
    [Tooltip("Distance at which obstacles are spawned")]
    public float obstacleSpawnDistance_ = 1100f;
    public int numberOfPlayers_ = 1;

    public int playerHPCap_ = 5;
    public int playerSoftArmorCap_ = 3;
    public int playerHardArmorCap_ = 5;
    public int playerShieldCap_ = 3;
    [Tooltip("How far ship has to fly untouched to gain one shield stack")]
    public float playerShieldDistancePerStack_ = 500;
    public int playerStunFrames_ = 20;

    [Tooltip("Temporary key used to test new GameRules valuse")]
    public KeyCode reload = KeyCode.Q;

    public static float _distanceTravelled;

    public const float acceleration = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        LoadValues();
        _distanceTravelled = (int)-obstacleSpawnDistance_;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(reload)) LoadValues();

        _distanceTravelled += playerSpeed * Time.fixedDeltaTime;

        playerSpeed += acceleration * Time.fixedDeltaTime;
    }

    public void LoadValues()
    {
        bottomHeight = bottomHeight_;
        wallsPositions = wallsPositions_;
        playerSpeed = playerSpeed_;
        obstacleSpawnMultiplier = obstacleSpawnMultiplier_;
        obstacleTerminationLine = obstacleTerminationLine_;
        obstacleSpawnDistance = obstacleSpawnDistance_;
        numberOfPlayers = numberOfPlayers_;
        playerHPCap = playerHPCap_;
        playerSoftArmorCap = playerHardArmorCap_;
        playerHardArmorCap = playerHardArmorCap_;
        playerShieldCap = playerShieldCap_;
        playerShieldDistancePerStack = playerShieldDistancePerStack_;
        playerStunFrames = playerStunFrames_;
    }
}
