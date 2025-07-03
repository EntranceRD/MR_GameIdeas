using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicalLine : Entrance.PoolableObject
{
    #region UNITY METHODS
    private void Awake()
    {
        points = new List<Vector3>();
        createdSegments = new List<TemporarySegment>();
        pointAddingTimer = new Timer() {
            OnFinish = () => {
                isLineCompleted = true;
                CheckPointDestruction();
            },
            Target = 5f
        };

    }
    private void FixedUpdate()
    {
        if (!isLineCompleted) {
            pointAddingTimer.Tick(Time.deltaTime);
        }
        var temp = new List<TemporarySegment>(createdSegments);

        foreach (var segment in temp)
        {
            segment.Step(Time.fixedDeltaTime);
        }

        DrawPoints(points.ToArray());
        SetCollider();
        //DrawPoints(points.ToArray());
    }
    #endregion

    #region VARIABLES
    public LineRenderer rend;
    [SerializeField]private BouncySurface surface;
    [Range(0, 20), SerializeField] private int maxSize = 10;
    [Range(0, 1), SerializeField] private float minDistance = 0.2f;
    [Range(0, 1), SerializeField] private float maxDistance = 0.2f;

    private List<Vector3> points;
    public System.Action<GameObject> OnNewSegment;
    public bool isLineCompleted { get; protected set; } = false;
    private Timer pointAddingTimer;

    private List<TemporarySegment> createdSegments;
    private class TemporarySegment
    {

        public float Time = 5f;
        private float timer = 0f;
        public System.Action OnTimeFinish;

        public void Restart() { timer = Time; }
        public void Step(float deltaTime)
        {
            if (timer <= 0) return;
            timer -= deltaTime;
            if (timer <= 0) { OnTimeFinish?.Invoke(); }
        }
    }
    #endregion

    #region PUBLIC METHODS
    public void Finish()
    {
        Recycle();
        isLineCompleted = false;
        points.Clear();
        createdSegments.Clear();
    }
    public bool isPointClose(Vector3 point)
    {
        if (isLineCompleted) { return false; }
        if (points.Count == 0) return false;
        if (hasReachedMaxSize()) return false;
        //Debug.Log($"Point {point} is comparing distance to {points[points.Count - 1]}");
        //return Vector2.Distance(points[points.Count - 1], point) < (maxDistance);
        return Vector3.Distance(points[points.Count - 1], point) < (maxDistance);
    }
    public void Create(Vector3 start)
    {
        if (isLineCompleted) { return; }
        Activate();
        points.Add(start);
        DrawPoints(points.ToArray());
        pointAddingTimer.Restart();
    }
    public void SetColliderRightReference(Vector3 right) { surface.SetRigidColliderRight(right); }
    public void Add(Vector3 point)
    {
        if (isLineCompleted) { return; }
        //Debug.Log($"Adding new point {point} to line, but line is {active} and has size {points.Count}/{maxSize}");
        if (!active) return;
        if (hasReachedMaxSize()) return;

        var last = points[points.Count - 1];

        var dist = Vector3.Distance(last, point);
        if (dist < minDistance) return;
        points.Add(point);
        DrawPoints(points.ToArray());
        CreateSegment();
        SetCollider();

        OnNewSegment?.Invoke(surface.gameObject);
        if (hasReachedMaxSize()) { isLineCompleted = true; }
    }
    #endregion

    #region PRIVATE METHODS
    private bool hasReachedMaxSize()
    {
        return points.Count >= maxSize;
    }
    private void SetCollider()
    {
        var lineWidth = rend.widthMultiplier;
        surface.Deactivate();
        surface.SetupBounciness();
        surface.Setup(points.ToArray(), lineWidth, transform.position);
    }
    private void DrawPoints(Vector3[] points)
    {
        rend.positionCount = points.Length;
        rend.SetPositions(points);
    }
    private void CreateSegment()
    {
        var newSegment = new TemporarySegment()
        {
            Time = 6f,
            OnTimeFinish = () =>
            {
                CheckPointDestruction();
            }
        };
        newSegment.Restart();
        createdSegments.Add(newSegment);
    }

    private void CheckPointDestruction() {
        if (points.Count > 0)
        {
            points.RemoveAt(0);
        }
        if (createdSegments.Count > 0) { 
            createdSegments.RemoveAt(0);
        }
        if (points.Count <= 1)
        {
            Finish();
        }
    }
    #endregion
}
