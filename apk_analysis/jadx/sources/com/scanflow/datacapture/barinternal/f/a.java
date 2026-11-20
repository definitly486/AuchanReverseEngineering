package com.scanflow.datacapture.barinternal.f;

import android.graphics.Bitmap;
import com.scanflow.datacapture.model.LowLightResponse;
import com.scanflow.datacapture.utils.ScanflowLog;
import kotlin.jvm.internal.Intrinsics;
import org.opencv.android.Utils;
import org.opencv.core.Core;
import org.opencv.core.Mat;
import org.opencv.imgproc.Imgproc;

/* JADX INFO: loaded from: classes3.dex */
public final class a {
    public static final a a = new a();

    public final synchronized LowLightResponse a(Bitmap cropBitmap, Bitmap bitmap) {
        try {
            Intrinsics.checkNotNullParameter(cropBitmap, "cropBitmap");
            Intrinsics.checkNotNullParameter(bitmap, "frameBitmap");
            Intrinsics.checkNotNullParameter(bitmap, "bitmap");
            Mat mat = new Mat();
            Utils.bitmapToMat(bitmap, mat);
            Imgproc.cvtColor(mat, mat, 52);
            int i = (int) Core.mean(mat).val[1];
            ScanflowLog.INSTANCE.v("DarkEnvironmentUtils", "Is Low light Image : Brightness : " + i);
            if (i <= 15) {
                return null;
            }
            boolean z = i < 80;
            if (z) {
                Intrinsics.checkNotNullParameter(cropBitmap, "<this>");
                Mat mat2 = new Mat();
                Mat mat3 = new Mat();
                Utils.bitmapToMat(cropBitmap, mat2);
                Mat mat4 = new Mat(1, 256, 0);
                byte[] bArr = new byte[(int) (mat4.total() * ((long) mat4.channels()))];
                int iCols = mat4.cols();
                for (int i2 = 0; i2 < iCols; i2++) {
                    bArr[i2] = (byte) (Math.pow(((double) i2) / 255.0d, 0.4d) * 255.0d);
                }
                mat4.put(0, 0, bArr);
                Core.LUT(mat2, mat4, mat3);
                cropBitmap = Bitmap.createBitmap((int) mat3.size().width, (int) mat3.size().height, Bitmap.Config.RGB_565);
                Intrinsics.checkNotNullExpressionValue(cropBitmap, "createBitmap(...)");
                Utils.matToBitmap(mat3, cropBitmap);
            }
            return new LowLightResponse(cropBitmap, z);
        } catch (Throwable th) {
            throw th;
        }
    }
}
