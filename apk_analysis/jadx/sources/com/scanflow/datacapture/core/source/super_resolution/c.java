package com.scanflow.datacapture.core.source.super_resolution;

import android.graphics.Bitmap;
import androidx.core.view.ViewCompat;
import org.tensorflow.lite.support.tensorbuffer.TensorBuffer;

/* JADX INFO: loaded from: classes3.dex */
public final class c implements b {
    public final float[] a = {0.33007812f, 0.33007812f, 0.33007812f};
    public final float[] b = {0.2323942f, 0.22483271f, 0.22995465f};

    @Override // com.scanflow.datacapture.core.source.super_resolution.b
    public final EnhancementResult[] a(TensorBuffer[] tensorBufferArr) {
        char c = 0;
        int i = tensorBufferArr[0].getShape()[1];
        int i2 = tensorBufferArr[0].getShape()[2];
        int i3 = i2 * i;
        float[] floatArray = tensorBufferArr[0].getFloatArray();
        int[] iArr = new int[i3];
        int i4 = 0;
        while (i4 < i3 * 3) {
            iArr[i4 / 3] = ((int) (Math.min(Math.max((floatArray[i4 + 2] * this.b[2]) + this.a[2], 0.0f), 1.0f) * 255.0f)) | (((int) (Math.min(Math.max((floatArray[i4] * this.b[c]) + this.a[c], 0.0f), 1.0f) * 255.0f)) << 16) | ViewCompat.MEASURED_STATE_MASK | (((int) (Math.min(Math.max((floatArray[i4 + 1] * this.b[1]) + this.a[1], 0.0f), 1.0f) * 255.0f)) << 8);
            i4 += 3;
            c = 0;
        }
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap(i2, i, Bitmap.Config.ARGB_8888);
        bitmapCreateBitmap.setPixels(iArr, 0, i2, 0, 0, i2, i);
        return new EnhancementResult[]{new EnhancementResult(new Bitmap[]{bitmapCreateBitmap})};
    }
}
