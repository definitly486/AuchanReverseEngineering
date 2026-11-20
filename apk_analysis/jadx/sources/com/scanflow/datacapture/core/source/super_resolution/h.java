package com.scanflow.datacapture.core.source.super_resolution;

import android.app.Application;
import android.content.Context;
import android.graphics.Bitmap;
import android.os.SystemClock;
import android.util.Log;
import java.nio.MappedByteBuffer;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;
import org.tensorflow.lite.Delegate;
import org.tensorflow.lite.Interpreter;
import org.tensorflow.lite.gpu.GpuDelegate;
import org.tensorflow.lite.nnapi.NnApiDelegate;
import org.tensorflow.lite.support.common.FileUtil;
import org.tensorflow.lite.support.tensorbuffer.TensorBuffer;

/* JADX INFO: loaded from: classes3.dex */
public abstract class h {
    private static final String TAG = "h";
    protected Context context;
    protected String[] labels;
    protected com.scanflow.datacapture.core.source.super_resolution.a model;
    private final Map<String, com.scanflow.datacapture.core.source.super_resolution.a> modelsMap;
    protected Interpreter tflite;
    protected TensorBuffer[] tfliteOutputs;
    private GpuDelegate gpuDelegate = null;
    private NnApiDelegate nnApiDelegate = null;

