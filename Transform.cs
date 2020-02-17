//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To subscribe to the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

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
/// 
/// @author Christian Scheiblich (cscheiblich@gmail.com)
/// @date 23.05.2008 17:42:23
/// 
/// </summary>
namespace jwave
{
	using Complex = jwave.datatypes.natives.Complex;
	using JWaveException = jwave.exceptions.JWaveException;
	using JWaveFailure = jwave.exceptions.JWaveFailure;
	using BasicTransform = jwave.transforms.BasicTransform;
	using Wavelet = jwave.transforms.wavelets.Wavelet;

	/// <summary>
	/// Base class for transforms like DiscreteFourierTransform, FastBasicTransform,
	/// and WaveletPacketTransform.
	/// 
	/// @date 19.05.2009 09:43:40
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// </summary>
	public sealed class Transform
	{

	  /// <summary>
	  /// Transform object of type base class
	  /// </summary>
	  protected internal readonly BasicTransform _basicTransform;

	  /// <summary>
	  /// Constructor; needs some object like DiscreteFourierTransform,
	  /// FastBasicTransform, WaveletPacketTransfom, ...
	  /// 
	  /// @date 19.05.2009 09:50:24
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="transform">
	  ///          Transform object </param>
	  public Transform(BasicTransform transform)
	  {
		_basicTransform = transform;
		try
		{
		  if (_basicTransform == null)
		  {
			throw new JWaveFailure("given object is null!");
		  }
		  if (!(_basicTransform is BasicTransform))
		  {
			throw new JWaveFailure("given object is not of type BasicTransform");
		  }
		}
		catch (JWaveException e)
		{
		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		} // try
	  } // Transform

	  /// <summary>
	  /// Performs the forward transform of the specified BasicWave object.
	  /// 
	  /// @date 10.02.2010 09:41:01
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="arrTime">
	  ///          coefficients of time domain </param>
	  /// <returns> coefficients of frequency or Hilbert domain </returns>
	  public double[] forward(double[] arrTime)
	  {
		double[] arrHilb = null;
		try
		{
		  arrHilb = _basicTransform.forward(arrTime);
		}
		catch (JWaveException e)
		{
		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		} // try
		return arrHilb;
	  } // forward

	  /// <summary>
	  /// Performs the reverse transform of the specified BasicWave object.
	  /// 
	  /// @date 10.02.2010 09:42:18
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="arrHilb">
	  ///          coefficients of frequency or Hilbert domain </param>
	  /// <returns> coefficients of time domain </returns>
	  public double[] reverse(double[] arrHilb)
	  {
		double[] arrTime = null;
		try
		{
		  arrTime = _basicTransform.reverse(arrHilb);
		}
		catch (JWaveException e)
		{
		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		} // try
		return arrTime;
	  } // reverse

	  /// <summary>
	  /// Performs a forward transform to a certain level of Hilbert space.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 11:53:05 </summary>
	  /// <param name="arrTime">
	  ///          array of length 2^p | p E N .. 2, 4, 8, 16, 32, 64, ... </param>
	  /// <param name="level">
	  ///          a certain level that matches the array </param>
	  /// <returns> Hilbert space of certain level </returns>
	  public double[] forward(double[] arrTime, int level)
	  {
		double[] arrHilb = null;
		try
		{
		  arrHilb = _basicTransform.forward(arrTime, level);
		}
		catch (JWaveException e)
		{
		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		} // try
		return arrHilb;
	  } // forward

	  /// <summary>
	  /// Performs a reverse transform for a Hilbert space of certain level; level
	  /// has to match the supported coefficients in the array!
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 22.03.2015 11:54:59 </summary>
	  /// <param name="arrHilb">
	  ///          Hilbert space by an array of length 2^p | p E N .. 2, 4, 8, 16,
	  ///          32, 64, ... </param>
	  /// <param name="level">
	  ///          the certain level the supported hilbert space </param>
	  /// <returns> time domain for a certain level of Hilbert space </returns>
	  public double[] reverse(double[] arrHilb, int level)
	  {
		double[] arrTime = null;
		try
		{
		  arrTime = _basicTransform.reverse(arrHilb, level);
		}
		catch (JWaveException e)
		{
		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		} // try
		return arrTime;
	  } // reverse

	  /// <summary>
	  /// Performs the forward transform from time domain to frequency or Hilbert
	  /// domain for a given array depending on the used transform algorithm by
	  /// inheritance.
	  /// 
	  /// @date 23.11.2010 19:19:24
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="arrTime">
	  ///          coefficients of 1-D time domain </param>
	  /// <returns> coefficients of 1-D frequency or Hilbert domain </returns>
	  public Complex[] forward(Complex[] arrTime)
	  {
		Complex[] arrFreq = null;
		try
		{
		  arrFreq = ((BasicTransform)_basicTransform).forward(arrTime);
		}
		catch (JWaveException e)
		{
		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		} // try
		return arrFreq;
	  } // forward

	  /// <summary>
	  /// Performs the reverse transform from frequency or Hilbert domain to time
	  /// domain for a given array depending on the used transform algorithm by
	  /// inheritance.
	  /// 
	  /// @date 23.11.2010 19:19:33
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="arrFreq">
	  ///          coefficients of 1-D frequency or Hilbert domain </param>
	  /// <returns> coefficients of 1-D time domain </returns>
	  public Complex[] reverse(Complex[] arrFreq)
	  {
		Complex[] arrTime = null;
		try
		{
		  arrTime = ((BasicTransform)_basicTransform).reverse(arrFreq);
		}
		catch (JWaveException e)
		{
		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		} // try
		return arrTime;
	  } // reverse

	  /// <summary>
	  /// Performs the 2-D forward transform of the specified BasicWave object.
	  /// 
	  /// @date 10.02.2010 10:58:54
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="matrixTime">
	  ///          coefficients of 2-D time domain; internal M(i),N(j) </param>
	  /// <returns> coefficients of 2-D frequency or Hilbert domain </returns>
	  public double[][] forward(double[][] matrixTime)
	  {
		double[][] matrixHilb = null;
		try
		{
		  matrixHilb = _basicTransform.forward(matrixTime);
		}
		catch (JWaveException e)
		{
		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		} // try
		return matrixHilb;
	  } // forward

	  /// <summary>
	  /// Performs the 2-D reverse transform of the specified BasicWave object.
	  /// 
	  /// @date 10.02.2010 10:59:32
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="matrixFreq">
	  ///          coefficients of 2-D frequency or Hilbert domain; internal
	  ///          M(i),N(j) </param>
	  /// <returns> coefficients of 2-D time domain </returns>
	  public double[][] reverse(double[][] matrixHilb)
	  {

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To subscribe to the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
