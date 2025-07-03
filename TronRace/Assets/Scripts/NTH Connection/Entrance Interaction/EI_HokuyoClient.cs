using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
using System.IO;
using Entrance.Hokuyo;
using Entrance.Interaction;

namespace Entrance.Network
{
    //Entrance Interaction
    public class EI_HokuyoClient : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            resp = new HokuyoResponse() { data = new HokuyoDataResponse[0] };

            client = new TcpClient();
            client.ReceiveTimeout = 300;
            client.SendTimeout = 300;
            ConnectToServer();
            Thread sendThread = new Thread(new ThreadStart(SendData));
            sendThread.Start();
        }
        private void Update()
        {
            if (resp.data.Length > 0)
            {
                foreach (var data in resp.data)
                {
                    //Debug.Log(data.Direction);
                    EI_InputController.Instance.CheckInteractions(data.Direction, data.InteractionPoints);
                    //NTH_InputController.Instance.CheckInteractions(data.Direction, data.InteractionPoints);
                }
            }

            RenderHokuyoResponse();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            on = false;
            if (client != null)
            {
                client.Close();
            }
        }
        #endregion

        #region VARIABLES
        public bool RenderRays = false;
        public Vector3 sensorPosition;
        public Vector3 displacement;
        public LineRenderer[] renderers;
        private TcpClient client;
        private NetworkStream stream;
        private SurfaceIDs[] surfaces;
        private bool on = true;
        private HokuyoResponse resp;
        [Range(0,7)]
        public int sensorRequestIndex=0;
        public string[] hokuyoIPrequests;
        #endregion

        #region PRIVATE METHODS
        private void ConnectToServer()
        {
            try
            {
                var config = GetClientConfig();
                if (config == null) return;

                surfaces = config.surfaces;

                // Connect to the server
                client.Connect(config.IP, config.Port);
                stream = client.GetStream();
            }
            catch (Exception e)
            {
                Debug.LogError("Error: " + e.Message);
            }
        }
        private void SendData()
        {
            //Debug.Log(client.ReceiveTimeout);
            while (on)
            {
                if (!client.Connected)
                {
                    client?.Close();
                    client = new TcpClient();
                    client.ReceiveTimeout = 300;
                    client.SendTimeout = 300;
                    ConnectToServer();
                }


                var stream = client.GetStream();
                string msg = "";
                try
                {
                    #region send request
                    //var request = new HokuyoRequest(surfaces);
                    var request = new HokuyoRequest(new SurfaceIDs[] { SurfaceIDs.Hokuyo_Sensor }) { AdditionalInfo = hokuyoIPrequests[sensorRequestIndex] };
                    if (!RenderRays) {
                        request.surfaces = surfaces;
                        request.AdditionalInfo = string.Empty;
                    }

                    string requestMessage = JsonUtility.ToJson(request);
                    //Debug.Log(requestMessage);
                    byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);
                    stream.Write(requestData, 0, requestData.Length);
                    stream.Flush();
                    #endregion

                    #region receive response
                    //byte[] buffer = new byte[7168];//7kb
                    byte[] buffer = new byte[200000];//200kb
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string responseMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    msg = responseMessage;
                    //Debug.Log(msg);
                    var response = JsonUtility.FromJson<HokuyoResponse>(responseMessage);
                    resp = response;

                    #endregion
                    Thread.Sleep(25);
                }
                catch (System.Exception ex)
                {
                    Debug.Log(ex.Message);
                    Debug.Log(msg);

                }
            }
        }
        private NTHConfig GetClientConfig()
        {
            try
            {
                var path = Application.streamingAssetsPath + "/Entrance Network/HokuyoConfig.json";
                var json = File.ReadAllText(path);
                return JsonUtility.FromJson<NTHConfig>(json);
            }
            catch (System.Exception) { return null; }
        }
        private void RenderHokuyoResponse() {
            if (!RenderRays) return;
            if (renderers.Length <= 0) return;
            var j = 0;
            foreach (var group in resp.data)
            {
                RenderHokuyoRays(renderers[j], group);
                ++j;
            }
        }
        private void RenderHokuyoRays(LineRenderer renderer, HokuyoDataResponse surfaceInteractionData) {
            sensorPosition = surfaceInteractionData.Direction;

            renderer.positionCount = surfaceInteractionData.InteractionPoints.Length * 2;
            for (int i = 0; i < surfaceInteractionData.InteractionPoints.Length; i++)
            {
                var index = i * 2;

                renderer.SetPosition(index, sensorPosition + displacement);

                renderer.SetPosition(index + 1, surfaceInteractionData.InteractionPoints[i] + displacement);
            }
        }
        #endregion
    }
}