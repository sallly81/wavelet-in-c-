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
namespace jwave.datatypes
{
	using JWaveException = jwave.exceptions.JWaveException;
	using JWaveFailureNotAllocated = jwave.exceptions.JWaveFailureNotAllocated;

	/// <summary>
	/// Instead using Java's Object class as super type, a named Super typed is used
	/// for grouping data containers like Line, Block, or Space objects together!
	/// 
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// @date 16.05.2015 19:27:00
	/// </summary>
	public abstract class Super
	{

	  /// <summary>
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 16.05.2015 19:27:01
	  /// </summary>
	  public Super()
	  {
	  } // Super

	  /// <summary>
	  /// Checks whether memory is allocated for this Line object or not. If not a
	  /// "not allocated" failure is thrown.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 18.05.2015 20:36:45 </summary>
	  /// <exception cref="JWaveException">
	  ///           if no memory is allocated </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void checkMemory() throws jwave.exceptions.JWaveException
	  protected internal virtual void checkMemory()
	  {

		if (!Allocated)
		{
		  throw new JWaveFailureNotAllocated("Super#checkMemory - no memory allocated for this object!");
		}

	  } // checkMemory( )

	  /// <summary>
	  /// Returns a copy of the object - if allocated, with all data!
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 18.05.2015 20:56:50 </summary>
	  /// <returns> copy of itself, if allocated with all data stored </returns>
	  public abstract Super copy();

	  /// <summary>
	  /// If memory is allocated then return true else return false.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 18.05.2015 18:03:55 </summary>
	  /// <returns> true if memory is allocated </returns>
	  public abstract bool Allocated {get;}

	  /// <summary>
	  /// Allocates the memory of the object internally, but only if no memory is
	  /// allocated yet. However, there can be different strategies in data storage
	  /// for each object.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 18.05.2015 17:59:24 </summary>
	  /// <exception cref="JWaveException">
	  ///           if memory is already occupied or if memory cannot be allocated </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public abstract void alloc() throws jwave.exceptions.JWaveException;
	  public abstract void alloc();

	  /// <summary>
	  /// Simply drops the internal storage and places a null pointer in Java.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 18.05.2015 18:01:56 </summary>
	  /// <exception cref="JWaveException">
	  ///           if internal memory is already erased </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public abstract void erase() throws jwave.exceptions.JWaveException;
	  public abstract void erase();

	} // Super

}