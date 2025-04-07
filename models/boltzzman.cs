using System;
using BoltzzmanMachine.Utils;

namespace BoltzzmanMachine.Models
{
	public class BoltzzmanMachine
	{
		private int hidden_size, visible_size;

		private double[,] weights;

		private Random random = new Random();

		public BoltzzmanMachine(int visible, int hidden){
			visible_size = visible;
			hidden_size = hidden;
			weights = new double[visible_size, hidden_size];

			InitializeWeights();
		}

		public void InitializeWeights(){
			for(int i=0; i < visible_size; i++){
				for(int x=0; x < hidden_size; x++){
					weights[i, x] = (random.NextDouble() - 0.5) * 0.1;
				}
			}
		}

		public int[] SampleHidden(int[] visible) {
    			int[] hidden = new int[hidden_size];
    			for (int i = 0; i < hidden_size; i++) {
        			double activation = 0.0;

        			// Loop over visible units
        			for (int x = 0; x < visible_size; x++) {
            				activation += visible[x] * weights[x, i]; 
        			}

        			// Sigmoid activation function to compute the probability
        			double probability = MathUtils.Sigmoid(activation);
        			hidden[i] = random.NextDouble() < probability ? 1 : 0;
    			}
    			return hidden;
		}

		public int[] SampleVisible(int[] hidden) {
    			int[] visible = new int[visible_size];
    			for (int i = 0; i < visible_size; i++) {
        			double activation = 0.0;


        			for (int x = 0; x < hidden_size; x++) {
            				activation += hidden[x] * weights[i, x];  // Corrected: weights[i, x]
        			}

     
        			double probability = MathUtils.Sigmoid(activation);
        			visible[i] = random.NextDouble() < probability ? 1 : 0;
    			}
    			return visible;
		}


		public void Train(int[][] data, int epochs, double learning_rate){
			for(int epoch=0; epoch < epochs; epoch++){
				foreach(var sample in data){
					int[] HiddenSample = SampleHidden(sample);
					int[] VisibleSample = SampleVisible(HiddenSample);
					int[] ReconstructedHidden = SampleHidden(VisibleSample);



					for(int i=0; i < visible_size; i++){
						for(int x=0; x < hidden_size; x++){
							double positive_gradient = sample[i] * HiddenSample[x];
							double negative_gradient = VisibleSample[i] * ReconstructedHidden[x];

							weights[i, x] += learning_rate * (positive_gradient - negative_gradient);
						}
					}
				}

				Console.WriteLine($"Epoch{epoch + 1}/{epochs} completed");
			}
		}
	}
}
