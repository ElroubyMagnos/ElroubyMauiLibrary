using System;
using System.IO;
using System.Reflection;
using Microsoft.Maui.Controls;

namespace ElroubyMauiLibrary;

public static class Extensions
{
	public static Stream ImageStreamFromRes(this string ProjName, string PicName, Type App)
	{
		Assembly assembly = App.GetTypeInfo().Assembly;
		return assembly.GetManifestResourceStream(ProjName + "." + PicName);
	}

	public static DateTime ConvertFromString(this string Date)
	{
		try
		{
			return DateTime.Parse(Date);
		}
		catch
		{
			return DateTime.Now;
		}
	}

	public static ImageSource ConvertFrom(byte[] value)
	{
		if (value == null)
		{
			return null;
		}
		return ImageSource.FromStream((Func<Stream>)(() => new MemoryStream(value)));
	}

	public static string ToStringOrEmpty<T>(this T Data)
	{
		try
		{
			return Data.ToString();
		}
		catch
		{
			return "";
		}
	}

	public static int IntOrDefault(this string IOD)
	{
		int.TryParse(IOD, out var result);
		return result;
	}

	public static short ShortOrDefault(this string IOD)
	{
		short.TryParse(IOD, out var result);
		return result;
	}

	public static byte ByteOrDefault(this string IOD)
	{
		byte.TryParse(IOD, out var result);
		return result;
	}

	public static decimal DecimalOrDefault(this string IOD)
	{
		decimal.TryParse(IOD, out var result);
		return result;
	}

	public static double DoubleOrDefault(this string IOD)
	{
		double.TryParse(IOD, out var result);
		return result;
	}

	public static bool IsDate(this string Time)
	{
		DateTime.TryParse(Time, out var result);
		return result.Day != 0;
	}

	public static ImageSource StreamToImageSource(Stream StreamCode)
	{
		return ImageSource.FromStream((Func<Stream>)(() => StreamCode));
	}

	public static byte[] StreamToByteArray(Stream StreamCode)
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamCode.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}
}
