//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To subscribe to the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System;
using System.Collections.Generic;

/// <summary>
/// Create Wavelet objects ...
/// 
/// @author Christian Scheiblich (cscheiblich@gmail.com)
/// @date 14.03.2015 13:50:30 
/// 
/// WaveletBuilder.java
/// </summary>
namespace jwave.transforms.wavelets
{

	using JWaveException = jwave.exceptions.JWaveException;
	using JWaveFailure = jwave.exceptions.JWaveFailure;
	using BiOrthogonal11 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal11;
	using BiOrthogonal13 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal13;
	using BiOrthogonal15 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal15;
	using BiOrthogonal22 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal22;
	using BiOrthogonal24 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal24;
	using BiOrthogonal26 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal26;
	using BiOrthogonal28 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal28;
	using BiOrthogonal31 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal31;
	using BiOrthogonal33 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal33;
	using BiOrthogonal35 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal35;
	using BiOrthogonal37 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal37;
	using BiOrthogonal39 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal39;
	using BiOrthogonal44 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal44;
	using BiOrthogonal55 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal55;
	using BiOrthogonal68 = jwave.transforms.wavelets.biorthogonal.BiOrthogonal68;
	using Coiflet1 = jwave.transforms.wavelets.coiflet.Coiflet1;
	using Coiflet2 = jwave.transforms.wavelets.coiflet.Coiflet2;
	using Coiflet3 = jwave.transforms.wavelets.coiflet.Coiflet3;
	using Coiflet4 = jwave.transforms.wavelets.coiflet.Coiflet4;
	using Coiflet5 = jwave.transforms.wavelets.coiflet.Coiflet5;
	using Daubechies10 = jwave.transforms.wavelets.daubechies.Daubechies10;
	using Daubechies11 = jwave.transforms.wavelets.daubechies.Daubechies11;
	using Daubechies12 = jwave.transforms.wavelets.daubechies.Daubechies12;
	using Daubechies13 = jwave.transforms.wavelets.daubechies.Daubechies13;
	using Daubechies14 = jwave.transforms.wavelets.daubechies.Daubechies14;
	using Daubechies15 = jwave.transforms.wavelets.daubechies.Daubechies15;
	using Daubechies16 = jwave.transforms.wavelets.daubechies.Daubechies16;
	using Daubechies17 = jwave.transforms.wavelets.daubechies.Daubechies17;
	using Daubechies18 = jwave.transforms.wavelets.daubechies.Daubechies18;
	using Daubechies19 = jwave.transforms.wavelets.daubechies.Daubechies19;
	using Daubechies2 = jwave.transforms.wavelets.daubechies.Daubechies2;
	using Daubechies20 = jwave.transforms.wavelets.daubechies.Daubechies20;
	using Daubechies3 = jwave.transforms.wavelets.daubechies.Daubechies3;
	using Daubechies4 = jwave.transforms.wavelets.daubechies.Daubechies4;
	using Daubechies5 = jwave.transforms.wavelets.daubechies.Daubechies5;
	using Daubechies6 = jwave.transforms.wavelets.daubechies.Daubechies6;
	using Daubechies7 = jwave.transforms.wavelets.daubechies.Daubechies7;
	using Daubechies8 = jwave.transforms.wavelets.daubechies.Daubechies8;
	using Daubechies9 = jwave.transforms.wavelets.daubechies.Daubechies9;
	using Haar1 = jwave.transforms.wavelets.haar.Haar1;
	using Haar1Orthogonal = jwave.transforms.wavelets.haar.Haar1Orthogonal;
	using Legendre1 = jwave.transforms.wavelets.legendre.Legendre1;
	using Legendre2 = jwave.transforms.wavelets.legendre.Legendre2;
	using Legendre3 = jwave.transforms.wavelets.legendre.Legendre3;
	using DiscreteMayer = jwave.transforms.wavelets.other.DiscreteMayer;
	using Symlet10 = jwave.transforms.wavelets.symlets.Symlet10;
	using Symlet11 = jwave.transforms.wavelets.symlets.Symlet11;
	using Symlet12 = jwave.transforms.wavelets.symlets.Symlet12;
	using Symlet13 = jwave.transforms.wavelets.symlets.Symlet13;
	using Symlet14 = jwave.transforms.wavelets.symlets.Symlet14;
	using Symlet15 = jwave.transforms.wavelets.symlets.Symlet15;
	using Symlet16 = jwave.transforms.wavelets.symlets.Symlet16;
	using Symlet17 = jwave.transforms.wavelets.symlets.Symlet17;
	using Symlet18 = jwave.transforms.wavelets.symlets.Symlet18;
	using Symlet19 = jwave.transforms.wavelets.symlets.Symlet19;
	using Symlet2 = jwave.transforms.wavelets.symlets.Symlet2;
	using Symlet20 = jwave.transforms.wavelets.symlets.Symlet20;
	using Symlet3 = jwave.transforms.wavelets.symlets.Symlet3;
	using Symlet4 = jwave.transforms.wavelets.symlets.Symlet4;
	using Symlet5 = jwave.transforms.wavelets.symlets.Symlet5;
	using Symlet6 = jwave.transforms.wavelets.symlets.Symlet6;
	using Symlet7 = jwave.transforms.wavelets.symlets.Symlet7;
	using Symlet8 = jwave.transforms.wavelets.symlets.Symlet8;
	using Symlet9 = jwave.transforms.wavelets.symlets.Symlet9;

	/// <summary>
	/// Class for creating and identifying Wavelet object.
	/// 
	/// @author Christian Scheiblich (cscheiblich@gmail.com)
	/// @date 14.03.2015 13:50:30
	/// </summary>
	public class WaveletBuilder
	{

	  /// <summary>
	  /// Create a Wavelet object by string. Look into each Wavelet for matching
	  /// string identifier. By the way the method requires Java 7, due to the
	  /// switch statement with at String. *rofl*
	  /// 
	  /// @author Christian Scheiblich (cscheiblich@gmail.com)
	  /// @date 14.03.2015 14:19:09 </summary>
	  /// <param name="waveletName">
	  ///          identifier as stored in Wavelet object </param>
	  /// <returns> a matching object of type Wavelet </returns>
	  public static Wavelet create(string waveletName)
	  {

		Wavelet wavelet = null;

		try
		{

		  switch (waveletName)
		  {

			case "Haar":
			  wavelet = new Haar1();
			  break;

			case "Haar orthogonal":
			  wavelet = new Haar1Orthogonal();
			  break;

			case "Daubechies 2":
			  wavelet = new Daubechies2();
			  break;

			case "Daubechies 3":
			  wavelet = new Daubechies3();
			  break;

			case "Daubechies 4":
			  wavelet = new Daubechies4();
			  break;

			case "Daubechies 5":
			  wavelet = new Daubechies5();
			  break;

			case "Daubechies 6":
			  wavelet = new Daubechies6();
			  break;

			case "Daubechies 7":
			  wavelet = new Daubechies7();
			  break;

			case "Daubechies 8":
			  wavelet = new Daubechies8();

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To subscribe to the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
