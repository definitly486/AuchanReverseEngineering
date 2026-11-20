package com.scanflow.datacapture.barinternal.boofcv.android;

import android.graphics.Bitmap;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I8;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvertBitmap {
    public static DogArray_I8 resizeStorage(Bitmap bitmap, DogArray_I8 dogArray_I8) {
        int width = bitmap.getWidth() * bitmap.getHeight() * (bitmap.getConfig() == Bitmap.Config.ARGB_8888 ? 4 : 2);
        if (dogArray_I8 == null) {
            return new DogArray_I8(width);
        }
        dogArray_I8.resize(width);
        return dogArray_I8;
    }

    public static GrayU8 bitmapToGray(Bitmap bitmap, GrayU8 grayU8, DogArray_I8 dogArray_I8) {
        DogArray_I8 dogArray_I8ResizeStorage = resizeStorage(bitmap, dogArray_I8);
        if (grayU8 == null) {
            grayU8 = new GrayU8(bitmap.getWidth(), bitmap.getHeight());
        } else {
            grayU8.reshape(bitmap.getWidth(), bitmap.getHeight());
        }
        bitmap.copyPixelsToBuffer(ByteBuffer.wrap(dogArray_I8ResizeStorage.data));
        ImplConvertBitmap.arrayToGray(dogArray_I8ResizeStorage.data, bitmap.getConfig(), grayU8);
        return grayU8;
    }
}
