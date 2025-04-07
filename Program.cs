using System;
using BoltzzmanMachine.Models;
using BoltzzmanMachine.Data;

class Program
{
    static void Main()
    {
        int visible_units = 4;
        int hidden_units = 3;

        BoltzzmanMachine.Models.BoltzzmanMachine rbm = new BoltzzmanMachine.Models.BoltzzmanMachine(visible_units, hidden_units);

        int[][] training_data = TrainingData.GetTrainingSamples();

        rbm.Train(training_data, epochs: 6000, learning_rate: 0.1);

        int[] testInput = { 1, 0, 1, 0, 1, 0 };
        int[] hidden = rbm.SampleHidden(testInput);
        int[] reconstructed = rbm.SampleVisible(hidden);

        Console.WriteLine("Original Input:    " + string.Join(",", testInput));
        Console.WriteLine("Reconstructed:     " + string.Join(",", reconstructed));
    }
}
