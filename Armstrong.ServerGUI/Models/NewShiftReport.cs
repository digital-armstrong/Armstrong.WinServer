using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armstrong.WinServer.Models
{
    public class NewShiftReport
    {
        public int ChannelAddress { get; set; }
        public double MinValueLimit { get; set; }
        public double MaxValueLimit { get; set; }
        public double[] ImpulsesBuffer { get; set; }
        public double AvgImpulsesValue { get; set; }
        public bool IsDetectorHaveField { get; set; } = false;
        public bool IsFielRewind { get; set; }
        public bool IsSignallValid { get; set; }
        public bool IsLineDown { get; set; }

        public NewShiftReport(int channelAddress, double minLimit, double maxLimit, int impulsesBufferSize, bool isDetectorHaveField) 
        {
            this.ChannelAddress = channelAddress;
            this.MinValueLimit = minLimit;
            this.MaxValueLimit = maxLimit;
            this.IsDetectorHaveField = isDetectorHaveField;
            this.ImpulsesBuffer = impulsesBufferSize <= 0 ? throw new ArgumentOutOfRangeException(nameof(impulsesBufferSize)) : new double[impulsesBufferSize];
        }

        public double GetAvgImpulsesValue()
        {
            AvgImpulsesValue = ImpulsesBuffer.Sum(x => x) / ImpulsesBuffer.Length;

            return AvgImpulsesValue;
        }

        public bool GetIsSignalValid()
        {
            var _avg = GetAvgImpulsesValue();
            IsSignallValid = _avg > MinValueLimit && _avg < MaxValueLimit;

            return IsSignallValid;
        }
    }
}
