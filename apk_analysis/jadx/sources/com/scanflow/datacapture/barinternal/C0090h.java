package com.scanflow.datacapture.barinternal;

import android.graphics.Bitmap;
import android.util.Log;
import com.scanflow.datacapture.model.LowLightResponse;
import kotlin.jvm.internal.Intrinsics;
import org.opencv.android.Utils;
import org.opencv.core.Core;
import org.opencv.core.Mat;
import org.opencv.imgproc.Imgproc;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.h, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0090h {
    public static final C0090h a = new C0090h();

    public final synchronized LowLightResponse a(Bitmap bitmap) {
        try {
            Intrinsics.checkNotNullParameter(bitmap, "bitmap");
            Intrinsics.checkNotNullParameter(bitmap, "bitmap");
            Mat mat = new Mat();
            Utils.bitmapToMat(bitmap, mat);
            Imgproc.cvtColor(mat, mat, 52);
            int i = (int) Core.mean(mat).val[1];
            Log.v("DarkEnvironmentUtils", "Is Low light Image : Brightness : " + i);
            if (i <= 15) {
                return null;
            }
            boolean z = i < 100;
            if (z) {
                Intrinsics.checkNotNullParameter(bitmap, "<this>");
                Mat mat2 = new Mat();
                Mat mat3 = new Mat();
                Utils.bitmapToMat(bitmap, mat2);
                Mat mat4 = new Mat(1, 256, 0);
                byte[] bArr = new byte[(int) (mat4.total() * ((long) mat4.channels()))];
                int iCols = mat4.cols();
                for (int i2 = 0; i2 < iCols; i2++) {
                    bArr[i2] = (byte) (Math.pow(((double) i2) / 255.0d, 0.4d) * 255.0d);
                }
                mat4.put(0, 0, bArr);
                Core.LUT(mat2, mat4, mat3);
                bitmap = Bitmap.createBitmap((int) mat3.size().width, (int) mat3.size().height, Bitmap.Config.RGB_565);
                Intrinsics.checkNotNullExpressionValue(bitmap, "createBitmap(...)");
                Utils.matToBitmap(mat3, bitmap);
            }
            return new LowLightResponse(bitmap, z);
        } catch (Throwable th) {
            throw th;
        }
    }
}
