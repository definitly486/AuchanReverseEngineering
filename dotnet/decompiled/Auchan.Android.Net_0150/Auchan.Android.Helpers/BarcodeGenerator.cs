using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using AndroidX.Core.Content;
using Com.Google.Zxing;
using Com.Google.Zxing.Pdf417.Encoder;
using Com.Google.Zxing.Qrcode.Decoder;

namespace Auchan.Android.Helpers;

public static class BarcodeGenerator
{
	private static readonly BarcodeEncoder _encoder = new BarcodeEncoder();

	public static Bitmap CreateQrCode(string content, int size)
	{
		return _encoder.EncodeBitmap(content, BarcodeFormat.QrCode, size, size, new Dictionary<EncodeHintType, object>
		{
			{
				EncodeHintType.ErrorCorrection,
				ErrorCorrectionLevel.H
			},
			{
				EncodeHintType.MinSize,
				size
			},
			{
				EncodeHintType.Margin,
				0
			}
		});
	}

	public static Bitmap CreateQrCodeWithLogo(string content, int size, int imageId, float imageRatio = 0.35f)
	{
		Bitmap bitmap = CreateQrCode(content, size);
		using Canvas canvas = new Canvas(bitmap);
		using Drawable drawable = ContextCompat.GetDrawable(Application.Context, imageId);
		float num = (float)size / 2f;
		float num2 = (float)size * imageRatio / 2f;
		int left = (int)(num - num2);
		int top = (int)(num - num2);
		int right = (int)(num + num2);
		int bottom = (int)(num + num2);
		drawable.Bounds = new Rect(left, top, right, bottom);
		drawable.Draw(canvas);
		return bitmap;
	}

	public static Bitmap CreatePDF417Code(string content, int width, int height)
	{
		return _encoder.EncodeBitmap(content, BarcodeFormat.Pdf417, width, height, new Dictionary<EncodeHintType, object>
		{
			{
				EncodeHintType.Pdf417Compact,
				false
			},
			{
				EncodeHintType.Pdf417Compaction,
				Compaction.Byte
			},
			{
				EncodeHintType.Margin,
				0
			}
		});
	}

	public static Bitmap CreateEAN13Code(string content, int width, int height)
	{
		return _encoder.EncodeBitmap(content, BarcodeFormat.Ean13, width, height);
	}
}
