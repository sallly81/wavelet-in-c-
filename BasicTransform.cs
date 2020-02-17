//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To subscribe to the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

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
	using Complex = jwave.datatypes.natives.Complex;
	using JWaveError = jwave.exceptions.JWaveError;
	using JWaveException = jwave.exceptions.JWaveException;
	using JWaveFailure = jwave.exceptions.JWaveFailure;
	using MathToolKit = jwave.tools.MathToolKit;
	using Wavelet = jwave.transforms.wavelets.Wavelet;

	/// <summary>
	/// Basic Wave for transformations like Fast Fourier Transform (FFT), Fast
	/// Wavelet Transform (FWT), Fast Wavelet Packet Transform (WPT), or Discrete
	/// Wavelet Transform (DWT). Naming of this class due to en.wikipedia.org; to
	/// write Fourier series in terms of the 'basic waves' of function: e^(2*pi*i*w).
	/// 
	/// @date 08.02.2010 11:11:59
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// </summary>
	public abstract class BasicTransform
	{

	  /// <summary>
	  /// String identifier of the current Transform object.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.03.2015 14:25:56
	  /// </summary>
	  protected internal string _name;

	  /// <summary>
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 19.02.2014 18:38:21
	  /// </summary>
	  public BasicTransform()
	  {

		_name = null;

	  } // BasicTransform

	  /// <summary>
	  /// Returns String identifier of current type of BasicTransform Object.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.03.2015 18:13:34 </summary>
	  /// <returns> identifier as String </returns>
	  public virtual string Name
	  {
		  get
		  {
			return _name;
		  }
	  } // getName

	  /// <summary>
	  /// Returns the stored Wavelet object or null pointer.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.03.2015 18:26:44 </summary>
	  /// <returns> object of type Wavelet of null pointer </returns>
	  /// <exception cref="JWaveFailure">
	  ///           if Wavelet object is not available </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public jwave.transforms.wavelets.Wavelet getWavelet() throws jwave.exceptions.JWaveFailure
	  public virtual Wavelet Wavelet
	  {
		  get
		  {
			throw new JWaveFailure("BasicTransform#getWavelet - not available");
		  }
	  } // getWavelet

	  /// <summary>
	  /// Performs the forward transform from time domain to frequency or Hilbert
	  /// domain for a given array depending on the used transform algorithm by
	  /// inheritance.
	  /// 
	  /// @date 10.02.2010 08:23:24
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="arrTime">
	  ///          coefficients of 1-D time domain </param>
	  /// <returns> coefficients of 1-D frequency or Hilbert space </returns>
	  /// <exception cref="JWaveException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public abstract double[] forward(double[] arrTime) throws jwave.exceptions.JWaveException;
	  public abstract double[] forward(double[] arrTime);

	  /// <summary>
	  /// Performs the reverse transform from frequency or Hilbert domain to time
	  /// domain for a given array depending on the used transform algorithm by
	  /// inheritance.
	  /// 
	  /// @date 10.02.2010 08:23:24
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="arrFreq">
	  ///          coefficients of 1-D frequency or Hilbert domain </param>
	  /// <returns> coefficients of time series of 1-D frequency or Hilbert space </returns>
	  /// <exception cref="JWaveException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public abstract double[] reverse(double[] arrFreq) throws jwave.exceptions.JWaveException;
	  public abstract double[] reverse(double[] arrFreq);

	  /// <summary>
	  /// Performs the forward transform from time domain to Hilbert domain of a
	  /// given level depending on the used transform algorithm by inheritance.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 11:33:11 </summary>
	  /// <param name="arrTime"> </param>
	  /// <param name="level">
	  ///          the level of Hilbert space; energy & detail coefficients </param>
	  /// <returns> array keeping Hilbert space of requested level </returns>
	  /// <exception cref="JWaveException">
	  ///           if given array is not of type 2^p | p E N or given level does not
	  ///           match the possibilities of given array. </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[] forward(double[] arrTime, int level) throws jwave.exceptions.JWaveException
	  public virtual double[] forward(double[] arrTime, int level)
	  {

		throw new JWaveError("BasicTransform#forward - " + "method is not implemented for this transform type!");

	  } // forward

	  /// <summary>
	  /// Performs the reverse transform from Hilbert domain of a given level to time
	  /// domain depending on the used transform algorithm by inheritance.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 11:34:27 </summary>
	  /// <param name="arrFreq"> </param>
	  /// <param name="level">
	  ///          the level of Hilbert space; energy & detail coefficients </param>
	  /// <returns> array keeping Hilbert space of requested level </returns>
	  /// <exception cref="JWaveException">
	  ///           if given array is not of type 2^p | p E N or given level does not
	  ///           match the possibilities of given array. </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[] reverse(double[] arrFreq, int level) throws jwave.exceptions.JWaveException
	  public virtual double[] reverse(double[] arrFreq, int level)
	  {

		throw new JWaveError("BasicTransform#reverse - " + "method is not implemented for this transform type!");

	  } // reverse

	  /// <summary>
	  /// Generates from a 2-D decomposition a 1-D time series.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 17.08.2014 10:07:19 </summary>
	  /// <param name="matDeComp">
	  ///          2-D Hilbert spaces: [ 0 .. p ][ 0 .. N ] where p is the exponent
	  ///          of N=2^p </param>
	  /// <returns> a 1-D time domain signal </returns>
	  /// <exception cref="JWaveException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] decompose(double[] arrTime) throws jwave.exceptions.JWaveException
	  public virtual double[][] decompose(double[] arrTime)
	  {

		throw new JWaveError("BasicTransform#decompose - " + "method is not implemented for this transform type!");

	  } // decompose

	  /// <summary>
	  /// Generates from a 1-D signal a 2-D output, where the second dimension are
	  /// the levels of the wavelet transform. The first level should keep the
	  /// original coefficients. All following levels should keep each step of the
	  /// decomposition of the Fast Wavelet Transform. However, each level of the
	  /// this decomposition matrix is having the full set, full energy and full
	  /// details, that are needed to do a full reconstruction. So one can select a
	  /// level filter it and then do reconstruction only from this single line! BY
	  /// THIS METHOD, THE _HIGHEST_ LEVEL IS _ALWAYS_ TAKEN FOR RECONSTRUCTION!
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 17.08.2014 10:07:19 </summary>
	  /// <param name="matDeComp">
	  ///          2-D Hilbert spaces: [ 0 .. p ][ 0 .. M ] where p is the exponent
	  ///          of M=2^p | pEN </param>
	  /// <returns> a 1-D time domain signal </returns>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[] recompose(double[][] matDeComp) throws jwave.exceptions.JWaveException
	  public virtual double[] recompose(double[][] matDeComp)
	  {

		// Each level of the matrix is having the full set (full energy + details)
		// of decomposition. Therefore, each level can be used to do a full reconstruction,
		int level = matDeComp.Length - 1; // selected highest level in general.
		double[] arrTime = null;
		try
		{
		  arrTime = recompose(matDeComp, level);
		}
		catch (JWaveFailure e)
		{
		  e.showMessage();
		  e.printStackTrace();
		} // try

		return arrTime;

	  } // recompose

	  /// <summary>
	  /// Generates from a 1-D signal a 2-D output, where the second dimension are
	  /// the levels of the wavelet transform. The first level should keep the
	  /// original coefficients. All following levels should keep each step of the
	  /// decomposition of the Fast Wavelet Transform. However, each level of the
	  /// this decomposition matrix is having the full set, full energy and full
	  /// details, that are needed to do a full reconstruction. So one can select a
	  /// level filter it and then do reconstruction only from this single line!
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 15:12:19 </summary>
	  /// <param name="matDeComp">
	  ///          2-D Hilbert spaces: [ 0 .. p ][ 0 .. M ] where p is the exponent
	  ///          of M=2^p | pEN </param>
	  /// <param name="level">
	  ///          the level that should be used for reconstruction </param>
	  /// <returns> the reconstructed time series of a selected level </returns>
	  /// <exception cref="JWaveException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[] recompose(double[][] matDeComp, int level) throws jwave.exceptions.JWaveException
	  public virtual double[] recompose(double[][] matDeComp, int level)
	  {

		double[] arrTime = null;
		try
		{
		  arrTime = recompose(matDeComp, level);
		}
		catch (JWaveFailure e)
		{
		  e.showMessage();
		  e.printStackTrace();
		} // try

		return arrTime;

	  } // recompose

	  /// <summary>
	  /// Performs the forward transform from time domain to frequency or Hilbert
	  /// domain for a given array depending on the used transform algorithm by
	  /// inheritance.
	  /// 
	  /// @date 16.02.2014 14:42:57
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  ///         (cscheiblich@gmail.com) </summary>
	  /// <param name="arrTime">
	  ///          coefficients of 1-D time domain </param>
	  /// <returns> coefficients of 1-D frequency or Hilbert domain </returns>
	  /// <exception cref="JWaveException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public jwave.datatypes.natives.Complex[] forward(jwave.datatypes.natives.Complex[] arrTime) throws jwave.exceptions.JWaveException
	  public virtual Complex[] forward(Complex[] arrTime)
	  {

		double[] arrTimeBulk = new double[2 * arrTime.Length];

		for (int i = 0; i < arrTime.Length; i++)
		{

		  // TODO rehack complex number splitting this to: { r1, r2, r3, .., c1, c2, c3, .. }
		  int k = i * 2;
		  arrTimeBulk[k] = arrTime[i].Real;
		  arrTimeBulk[k + 1] = arrTime[i].Imag;

		} // i blown to k = 2 * i

		double[] arrHilbBulk = forward(arrTimeBulk);

		Complex[] arrHilb = new Complex[arrTime.Length];

		for (int i = 0; i < arrTime.Length; i++)
		{

		  int k = i * 2;
		  arrHilb[i] = new Complex(arrHilbBulk[k], arrHilbBulk[k + 1]);

		} // k = 2 * i shrink to i

		return arrHilb;

	  } // forward

	  /// <summary>
	  /// Performs the reverse transform from frequency or Hilbert domain to time
	  /// domain for a given array depending on the used transform algorithm by
	  /// inheritance.
	  /// 
	  /// @date 16.02.2014 14:42:57
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  ///         (cscheiblich@gmail.com) </summary>
	  /// <param name="arrFreq">
	  ///          coefficients of 1-D frequency or Hilbert domain </param>
	  /// <returns> coefficients of 1-D time domain </returns>
	  /// <exception cref="JWaveException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public jwave.datatypes.natives.Complex[] reverse(jwave.datatypes.natives.Complex[] arrHilb) throws jwave.exceptions.JWaveException
	  public virtual Complex[] reverse(Complex[] arrHilb)
	  {

		double[] arrHilbBulk = new double[2 * arrHilb.Length];

		for (int i = 0; i < arrHilb.Length; i++)
		{

		  int k = i * 2;
		  arrHilbBulk[k] = arrHilb[i].Real;
		  arrHilbBulk[k + 1] = arrHilb[i].Imag;

		} // i blown to k = 2 * i

		double[] arrTimeBulk = reverse(arrHilbBulk);

		Complex[] arrTime = new Complex[arrHilb.Length];

		for (int i = 0; i < arrTime.Length; i++)
		{

		  int k = i * 2;
		  arrTime[i] = new Complex(arrTimeBulk[k], arrTimeBulk[k + 1]);

		} // k = 2 * i shrink to i

		return arrTime;

	  } // reverse

	  /// <summary>
	  /// Performs the 2-D forward transform from time domain to frequency or Hilbert
	  /// domain for a given matrix depending on the used transform algorithm by
	  /// inheritance.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 12:47:01 </summary>
	  /// <param name="matTime">
	  /// @return </param>
	  /// <exception cref="JWaveException">
	  ///           if matrix id not of matching dimension like 2^p | pEN </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] forward(double[][] matTime) throws jwave.exceptions.JWaveException
	  public virtual double[][] forward(double[][] matTime)
	  {

		int maxM = MathToolKit.getExponent(matTime.Length);
		int maxN = MathToolKit.getExponent(matTime[0].Length);
		return forward(matTime, maxM, maxN);

	  } // forward

	  /// <summary>
	  /// Performs the 2-D forward transform from time domain to frequency or Hilbert
	  /// domain of a certain level for a given matrix depending on the used
	  /// transform algorithm by inheritance. The supported level has to match the
	  /// possible dimensions of the given matrix.
	  /// 
	  /// @date 10.02.2010 11:00:29
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="matTime">
	  ///          coefficients of 2-D time domain </param>
	  /// <param name="lvlM">
	  ///          level to stop in dimension M of the matrix </param>
	  /// <param name="lvlN">
	  ///          level to stop in dimension N of the matrix </param>
	  /// <returns> coefficients of 2-D frequency or Hilbert domain </returns>
	  /// <exception cref="JWaveException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] forward(double[][] matTime, int lvlM, int lvlN) throws jwave.exceptions.JWaveException
	  public virtual double[][] forward(double[][] matTime, int lvlM, int lvlN)
	  {

		int noOfRows = matTime.Length;
		int noOfCols = matTime[0].Length;

//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: double[][] matHilb = new double[noOfRows][noOfCols];
		double[][] matHilb = RectangularArrays.RectangularDoubleArray(noOfRows, noOfCols);

		for (int i = 0; i < noOfRows; i++)
		{

		  double[] arrTime = new double[noOfCols];

		  for (int j = 0; j < noOfCols; j++)
		  {
			arrTime[j] = matTime[i][j];
		  }

		  double[] arrHilb = forward(arrTime, lvlN);

		  for (int j = 0; j < noOfCols; j++)
		  {
			matHilb[i][j] = arrHilb[j];
		  }


//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To subscribe to the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
