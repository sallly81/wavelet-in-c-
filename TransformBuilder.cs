using System;

/// <summary>
/// Create Transform objects ...
/// 
/// @author Christian Scheiblich (cscheiblich@gmail.com)
/// @date 14.03.2015 14:25:21 
/// 
/// TransformBuilder.java
/// </summary>
namespace jwave
{
	using JWaveException = jwave.exceptions.JWaveException;
	using JWaveFailure = jwave.exceptions.JWaveFailure;
	using BasicTransform = jwave.transforms.BasicTransform;
	using DiscreteFourierTransform = jwave.transforms.DiscreteFourierTransform;
	using FastWaveletTransform = jwave.transforms.FastWaveletTransform;
	using WaveletPacketTransform = jwave.transforms.WaveletPacketTransform;
	using Wavelet = jwave.transforms.wavelets.Wavelet;
	using WaveletBuilder = jwave.transforms.wavelets.WaveletBuilder;

	/// <summary>
	/// Class for creating and identifying Transform object.
	/// 
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// @date 14.03.2015 14:25:21
	/// </summary>
	public class TransformBuilder
	{

	  /// <summary>
	  /// Create a Transform object by a given string and a given Wavelet object.
	  /// Look into each Transform for matching string identifier. By the way the
	  /// method requires Java 7, due to the switch statement on a string. *rofl*
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.03.2015 14:35:12 </summary>
	  /// <param name="transformName">
	  ///          identifier as stored in Transform object </param>
	  /// <param name="wavelet"> </param>
	  /// <returns> a matching object of type Transform </returns>
	  public static Transform create(string transformName, Wavelet wavelet)
	  {

		BasicTransform basicTransform = null;

		try
		{

		  switch (transformName)
		  {

			case "Discrete Fourier Transform":
			  basicTransform = new DiscreteFourierTransform();
			  break;

			case "Fast Wavelet Transform":
			  basicTransform = new FastWaveletTransform(wavelet);
			  break;

			case "Wavelet Packet Transform":
			  basicTransform = new WaveletPacketTransform(wavelet);
			  break;

			default:

			  throw new JWaveFailure("TransformBuilder::create - unknown type of transform for given string!");

		  } // switch

		}
		catch (JWaveException e)
		{

		  e.showMessage();
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);

		} // try

		return new Transform(basicTransform);

	  } // create

	  /// <summary>
	  /// Create a Transform object by a given string and a given string for a
	  /// Wavelet object. Look into each Transform and Wavelet for matching string
	  /// identifier.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.03.2015 14:37:30 </summary>
	  /// <param name="transformName">
	  ///          identifier as stored in Transform object </param>
	  /// <param name="waveletName"> </param>
	  /// <returns> identifier as stored in Wavelet object </returns>
	  public static Transform create(string transformName, string waveletName)
	  {

		return create(transformName, WaveletBuilder.create(waveletName));

	  } // create

	  /// <summary>
	  /// Returns the identifier string of a given Transform object.
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.03.2015 14:34:20 </summary>
	  /// <param name="transform">
	  ///          string identifier of the given Transform object </param>
	  /// <returns> a string as the identifier of the given Transform object </returns>
	  public static string identify(Transform transform)
	  {

		BasicTransform basicTransform = transform.BasicTransform;
		return basicTransform.Name;

	  } // identify

	} // class

}