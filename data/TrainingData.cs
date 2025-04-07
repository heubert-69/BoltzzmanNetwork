using System;

namespace BoltzzmanMachine.Data
{
    public static class TrainingData
    {
        public static int[][] GetTrainingSamples()
        {
            return new int[][]
            {
                new int[] { 0, 0, 0, 0 }, //0
                new int[] { 0, 0, 0, 1 }, //1
                new int[] { 0, 0, 1, 0 }, //2
                new int[] { 0, 0, 1, 1 }, //3
                new int[] { 0, 1, 0, 0 }, //4
                new int[] { 0, 1, 0, 1 }, //5
                new int[] { 0, 1, 1, 0 }, //6
                new int[] { 0, 1, 1, 1 }, //7
                new int[] { 1, 0, 0, 0 }, //8
                new int[] { 1, 0, 0, 1 }, //9
                new int[] { 1, 0, 1, 0 }, //10
                new int[] { 1, 0, 1, 1 }, //11
                new int[] { 1, 1, 0, 0 }, //12
                new int[] { 1, 1, 0, 1 }, //13
                new int[] { 1, 1, 1, 0 }, //14
                new int[] { 1, 1, 1, 1 }  //15
            };
        }
    }
}
