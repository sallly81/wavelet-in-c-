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
namespace jwave.exceptions
{
	/// <summary>
	/// General exception class of the JWave package.
	/// 
	/// @date 16.10.2008 07:30:20
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// </summary>
	public class JWaveException : Exception
	{

	  /// <summary>
	  /// @date 27.05.2009 06:58:27
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// </summary>
	  private const long serialVersionUID = -4165486739091019056L;

	  /// <summary>
	  /// Member string for the stored exception message.
	  /// </summary>
	  protected internal string _message; // exception message

	  /// <summary>
	  /// Constructor for storing a handed exception message.
	  /// 
	  /// @date 27.05.2009 06:51:57
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="message">
	  ///          this message should tell exactly what went wrong </param>
	  public JWaveException(string message)
	  {
		_message = "JWave "; // overwrite
		_message += "- "; // separator
		_message += "Exception"; // Exception type
		_message += "- "; // separator
		_message += message; // add message
		_message += "\n"; // break line
	  } // TransformException

	  /// <summary>
	  /// Copy constructor; use this for a quick fix of sub types.
	  /// 
	  /// @date 29.07.2009 07:03:45
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <param name="e">
	  ///          an object of this class </param>
	  public JWaveException(Exception e)
	  {
		_message = e.Message;
	  } // TransformException

	  /// <summary>
	  /// Returns the stored exception message as a string.
	  /// 
	  /// @date 27.05.2009 06:52:46
	  /// @author Christian Scheiblich (cscheiblich@gmail.com) </summary>
	  /// <returns> exception message that should tell exactly what went wrong </returns>
	  public override string Message
	  {
		  get
		  {
			return _message;
		  }
	  } // getMessage

	  /// <summary>
	  /// Displays the stored exception message at console out.
	  /// 
	  /// @date 27.05.2009 06:53:23
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// </summary>
	  public virtual void showMessage()
	  {
		Console.WriteLine(_message);
	  } // showMessage

	  /// <summary>
	  /// Nuke the run and print stack trace.
	  /// 
	  /// @date 02.07.2009 05:07:42
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// </summary>
	  public virtual void nuke()
	  {
		Console.WriteLine("");
		Console.WriteLine("                  ____             ");
		Console.WriteLine("          __,-~~/~    `---.        ");
		Console.WriteLine("        _/_,---(      ,    )       ");
		Console.WriteLine("    __ /        NUKED     ) \\ __  ");
		Console.WriteLine("   ====------------------===;;;==  ");
		Console.WriteLine("      /  ~\"~\"~\"~\"~\"~~\"~)     ");
		Console.WriteLine("      (_ (      (     >    \\)     ");
		Console.WriteLine("       \\_( _ <         >_>\'      ");
		Console.WriteLine("           ~ `-i' ::>|--\"         ");
		Console.WriteLine("               I;|.|.|             ");
		Console.WriteLine("              <|i::|i|>            ");
		Console.WriteLine("               |[::|.|             ");
		Console.WriteLine("                ||: |              ");
		Console.WriteLine("");
		this.showMessage();
		Console.WriteLine(this.ToString());
		Console.Write(this.StackTrace);
	  } // nuke

	} // class

}