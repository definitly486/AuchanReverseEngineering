package com.scanflow.datacapture.barinternal;

import android.graphics.Bitmap;
import com.scanflow.datacapture.barinternal.org.opencv.core.Size;
import kotlin.jvm.internal.Intrinsics;
import org.opencv.android.Utils;
import org.opencv.core.Mat;
import org.opencv.imgproc.Imgproc;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.s, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0103s {
    public static final Bitmap a;

    static {
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        a = bitmapCreateBitmap;
    }

    public static Bitmap a(Bitmap bitmapSource) {
        Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
        Mat mat = new Mat();
        Utils.bitmapToMat(bitmapSource, mat);
        Mat mat2 = new Mat();
        Imgproc.resize(mat, mat2, new Size(((double) bitmapSource.getWidth()) * 2.0d, ((double) bitmapSource.getHeight()) * 2.0d), 0.0d, 0.0d, 2);
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap(mat2.cols(), mat2.rows(), Bitmap.Config.ARGB_8888);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        Utils.matToBitmap(mat2, bitmapCreateBitmap);
        return bitmapCreateBitmap;
    }
}
