using System.Drawing;

namespace Armstrong.WinServer.Models
{
    public enum MessageType { SendedSuccessfull = 0, SendedError, ReceivedSuccessfull, ReceivedError }
    public class DialogMessage
    {
        public MessageType MessageType { get; set; }
        public string MessageText { get; set; }
        public string PackageText { get; set; }
        public double Value { get; set; } = 0;
        public Color TextColor { get; set; }
    }
}
