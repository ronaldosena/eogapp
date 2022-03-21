using System;

namespace Toolbox.Acquisition
{
    public static class Commands
    {
        // Commands
        public static byte toggleLed = 0x41;
        public static byte startAcq = 0x42;
        public static byte stopAcq = 0x43;

        // Identifiers
        public static byte idBegin = 0x0A;
        public static byte idEnd = 0xA0;
    }
}
