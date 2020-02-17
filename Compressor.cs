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
namespace jwave.compressions
{
	using JWaveException = jwave.exceptions.JWaveException;
	using JWaveFailure = jwave.exceptions.JWaveFailure;

	/// <summary>
	/// Some how this class is doing the same as the technical counterpart is doing -
	/// compressing data that is transformed to Hilbert space by different methods.
	/// 
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// @date 20.02.2014 23:41:35
	/// </summary>
	public abstract class Compressor
	{

	  /// <summary>
	  /// A threshold that is used in several compression methods.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 20.02.2014 23:44:26
	  /// </summary>
	  protected internal double _threshold = 1.0;

	  /// <summary>
	  /// The calculated magnitude by algorithm of derived class.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.05.2015 18:36:17
	  /// </summary>
	  protected internal double _magnitude = 0.0;

	  /// <summary>
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 20.02.2014 23:41:35
	  /// </summary>
	  public Compressor()
	  {

		_magnitude = 0.0;
		_threshold = 1.0;

	  } // Compressor

	  public Compressor(double threshold)
	  {

		_magnitude = 0.0;

		try
		{

		  if (threshold <= 0.0)
		  {
			throw new JWaveFailure("Compressor - given threshold should be larger than zero!");
		  }
		}
		catch (JWaveException e)
		{

		  e.showMessage();
		  Console.WriteLine("Compressor - setting threshold to default value: " + 1.0);
		  threshold = 1.0;

		}

		_threshold = threshold;

	  } // Compressor

	  /// <summary>
	  /// Compresses by comparing the magnitude value by the set compression factor,
	  /// the threshold, and the sets all lower values to zero.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.05.2015 18:06:52 </summary>
	  /// <param name="arr"> </param>
	  /// <param name="magnitude">
	  /// @return </param>
	  protected internal virtual double[] compress(double[] arr, double magnitude)
	  {

		int arrLength = arr.Length;

		double[] arrComp = new double[arrLength];

		for (int i = 0; i < arrLength; i++)
		{
		  if (Math.Abs(arr[i]) >= magnitude * _threshold)
		  {
			arrComp[i] = arr[i];
		  }
		  else
		  {
			arrComp[i] = 0.0; // compression be setting to zero
		  }
		}

		return arrComp;

	  } // compress

	  /// <summary>
	  /// Compresses by comparing the magnitude value by the set compression factor,
	  /// the threshold, and the sets all lower values to zero.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.05.2015 18:17:31 </summary>
	  /// <param name="mat"> </param>
	  /// <param name="magnitude">
	  /// @return </param>
	  protected internal virtual double[][] compress(double[][] mat, double magnitude)
	  {

		int matHilbNoOfRows = mat.Length;
		int matHilbNoOfCols = mat[0].Length;

//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: double[][] matComp = new double[matHilbNoOfRows][matHilbNoOfCols];
		double[][] matComp = RectangularArrays.RectangularDoubleArray(matHilbNoOfRows, matHilbNoOfCols);

		for (int i = 0; i < matHilbNoOfRows; i++)
		{
		  for (int j = 0; j < matHilbNoOfCols; j++)
		  {
			if (Math.Abs(mat[i][j]) >= magnitude * _threshold)
			{
			  matComp[i][j] = mat[i][j];
			}
			else
			{
			  matComp[i][j] = 0.0;
			}
		  }
		}

		return matComp;

	  } // compress

	  /// <summary>
	  /// Compresses by comparing the magnitude value by the set compression factor,
	  /// the threshold, and the sets all lower values to zero.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.05.2015 18:18:44 </summary>
	  /// <param name="spc"> </param>
	  /// <param name="magnitude">
	  /// @return </param>
	  protected internal virtual double[][][] compress(double[][][] spc, double magnitude)
	  {

		int matHilbNoOfRows = spc.Length;
		int matHilbNoOfCols = spc[0].Length;
		int matHilbNoOfLvls = spc[0][0].Length;

//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: double[][][] spcComp = new double[matHilbNoOfRows][matHilbNoOfCols][matHilbNoOfLvls];
		double[][][] spcComp = RectangularArrays.RectangularDoubleArray(matHilbNoOfRows, matHilbNoOfCols, matHilbNoOfLvls);

		for (int i = 0; i < matHilbNoOfRows; i++)
		{
		  for (int j = 0; j < matHilbNoOfCols; j++)
		  {
			for (int k = 0; k < matHilbNoOfLvls; k++)
			{
			  if (Math.Abs(spc[i][j][k]) >= magnitude * _threshold)
			  {
				spcComp[i][j][k] = spc[i][j][k];
			  }
			  else
			  {
				spcComp[i][j][k] = 0.0;
			  }
			}
		  }
		}

		return spcComp;

	  } // compress

	  /// <summary>
	  /// Calculate the compression rate for a given array; means the percentage of
	  /// the number of zeros kept by the array.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 06.01.2016 23:47:06 </summary>
	  /// <param name="arr">
	  ///          the input of array keeping values and zeros </param>
	  /// <returns> the compression rate as a percentage: [0 .. 100] % </returns>
	  public virtual double calcCompressionRate(double[] arr)
	  {

		double compressionRate = 0.0;
		int noOfZeros = 0;
		int length = arr.Length;
		for (int i = 0; i < length; i++)
		{
		  if (arr[i] == 0.0)
		  {
			noOfZeros++;
		  }
		} // i
		if (noOfZeros != 0)
		{
		  compressionRate = (double)noOfZeros / (double)length * 100.0;
		}
		else
		{
		  compressionRate = (double)noOfZeros;
		}
		return compressionRate;

	  } // calcCompressionRate

	  /// <summary>
	  /// Getter for _threshold member.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.05.2015 18:38:33 </summary>
	  /// <returns> value of threshold member </returns>
	  public virtual double Threshold
	  {
		  get
		  {
    
			return _threshold;
    
		  }
	  } // getThreshold

	  /// <summary>
	  /// Getter for calculated _magnitude member.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.05.2015 18:39:32 </summary>
	  /// <returns> value of magnitude member </returns>
	  public virtual double Magnitude
	  {
		  get
		  {
    
			return _magnitude;
    
		  }
	  } // getMagnitude

	  /// <summary>
	  /// Interface for arrays for driving the different compression methods.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 20.02.2014 23:48:06 </summary>
	  /// <param name="arrHilb">
	  /// @return </param>
	  public abstract double[] compress(double[] arrHilb);

	  /// <summary>
	  /// Interface for matrices for driving the different compression methods.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 20.02.2014 23:54:11 </summary>
	  /// <param name="matHilb">
	  /// @return </param>
	  public abstract double[][] compress(double[][] matHilb);

	  /// <summary>
	  /// Interface for spaces for driving the different compression methods.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 20.02.2014 23:54:52 </summary>
	  /// <param name="spcHilb">
	  /// @return </param>
	  public abstract double[][][] compress(double[][][] spcHilb);

	} // Compressor

}