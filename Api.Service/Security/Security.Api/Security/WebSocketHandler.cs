using System.Net.WebSockets;
using System.Text;

namespace Security.Api.Security
{
    public static class WebSocketHandler
    {
        private static readonly Dictionary<string, List<WebSocket>> ActiveConnections = new();

        public static async Task HandleWebSocketCommunication(HttpContext context, WebSocket webSocket)
        {
            var userId = context.Request.Query["userId"];

            if (string.IsNullOrEmpty(userId))
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "User ID is required", CancellationToken.None);
                return;
            }

            lock (ActiveConnections)
            {
                if (!ActiveConnections.ContainsKey(userId))
                    ActiveConnections[userId] = new List<WebSocket>();

                ActiveConnections[userId].Add(webSocket);
            }

            try
            {
                var buffer = new byte[1024 * 4];
                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None);
                        break;
                    }
                }
            }
            finally
            {
                lock (ActiveConnections)
                {
                    ActiveConnections[userId].Remove(webSocket);
                    if (!ActiveConnections[userId].Any())
                    {
                        ActiveConnections.Remove(userId);
                    }
                }
            }
        }
        public static async Task NotifyOtherSessionsAsync(string userId)
        {
            List<WebSocket>? connections;

            lock (ActiveConnections)
            {
                if (!ActiveConnections.TryGetValue(userId, out connections))
                    return;
            }

            foreach (var connection in connections)
            {
                if (connection.State == WebSocketState.Open)
                {
                    var message = Encoding.UTF8.GetBytes("logout");
                    await connection.SendAsync(new ArraySegment<byte>(message), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
