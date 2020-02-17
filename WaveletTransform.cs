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
namespace jwave.transforms
{
	using Wavelet = jwave.transforms.wavelets.Wavelet;
	using JWaveException = jwave.exceptions.JWaveException;
	using JWaveFailure = jwave.exceptions.JWaveFailure;

	/// <summary>
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// @date 15.02.2014 21:05:33
	/// </summary>
	public abstract class WaveletTransform : BasicTransform
	{

	  /// <summary>
	  /// The used wavelet for transforming
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 15.02.2014 21:05:33
	  /// </summary>
	  protected internal Wavelet _wavelet;

	  /// <summary>
	  /// Constructor checks whether the given object is all right.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 15.02.2014 21:05:33 </summary>
	  /// <param name="wavelet">
	  ///          object of type Wavelet </param>
	  protected internal WaveletTransform(Wavelet wavelet)
	  {
		_wavelet = wavelet;
	  } // check for objects od type Wavelet

	  /*
	   * Returns the stored Wavelet object.
	   * @author Christian Scheiblich (cscheiblich@gmail.com)
	   * @date 14.03.2015 18:27:05 (non-Javadoc)
	   * @see jwave.transforms.BasicTransform#getWavelet()
	   */
	  public override Wavelet Wavelet
	  {
		  get
		  {
			return _wavelet;
		  }
	  } // getWavelet

	  /// <summary>
	  /// Performs a 1-D forward transform from time domain to Hilbert domain using
	  /// one kind of wavelet transform algorithm for a given array of dimension
	  /// (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, .., and so on.
	  /// 
	  /// @date 10.02.2010 08:23:24
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <exception cref="JWaveException">
	  ///           if given array is not of length 2^p | pEN </exception>
	  /// <seealso cref= jwave.transforms.BasicTransform#forward(double[]) </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public double[] forward(double[] arrTime) throws jwave.exceptions.JWaveException
	  public override double[] forward(double[] arrTime)
	  {

		if (!isBinary(arrTime.Length))
		{
		  throw new JWaveFailure("WaveletTransform#forward - " + "given array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. " + "please use the Ancient Egyptian Decomposition for any other array length!");
		}

		int maxLevel = calcExponent(arrTime.Length);
		return forward(arrTime, maxLevel); // forward by maximal steps

	  } // forward

	  /// <summary>
	  /// Performs a 1-D reverse transform from Hilbert domain to time domain using
	  /// one kind of wavelet transform algorithm for a given array of dimension
	  /// (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, .., and so on.
	  /// 
	  /// @date 10.02.2010 08:23:24
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <exception cref="JWaveException">
	  ///           if given array is not of length 2^p | pEN </exception>
	  /// <seealso cref= jwave.transforms.BasicTransform#reverse(double[]) </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public double[] reverse(double[] arrHilb) throws jwave.exceptions.JWaveException
	  public override double[] reverse(double[] arrHilb)
	  {

		if (!isBinary(arrHilb.Length))
		{
		  throw new JWaveFailure("WaveletTransform#reverse - " + "given array length is not 2^p | p E N ... = 1, 2, 4, 8, 16, 32, .. " + "please use the Ancient Egyptian Decomposition for any other array length!");
		}

		int maxLevel = calcExponent(arrHilb.Length);
		return reverse(arrHilb, maxLevel); // reverse by maximal steps

	  } // reverse

	  /// <summary>
	  /// Performs several 1-D forward transforms from time domain to all possible
	  /// Hilbert domains using one kind of wavelet transform algorithm for a given
	  /// array of dimension (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, ..,
	  /// and so on. However, the algorithm stores all levels in a matrix that has in
	  /// first dimension the range of 0, .., p and in second dimension the
	  /// coefficients (energy & details) of a certain level. From any level a full
	  /// reconstruction can be performed. The first dimension is keeping the time
	  /// series, due to being the Hilbert space of level 0. All following dimensions
	  /// are keeping the next higher Hilbert spaces, so the next step in wavelet
	  /// filtering.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 14:28:49 </summary>
	  /// <param name="arrTime">
	  ///          coefficients of time domain </param>
	  /// <returns> matDeComp coefficients of frequency or Hilbert domain in 2-D
	  ///         spaces: [ 0 .. p ][ 0 .. M ] where p is the exponent of M=2^p | pEN </returns>
	  /// <exception cref="JWaveException">
	  ///           if something does not match upon the criteria of input </exception>
	  /// <seealso cref= jwave.transforms.BasicTransform#decompose(double[]) </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public double[][] decompose(double[] arrTime) throws jwave.exceptions.JWaveException
	  public override double[][] decompose(double[] arrTime)
	  {

		int length = arrTime.Length;
		int levels = calcExponent(length);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: double[][] matDeComp = new double[levels + 1][length];
		double[][] matDeComp = RectangularArrays.RectangularDoubleArray(levels + 1, length);
		for (int p = 0; p <= levels; p++)
		{
		  Array.Copy(forward(arrTime, p), 0, matDeComp[p], 0, length);
		}
		return matDeComp;

	  } // decompose

	  /// <summary>
	  /// Performs one 1-D reverse transform from Hilbert domain to time domain using
	  /// one kind of wavelet transform algorithm for a given array of dimension
	  /// (length) 2^p | pEN; N = 2, 4, 8, 16, 32, 64, 128, .., and so on. However,
	  /// the algorithm uses on of level in a matrix that has in first dimension the
	  /// range of 0, .., p and in second dimension the coefficients (energy &
	  /// details) the level. From any level a full a reconstruction can be
	  /// performed; so from the selected by "level". Anyway, the first dimension is
	  /// keeping the time series, due to being the Hilbert space of level 0. All
	  /// following dimensions are keeping the next higher Hilbert spaces, so the
	  /// next step in wavelet filtering. If one want to denoise each level in the
	  /// same way and compare results after reverse transform, this is the best
	  /// input for it.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 14:29:01 </summary>
	  /// <seealso cref= jwave.transforms.BasicTransform#recompose(double[][], int) </seealso>
	  /// <param name="matDeComp">
	  ///          2-D Hilbert spaces: [ 0 .. p ][ 0 .. M ] where p is the exponent
	  ///          of M=2^p | pEN </param>
	  /// <exception cref="JWaveException">
	  ///           if something does not match upon the criteria of input </exception>
	  /// <returns> a 1-D time domain signal </returns>
	  /// <seealso cref= jwave.transforms.BasicTransform#recompose(double[]) </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[] recompose(double[][] matDeComp, int level) throws jwave.exceptions.JWaveException
	  public override double[] recompose(double[][] matDeComp, int level)
	  {

		if (level < 0 || level >= matDeComp.Length)
		{
		  throw new JWaveFailure("WaveletTransform#recompose - " + "given level is out of range");
		}

		return reverse(matDeComp[level], level);

	  } // recompose

	} // WaveletTransform
}