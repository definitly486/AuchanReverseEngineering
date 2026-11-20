using System;
using System.Collections.Generic;
using Android.Graphics;
using Com.Google.Zxing;
using Com.Google.Zxing.Common;

namespace Auchan.Android.Helpers;

public class BarcodeEncoder
{
	private int bgColor = -1;

	private int fgColor = -16777216;

	public void SetBackgroundColor(int bgColor)
	{
		this.bgColor = bgColor;
	}

	public void SetForegroundColor(int fgColor)
	{
		this.fgColor = fgColor;
	}

	public Bitmap CreateBitmap(BitMatrix matrix)
	{
		int width = matrix.Width;
		int height = matrix.Height;
		int[] array = new int[width * height];
		for (int i = 0; i < height; i++)
		{
			int num = i * width;
			for (int j = 0; j < width; j++)
			{
				array[num + j] = (matrix.Get(j, i) ? fgColor : bgColor);
			}
		}
		Bitmap bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
		bitmap.SetPixels(array, 0, width, 0, 0, width, height);
		return bitmap;
	}

	public BitMatrix Encode(string contents, BarcodeFormat format, int width, int height)
	{
		try
		{
			return new MultiFormatWriter().Encode(contents, format, width, height);
		}
		catch (WriterException ex)
		{
			throw ex;
		}
		catch (Exception ex2)
		{
			throw new WriterException(ex2.Message);
		}
	}

	public BitMatrix Encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
	{
		try
		{
			return new MultiFormatWriter().Encode(contents, format, width, height, hints);
		}
		catch (WriterException ex)
		{
			throw ex;
		}
		catch (Exception ex2)
		{
			throw new WriterException(ex2.Message);
		}
	}

	public Bitmap EncodeBitmap(string contents, BarcodeFormat format, int width, int height)
	{
		return CreateBitmap(Encode(contents, format, width, height));
	}

	public Bitmap EncodeBitmap(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
	{
		return CreateBitmap(Encode(contents, format, width, height, hints));
	}
}
