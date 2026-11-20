package com.scanflow.datacapture.core.source.super_resolution;

import android.graphics.Bitmap;
import org.tensorflow.lite.DataType;
import org.tensorflow.lite.support.common.TensorOperator;
import org.tensorflow.lite.support.common.ops.NormalizeOp;
import org.tensorflow.lite.support.image.ImageOperator;
import org.tensorflow.lite.support.image.ImageProcessor;
import org.tensorflow.lite.support.image.TensorImage;
import org.tensorflow.lite.support.image.ops.ResizeOp;
import org.tensorflow.lite.support.tensorbuffer.TensorBuffer;

/* JADX INFO: loaded from: classes3.dex */
public final class g implements e {
    public TensorImage c = new TensorImage(DataType.FLOAT32);
    public final float[] a = {127.5f, 127.5f, 127.5f};
    public final float[] b = {1.0f, 1.0f, 1.0f};

    @Override // com.scanflow.datacapture.core.source.super_resolution.e
    public final TensorBuffer a(Bitmap bitmap) {
        ImageProcessor.Builder builderAdd;
        NormalizeOp normalizeOp;
        this.c.load(bitmap);
        int width = bitmap.getWidth();
        int height = bitmap.getHeight();
        int i = (width / 4) * 4;
        int i2 = (height / 4) * 4;
        if (i == width && i2 == height) {
            builderAdd = new ImageProcessor.Builder();
            normalizeOp = new NormalizeOp(this.a, this.b);
        } else {
            builderAdd = new ImageProcessor.Builder().add((ImageOperator) new ResizeOp(i2, i, ResizeOp.ResizeMethod.BILINEAR));
            normalizeOp = new NormalizeOp(this.a, this.b);
        }
        TensorImage tensorImageProcess = builderAdd.add((TensorOperator) normalizeOp).build().process(this.c);
        this.c = tensorImageProcess;
        return tensorImageProcess.getTensorBuffer();
    }
}
