package com.scanflow.datacapture.core.source.super_resolution;

import android.graphics.Bitmap;
import android.os.SystemClock;
import androidx.annotation.Keep;
import java.util.LinkedHashMap;
import java.util.Map;
import org.tensorflow.lite.support.tensorbuffer.TensorBuffer;

/* JADX INFO: loaded from: classes3.dex */
@Keep
public class Enhancement extends h {
    private static final Map<String, com.scanflow.datacapture.core.source.super_resolution.a> ENHANCEMENT_MODELS = new a();
    private static final String TAG = "Enhancement";
    private final boolean isDynamicInput;

    public class a extends LinkedHashMap<String, com.scanflow.datacapture.core.source.super_resolution.a> {
        public a() {
            put("Enhancement", new com.scanflow.datacapture.core.source.super_resolution.a("Sensifai_Enhancement_TFLite.tflite", new f(), new c()));
            put("SuperResolution", new com.scanflow.datacapture.core.source.super_resolution.a("Sensifai_SuperResolution_TFLite.tflite", new g(), new d()));
            put("Enhancement16", new com.scanflow.datacapture.core.source.super_resolution.a("Sensifai_Enhancement_TFLite_float16.tflite", new f(), new c()));
        }
    }

    public Enhancement(boolean z) {
        super(ENHANCEMENT_MODELS);
        this.isDynamicInput = z;
    }

    @Override // com.scanflow.datacapture.core.source.super_resolution.h
    public ProcessResult process(Bitmap[] bitmapArr, int i) {
        long jUptimeMillis = SystemClock.uptimeMillis();
        if (this.isDynamicInput) {
            int[] shape = this.tfliteOutputs[0].getShape();
            shape[1] = (bitmapArr[0].getHeight() / 4) * 4;
            shape[2] = (bitmapArr[0].getWidth() / 4) * 4;
            this.tfliteOutputs = new TensorBuffer[]{TensorBuffer.createFixedSize(shape, this.tfliteOutputs[0].getDataType())};
            this.tflite.resizeInput(0, shape);
        }
        ProcessResult processResultProcess = super.process(bitmapArr, i);
        if (processResultProcess == null) {
            return null;
        }
        return new ProcessResult(processResultProcess.getResults(), new String[0], processResultProcess.getInferenceTime(), SystemClock.uptimeMillis() - jUptimeMillis);
    }
}
