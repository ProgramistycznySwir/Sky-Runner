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
    public static Range wallsPositions;
    public static float playerSpeed;
    public static float obstacleSpawnMultiplier;
    public static float obstacleTerminationLine;
    public static float obstacleSpawnDistance;

    private static int numberOfPlayers;

    public static int playerHPCap;
    public static int playerSoftArmorCap;
    public static int playerHardArmorCap;
    public static int playerShieldCap;
    public static float playerShieldDistancePerStack;
    public static int playerStunFrames;
    #endregion

    [Header("Gamerules:")]
    public float bottomHeight__ = 0f;
    public Range wallsPositions__ = new Range(-250f, 250f);
    public float playerSpeed__ = 100;
    public float obstacleSpawnMultiplier__ = 1f;
    [Tooltip("The z coordinate after which all obstacles are terminated (note that variable is set at Start() of obstacle and is not changed after that)")]
    public float obstacleTerminationLine__ = -500f;
    [Tooltip("Distance at which obstacles are spawned")]
    public float obstacleSpawnDistance__ = 1100f;
    public int numberOfPlayers__ = 1;

    public int playerHPCap__ = 5;
    public int playerSoftArmorCap__ = 3;
    public int playerHardArmorCap__ = 5;
    public int playerShieldCap__ = 3;
    [Tooltip("How far ship has to fly untouched to gain one shield stack")]
    public float playerShieldDistancePerStack__ = 500;
    public int playerStunFrames__ = 20;

    [Tooltip("Temporary key used to test new GameRules valuse")]
    public KeyCode reload = KeyCode.Q;

    static float __distanceTravelled;
    public static float distanceTravelled => __distanceTravelled;

    public const float acceleration = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        LoadValues();
        __distanceTravelled = (int)-obstacleSpawnDistance__;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //<NOTE_DEBUG> It's for debug.
        if (Input.GetKeyDown(reload))
            LoadValues();

        __distanceTravelled += playerSpeed * Time.fixedDeltaTime;

        playerSpeed += acceleration * Time.fixedDeltaTime;
    }

    public void LoadValues()
    {
        bottomHeight = bottomHeight__;
        wallsPositions = wallsPositions__;
        playerSpeed = playerSpeed__;
        obstacleSpawnMultiplier = obstacleSpawnMultiplier__;
        obstacleTerminationLine = obstacleTerminationLine__;
        obstacleSpawnDistance = obstacleSpawnDistance__;
        numberOfPlayers = numberOfPlayers__;
        playerHPCap = playerHPCap__;
        playerSoftArmorCap = playerHardArmorCap__;
        playerHardArmorCap = playerHardArmorCap__;
        playerShieldCap = playerShieldCap__;
        playerShieldDistancePerStack = playerShieldDistancePerStack__;
        playerStunFrames = playerStunFrames__;
    }
}
