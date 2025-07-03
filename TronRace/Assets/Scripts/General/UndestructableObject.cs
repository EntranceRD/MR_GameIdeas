using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndestructableObject : MonoBehaviour
{
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
