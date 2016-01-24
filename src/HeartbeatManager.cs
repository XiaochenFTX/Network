using System;
using System.Collections.Generic;
using System.Text;

namespace Network
{
    class HeartbeatManager
    {
        private readonly int heartbeatInSeconds; //实际的心跳间隔，客户端发起间隔

        private const int HeartbeatInterval = 5; //心跳间隔

        private readonly byte[] clientHandshakeBuffer = new byte[4 + 4]; // 握手时候的客户端id buffer cache，[sign*5,clientId*4,heartbeat*4]
        private int heartbeatInternalTimeout = 600; //内部网络心跳超时,服务器校验
        private int heartbeatTimeout = 30; //网络心跳超时,服务器校验

        public void SetHeartbeatTimeout(int timeout, int internalTimeout)
        {
            heartbeatTimeout = timeout <= HeartbeatInterval ? HeartbeatInterval * 3 : timeout;
            heartbeatInternalTimeout = internalTimeout <= HeartbeatInterval ? HeartbeatInterval * 3 : internalTimeout;
        }

        //private DateTime lastCheckTime = UXTime.GetNowDateTime();

        private void CheckHeartbeat()
        {
            //if (UXTime.GetNowDateTime().Subtract(lastCheckTime).TotalSeconds < 1) //心跳1秒算一次
            //{
            //    return;
            //}

            //lastCheckTime = UXTime.GetNowDateTime();

            //// 如果有心跳超时的客户端，在这里判断处理
            //foreach (var client in clientConnectorsDict)
            //{
            //    float timeout = client.Value.UserId > 0 ? heartbeatTimeout : heartbeatInternalTimeout;//内部socket超时时间和对外不同
            //    if (timeout > 0 && nowTime > client.Value.LastHeartbeatTime.AddSeconds(timeout))
            //    {
            //        Close(client.Value, NetworkCloseMode.HeartbeatTimeout);//心跳超时，断开
            //    }
            //}
        }
    }
}
