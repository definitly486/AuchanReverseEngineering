package com.scanflow.datacapture.utils;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Matrix;
import android.graphics.Rect;
import android.graphics.YuvImage;
import android.util.Log;
import androidx.camera.core.ImageProxy;
import java.io.ByteArrayOutputStream;
import java.nio.ByteBuffer;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class a {
    public static Bitmap a(ImageProxy image) {
        Intrinsics.checkNotNullParameter(image, "image");
        FrameMetadata metadata = new FrameMetadata.Builder().setWidth(image.getWidth()).setHeight(image.getHeight()).build();
        Intrinsics.checkNotNullExpressionValue(metadata, "build(...)");
        ImageProxy.PlaneProxy[] planes = image.getPlanes();
        Intrinsics.checkNotNullExpressionValue(planes, "getPlanes(...)");
        int width = image.getWidth();
        int height = image.getHeight();
        int i = width * height;
        byte[] bArr = new byte[((i / 4) * 2) + i];
        ByteBuffer buffer = planes[1].getBuffer();
        Intrinsics.checkNotNullExpressionValue(buffer, "getBuffer(...)");
        ByteBuffer buffer2 = planes[2].getBuffer();
        Intrinsics.checkNotNullExpressionValue(buffer2, "getBuffer(...)");
        int iPosition = buffer2.position();
        int iLimit = buffer.limit();
        buffer2.position(iPosition + 1);
        buffer.limit(iLimit - 1);
        int i2 = (i * 2) / 4;
        boolean z = buffer2.remaining() == i2 + (-2) && buffer2.compareTo(buffer) == 0;
        buffer2.position(iPosition);
        buffer.limit(iLimit);
        if (z) {
            planes[0].getBuffer().get(bArr, 0, i);
            ByteBuffer buffer3 = planes[1].getBuffer();
            Intrinsics.checkNotNullExpressionValue(buffer3, "getBuffer(...)");
            ByteBuffer buffer4 = planes[2].getBuffer();
            Intrinsics.checkNotNullExpressionValue(buffer4, "getBuffer(...)");
            buffer4.get(bArr, i, 1);
            buffer3.get(bArr, i + 1, i2 - 1);
        } else {
            a(planes[0], width, height, bArr, 0, 1);
            a(planes[1], width, height, bArr, i + 1, 2);
            a(planes[2], width, height, bArr, i, 2);
        }
        ByteBuffer data = ByteBuffer.wrap(bArr);
        Intrinsics.checkNotNullExpressionValue(data, "wrap(...)");
        Intrinsics.checkNotNullParameter(data, "data");
        Intrinsics.checkNotNullParameter(metadata, "metadata");
        data.rewind();
        int iLimit2 = data.limit();
        byte[] bArr2 = new byte[iLimit2];
        data.get(bArr2, 0, iLimit2);
        try {
            YuvImage yuvImage = new YuvImage(bArr2, 17, metadata.getWidth(), metadata.getHeight(), null);
            ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
            yuvImage.compressToJpeg(new Rect(0, 0, metadata.getWidth(), metadata.getHeight()), 80, byteArrayOutputStream);
            Bitmap bitmap = BitmapFactory.decodeByteArray(byteArrayOutputStream.toByteArray(), 0, byteArrayOutputStream.size());
            byteArrayOutputStream.close();
            Intrinsics.checkNotNull(bitmap);
            int rotation = metadata.getRotation();
            Intrinsics.checkNotNullParameter(bitmap, "bitmap");
            Matrix matrix = new Matrix();
            matrix.postRotate(rotation);
            matrix.postScale(1.0f, 1.0f);
            Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmap, 0, 0, bitmap.getWidth(), bitmap.getHeight(), matrix, true);
            Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
            if (!Intrinsics.areEqual(bitmapCreateBitmap, bitmap)) {
                bitmap.recycle();
            }
            return bitmapCreateBitmap;
        } catch (Exception e) {
            Log.e("VisionProcessorBase", "Error: " + e.getMessage());
            return null;
        }
    }

    public static void a(ImageProxy.PlaneProxy planeProxy, int i, int i2, byte[] bArr, int i3, int i4) {
        ByteBuffer buffer = planeProxy.getBuffer();
        Intrinsics.checkNotNullExpressionValue(buffer, "getBuffer(...)");
        buffer.rewind();
        int rowStride = ((planeProxy.getRowStride() + buffer.limit()) - 1) / planeProxy.getRowStride();
        if (rowStride == 0) {
            return;
        }
        int i5 = i / (i2 / rowStride);
        int rowStride2 = 0;
        for (int i6 = 0; i6 < rowStride; i6++) {
            int pixelStride = rowStride2;
            for (int i7 = 0; i7 < i5; i7++) {
                bArr[i3] = buffer.get(pixelStride);
                i3 += i4;
                pixelStride += planeProxy.getPixelStride();
            }
            rowStride2 += planeProxy.getRowStride();
        }
    }
}
