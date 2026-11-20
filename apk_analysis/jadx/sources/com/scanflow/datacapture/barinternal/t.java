package com.scanflow.datacapture.barinternal;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.Rect;
import android.graphics.YuvImage;
import androidx.camera.core.ImageProxy;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.io.ByteStreamsKt;
import com.scanflow.datacapture.barinternal.kotlin.io.CloseableKt;
import com.scanflow.datacapture.utils.FrameMetadata;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.nio.ByteBuffer;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class t {
    public static final t a = new t();

    public static Bitmap a(Bitmap bitmap) {
        Intrinsics.checkNotNullParameter(bitmap, "bitmap");
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmap.getWidth(), bitmap.getHeight() + 50, Bitmap.Config.ARGB_8888);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        Canvas canvas = new Canvas(bitmapCreateBitmap);
        canvas.drawColor(-1);
        canvas.drawBitmap(bitmap, 0.0f, 0.0f, (Paint) null);
        return bitmapCreateBitmap;
    }

    public static Bitmap b(Bitmap originalBitmap) {
        Intrinsics.checkNotNullParameter(originalBitmap, "originalBitmap");
        int width = originalBitmap.getWidth() + 300;
        int height = originalBitmap.getHeight() + 300;
        Bitmap.Config config = originalBitmap.getConfig();
        if (config == null) {
            config = Bitmap.Config.ARGB_8888;
        }
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap(width, height, config);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        bitmapCreateBitmap.eraseColor(-1);
        new Canvas(bitmapCreateBitmap).drawBitmap(originalBitmap, (width - originalBitmap.getWidth()) / 2, (height - originalBitmap.getHeight()) / 2, (Paint) null);
        return bitmapCreateBitmap;
    }

    public final synchronized Bitmap c(Bitmap source) {
        Bitmap bitmapCreateBitmap;
        Intrinsics.checkNotNullParameter(source, "source");
        int height = source.getHeight();
        int width = source.getWidth();
        bitmapCreateBitmap = Bitmap.createBitmap(448, 448, Bitmap.Config.ARGB_8888);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        Matrix matrixA = a(width, height, 448, 448, 0);
        matrixA.invert(new Matrix());
        new Canvas(bitmapCreateBitmap).drawBitmap(source, matrixA, null);
        return bitmapCreateBitmap;
    }

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
            yuvImage.compressToJpeg(new Rect(0, 0, metadata.getWidth(), metadata.getHeight()), 100, byteArrayOutputStream);
            Bitmap bitmapDecodeByteArray = BitmapFactory.decodeByteArray(byteArrayOutputStream.toByteArray(), 0, byteArrayOutputStream.size());
            byteArrayOutputStream.close();
            Intrinsics.checkNotNull(bitmapDecodeByteArray);
            return a(bitmapDecodeByteArray, metadata.getRotation());
        } catch (Exception unused) {
            return null;
        }
    }

    public static File a(Context context, String fileName) throws IOException {
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(fileName, "fileName");
        File file = new File(context.getCacheDir(), fileName);
        FileOutputStream fileOutputStream = new FileOutputStream(file);
        try {
            InputStream inputStreamOpen = context.getAssets().open(fileName);
            try {
                Intrinsics.checkNotNull(inputStreamOpen);
                ByteStreamsKt.copyTo$default(inputStreamOpen, fileOutputStream, 0, 2, null);
                Unit unit = Unit.INSTANCE;
                CloseableKt.closeFinally(inputStreamOpen, null);
                CloseableKt.closeFinally(fileOutputStream, null);
                return file;
            } catch (Throwable th) {
                try {
                    throw th;
                } catch (Throwable th2) {
                    CloseableKt.closeFinally(inputStreamOpen, th);
                    throw th2;
                }
            }
        } catch (Throwable th3) {
            try {
                throw th3;
            } catch (Throwable th4) {
                CloseableKt.closeFinally(fileOutputStream, th3);
                throw th4;
            }
        }
    }

    public static Matrix a(int i, int i2, int i3, int i4, int i5) {
        Matrix matrix = new Matrix();
        if (i5 != 0) {
            matrix.postTranslate((-i) / 2.0f, (-i2) / 2.0f);
            matrix.postRotate(i5);
        }
        boolean z = (Math.abs(i5) + 90) % 180 == 0;
        int i6 = z ? i2 : i;
        if (!z) {
            i = i2;
        }
        if (i6 != i3 || i != i4) {
            matrix.postScale(i3 / i6, i4 / i);
        }
        if (i5 != 0) {
            matrix.postTranslate(i3 / 2.0f, i4 / 2.0f);
        }
        return matrix;
    }

    public static Bitmap a(Bitmap bitmap, int i, Rect cropRect) {
        Intrinsics.checkNotNullParameter(bitmap, "bitmap");
        Intrinsics.checkNotNullParameter(cropRect, "cropRect");
        try {
            Matrix matrix = new Matrix();
            matrix.preRotate(i);
            Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmap, cropRect.left, cropRect.top, cropRect.width(), cropRect.height(), matrix, true);
            Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
            return bitmapCreateBitmap;
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public static Bitmap a(Bitmap bitmap, int i) {
        Intrinsics.checkNotNullParameter(bitmap, "bitmap");
        Matrix matrix = new Matrix();
        matrix.postRotate(i);
        matrix.postScale(1.0f, 1.0f);
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmap, 0, 0, bitmap.getWidth(), bitmap.getHeight(), matrix, true);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        if (!Intrinsics.areEqual(bitmapCreateBitmap, bitmap)) {
            bitmap.recycle();
        }
        return bitmapCreateBitmap;
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
