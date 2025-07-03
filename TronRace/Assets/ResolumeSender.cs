using OscJack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolumeSender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) {
            Resolume_NextColumn();
            Debug.Log("Next");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Resolume_PreviousColumn();
            Debug.Log("Prev");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Resolume_SpecificColumn();
            Debug.Log("specific");
        }
    }

    [Range(0, 100)] public int column=10;

    private void Resolume_SpecificColumn() {
        using (var client = new OscClient("127.0.0.1", 7000))
        {
            client.Send("/composition/connectspecificcolumn", column-1);
        }
    }
    private void Resolume_NextColumn() {
        Resolume_SendMessage("/composition/connectnextcolumn");
    }
    private void Resolume_PreviousColumn() {
        Resolume_SendMessage("/composition/connectprevcolumn");
    }

    private void Resolume_SendMessage(string message) {
        using (var client = new OscClient("127.0.0.1", 7000))
        { 
            client.Send(message);
        }
    }
}
