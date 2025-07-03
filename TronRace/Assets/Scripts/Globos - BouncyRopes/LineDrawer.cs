using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    #region UNITY METHODS
    void Awake()
    {
        if (lines == null) lines = new List<PhysicalLine>();
    }
    private void Start()
    {
        //drawingTimes = new List<float>();
        //drawPoints = new List<Vector3>();
        if (replaying) {
            replayTimer = new Timer();
            replayTimer.Target = drawingTimes[replayIndex];
            replayTimer.OnFinish = () =>
            {
                Debug.Log($"REPLAYING {replayIndex} with time {drawingTimes[replayIndex]}");
                var point = drawPoints[replayIndex];
                Draw(point);
                replayIndex = (replayIndex + 1) % drawingTimes.Count;
                replayTimer.Target = drawingTimes[replayIndex];
                replayTimer.Restart();
            };
            replayTimer.Restart();
        }
    }

    void Update()
    {
        if (recording) { 
        timer += Time.deltaTime;
        }
        if (replaying) {
            replayTimer.Tick(Time.deltaTime);
        }
    }
    #endregion

    #region VARIABLES
    public bool recording = false;
    public bool replaying = false;
    [SerializeField]
    private List<float> drawingTimes;
    [SerializeField]
    private List<Vector3> drawPoints;

    private Timer replayTimer;
    private int replayIndex = 0;
    float timer = 0f;

    public PhysicalLine prefab;
    private List<PhysicalLine> lines;
    public System.Action<GameObject> OnLineSegmentSpawn;
    private Entrance.ObjectPool linePool = new Entrance.ObjectPool();
    [SerializeField] private Transform SurfaceReference;
    #endregion

    #region PUBLIC METHODS
    public void Draw(Vector3 point)
    {
        var rPoint = point;
        //to avoid collision o drawing area
        point = point + (SurfaceReference.forward * -2);

        foreach (var line in lines)
        {
            if (!line.isLineCompleted) { 
                //Debug.Log($"is Point {point} close to line? {line.isPointClose(point)}");
                if (line.isPointClose(point)) {
                    if (recording)
                    {
                        drawingTimes.Add(timer);
                        drawPoints.Add(rPoint);
                        timer = 0f;
                    }
                    line.Add(point);
                    return; 
                }
            }
        }


        var pos = Vector3.zero;
        pos.z = point.z;

        var lineObj = linePool.GetObject();
        PhysicalLine pLine = null;
        if (lineObj == null)
        {
            pLine = Instantiate(prefab, pos, Quaternion.identity);

            //sets surface bounciness
            pLine.OnNewSegment = OnLineSegmentSpawn;
            lines.Add(pLine);
            linePool.SetupObjectForPoolOnRecycle(pLine);
            pLine.SetColliderRightReference(SurfaceReference.forward);
        }
        else {
             pLine = lineObj.GetComponent<PhysicalLine>();
        }
        pLine.Create(point);
        if (recording)
        {
            drawingTimes.Add(timer);
            drawPoints.Add(rPoint);
            timer = 0f;
        }
    }
    #endregion
}