    public static /* synthetic */ class a {
        public static final /* synthetic */ int[] a;

        static {
            int[] iArr = new int[Device.values().length];
            a = iArr;
            try {
                iArr[Device.NNAPI.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                a[Device.GPU.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                a[Device.DSP.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                a[Device.CPU.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
        }
    }

    public h(Map<String, com.scanflow.datacapture.core.source.super_resolution.a> map) {
        this.modelsMap = map;
    }

    public Set<String> getAllModels() {
        return this.modelsMap.keySet();
    }

    public Context getContext() {
        return this.context;
    }

    /* JADX WARN: Code duplicated, block: B:18:0x0067 A[Catch: Exception -> 0x0035, LOOP:0: B:16:0x005f->B:18:0x0067, LOOP_END, TryCatch #0 {Exception -> 0x0035, blocks: (B:5:0x0019, B:15:0x0041, B:16:0x005f, B:18:0x0067, B:19:0x0085, B:21:0x0095, B:10:0x002d, B:14:0x003e, B:13:0x0037), top: B:25:0x0019 }] */
    /* JADX WARN: Code duplicated, block: B:21:0x0095 A[Catch: Exception -> 0x0035, TRY_LEAVE, TryCatch #0 {Exception -> 0x0035, blocks: (B:5:0x0019, B:15:0x0041, B:16:0x005f, B:18:0x0067, B:19:0x0085, B:21:0x0095, B:10:0x002d, B:14:0x003e, B:13:0x0037), top: B:25:0x0019 }] */
    public boolean init(Context context, String str, Device device, int i) {
        Delegate delegate;
        ArrayList arrayList;
        int i2;
        String str2;
        this.context = context;
        Application application = (Application) context.getApplicationContext();
        this.tflite = null;
        com.scanflow.datacapture.core.source.super_resolution.a aVar = this.modelsMap.get(str);
        this.model = aVar;
        if (aVar == null) {
            return false;
        }
        try {
            Interpreter.Options options = new Interpreter.Options();
            int i3 = a.a[device.ordinal()];
            if (i3 != 1) {
                if (i3 == 2) {
                    GpuDelegate gpuDelegate = new GpuDelegate();
                    this.gpuDelegate = gpuDelegate;
                    delegate = gpuDelegate;
                }
                MappedByteBuffer mappedByteBufferLoadMappedFile = FileUtil.loadMappedFile(application, this.model.a);
                options.setNumThreads(i);
                this.tflite = new Interpreter(mappedByteBufferLoadMappedFile, options);
                arrayList = new ArrayList(this.tflite.getOutputTensorCount());
                for (i2 = 0; i2 < this.tflite.getOutputTensorCount(); i2++) {
                    arrayList.add(TensorBuffer.createFixedSize(this.tflite.getOutputTensor(i2).shape(), this.tflite.getOutputTensor(i2).dataType()));
                }
                this.tfliteOutputs = (TensorBuffer[]) arrayList.toArray(new TensorBuffer[0]);
                str2 = this.model.b;
                if (str2 != null) {
                    this.labels = (String[]) FileUtil.loadLabels(application, str2).toArray(new String[0]);
                }
                return true;
            }
            NnApiDelegate nnApiDelegate = new NnApiDelegate();
            this.nnApiDelegate = nnApiDelegate;
            delegate = nnApiDelegate;
            options.addDelegate(delegate);
            MappedByteBuffer mappedByteBufferLoadMappedFile2 = FileUtil.loadMappedFile(application, this.model.a);
            options.setNumThreads(i);
            this.tflite = new Interpreter(mappedByteBufferLoadMappedFile2, options);
            arrayList = new ArrayList(this.tflite.getOutputTensorCount());
            while (i2 < this.tflite.getOutputTensorCount()) {
                arrayList.add(TensorBuffer.createFixedSize(this.tflite.getOutputTensor(i2).shape(), this.tflite.getOutputTensor(i2).dataType()));
            }
            this.tfliteOutputs = (TensorBuffer[]) arrayList.toArray(new TensorBuffer[0]);
            str2 = this.model.b;
            if (str2 != null) {
                this.labels = (String[]) FileUtil.loadLabels(application, str2).toArray(new String[0]);
            }
            return true;
        } catch (Exception e) {
            release();
            e.printStackTrace();
            return false;
        }
    }

    public ProcessResult process(Bitmap[] bitmapArr, int i) {
        ProcessResult processResult;
        Bitmap[] bitmapArr2 = bitmapArr;
        ProcessResult processResult2 = null;
        if (this.model.c == 1 && this.tflite == null) {
            return null;
        }
        try {
            ArrayList arrayList = new ArrayList();
            long jUptimeMillis = SystemClock.uptimeMillis();
            int length = bitmapArr2.length;
            long j = 0;
            long jUptimeMillis2 = 0;
            long j2 = 0;
            int i2 = 0;
            while (i2 < length) {
                Bitmap bitmap = bitmapArr2[i2];
                TensorBuffer tensorBufferA = this.model.d.a(bitmap);
                jUptimeMillis2 = SystemClock.uptimeMillis() - jUptimeMillis;
                Object[] objArr = {tensorBufferA.getBuffer()};
                HashMap map = new HashMap();
                TensorBuffer[] tensorBufferArr = this.tfliteOutputs;
                int length2 = tensorBufferArr.length;
                processResult = processResult2;
                int i3 = 0;
                int i4 = 0;
                while (i3 < length2) {
                    try {
                        map.put(Integer.valueOf(i4), tensorBufferArr[i3].getBuffer().rewind());
                        i3++;
                        i4++;
                    } catch (Exception e) {
                        e = e;
                        Log.e(TAG, "beginning of stacktrace:");
                        e.printStackTrace();
                        return processResult;
                    }
                }
                long jUptimeMillis3 = SystemClock.uptimeMillis();
                this.tflite.runForMultipleInputsOutputs(objArr, map);
                long jUptimeMillis4 = SystemClock.uptimeMillis();
                TensorBuffer[] tensorBufferArr2 = this.tfliteOutputs;
                b bVar = this.model.e;
                bitmap.getWidth();
                bitmap.getHeight();
                arrayList.addAll(Arrays.asList(bVar.a(tensorBufferArr2)));
                i2++;
                bitmapArr2 = bitmapArr;
                processResult2 = processResult;
                j = jUptimeMillis4;
                j2 = jUptimeMillis4 - jUptimeMillis3;
            }
            processResult = processResult2;
            long jUptimeMillis5 = SystemClock.uptimeMillis() - j;
            long jUptimeMillis6 = SystemClock.uptimeMillis() - jUptimeMillis;
            String str = TAG;
            Log.i(str, String.format("Total time %d ms.", Long.valueOf(jUptimeMillis6)));
            Log.i(str, String.format("preProcess time %d ms.", Long.valueOf(jUptimeMillis2)));
            Log.i(str, String.format("postProcess time %d ms.", Long.valueOf(jUptimeMillis5)));
            Log.i(str, String.format("Inference time %d ms.", Long.valueOf(j2)));
            return new ProcessResult(arrayList, this.labels, j2, jUptimeMillis6);
        } catch (Exception e2) {
            e = e2;
            processResult = processResult2;
        }
    }

    public boolean release() {
        Interpreter interpreter = this.tflite;
        if (interpreter != null) {
            interpreter.close();
            this.tflite = null;
        }
        GpuDelegate gpuDelegate = this.gpuDelegate;
        if (gpuDelegate != null) {
            gpuDelegate.close();
            this.gpuDelegate = null;
        }
        NnApiDelegate nnApiDelegate = this.nnApiDelegate;
        if (nnApiDelegate != null) {
            nnApiDelegate.close();
            this.nnApiDelegate = null;
        }
        this.tfliteOutputs = null;
        return true;
    }
}
