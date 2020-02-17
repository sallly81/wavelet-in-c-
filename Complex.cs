//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To subscribe to the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System;
using System.Text;

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
namespace jwave.datatypes.natives
{
	/// <summary>
	/// A class to represent a complex number. A Complex object is immutable once
	/// created; the add, subtract and multiply routines return newly-created Complex
	/// objects containing each requested result.
	/// 
	/// @date 19.11.2010 13:20:48
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// </summary>
	public class Complex
	{

	  /// <summary>
	  /// The real number.
	  /// </summary>
	  private double _r;

	  /// <summary>
	  /// The imaginary number.
	  /// </summary>
	  private double _j;

	  /// <summary>
	  /// Standard constructor.
	  /// 
	  /// @date 19.11.2010 13:38:56
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// </summary>
	  public Complex()
	  {
		_r = 0.0;
		_j = 0.0;
	  } // Complex

	  /// <summary>
	  /// Copy constructor.
	  /// 
	  /// @date 19.11.2010 13:22:54
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="c">
	  ///          complex number </param>
	  public Complex(Complex c)
	  {
		_r = c._r;
		_j = c._j;
	  } // Complex

	  /// <summary>
	  /// Constructor taking real and imaginary number.
	  /// 
	  /// @date 19.11.2010 13:21:48
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="r">
	  ///          real number </param>
	  /// <param name="j">
	  ///          imaginary number </param>
	  public Complex(double r, double j)
	  {
		_r = r;
		_j = j;
	  } // Complex

	  /// <summary>
	  /// Display the current Complex as a String, for usage in println( ) or writing
	  /// the complex into a file.
	  /// 
	  /// @date 19.11.2010 13:23:13
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// </summary>
	  public override string ToString()
	  {
		StringBuilder sb = (new StringBuilder()).Append(_r);
		if (_j >= 0)
		{
		  sb.Append('+');
		}
		else
		{
		  sb.Append('-');
		}
		return sb.Append(_j).Append('j').ToString();
	  } // toString

	  /// <summary>
	  /// Return the real number.
	  /// 
	  /// @date 19.11.2010 13:23:34
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <returns> real number of this complex number </returns>
	  public virtual double Real
	  {
		  get
		  {
			return _r;
		  }
		  set
		  {
			_r = value;
		  } // setReal
	  } // getReal( )

	  /// <summary>
	  /// Return the imaginary number.
	  /// 
	  /// @date 19.11.2010 13:23:51
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <returns> imaginary number of this complex number </returns>
	  public virtual double Imag
	  {
		  get
		  {
			return _j;
		  }
		  set
		  {
			_j = value;
		  } // setImag
	  } // getImag



	  /// <summary>
	  /// Add to real number.
	  /// 
	  /// @date 23.11.2010 18:49:57
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="r">
	  ///          the real number </param>
	  public virtual void addReal(double r)
	  {
		_r += r;
	  } // addReal

	  /// <summary>
	  /// Add to imaginary number.
	  /// 
	  /// @date 23.11.2010 18:50:23
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="j">
	  ///          the imaginary number </param>
	  public virtual void addImag(double j)
	  {
		_j += j;
	  } // addImag

	  /// <summary>
	  /// multiply scalar to real number.
	  /// 
	  /// @date 23.11.2010 18:53:27
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="s">
	  ///          scalar </param>
	  public virtual void mulReal(double s)
	  {
		_r *= s;
	  } // mulReal

	  /// <summary>
	  /// multiply scalar to imaginary number.
	  /// 
	  /// @date 23.11.2010 18:54:48
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="s">
	  ///          scalar </param>
	  public virtual void mulImag(double s)
	  {
		_j *= s;
	  } // mulImag

	  /// <summary>
	  /// Calculate the magnitude of the complex number.
	  /// 
	  /// @date 19.11.2010 13:24:28
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <returns> magnitude of this complex number </returns>
	  public virtual double Mag
	  {
		  get
		  {
			return Math.Sqrt(_r * _r + _j * _j);
		  }
	  } // getMag( )

