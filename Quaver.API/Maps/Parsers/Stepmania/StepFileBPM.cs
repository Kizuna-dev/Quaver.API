using System;
using System.Collections.Generic;

namespace Quaver.API.Maps.Parsers.Stepmania
{
    public class StepFileBPM
    {
        /// <summary>
        /// </summary>
        public double Beat { get; }

        /// <summary>
        /// </summary>
        public double BPM { get; }

        /// <summary>
        /// </summary>
        /// <param name="beat"></param>
        /// <param name="bpm"></param>
        public StepFileBPM(double beat, double bpm)
        {
            Beat = beat;
            BPM = bpm;
        }

        /// <summary>
        ///     Parses the `#BPMS` line in a stepfile, and returns the list of bpms.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static List<StepFileBPM> Parse(string line)
        {
            var bpms = new List<StepFileBPM>();

            var split = line.Split(',');

            foreach (var bpm in split)
            {
                if (string.IsNullOrEmpty(bpm))
                    continue;

                var bpmSplit = bpm.Replace(",", "").Replace(";", "").Split('=');

                if (bpmSplit.Length != 2)
                    continue;

                bpms.Add(new StepFileBPM(double.Parse(bpmSplit[0]), double.Parse(bpmSplit[1])));
            }

            return bpms;
        }
    }
}