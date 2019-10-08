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

    [Tooltip("Temporary key used to test new GameRules valuse")]
    public KeyCode reload = KeyCode.Q;

    // Start is called before the first frame update
    void Awake()
    {
        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(reload)) LoadValues();
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
    }
}