	  /// <summary>
	  /// Calculates the angle phi of a complex number.
	  /// 
	  /// @date 19.11.2010 13:24:48
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <returns> angle of this complex number </returns>
	  public virtual double Phi
	  {
		  get
		  {
			if (_r == 0.0 && _j == 0)
			{
			  return 0.0;
			}
			double phi = Math.toDegrees(Math.Atan(Math.Abs(_j / _r)));
			if (_r >= 0.0 && _j >= 0.0) // 1. quadrant
			{
			  return phi;
			}
			if (_r <= 0.0 && _j >= 0.0) // 2. quadrant
			{
			  return 180.0 - phi;
			}
			if (_r <= 0.0 && _j <= 0.0) // 3. quadrant
			{
			  return phi + 180.0;
			}
			if (_r >= 0.0 && _j <= 0.0) // 4. quadrant
			{
			  return 360.0 - phi;
			}
			return Math.toDegrees(Math.Atan(Math.Abs(_j / _r)));
		  }
	  } // getPhi( )

	  /// <summary>
	  /// Returns the stored values as new double array: [ real, imag ].
	  /// 
	  /// @date 19.11.2010 13:25:38
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <returns> returns stored values as array [ real, imag ] </returns>
	  public virtual double[] toArr()
	  {
		double[] arr = new double[] {_r, _j};
		return arr;
	  } // toArr

	  /// <summary>
	  /// Returns the conjugate complex number of this complex number.
	  /// 
	  /// @date 19.11.2010 19:36:52
	  /// @author Thomas Leduc </summary>
	  /// <returns> new object of Complex keeping the result </returns>
	  public virtual Complex conjugate()
	  {
		return new Complex(_r, -_j);
	  } // conjugate

	  /// <summary>
	  /// Add another complex number to this one and return.
	  /// 
	  /// @date 19.11.2010 13:25:55
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="c">
	  ///          complex number </param>
	  /// <returns> new object of Complex keeping the result </returns>
	  public virtual Complex add(Complex c)
	  {
		return new Complex(_r + c._r, _j + c._j);
	  } // add

	  /// <summary>
	  /// Subtract another complex number from this one.
	  /// 
	  /// @date 19.11.2010 13:27:05
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="c">
	  ///          complex number </param>
	  /// <returns> new object of Complex keeping the result </returns>
	  public virtual Complex sub(Complex c)
	  {
		return new Complex(_r - c._r, _j - c._j);
	  } // sub

	  /// <summary>
	  /// Multiply this complex number times another one.
	  /// 
	  /// @date 19.11.2010 13:27:36
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="c">
	  ///          complex number </param>
	  /// <returns> new object of Complex keeping the result </returns>
	  public virtual Complex mul(Complex c)
	  {
		return new Complex(_r * c._r - _j * c._j, _r * c._j + _j * c._r);
	  } // mul

	  /// <summary>
	  /// Multiply this complex number times a scalar.
	  /// 
	  /// @date 19.11.2010 13:28:03
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="s">
	  ///          scalar </param>
	  /// <returns> new object of Complex keeping the result </returns>
	  public virtual Complex mul(double s)
	  {
		return new Complex(_r * s, _j * s);
	  } // mul

	  /// <summary>
	  /// Divide this complex number by another one.
	  /// 
	  /// @date 19.11.2010 19:45:02
	  /// @author Thomas Leduc </summary>
	  /// <param name="c">
	  ///          complex number </param>
	  /// <returns> new object of Complex keeping the result </returns>
	  public virtual Complex div(Complex c)
	  {
		return mul(c.conjugate()).div(c._r * c._r + c._j * c._j);
	  } // div

	  /// <summary>
	  /// Divide this complex number by a scalar.
	  /// 
	  /// @date 19.11.2010 13:29:49
	  /// @author Thomas Leduc </summary>
	  /// <param name="s">
	  ///          scalar </param>
	  /// <returns> new object of Complex keeping the result </returns>
	  public virtual Complex div(double s)
	  {
		return mul(1.0 / s);
	  } // div

	  /// <summary>
	  /// Generates a hash code for this object.
	  /// 
	  /// @date 19.11.2010 19:42:39
	  /// @author Thomas Leduc </summary>
	  /// <seealso cref= java.lang.Object#hashCode() </seealso>

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To subscribe to the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
