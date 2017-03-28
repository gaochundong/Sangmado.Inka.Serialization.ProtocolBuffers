
namespace Sangmado.Inka.Serialization.ProtocolBuffers
{
    public class BclHelpers
    {
        public static decimal ReadDecimal(ulong low, uint high, uint signScale)
        {
            if (low == 0 && high == 0) return decimal.Zero;

            int lo = (int)(low & 0xFFFFFFFFL),
                mid = (int)((low >> 32) & 0xFFFFFFFFL),
                hi = (int)high;
            bool isNeg = (signScale & 0x0001) == 0x0001;
            byte scale = (byte)((signScale & 0x01FE) >> 1);
            return new decimal(lo, mid, hi, isNeg, scale);
        }

        public static void WriteDecimal(decimal value, out ulong low, out uint high, out uint signScale)
        {
            int[] bits = decimal.GetBits(value);
            ulong a = ((ulong)bits[1]) << 32, b = ((ulong)bits[0]) & 0xFFFFFFFFL;
            low = a | b;
            high = (uint)bits[2];
            signScale = (uint)(((bits[3] >> 15) & 0x01FE) | ((bits[3] >> 31) & 0x0001));
        }
    }
}
