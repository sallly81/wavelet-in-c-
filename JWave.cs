using System;

/// <summary>
/// JWave is distributed under the MIT License (MIT); this file is part of.
/// 
/// Copyright (c) 2008-2018 Christian Scheiblich (cscheiblich@gmail.com)
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// </summary>
namespace jwave
{
	using DiscreteFourierTransform = jwave.transforms.DiscreteFourierTransform;
	using Wavelet = jwave.transforms.wavelets.Wavelet;
	using WaveletBuilder = jwave.transforms.wavelets.WaveletBuilder;

	/// <summary>
	/// Main class can be used to do a little console test by entering a transform
	/// type and a wavelet by their names. However, this should only make a quick n
	/// dirty test available by skipping the JUnit framework. JWave is supported as a
	/// library and foreseen to be used like this.
	/// 
	/// @date 23.02.2010 14:26:47
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// </summary>
	public class JWave
	{

	  /// <summary>
	  /// Main method for doing little test runs for different transform types and
	  /// different wavelets without JUnit. Type in the name of the transform and the
	  /// name of the wavelet. The result is an array of length 16 (2^p | p E N) is
	  /// transformed in four hierarchical steps (16/2=8 .. 8/2=4 .. 4/2=2 .. 2/1=1)
	  /// and reduced by 1/sqrt(2.). The result is an array in Hilbert space keeping
	  /// only one coefficient, the energy of value 4. (low pass), in the first
	  /// position of the array. All detail coefficients (high pass of four stages)
	  /// are zero, due to the fact that the input array was constant. This shows an
	  /// application of a loss less compression of 93.75 % (15/16 * 100 %).
	  /// Therefore, the reverse transform allows, due to orthogonality (even
	  /// orthonormality) a located reconstruction of any coefficient that is
	  /// currently supported in Hilbert space. Anyway, this little example already
	  /// reveals the application power of wavelets. that can be used for any kind of
	  /// data!
	  /// 
	  /// @date 23.02.2010 14:26:47
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="args">
	  ///          [transformType] [waveletType] </param>
	  public static void Main(string[] args)
	  {

		if (args.Length < 3 || args.Length > 5)
		{
		  Console.Error.WriteLine("example usage: JWave [transformType] {waveletType}");
		  Console.Error.WriteLine("");
		  Console.Error.WriteLine("Transform names: " + "'Discrete Fourier Transform'" + " " + "'Fast Wavelet Transform'" + " " + "'Wavelet Packet Transform'");
		  Console.Error.WriteLine("Wavelet names: " + "'Haar'," + " " + "'Haar orthogonal'," + " " + "'Daubechies 2'" + " " + ".." + " " + "'Daubechies 20'," + " " + "'Symlet 2'" + " " + ".." + " " + "'Symlet 20'," + " " + "'Coiflet 1'" + " " + ".." + " " + "'Coiflet 5'," + " " + "'Legendre 1'" + " " + ".." + " " + "'Legendre 3'," + " " + " ... 'BiOrthogonal 1/1'" + " have a look for more in the 'transform.wavelets' package!");
		  return;
		} // if args

		string waveletIdentifier = "";
		if (args.Length > 4)
		{
		  waveletIdentifier = args[3] + " " + args[4]; // raw n dirty but working
		}
		else
		{
		  waveletIdentifier = args[3]; // if "Haar" is used
		}
		string transformIdentifier = args[0] + " " + args[1] + " " + args[2]; // raw n dirty but working

		Transform transform = TransformBuilder.create(transformIdentifier, waveletIdentifier);

		Wavelet wavelet = transform.Wavelet;

		double[] arrTime = new double[] {1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0};

		if (transform.BasicTransform is DiscreteFourierTransform)
		{
		  Console.Write(TransformBuilder.identify(transform));
		}
		else
		{
		  Console.Write(TransformBuilder.identify(transform) + " using " + WaveletBuilder.identify(wavelet));
		}
		Console.WriteLine("");
		Console.WriteLine("time domain:");
		for (int p = 0; p < arrTime.Length; p++)
		{
		  Console.Write("{0,7:F4}", arrTime[p]);
		}
		Console.WriteLine("");

		double[] arrFreqOrHilb = transform.forward(arrTime);

		if (transform.BasicTransform is DiscreteFourierTransform)
		{
		  Console.WriteLine("frequency domain:");
		}
		else
		{
		  Console.WriteLine("Hilbert domain:");
		}
		for (int p = 0; p < arrTime.Length; p++)
		{
		  Console.Write("{0,7:F4}", arrFreqOrHilb[p]);
		}
		Console.WriteLine("");

		double[] arrReco = transform.reverse(arrFreqOrHilb);

		Console.WriteLine("reconstruction:");
		for (int p = 0; p < arrTime.Length; p++)
		{
		  Console.Write("{0,7:F4}", arrReco[p]);
		}
		Console.WriteLine("");

	  } // main

	} // class

}