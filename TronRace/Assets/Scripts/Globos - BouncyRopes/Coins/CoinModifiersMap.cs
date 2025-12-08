using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinModifiersMap : MonoBehaviour
{
    public static CoinModifiersMap instance;
    public ObjectGroup<ObjectGroup<Transform>> instanceColumns;

    private void Awake()
    {
        instance = this;
    }

    public Transform GetNewPoint(int column)
    {
        int index = Mathf.Clamp(column,0,instanceColumns.objects.Count);
        return GetRanFromColumnPoint(index);
    }

    public Transform GetRanFromColumnPoint(int column)
    {
        var fila = instanceColumns.objects[column];
        int random = Random.Range(0, fila.objects.Count);
        return fila.objects[random];
    }
}
