
using Wavelet = jwave.transforms.wavelets.Wavelet;
using JWaveException = jwave.exceptions.JWaveException;
using JWaveFailure = jwave.exceptions.JWaveFailure;
using Accord.Imaging.Filters;
using Accord.Math.Wavelets;
using AForge.Imaging.Filters;
using System;
using Org.BouncyCastle.Utilities;

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
namespace jwave.transforms
{
	/// <summary>
	/// Base class for - stepping - forward and reverse methods, due to one kind of a
	/// Fast Wavelet Packet Transform (WPT) or Wavelet Packet Decomposition (WPD) in
	/// 1-D using a specific Wavelet.
	/// 
	/// @date 23.02.2010 13:44:05
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// </summary>
	public class WaveletPacketTransform : WaveletTransform
	{
	

		/// <summary>
		/// Constructor receiving a Wavelet object and setting identifier of transform.
		/// 
		/// @date 23.02.2010 13:44:05
		/// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
		/// <param name="wavelet">
		///          object of type Wavelet </param>
		public WaveletPacketTransform(Wavelet wavelet) : base(wavelet)
	  {


			const string V = "Wavelet Packet Transform";
			_wavelet = V;
			
		} // WaveletPacketTransform

	  /// <summary>
	  /// Performs a 1-D forward transform from time domain to Hilbert domain using
	  /// one kind of a Wavelet Packet Transform (WPT) algorithm for a given array of
	  /// dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, .., and so on.
	  /// However, the algorithms stops for a supported level that has be in the
	  /// range 0, .., p of the dimension of the input array; 0 is the time series
	  /// itself and p is the maximal number of possible levels.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 12:35:15 </summary>
	  /// <exception cref="JWaveException">
	  ///           if givven array is not of length 2^p | pEN or the given level is
	  ///           out of range for the supported Hilbert space (array). </exception>
	  /// <seealso cref= jwave.transforms.BasicTransform#forward(double[], int) </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public double[] forward(double[] arrTime, int level) throws jwave.exceptions.JWaveException
	  public override double[] forward(double[] arrTime, int level)
	  {

		if (!isBinary(arrTime.Length))
		{
		  throw new JWaveFailure("given array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. " + "please use the Ancient Egyptian Decomposition for any other array length!");
		}

		int noOfLevels = calcExponent(arrTime.Length);
		if (level < 0 || level > noOfLevels)
		{
		  throw new JWaveFailure("WaveletPacketTransform#forward - given level is out of range for given array");
		}

		double[] arrHilb = new double[arrTime.Length];
		for (int i = 0; i < arrTime.Length; i++)
		{
		  arrHilb[i] = arrTime[i];
		}

		int k = arrTime.Length;

		int h = arrTime.Length;

		int transformWavelength = _wavelet.TransformWavelength; // 2, 4, 8, 16, 32, ...

		int l = 0;

		while (h >= transformWavelength && l < level)
		{

		  int g = k / h; // 1 -> 2 -> 4 -> 8 -> ...

		  for (int p = 0; p < g; p++)
		  {

			double[] iBuf = new double[h];

			for (int i = 0; i < h; i++)
			{
			  iBuf[i] = arrHilb[i + (p * h)];
			}

			double[] oBuf = _wavelet.forward(iBuf, h);

			for (int i = 0; i < h; i++)
			{
			  arrHilb[i + (p * h)] = oBuf[i];
			}

		  } // packets

		  h = h >> 1;

		  l++;

		} // levels

		return arrHilb;

	  } // forward

	  /// <summary>
	  /// Performs a 1-D reverse transform from Hilbert domain to time domain using
	  /// one kind of a Wavelet Packet Transform (WPT) algorithm for a given array of
	  /// dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, .., and so on.
	  /// However, the algorithms starts for at a supported level that has be in the
	  /// range 0, .., p of the dimension of the input array; 0 is the time series
	  /// itself and p is the maximal number of possible levels. The coefficients of
	  /// the input array have to match to the supported level.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 12:38:23 </summary>
	  /// <exception cref="JWaveException">
	  ///           (non-Javadoc) </exception>
	  /// <seealso cref= jwave.transforms.BasicTransform#reverse(double[], int) </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public double[] reverse(double[] arrHilb, int level) throws jwave.exceptions.JWaveException
	  public override double[] reverse(double[] arrHilb, int level)
	  {

		if (!isBinary(arrHilb.Length))
		{
		  throw new JWaveFailure("given array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. " + "please use the Ancient Egyptian Decomposition for any other array length!");
		}

		int noOfLevels = calcExponent(arrHilb.Length);
		if (level < 0 || level > noOfLevels)
		{
		  throw new JWaveFailure("WaveletPacketTransform#reverse - given level is out of range for given array");
		}

		int length = arrHilb.Length; // length of first Hilbert space
		double[] arrTime = Arrays.CopyOf( arrHilb,length);

		int transformWavelength = _wavelet.TransformWavelength; // 2, 4, 8, 16, 32, ...

		int k = arrTime.Length;

		int h = transformWavelength;

		int steps = calcExponent(length);
		for (int l = level; l < steps; l++)
		{
		  h = h << 1; // begin reverse transform at certain - matching - level of hilbert space
		}

		while (h <= arrTime.Length && h >= transformWavelength)
		{

		  int g = k / h; // ... -> 8 -> 4 -> 2 -> 1

		  for (int p = 0; p < g; p++)
		  {

			double[] iBuf = new double[h];

			for (int i = 0; i < h; i++)
			{
			  iBuf[i] = arrTime[i + (p * h)];
			}

			double[] oBuf = _wavelet.reverse(iBuf, h);

			for (int i = 0; i < h; i++)
			{
			  arrTime[i + (p * h)] = oBuf[i];
			}

		  } // packets

		  h = h << 1;

		} // levels

		return arrTime;

	  } // reverse

		private bool isBinary(int length)
		{
			throw new NotImplementedException();
		}

		private int calcExponent(int length)
		{
			throw new NotImplementedException();
		}
	} // class

}