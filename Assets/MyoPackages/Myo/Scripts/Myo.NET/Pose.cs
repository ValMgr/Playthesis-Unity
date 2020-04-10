using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_ANDROID || WIN64 || WIN32


namespace Thalmic.Myo
{
    public enum Pose
    {
        Rest = libmyo.PoseType.Rest,
        Fist = libmyo.PoseType.Fist,
        WaveIn = libmyo.PoseType.WaveIn,
        WaveOut = libmyo.PoseType.WaveOut,
        FingersSpread = libmyo.PoseType.FingersSpread,
        DoubleTap = libmyo.PoseType.DoubleTap,
        Unknown = libmyo.PoseType.Unknown
    }
}


#endif