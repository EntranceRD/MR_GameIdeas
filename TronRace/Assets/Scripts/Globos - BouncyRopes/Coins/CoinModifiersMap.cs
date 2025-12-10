using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinModifiersMap : MonoBehaviour
{
    #region UNITY METHODS
    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region VARIABLES
    public static CoinModifiersMap instance;
    public ObjectGroup<ObjectGroup<Transform>> instanceColumns;
    #endregion

    #region PUBLIC METHODS
    public Transform GetNewPoint(int column)
    {
        int index = Mathf.Clamp(column,0,instanceColumns.objects.Count);
        return GetRanFromColumnPoint(index);
    }

    public Transform GetRanFromColumnPoint(int column)
    {
        var row = instanceColumns.objects[column];
        int random = Random.Range(0, row.objects.Count);
        return row.objects[random];
    }
    #endregion

    #region PRIVATE METHODS
    #endregion
}
