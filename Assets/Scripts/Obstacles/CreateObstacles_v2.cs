using UnityEngine;
using System.IO;

public class CreateObstacles_v2 : MonoBehaviour
{
    #region >>> Variables <<<

    public float distanceInFront = 200f;
    public float naboki = 200f;

    int[] cooldowns;

    public bool multiplayer = false;

    public Vector2 heightOfObstacles = new Vector2(50f, 50f);

    public float currentStageDistanceTravelled;
    public float currentStageLenght;

    [Header("Sockets:")]
    //public Transform player;
    public Light sun;
    public GameObject[] obstacles;
    public GameObject stageSeparator;
    [Tooltip("NOT IMPLEMENTED")]
    public GameObject[] buffs;

    [Header("GameData:")]
    public string stagesDataFileName = "stages.json";
    private StagesData stagesData;
    private Stage currentStage;

    #endregion

    #region >>> MonoBehaviour Methods <<<

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        //CreateTemplateFile();
        LoadData();
        ChooseRandomStage();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (multiplayer)
        //{
        //    transform.position = new Vector3(0,0,player.position.z);
        //}
        for (int i = 0; i < currentStage.obstacles.Length; i++)
        {
            if (cooldowns[i] <= 0)
            {
                GameObject newObstacle = Instantiate(obstacles[currentStage.obstacles[i].ID], new Vector3(Random.Range(-naboki, naboki), /*-50*/0, distanceInFront), Quaternion.identity);
                if (currentStage.obstacles[i].varySize) newObstacle.transform.localScale = new Vector3(newObstacle.transform.localScale.x, Random.Range(heightOfObstacles.x, heightOfObstacles.y), newObstacle.transform.localScale.z);
                cooldowns[i] = currentStage.obstacles[i].cooldown;
            }
            else cooldowns[i]--;
        }

        //if (cooldownBuffs <= 0)
        //{
        //    Instantiate(buffs[Random.Range(0, buffs.Length - 1)], new Vector3(Random.Range(-naboki, naboki), 0, transform.position.z + distanceInFront), new Quaternion(0, 0, 0, 0));
        //    cooldownBuffs = waitBuffs;
        //}
        //else cooldownBuffs--;

        if (Input.GetKeyDown(KeyCode.Space)) ChooseRandomStage();
    }

    #endregion

    #region >>> Data Manageing <<<

    public void CreateTemplateFile()
    {
        string filePath = Path.Combine(Application.dataPath, "stagesTemplate.json");
        StagesData stagesData = new StagesData();
        stagesData.stages = new Stage[4];
        stagesData.stages[0].obstacles = new Obstacle[3];
        //Debug.Log("name: " + stagesData.stage.name);
        File.WriteAllText(filePath, JsonUtility.ToJson(stagesData, true));
        //File.WriteAllText( filePath, "Shiet...");
        Debug.Log("Well... Everything went well! >> " + filePath);
    }

    public void LoadData()
    {
        string filePath = Path.Combine(Application.dataPath, stagesDataFileName);
        if (!File.Exists(filePath)) { Debug.LogError("File at " + filePath + " Doesn't exist..."); return; } //catches Unexisting File Exception

        string fileData = File.ReadAllText(filePath);
        StagesData stagesDataTemp = JsonUtility.FromJson<StagesData>(fileData);

        stagesData = stagesDataTemp;

        Debug.Log("Stage Data loaded successfully!");
    }

    #endregion

    #region >>> Stages Managing <<<

    public void ChooseRandomStage()
    {
        int sumOfChances = 0;
        int previousChances = 0;

        foreach (Stage stage in stagesData.stages)
        {
            sumOfChances += stage.chanceOccuring;
        }

        int randomNumber = Random.Range(0, sumOfChances);

        for (int i = 0; i < stagesData.stages.Length; i++)
        {
            if (randomNumber < stagesData.stages[i].chanceOccuring + previousChances && randomNumber >= previousChances)
            {
                currentStage = stagesData.stages[i];
                currentStageLenght = Random.Range(stagesData.stages[i].lenghtRange[0], stagesData.stages[i].lenghtRange[1]);
                cooldowns = new int[stagesData.stages[i].obstacles.Length];

                GameObject newStageSeparator = Instantiate(stageSeparator, new Vector3(0, -50, distanceInFront), Quaternion.identity);
                string text = "";
                for (int a = 0; a < 10; a++)
                {
                    text += "  " + currentStage.name + "  ";
                }
                newStageSeparator.GetComponentInChildren<TMPro.TextMeshPro>().text = text;

                SetLightning();

                Debug.Log("Chosen stage: " + currentStage.name);
                return;
            }
            else previousChances += stagesData.stages[i].chanceOccuring;
        }

        Debug.LogError("Failed to choose stage..."); //method should return void to this point, should
    }

    public void SetLightning()
    {
        sun.color = new Color(currentStage.lightData.sunLightColor[0], currentStage.lightData.sunLightColor[1], currentStage.lightData.sunLightColor[2]);
        sun.intensity = currentStage.lightData.sunLightIntensity;

        RenderSettings.ambientIntensity = currentStage.lightData.ambientIntensity;
    }

    #endregion
}
