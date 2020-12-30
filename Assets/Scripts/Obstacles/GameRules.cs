using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This whole script contains all rules of game used by scripts
/// </summary>
public class GameRules : MonoBehaviour
{
    // Unity specific singleton.
    static GameRules instance;
    void Awake()
    {
        instance = this;
        __distanceTravelled = (int)-obstacleSpawnDistance__;
    }

    #region >>> Statics <<<
    public static float bottomHeight => instance.bottomHeight__;
    public static Range wallsPositions => instance.wallsPositions__;
    public static float playerSpeed => instance.playerSpeed__;
    public static float obstacleSpawnMultiplier => instance.obstacleSpawnMultiplier__;
    public static float obstacleTerminationLine => instance.obstacleTerminationLine__;
    public static float obstacleSpawnDistance => instance.obstacleSpawnDistance__;

    private static int numberOfPlayers => instance.numberOfPlayers__;

    public static int playerHPCap => instance.playerHPCap__;
    public static int playerSoftArmorCap => instance.playerSoftArmorCap__;
    public static int playerHardArmorCap => instance.playerHardArmorCap__;
    public static int playerShieldCap => instance.playerShieldCap__;
    public static float playerShieldDistancePerStack => instance.playerShieldDistancePerStack__;
    public static int playerStunFrames => instance.playerStunFrames__;
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


    // Update is called once per frame
    void FixedUpdate()
    {
        __distanceTravelled += playerSpeed * Time.fixedDeltaTime;

        playerSpeed__ += acceleration * Time.fixedDeltaTime;
    }
}
