package com.scanflow.datacapture.barcode;

import android.app.Activity;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.PointF;
import android.graphics.PorterDuff;
import android.graphics.RectF;
import android.util.Log;
import androidx.security.crypto.EncryptedSharedPreferences;
import androidx.security.crypto.MasterKey;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.Delegate;
import com.google.mediapipe.tasks.vision.imageclassifier.ImageClassifier;
import com.google.mlkit.vision.barcode.BarcodeScanner;
import com.google.mlkit.vision.barcode.common.Barcode;
import com.google.mlkit.vision.common.InputImage;
import com.google.zxing.BinaryBitmap;
import com.google.zxing.DecodeHintType;
import com.google.zxing.LuminanceSource;
import com.google.zxing.MultiFormatReader;
import com.google.zxing.RGBLuminanceSource;
import com.google.zxing.Result;
import com.google.zxing.common.GlobalHistogramBinarizer;
import com.google.zxing.common.HybridBinarizer;
import com.scanflow.datacapture.barcode.b;
import com.scanflow.datacapture.barcode.config.DecodeConfig;
import com.scanflow.datacapture.barinternal.AbstractC0085c;
import com.scanflow.datacapture.barinternal.AbstractC0094l;
import com.scanflow.datacapture.barinternal.AbstractC0095m;
import com.scanflow.datacapture.barinternal.AbstractC0103s;
import com.scanflow.datacapture.barinternal.B;
import com.scanflow.datacapture.barinternal.C0084b;
import com.scanflow.datacapture.barinternal.C0090h;
import com.scanflow.datacapture.barinternal.N;
import com.scanflow.datacapture.barinternal.boofcv.abst.fiducial.QrCodePreciseDetector;
import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCode;
import com.scanflow.datacapture.barinternal.boofcv.android.ConvertBitmap;
import com.scanflow.datacapture.barinternal.boofcv.factory.fiducial.ConfigQrCode;
import com.scanflow.datacapture.barinternal.boofcv.factory.fiducial.FactoryFiducial;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__BuildersKt;
import com.scanflow.datacapture.barinternal.org.opencv.core.Size;
import com.scanflow.datacapture.barinternal.r;
import com.scanflow.datacapture.barinternal.t;
import com.scanflow.datacapture.barinternal.y;
import com.scanflow.datacapture.barinternal.z;
import com.scanflow.datacapture.core.camera.manager.BeepManager;
import com.scanflow.datacapture.core.source.super_resolution.Device;
import com.scanflow.datacapture.core.source.super_resolution.Enhancement;
import com.scanflow.datacapture.model.LowLightResponse;
import com.scanflow.datacapture.model.OneOFManyCodesScanResults;
import com.scanflow.datacapture.model.ScanResultSuccess;
import com.scanflow.datacapture.utils.BarcodeFormat;
import com.scanflow.datacapture.utils.ScanflowLog;
import java.io.File;
import java.io.IOException;
import java.security.InvalidAlgorithmParameterException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.atomic.AtomicBoolean;
import javax.crypto.NoSuchPaddingException;
import kotlin.jvm.internal.Intrinsics;
import org.opencv.android.Utils;
import org.opencv.core.Mat;
import org.opencv.imgproc.Imgproc;

/* JADX INFO: loaded from: classes3.dex */
public final class b extends SFBarcodeReader {
    public SFBarcodeReader.OnBarcodeScanResultCallback a;
    public final String b;
    public final int c;
    public final float d;
    public final Enhancement e;
    public final String f;
    public final boolean g;
    public final boolean h;
    public final boolean i;
    public final BeepManager j;
    public final String k;
    public final ArrayList l;
    public final Matrix m;
    public final HashSet n;
    public final LinkedList o;
    public final HashSet p;
    public final String q;

    /* JADX WARN: Code duplicated, block: B:119:0x032d  */
    /* JADX WARN: Code duplicated, block: B:122:0x0332  */
    /* JADX WARN: Code duplicated, block: B:124:0x0336 A[PHI: r0
      0x0336: PHI (r0v35 com.scanflow.datacapture.barcode.SFBarcodeReader$OnBarcodeScanResultCallback) = 
      (r0v26 com.scanflow.datacapture.barcode.SFBarcodeReader$OnBarcodeScanResultCallback)
      (r0v36 com.scanflow.datacapture.barcode.SFBarcodeReader$OnBarcodeScanResultCallback)
     binds: [B:123:0x0334, B:77:0x023f] A[DONT_GENERATE, DONT_INLINE]] */
    /* JADX WARN: Code duplicated, block: B:133:0x0367  */
    /* JADX WARN: Code duplicated, block: B:135:0x036b A[PHI: r0 r4
      0x036b: PHI (r0v24 com.scanflow.datacapture.barcode.SFBarcodeReader$OnBarcodeScanResultCallback) = 
      (r0v23 com.scanflow.datacapture.barcode.SFBarcodeReader$OnBarcodeScanResultCallback)
      (r0v27 com.scanflow.datacapture.barcode.SFBarcodeReader$OnBarcodeScanResultCallback)
     binds: [B:134:0x0369, B:120:0x032f] A[DONT_GENERATE, DONT_INLINE]
      0x036b: PHI (r4v12 com.scanflow.datacapture.barinternal.b) = (r4v10 com.scanflow.datacapture.barinternal.b), (r4v14 com.scanflow.datacapture.barinternal.b) binds: [B:134:0x0369, B:120:0x032f] A[DONT_GENERATE, DONT_INLINE]] */
    /* JADX WARN: Code duplicated, block: B:138:0x0372  */
    /* JADX WARN: Code duplicated, block: B:140:0x0376  */
    /* JADX WARN: Code duplicated, block: B:146:0x038c  */
    /* JADX WARN: Code duplicated, block: B:147:0x0392  */
    /* JADX WARN: Code duplicated, block: B:150:0x03ce  */
    /* JADX WARN: Code duplicated, block: B:152:0x03d8  */
    /* JADX WARN: Code duplicated, block: B:153:0x03dd  */
    /* JADX WARN: Code duplicated, block: B:180:? A[RETURN, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:181:? A[RETURN, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:25:0x013f A[ADDED_TO_REGION] */
    /* JADX WARN: Code duplicated, block: B:29:0x0148  */
    /* JADX WARN: Code duplicated, block: B:32:0x0174 A[DONT_INVERT] */
    /* JADX WARN: Code duplicated, block: B:33:0x0176  */
    /* JADX WARN: Code duplicated, block: B:35:0x0193  */
    /* JADX WARN: Code duplicated, block: B:37:0x0196  */
    /* JADX WARN: Code duplicated, block: B:40:0x019d  */
    /* JADX WARN: Code duplicated, block: B:43:0x01b4  */
    public b(Activity mActivity, String SCANFLOW_LICENSE_KEY, DecodeConfig decodeConfig, SFBarcodeReader.OnBarcodeScanResultCallback callback, Bitmap bitmap) throws NoSuchPaddingException, NoSuchAlgorithmException, IOException, InvalidKeyException, InvalidAlgorithmParameterException {
        SharedPreferences sharedPreferences;
        String str;
        int iA;
        Delegate delegate;
        N n;
        double d;
        Bitmap.Config config;
        Bitmap bitmapCreateBitmap;
        Bitmap bitmapSource;
        ArrayList arrayList;
        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback;
        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback2;
        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback3;
        Bitmap bitmapCreateBitmap2;
        Intrinsics.checkNotNullParameter(mActivity, "mActivity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
        Intrinsics.checkNotNullParameter(callback, "callback");
        Intrinsics.checkNotNullParameter(bitmap, "bitmap");
        AtomicBoolean atomicBoolean = new AtomicBoolean(false);
        this.b = "SFBarcodeBitmap";
        this.c = 448;
        this.d = 0.2f;
        this.f = "qr_code";
        this.k = "any";
        this.l = new ArrayList();
        new Matrix();
        this.n = new HashSet();
        this.o = new LinkedList();
        this.p = new HashSet();
        this.q = "sharp";
        Log.v("SFBarcodeBitmap", "License Checking - Started");
        this.a = callback;
        MasterKey masterKeyBuild = new MasterKey.Builder(mActivity, "_androidx_security_master_key_").setKeyScheme(MasterKey.KeyScheme.AES256_GCM).build();
        Intrinsics.checkNotNullExpressionValue(masterKeyBuild, "build(...)");
        SharedPreferences sharedPreferencesCreate = EncryptedSharedPreferences.create(mActivity, SCANFLOW_LICENSE_KEY, masterKeyBuild, EncryptedSharedPreferences.PrefKeyEncryptionScheme.AES256_SIV, EncryptedSharedPreferences.PrefValueEncryptionScheme.AES256_GCM);
        C0084b c0084b = null;
        if (sharedPreferencesCreate == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            sharedPreferences = null;
        } else {
            sharedPreferences = sharedPreferencesCreate;
        }
        SharedPreferences.Editor editorEdit = sharedPreferences.edit();
        editorEdit.putString("MODEL_FILE_KEY_PREF_NAME", "WN*J8yH19c9szb9#");
        editorEdit.apply();
        LowLightResponse lowLightResponseA = C0090h.a.a(bitmap);
        t tVar = t.a;
        Matrix matrixA = t.a(bitmap.getWidth(), bitmap.getHeight(), 448, 448, 0);
        if (lowLightResponseA == null) {
            a();
            return;
        }
        Matrix matrix = new Matrix();
        this.m = matrix;
        matrixA.invert(matrix);
        this.l = new ArrayList();
        BeepManager beepManager = new BeepManager(mActivity, Integer.valueOf(R.raw.beep));
        this.j = beepManager;
        beepManager.setVibrate(false);
        beepManager.setPlayBeep(true);
        atomicBoolean.get();
        Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
        switch (z.a[decodeConfig.ordinal()]) {
            case 1:
                str = "qr_code";
                this.f = str;
                this.g = false;
                BaseOptions.Builder modelAssetPath = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
                iA = AbstractC0085c.a(1);
                if (iA == 1 && iA == 2) {
                    delegate = Delegate.GPU;
                } else {
                    delegate = Delegate.CPU;
                }
                modelAssetPath.setDelegate(delegate);
                ImageClassifier.createFromOptions(mActivity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath.build()).setMaxResults(3).build());
                Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
                if (mActivity.getAssets() != null) {
                    if (sharedPreferencesCreate == null) {
                        Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                        sharedPreferencesCreate = null;
                    }
                    File fileA = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
                    Intrinsics.checkNotNull(fileA);
                    n = new N(mActivity, fileA);
                } else {
                    n = null;
                }
                if (n != null) {
                    n.a();
                }
                if (this.e == null) {
                    Enhancement enhancement = new Enhancement(true);
                    this.e = enhancement;
                    enhancement.init(mActivity, "SuperResolution", Device.CPU, 4);
                }
                if (!this.f.equals("dotmatrix_white") || this.f.equals("dotmatrix_metal")) {
                    Bitmap bitmap2 = AbstractC0103s.a;
                    Bitmap bitmapSource2 = lowLightResponseA.getBitmap();
                    if (this.f.equals("dotmatrix_white")) {
                        d = 255.0d;
                    } else {
                        d = 300.0d;
                    }
                    Intrinsics.checkNotNullParameter(bitmapSource2, "bitmapSource");
                    Mat mat = new Mat();
                    Utils.bitmapToMat(bitmapSource2, mat);
                    Mat mat2 = new Mat();
                    Imgproc.resize(mat, mat2, new Size(d, d), 0.0d, 0.0d, 2);
                    int iCols = mat2.cols();
                    int iRows = mat2.rows();
                    config = Bitmap.Config.ARGB_8888;
                    bitmapCreateBitmap = Bitmap.createBitmap(iCols, iRows, config);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                    Utils.matToBitmap(mat2, bitmapCreateBitmap);
                    if (bitmapCreateBitmap != null) {
                        if (this.f.equals("dotmatrix_white")) {
                            bitmapSource = r.b(bitmapCreateBitmap);
                        } else {
                            bitmapSource = r.a(bitmapCreateBitmap);
                        }
                        double width = ((double) bitmapCreateBitmap.getWidth()) / 4.0d;
                        double height = ((double) bitmapCreateBitmap.getHeight()) / 4.0d;
                        Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                        Mat mat3 = new Mat();
                        Utils.bitmapToMat(bitmapSource, mat3);
                        Mat mat4 = new Mat();
                        Imgproc.resize(mat3, mat4, new Size(width, height), 0.0d, 0.0d, 2);
                        Bitmap bitmapCreateBitmap3 = Bitmap.createBitmap(mat4.cols(), mat4.rows(), config);
                        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap3, "createBitmap(...)");
                        Utils.matToBitmap(mat4, bitmapCreateBitmap3);
                        InputImage inputImageFromBitmap = InputImage.fromBitmap(t.b(bitmapCreateBitmap3), 0);
                        Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap, "fromBitmap(...)");
                        AbstractC0094l.a.process(inputImageFromBitmap).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda1
                            @Override // com.google.android.gms.tasks.OnCompleteListener
                            public final void onComplete(Task task) {
                                b.a(this.f$0, task);
                            }
                        });
                        return;
                    }
                    return;
                }
                Bitmap bitmapC = tVar.c(bitmap);
                ScanflowLog scanflowLog = ScanflowLog.INSTANCE;
                scanflowLog.v("SFBarcodeBitmap", "image resize to 448 - Completed");
                scanflowLog.v("SFBarcodeBitmap", "448 image to model - Started");
                synchronized (this) {
                    arrayList = new ArrayList();
                    if (n != null && bitmapC != null) {
                        Intrinsics.checkNotNull(n);
                        ArrayList arrayListA = n.a(bitmapC);
                        if (arrayListA.size() == 0) {
                            bitmapC.recycle();
                        } else {
                            Iterator it = arrayListA.iterator();
                            Intrinsics.checkNotNullExpressionValue(it, "iterator(...)");
                            while (it.hasNext()) {
                                Object next = it.next();
                                Intrinsics.checkNotNullExpressionValue(next, "next(...)");
                                C0084b result = (C0084b) next;
                                float f = this.d;
                                String scanType = this.f;
                                scanType = scanType == null ? "" : scanType;
                                Intrinsics.checkNotNullParameter(result, "result");
                                Intrinsics.checkNotNullParameter(scanType, "scanType");
                                if (result.c >= f && (Intrinsics.areEqual(result.b, scanType) || Intrinsics.areEqual(scanType, this.k))) {
                                    arrayList.add(result);
                                }
                            }
                        }
                    }
                }
                if (arrayList.size() < 1) {
                    onBarcodeScanResultCallback3 = this.a;
                    if (onBarcodeScanResultCallback3 != null) {
                        onBarcodeScanResultCallback3.onScanBarcodeDetection(false);
                    }
                } else {
                    if (!this.g || arrayList.size() <= 0) {
                        if (this.i) {
                            Iterator it2 = arrayList.iterator();
                            Intrinsics.checkNotNullExpressionValue(it2, "iterator(...)");
                            while (it2.hasNext()) {
                                Object next2 = it2.next();
                                Intrinsics.checkNotNullExpressionValue(next2, "next(...)");
                                C0084b c0084b2 = (C0084b) next2;
                                RectF rectF = c0084b2.d;
                                float f2 = this.c / 2;
                                if (rectF.contains(f2, f2)) {
                                    c0084b = c0084b2;
                                    if (c0084b != null) {
                                        onBarcodeScanResultCallback2 = this.a;
                                        if (onBarcodeScanResultCallback2 != null) {
                                            onBarcodeScanResultCallback2.onScanBarcodeDetection(true);
                                        }
                                    } else {
                                        onBarcodeScanResultCallback3 = this.a;
                                        if (onBarcodeScanResultCallback3 != null) {
                                            onBarcodeScanResultCallback3.onScanBarcodeDetection(false);
                                        }
                                    }
                                }
                            }
                            if (c0084b != null) {
                                onBarcodeScanResultCallback2 = this.a;
                                if (onBarcodeScanResultCallback2 != null) {
                                    onBarcodeScanResultCallback2.onScanBarcodeDetection(true);
                                }
                            } else {
                                onBarcodeScanResultCallback3 = this.a;
                                if (onBarcodeScanResultCallback3 != null) {
                                    onBarcodeScanResultCallback3.onScanBarcodeDetection(false);
                                }
                            }
                        } else {
                            Iterator it3 = arrayList.iterator();
                            Intrinsics.checkNotNullExpressionValue(it3, "iterator(...)");
                            while (it3.hasNext()) {
                                Object next3 = it3.next();
                                Intrinsics.checkNotNullExpressionValue(next3, "next(...)");
                                C0084b c0084b3 = (C0084b) next3;
                                RectF rectF2 = c0084b3.d;
                                float f3 = this.c / 2;
                                if (rectF2.contains(f3, f3)) {
                                    c0084b = c0084b3;
                                    if (c0084b != null) {
                                        onBarcodeScanResultCallback = this.a;
                                        if (onBarcodeScanResultCallback != null) {
                                            onBarcodeScanResultCallback.onScanBarcodeDetection(false);
                                            return;
                                        }
                                        return;
                                    }
                                    onBarcodeScanResultCallback2 = this.a;
                                    if (onBarcodeScanResultCallback2 != null) {
                                        onBarcodeScanResultCallback2.onScanBarcodeDetection(true);
                                    }
                                }
                            }
                            if (c0084b != null) {
                                onBarcodeScanResultCallback = this.a;
                                if (onBarcodeScanResultCallback != null) {
                                    onBarcodeScanResultCallback.onScanBarcodeDetection(false);
                                    return;
                                }
                                return;
                            }
                            onBarcodeScanResultCallback2 = this.a;
                            if (onBarcodeScanResultCallback2 != null) {
                                onBarcodeScanResultCallback2.onScanBarcodeDetection(true);
                            }
                        }
                        a(c0084b, lowLightResponseA);
                        return;
                    }
                    SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback4 = this.a;
                    if (onBarcodeScanResultCallback4 != null) {
                        onBarcodeScanResultCallback4.onScanBarcodeDetection(true);
                    }
                    this.l = new ArrayList();
                    Iterator it4 = arrayList.iterator();
                    Intrinsics.checkNotNullExpressionValue(it4, "iterator(...)");
                    while (it4.hasNext()) {
                        Object next4 = it4.next();
                        Intrinsics.checkNotNullExpressionValue(next4, "next(...)");
                        C0084b c0084b4 = (C0084b) next4;
                        RectF rectF3 = c0084b4.d;
                        Matrix matrix2 = this.m;
                        Intrinsics.checkNotNull(matrix2);
                        matrix2.mapRect(rectF3);
                        Intrinsics.checkNotNullParameter(rectF3, "<set-?>");
                        c0084b4.d = rectF3;
                        this.o.add(c0084b4);
                        RectF rectF4 = c0084b4.d;
                        float f4 = rectF4.left;
                        float f5 = 25;
                        float f6 = f4 - f5;
                        f4 = f6 > 0.0f ? f6 : f4;
                        float f7 = rectF4.top;
                        float f8 = f7 - f5;
                        f7 = f8 > 0.0f ? f8 : f7;
                        if (f4 <= 0.0f || f7 <= 0.0f) {
                            Intrinsics.checkNotNull(bitmap);
                            bitmapCreateBitmap2 = Bitmap.createBitmap(bitmap, (int) rectF4.left, (int) rectF4.top, (int) rectF4.width(), (int) rectF4.height());
                        } else {
                            try {
                                Intrinsics.checkNotNull(bitmap);
                                bitmapCreateBitmap2 = Bitmap.createBitmap(bitmap, (int) f4, (int) f7, ((int) rectF4.width()) + 50, ((int) rectF4.height()) + 50);
                            } catch (Exception unused) {
                                bitmapCreateBitmap2 = null;
                            }
                        }
                        if (bitmapCreateBitmap2 != null) {
                            this.l.add(new B(bitmapCreateBitmap2, c0084b4.d));
                        }
                        break;
                    }
                    if (this.l.size() > 0) {
                        BuildersKt__BuildersKt.runBlocking$default(null, new a(this, null), 1, null);
                        return;
                    }
                }
                a();
                return;
            case 2:
                str = "bar_code";
                this.f = str;
                this.g = false;
                BaseOptions.Builder modelAssetPath2 = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
                iA = AbstractC0085c.a(1);
                if (iA == 1) {
                    delegate = Delegate.CPU;
                } else {
                    delegate = Delegate.CPU;
                }
                modelAssetPath2.setDelegate(delegate);
                ImageClassifier.createFromOptions(mActivity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath2.build()).setMaxResults(3).build());
                Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
                if (mActivity.getAssets() != null) {
                    if (sharedPreferencesCreate == null) {
                        Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                        sharedPreferencesCreate = null;
                    }
                    File fileA2 = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
                    Intrinsics.checkNotNull(fileA2);
                    n = new N(mActivity, fileA2);
                } else {
                    n = null;
                }
                if (n != null) {
                    n.a();
                }
                if (this.e == null) {
                    Enhancement enhancement2 = new Enhancement(true);
                    this.e = enhancement2;
                    enhancement2.init(mActivity, "SuperResolution", Device.CPU, 4);
                }
                if (this.f.equals("dotmatrix_white")) {
                    break;
                }
                Bitmap bitmap3 = AbstractC0103s.a;
                Bitmap bitmapSource3 = lowLightResponseA.getBitmap();
                if (this.f.equals("dotmatrix_white")) {
                    d = 255.0d;
                } else {
                    d = 300.0d;
                }
                Intrinsics.checkNotNullParameter(bitmapSource3, "bitmapSource");
                Mat mat5 = new Mat();
                Utils.bitmapToMat(bitmapSource3, mat5);
                Mat mat6 = new Mat();
                Imgproc.resize(mat5, mat6, new Size(d, d), 0.0d, 0.0d, 2);
                int iCols2 = mat6.cols();
                int iRows2 = mat6.rows();
                config = Bitmap.Config.ARGB_8888;
                bitmapCreateBitmap = Bitmap.createBitmap(iCols2, iRows2, config);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                Utils.matToBitmap(mat6, bitmapCreateBitmap);
                if (bitmapCreateBitmap != null) {
                    if (this.f.equals("dotmatrix_white")) {
                        bitmapSource = r.b(bitmapCreateBitmap);
                    } else {
                        bitmapSource = r.a(bitmapCreateBitmap);
                    }
                    double width2 = ((double) bitmapCreateBitmap.getWidth()) / 4.0d;
                    double height2 = ((double) bitmapCreateBitmap.getHeight()) / 4.0d;
                    Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                    Mat mat7 = new Mat();
                    Utils.bitmapToMat(bitmapSource, mat7);
                    Mat mat8 = new Mat();
                    Imgproc.resize(mat7, mat8, new Size(width2, height2), 0.0d, 0.0d, 2);
                    Bitmap bitmapCreateBitmap4 = Bitmap.createBitmap(mat8.cols(), mat8.rows(), config);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap4, "createBitmap(...)");
                    Utils.matToBitmap(mat8, bitmapCreateBitmap4);
                    InputImage inputImageFromBitmap2 = InputImage.fromBitmap(t.b(bitmapCreateBitmap4), 0);
                    Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap2, "fromBitmap(...)");
                    AbstractC0094l.a.process(inputImageFromBitmap2).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda1
                        @Override // com.google.android.gms.tasks.OnCompleteListener
                        public final void onComplete(Task task) {
                            b.a(this.f$0, task);
                        }
                    });
                    return;
                }
                return;
            case 3:
                str = "any";
                this.f = str;
                this.g = false;
                BaseOptions.Builder modelAssetPath3 = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
                iA = AbstractC0085c.a(1);
                if (iA == 1) {
                    delegate = Delegate.CPU;
                } else {
                    delegate = Delegate.CPU;
                }
                modelAssetPath3.setDelegate(delegate);
                ImageClassifier.createFromOptions(mActivity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath3.build()).setMaxResults(3).build());
                Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
                if (mActivity.getAssets() != null) {
                    if (sharedPreferencesCreate == null) {
                        Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                        sharedPreferencesCreate = null;
                    }
                    File fileA3 = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
                    Intrinsics.checkNotNull(fileA3);
                    n = new N(mActivity, fileA3);
                } else {
                    n = null;
                }
                if (n != null) {
                    n.a();
                }
                if (this.e == null) {
                    Enhancement enhancement3 = new Enhancement(true);
                    this.e = enhancement3;
                    enhancement3.init(mActivity, "SuperResolution", Device.CPU, 4);
                }
                if (this.f.equals("dotmatrix_white")) {
                    break;
                }
                Bitmap bitmap4 = AbstractC0103s.a;
                Bitmap bitmapSource4 = lowLightResponseA.getBitmap();
                if (this.f.equals("dotmatrix_white")) {
                    d = 255.0d;
                } else {
                    d = 300.0d;
                }
                Intrinsics.checkNotNullParameter(bitmapSource4, "bitmapSource");
                Mat mat9 = new Mat();
                Utils.bitmapToMat(bitmapSource4, mat9);
                Mat mat10 = new Mat();
                Imgproc.resize(mat9, mat10, new Size(d, d), 0.0d, 0.0d, 2);
                int iCols3 = mat10.cols();
                int iRows3 = mat10.rows();
                config = Bitmap.Config.ARGB_8888;
                bitmapCreateBitmap = Bitmap.createBitmap(iCols3, iRows3, config);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                Utils.matToBitmap(mat10, bitmapCreateBitmap);
                if (bitmapCreateBitmap != null) {
                    if (this.f.equals("dotmatrix_white")) {
                        bitmapSource = r.b(bitmapCreateBitmap);
                    } else {
                        bitmapSource = r.a(bitmapCreateBitmap);
                    }
                    double width3 = ((double) bitmapCreateBitmap.getWidth()) / 4.0d;
                    double height3 = ((double) bitmapCreateBitmap.getHeight()) / 4.0d;
                    Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                    Mat mat11 = new Mat();
                    Utils.bitmapToMat(bitmapSource, mat11);
                    Mat mat12 = new Mat();
                    Imgproc.resize(mat11, mat12, new Size(width3, height3), 0.0d, 0.0d, 2);
                    Bitmap bitmapCreateBitmap5 = Bitmap.createBitmap(mat12.cols(), mat12.rows(), config);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap5, "createBitmap(...)");
                    Utils.matToBitmap(mat12, bitmapCreateBitmap5);
                    InputImage inputImageFromBitmap3 = InputImage.fromBitmap(t.b(bitmapCreateBitmap5), 0);
                    Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap3, "fromBitmap(...)");
                    AbstractC0094l.a.process(inputImageFromBitmap3).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda1
                        @Override // com.google.android.gms.tasks.OnCompleteListener
                        public final void onComplete(Task task) {
                            b.a(this.f$0, task);
                        }
                    });
                    return;
                }
                return;
            case 4:
                this.f = "any";
                this.g = true;
                this.h = false;
                BaseOptions.Builder modelAssetPath4 = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
                iA = AbstractC0085c.a(1);
                if (iA == 1) {
                    delegate = Delegate.CPU;
                } else {
                    delegate = Delegate.CPU;
                }
                modelAssetPath4.setDelegate(delegate);
                ImageClassifier.createFromOptions(mActivity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath4.build()).setMaxResults(3).build());
                Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
                if (mActivity.getAssets() != null) {
                    if (sharedPreferencesCreate == null) {
                        Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                        sharedPreferencesCreate = null;
                    }
                    File fileA4 = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
                    Intrinsics.checkNotNull(fileA4);
                    n = new N(mActivity, fileA4);
                } else {
                    n = null;
                }
                if (n != null) {
                    n.a();
                }
                if (this.e == null) {
                    Enhancement enhancement4 = new Enhancement(true);
                    this.e = enhancement4;
                    enhancement4.init(mActivity, "SuperResolution", Device.CPU, 4);
                }
                if (this.f.equals("dotmatrix_white")) {
                    break;
                }
                Bitmap bitmap5 = AbstractC0103s.a;
                Bitmap bitmapSource5 = lowLightResponseA.getBitmap();
                if (this.f.equals("dotmatrix_white")) {
                    d = 255.0d;
                } else {
                    d = 300.0d;
                }
                Intrinsics.checkNotNullParameter(bitmapSource5, "bitmapSource");
                Mat mat13 = new Mat();
                Utils.bitmapToMat(bitmapSource5, mat13);
                Mat mat14 = new Mat();
                Imgproc.resize(mat13, mat14, new Size(d, d), 0.0d, 0.0d, 2);
                int iCols4 = mat14.cols();
                int iRows4 = mat14.rows();
                config = Bitmap.Config.ARGB_8888;
                bitmapCreateBitmap = Bitmap.createBitmap(iCols4, iRows4, config);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                Utils.matToBitmap(mat14, bitmapCreateBitmap);
                if (bitmapCreateBitmap != null) {
                    if (this.f.equals("dotmatrix_white")) {
                        bitmapSource = r.b(bitmapCreateBitmap);
                    } else {
                        bitmapSource = r.a(bitmapCreateBitmap);
                    }
                    double width4 = ((double) bitmapCreateBitmap.getWidth()) / 4.0d;
                    double height4 = ((double) bitmapCreateBitmap.getHeight()) / 4.0d;
                    Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                    Mat mat15 = new Mat();
                    Utils.bitmapToMat(bitmapSource, mat15);
                    Mat mat16 = new Mat();
                    Imgproc.resize(mat15, mat16, new Size(width4, height4), 0.0d, 0.0d, 2);
                    Bitmap bitmapCreateBitmap6 = Bitmap.createBitmap(mat16.cols(), mat16.rows(), config);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap6, "createBitmap(...)");
                    Utils.matToBitmap(mat16, bitmapCreateBitmap6);
                    InputImage inputImageFromBitmap4 = InputImage.fromBitmap(t.b(bitmapCreateBitmap6), 0);
                    Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap4, "fromBitmap(...)");
                    AbstractC0094l.a.process(inputImageFromBitmap4).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda1
                        @Override // com.google.android.gms.tasks.OnCompleteListener
                        public final void onComplete(Task task) {
                            b.a(this.f$0, task);
                        }
                    });
                    return;
                }
                return;
            case 5:
                this.f = "any";
                this.g = true;
                this.h = true;
                BaseOptions.Builder modelAssetPath5 = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
                iA = AbstractC0085c.a(1);
                if (iA == 1) {
                    delegate = Delegate.CPU;
                } else {
                    delegate = Delegate.CPU;
                }
                modelAssetPath5.setDelegate(delegate);
                ImageClassifier.createFromOptions(mActivity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath5.build()).setMaxResults(3).build());
                Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
                if (mActivity.getAssets() != null) {
                    if (sharedPreferencesCreate == null) {
                        Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                        sharedPreferencesCreate = null;
                    }
                    File fileA5 = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
                    Intrinsics.checkNotNull(fileA5);
                    n = new N(mActivity, fileA5);
                } else {
                    n = null;
                }
                if (n != null) {
                    n.a();
                }
                if (this.e == null) {
                    Enhancement enhancement5 = new Enhancement(true);
                    this.e = enhancement5;
                    enhancement5.init(mActivity, "SuperResolution", Device.CPU, 4);
                }
                if (this.f.equals("dotmatrix_white")) {
                    break;
                }
                Bitmap bitmap6 = AbstractC0103s.a;
                Bitmap bitmapSource6 = lowLightResponseA.getBitmap();
                if (this.f.equals("dotmatrix_white")) {
                    d = 255.0d;
                } else {
                    d = 300.0d;
                }
                Intrinsics.checkNotNullParameter(bitmapSource6, "bitmapSource");
                Mat mat17 = new Mat();
                Utils.bitmapToMat(bitmapSource6, mat17);
                Mat mat18 = new Mat();
                Imgproc.resize(mat17, mat18, new Size(d, d), 0.0d, 0.0d, 2);
                int iCols5 = mat18.cols();
                int iRows5 = mat18.rows();
                config = Bitmap.Config.ARGB_8888;
                bitmapCreateBitmap = Bitmap.createBitmap(iCols5, iRows5, config);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                Utils.matToBitmap(mat18, bitmapCreateBitmap);
                if (bitmapCreateBitmap != null) {
                    if (this.f.equals("dotmatrix_white")) {
                        bitmapSource = r.b(bitmapCreateBitmap);
                    } else {
                        bitmapSource = r.a(bitmapCreateBitmap);
                    }
                    double width5 = ((double) bitmapCreateBitmap.getWidth()) / 4.0d;
                    double height5 = ((double) bitmapCreateBitmap.getHeight()) / 4.0d;
                    Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                    Mat mat19 = new Mat();
                    Utils.bitmapToMat(bitmapSource, mat19);
                    Mat mat110 = new Mat();
                    Imgproc.resize(mat19, mat110, new Size(width5, height5), 0.0d, 0.0d, 2);
                    Bitmap bitmapCreateBitmap7 = Bitmap.createBitmap(mat110.cols(), mat110.rows(), config);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap7, "createBitmap(...)");
                    Utils.matToBitmap(mat110, bitmapCreateBitmap7);
                    InputImage inputImageFromBitmap5 = InputImage.fromBitmap(t.b(bitmapCreateBitmap7), 0);
                    Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap5, "fromBitmap(...)");
                    AbstractC0094l.a.process(inputImageFromBitmap5).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda1
                        @Override // com.google.android.gms.tasks.OnCompleteListener
                        public final void onComplete(Task task) {
                            b.a(this.f$0, task);
                        }
                    });
                    return;
                }
                return;
            case 6:
                this.f = "any";
                this.g = false;
                this.i = true;
                BaseOptions.Builder modelAssetPath6 = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
                iA = AbstractC0085c.a(1);
                if (iA == 1) {
                    delegate = Delegate.CPU;
                } else {
                    delegate = Delegate.CPU;
                }
                modelAssetPath6.setDelegate(delegate);
                ImageClassifier.createFromOptions(mActivity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath6.build()).setMaxResults(3).build());
                Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
                if (mActivity.getAssets() != null) {
                    if (sharedPreferencesCreate == null) {
                        Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                        sharedPreferencesCreate = null;
                    }
                    File fileA6 = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
                    Intrinsics.checkNotNull(fileA6);
                    n = new N(mActivity, fileA6);
                } else {
                    n = null;
                }
                if (n != null) {
                    n.a();
                }
                if (this.e == null) {
                    Enhancement enhancement6 = new Enhancement(true);
                    this.e = enhancement6;
                    enhancement6.init(mActivity, "SuperResolution", Device.CPU, 4);
                }
                if (this.f.equals("dotmatrix_white")) {
                    break;
                }
                Bitmap bitmap7 = AbstractC0103s.a;
                Bitmap bitmapSource7 = lowLightResponseA.getBitmap();
                if (this.f.equals("dotmatrix_white")) {
                    d = 255.0d;
                } else {
                    d = 300.0d;
                }
                Intrinsics.checkNotNullParameter(bitmapSource7, "bitmapSource");
                Mat mat111 = new Mat();
                Utils.bitmapToMat(bitmapSource7, mat111);
                Mat mat112 = new Mat();
                Imgproc.resize(mat111, mat112, new Size(d, d), 0.0d, 0.0d, 2);
                int iCols6 = mat112.cols();
                int iRows6 = mat112.rows();
                config = Bitmap.Config.ARGB_8888;
                bitmapCreateBitmap = Bitmap.createBitmap(iCols6, iRows6, config);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                Utils.matToBitmap(mat112, bitmapCreateBitmap);
                if (bitmapCreateBitmap != null) {
                    if (this.f.equals("dotmatrix_white")) {
                        bitmapSource = r.b(bitmapCreateBitmap);
                    } else {
                        bitmapSource = r.a(bitmapCreateBitmap);
                    }
                    double width6 = ((double) bitmapCreateBitmap.getWidth()) / 4.0d;
                    double height6 = ((double) bitmapCreateBitmap.getHeight()) / 4.0d;
                    Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                    Mat mat113 = new Mat();
                    Utils.bitmapToMat(bitmapSource, mat113);
                    Mat mat114 = new Mat();
                    Imgproc.resize(mat113, mat114, new Size(width6, height6), 0.0d, 0.0d, 2);
                    Bitmap bitmapCreateBitmap8 = Bitmap.createBitmap(mat114.cols(), mat114.rows(), config);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap8, "createBitmap(...)");
                    Utils.matToBitmap(mat114, bitmapCreateBitmap8);
                    InputImage inputImageFromBitmap6 = InputImage.fromBitmap(t.b(bitmapCreateBitmap8), 0);
                    Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap6, "fromBitmap(...)");
                    AbstractC0094l.a.process(inputImageFromBitmap6).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda1
                        @Override // com.google.android.gms.tasks.OnCompleteListener
                        public final void onComplete(Task task) {
                            b.a(this.f$0, task);
                        }
                    });
                    return;
                }
                return;
            case 7:
                str = "dotmatrix_white";
                this.f = str;
                this.g = false;
                BaseOptions.Builder modelAssetPath7 = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
                iA = AbstractC0085c.a(1);
                if (iA == 1) {
                    delegate = Delegate.CPU;
                } else {
                    delegate = Delegate.CPU;
                }
                modelAssetPath7.setDelegate(delegate);
                ImageClassifier.createFromOptions(mActivity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath7.build()).setMaxResults(3).build());
                Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
                if (mActivity.getAssets() != null) {
                    if (sharedPreferencesCreate == null) {
                        Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                        sharedPreferencesCreate = null;
                    }
                    File fileA7 = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
                    Intrinsics.checkNotNull(fileA7);
                    n = new N(mActivity, fileA7);
                } else {
                    n = null;
                }
                if (n != null) {
                    n.a();
                }
                if (this.e == null) {
                    Enhancement enhancement7 = new Enhancement(true);
                    this.e = enhancement7;
                    enhancement7.init(mActivity, "SuperResolution", Device.CPU, 4);
                }
                if (this.f.equals("dotmatrix_white")) {
                    break;
                }
                Bitmap bitmap8 = AbstractC0103s.a;
                Bitmap bitmapSource8 = lowLightResponseA.getBitmap();
                if (this.f.equals("dotmatrix_white")) {
                    d = 255.0d;
                } else {
                    d = 300.0d;
                }
                Intrinsics.checkNotNullParameter(bitmapSource8, "bitmapSource");
                Mat mat115 = new Mat();
                Utils.bitmapToMat(bitmapSource8, mat115);
                Mat mat116 = new Mat();
                Imgproc.resize(mat115, mat116, new Size(d, d), 0.0d, 0.0d, 2);
                int iCols7 = mat116.cols();
                int iRows7 = mat116.rows();
                config = Bitmap.Config.ARGB_8888;
                bitmapCreateBitmap = Bitmap.createBitmap(iCols7, iRows7, config);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                Utils.matToBitmap(mat116, bitmapCreateBitmap);
                if (bitmapCreateBitmap != null) {
                    if (this.f.equals("dotmatrix_white")) {
                        bitmapSource = r.b(bitmapCreateBitmap);
                    } else {
                        bitmapSource = r.a(bitmapCreateBitmap);
                    }
                    double width7 = ((double) bitmapCreateBitmap.getWidth()) / 4.0d;
                    double height7 = ((double) bitmapCreateBitmap.getHeight()) / 4.0d;
                    Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                    Mat mat117 = new Mat();
                    Utils.bitmapToMat(bitmapSource, mat117);
                    Mat mat118 = new Mat();
                    Imgproc.resize(mat117, mat118, new Size(width7, height7), 0.0d, 0.0d, 2);
                    Bitmap bitmapCreateBitmap9 = Bitmap.createBitmap(mat118.cols(), mat118.rows(), config);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap9, "createBitmap(...)");
                    Utils.matToBitmap(mat118, bitmapCreateBitmap9);
                    InputImage inputImageFromBitmap7 = InputImage.fromBitmap(t.b(bitmapCreateBitmap9), 0);
                    Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap7, "fromBitmap(...)");
                    AbstractC0094l.a.process(inputImageFromBitmap7).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda1
                        @Override // com.google.android.gms.tasks.OnCompleteListener
                        public final void onComplete(Task task) {
                            b.a(this.f$0, task);
                        }
                    });
                    return;
                }
                return;
            case 8:
                str = "dotmatrix_metal";
                this.f = str;
                this.g = false;
                BaseOptions.Builder modelAssetPath8 = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
                iA = AbstractC0085c.a(1);
                if (iA == 1) {
                    delegate = Delegate.CPU;
                } else {
                    delegate = Delegate.CPU;
                }
                modelAssetPath8.setDelegate(delegate);
                ImageClassifier.createFromOptions(mActivity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath8.build()).setMaxResults(3).build());
                Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
                if (mActivity.getAssets() != null) {
                    if (sharedPreferencesCreate == null) {
                        Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                        sharedPreferencesCreate = null;
                    }
                    File fileA8 = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
                    Intrinsics.checkNotNull(fileA8);
                    n = new N(mActivity, fileA8);
                } else {
                    n = null;
                }
                if (n != null) {
                    n.a();
                }
                if (this.e == null) {
                    Enhancement enhancement8 = new Enhancement(true);
                    this.e = enhancement8;
                    enhancement8.init(mActivity, "SuperResolution", Device.CPU, 4);
                }
                if (this.f.equals("dotmatrix_white")) {
                    break;
                }
                Bitmap bitmap9 = AbstractC0103s.a;
                Bitmap bitmapSource9 = lowLightResponseA.getBitmap();
                if (this.f.equals("dotmatrix_white")) {
                    d = 255.0d;
                } else {
                    d = 300.0d;
                }
                Intrinsics.checkNotNullParameter(bitmapSource9, "bitmapSource");
                Mat mat119 = new Mat();
                Utils.bitmapToMat(bitmapSource9, mat119);
                Mat mat1110 = new Mat();
                Imgproc.resize(mat119, mat1110, new Size(d, d), 0.0d, 0.0d, 2);
                int iCols8 = mat1110.cols();
                int iRows8 = mat1110.rows();
                config = Bitmap.Config.ARGB_8888;
                bitmapCreateBitmap = Bitmap.createBitmap(iCols8, iRows8, config);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                Utils.matToBitmap(mat1110, bitmapCreateBitmap);
                if (bitmapCreateBitmap != null) {
                    if (this.f.equals("dotmatrix_white")) {
                        bitmapSource = r.b(bitmapCreateBitmap);
                    } else {
                        bitmapSource = r.a(bitmapCreateBitmap);
                    }
                    double width8 = ((double) bitmapCreateBitmap.getWidth()) / 4.0d;
                    double height8 = ((double) bitmapCreateBitmap.getHeight()) / 4.0d;
                    Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                    Mat mat1111 = new Mat();
                    Utils.bitmapToMat(bitmapSource, mat1111);
                    Mat mat1112 = new Mat();
                    Imgproc.resize(mat1111, mat1112, new Size(width8, height8), 0.0d, 0.0d, 2);
                    Bitmap bitmapCreateBitmap10 = Bitmap.createBitmap(mat1112.cols(), mat1112.rows(), config);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap10, "createBitmap(...)");
                    Utils.matToBitmap(mat1112, bitmapCreateBitmap10);
                    InputImage inputImageFromBitmap8 = InputImage.fromBitmap(t.b(bitmapCreateBitmap10), 0);
                    Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap8, "fromBitmap(...)");
                    AbstractC0094l.a.process(inputImageFromBitmap8).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda1
                        @Override // com.google.android.gms.tasks.OnCompleteListener
                        public final void onComplete(Task task) {
                            b.a(this.f$0, task);
                        }
                    });
                    return;
                }
                return;
            default:
                throw new NoWhenBranchMatchedException();
        }
    }

    public static final void a(b this$0, Task it) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        Intrinsics.checkNotNullParameter(it, "it");
        if (it.isSuccessful() && ((List) it.getResult()).size() > 0 && ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue() != null) {
            String displayValue = ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue();
            Intrinsics.checkNotNull(displayValue);
            if (displayValue.length() != 0) {
                Log.v("qrResult", "qrResult ML- " + ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue());
                String displayValue2 = ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue();
                Intrinsics.checkNotNull(displayValue2);
                ScanResultSuccess scanResultSuccess = new ScanResultSuccess(displayValue2, BarcodeFormat.QR_CODE, true, new ArrayList(), new RectF(), "QR_CODE");
                BeepManager beepManager = this$0.j;
                if (beepManager != null) {
                    beepManager.playBeepSoundAndVibrate();
                }
                SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this$0.a;
                if (onBarcodeScanResultCallback != null) {
                    onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
                    return;
                }
                return;
            }
        }
        Log.v("qrResult", "qrResult - failed");
        this$0.a();
    }

    @Override // com.scanflow.datacapture.barcode.SFBarcodeReader
    public final SFBarcodeReader setOnBarcodeScanResultCallback(SFBarcodeReader.OnBarcodeScanResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.a = callback;
        return this;
    }

    public static double a(Point p1, Point p2) {
        Intrinsics.checkNotNullParameter(p1, "p1");
        Intrinsics.checkNotNullParameter(p2, "p2");
        double degrees = Math.toDegrees(Math.atan2(p1.y - p2.y, p2.x - p1.x));
        return degrees < 0.0d ? degrees + 360.0d : degrees;
    }

    public static BarcodeFormat a(int i) {
        if (i == 1) {
            return BarcodeFormat.CODE_128;
        }
        if (i == 2) {
            return BarcodeFormat.CODE_39;
        }
        switch (i) {
            case 4:
                return BarcodeFormat.CODE_93;
            case 8:
                return BarcodeFormat.CODABAR;
            case 16:
                return BarcodeFormat.DATA_MATRIX;
            case 32:
                return BarcodeFormat.EAN_13;
            case 64:
                return BarcodeFormat.EAN_8;
            case 128:
                return BarcodeFormat.ITF;
            case 256:
                return BarcodeFormat.QR_CODE;
            case 512:
                return BarcodeFormat.UPC_A;
            case 1024:
                return BarcodeFormat.UPC_E;
            case 2048:
                return BarcodeFormat.PDF_417;
            case 4096:
                return BarcodeFormat.AZTEC;
            default:
                return BarcodeFormat.CODE_128;
        }
    }

    public final void a(final Bitmap bitmap, final C0084b c0084b, final boolean z) {
        InputImage inputImageFromBitmap = InputImage.fromBitmap(t.a(bitmap), 0);
        Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap, "fromBitmap(...)");
        AbstractC0094l.a.process(inputImageFromBitmap).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.barcode.b$$ExternalSyntheticLambda0
            @Override // com.google.android.gms.tasks.OnCompleteListener
            public final void onComplete(Task task) {
                b.a(z, bitmap, this, c0084b, task);
            }
        });
    }

    public static final void a(boolean z, Bitmap croppedBitmap, b this$0, C0084b result, Task it) {
        int i;
        int i2;
        boolean z2;
        double dA;
        String displayValue;
        Point point;
        Point point2;
        Intrinsics.checkNotNullParameter(croppedBitmap, "$croppedBitmap");
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        Intrinsics.checkNotNullParameter(result, "$result");
        Intrinsics.checkNotNullParameter(it, "it");
        if (it.isSuccessful() && ((List) it.getResult()).size() > 0 && ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue() != null) {
            String displayValue2 = ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue();
            Intrinsics.checkNotNull(displayValue2);
            if (displayValue2.length() != 0) {
                int format = ((Barcode) ((List) it.getResult()).get(0)).getFormat();
                ArrayList arrayList = new ArrayList();
                int i3 = z ? 2 : 1;
                Point[] cornerPoints = ((Barcode) ((List) it.getResult()).get(0)).getCornerPoints();
                if (cornerPoints != null) {
                    Point point3 = cornerPoints[0];
                    arrayList.add(new PointF(new Point(point3.x / i3, point3.y / i3)));
                    Point point4 = cornerPoints[1];
                    arrayList.add(new PointF(new Point(point4.x / i3, point4.y / i3)));
                    Point point5 = cornerPoints[2];
                    arrayList.add(new PointF(new Point(point5.x / i3, point5.y / i3)));
                    Point point6 = cornerPoints[3];
                    arrayList.add(new PointF(new Point(point6.x / i3, point6.y / i3)));
                }
                Point[] cornerPoints2 = ((Barcode) ((List) it.getResult()).get(0)).getCornerPoints();
                if (cornerPoints2 != null) {
                    Point point7 = cornerPoints2[0];
                    double d = point7.x;
                    z2 = true;
                    int i4 = i3;
                    double d2 = point7.y;
                    Point point8 = cornerPoints2[1];
                    i2 = 0;
                    double d3 = point8.x;
                    double d4 = point8.y;
                    this$0.getClass();
                    double d5 = 2;
                    double dSqrt = Math.sqrt(Math.pow(d4 - d2, d5) + Math.pow(d3 - d, d5));
                    Point point9 = cornerPoints2[1];
                    i = format;
                    double d6 = point9.x;
                    double d7 = point9.y;
                    Point point10 = cornerPoints2[2];
                    double dSqrt2 = Math.sqrt(Math.pow(((double) point10.y) - d7, d5) + Math.pow(point10.x - d6, d5));
                    Log.v("SFBarcode", "Calculate Distance - " + dSqrt + ' ' + dSqrt2);
                    if (dSqrt > dSqrt2) {
                        Point point11 = cornerPoints2[0];
                        point = new Point(point11.x / i4, point11.y / i4);
                        Point point12 = cornerPoints2[1];
                        point2 = new Point(point12.x / i4, point12.y / i4);
                    } else {
                        Point point13 = cornerPoints2[1];
                        point = new Point(point13.x / i4, point13.y / i4);
                        Point point14 = cornerPoints2[2];
                        point2 = new Point(point14.x / i4, point14.y / i4);
                    }
                    dA = a(point, point2);
                } else {
                    i = format;
                    i2 = 0;
                    z2 = true;
                    dA = 0.0d;
                }
                Intrinsics.checkNotNullParameter(croppedBitmap, "croppedBitmap");
                Bitmap croppedBitmap2 = Bitmap.createBitmap(croppedBitmap.getWidth() + 50, croppedBitmap.getHeight() + 50, Bitmap.Config.ARGB_8888);
                Intrinsics.checkNotNullExpressionValue(croppedBitmap2, "createBitmap(...)");
                Canvas canvas = new Canvas(croppedBitmap2);
                canvas.drawColor(-1, PorterDuff.Mode.LIGHTEN);
                Paint paint = new Paint();
                boolean z3 = z2;
                paint.setAntiAlias(z3);
                paint.setFilterBitmap(z3);
                paint.setDither(z3);
                float f = 25;
                canvas.drawBitmap(croppedBitmap, f, f, paint);
                Intrinsics.checkNotNullParameter(croppedBitmap2, "croppedBitmap");
                Matrix matrix = new Matrix();
                matrix.postRotate((float) dA);
                Bitmap bitmapCreateScaledBitmap = Bitmap.createScaledBitmap(croppedBitmap2, croppedBitmap2.getWidth(), croppedBitmap2.getHeight(), z3);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateScaledBitmap, "createScaledBitmap(...)");
                Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmapCreateScaledBitmap, 0, 0, bitmapCreateScaledBitmap.getWidth(), bitmapCreateScaledBitmap.getHeight(), matrix, true);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                if (((Barcode) ((List) it.getResult()).get(i2)).getFormat() == 2) {
                    BarcodeScanner barcodeScanner = AbstractC0094l.a;
                    Log.v("SFBarcode", "decodeZxing - Started");
                    new ArrayList();
                    int[] iArr = new int[bitmapCreateBitmap.getHeight() * bitmapCreateBitmap.getWidth()];
                    bitmapCreateBitmap.getPixels(iArr, 0, bitmapCreateBitmap.getWidth(), 0, 0, bitmapCreateBitmap.getWidth(), bitmapCreateBitmap.getHeight());
                    RGBLuminanceSource rGBLuminanceSource = new RGBLuminanceSource(bitmapCreateBitmap.getWidth(), bitmapCreateBitmap.getHeight(), iArr);
                    HybridBinarizer hybridBinarizer = new HybridBinarizer(rGBLuminanceSource);
                    MultiFormatReader multiFormatReader = new MultiFormatReader();
                    HashMap map = new HashMap();
                    map.put(DecodeHintType.PURE_BARCODE, Boolean.TRUE);
                    multiFormatReader.setHints(map);
                    try {
                        try {
                            Result resultDecode = multiFormatReader.decode(new BinaryBitmap(hybridBinarizer), map);
                            if (resultDecode == null) {
                                resultDecode = multiFormatReader.decode(new BinaryBitmap(new GlobalHistogramBinarizer(rGBLuminanceSource)), map);
                            }
                            multiFormatReader.reset();
                            if (resultDecode == null) {
                                LuminanceSource luminanceSourceInvert = rGBLuminanceSource.invert();
                                try {
                                    try {
                                        Result resultDecodeWithState = multiFormatReader.decodeWithState(new BinaryBitmap(new HybridBinarizer(luminanceSourceInvert)));
                                        resultDecode = resultDecodeWithState == null ? multiFormatReader.decodeWithState(new BinaryBitmap(new GlobalHistogramBinarizer(luminanceSourceInvert))) : resultDecodeWithState;
                                        Log.v("White_points_inverted", resultDecode.getResultPoints()[0].toString());
                                        multiFormatReader.reset();
                                    } catch (Throwable th) {
                                        multiFormatReader.reset();
                                        throw th;
                                    }
                                } catch (Exception unused) {
                                    Log.v("processModelResultZxing", "Exception - 1");
                                    multiFormatReader.reset();
                                    displayValue = null;
                                }
                            }
                            String text = resultDecode.getText();
                            if (text != null) {
                                Log.v("processModelResultZxing", "decodeZxing - ".concat(text));
                            }
                            Log.v("SFBarcode", "decodeZxing - Completed");
                            displayValue = resultDecode.getText();
                        } catch (Exception unused2) {
                            Log.v("processModelResultZxing", "Exception - 0");
                        }
                    } catch (Throwable th2) {
                        multiFormatReader.reset();
                        throw th2;
                    }
                } else {
                    displayValue = ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue();
                }
                String str = displayValue;
                if (str != null) {
                    this$0.getClass();
                    ScanResultSuccess scanResultSuccess = new ScanResultSuccess(str, a(i), z, arrayList, result.d, result.b);
                    boolean z4 = this$0.g;
                    if (z4 && !this$0.h) {
                        ArrayList<ScanResultSuccess> arrayList2 = new ArrayList<>();
                        arrayList2.add(scanResultSuccess);
                        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this$0.a;
                        if (onBarcodeScanResultCallback != null) {
                            onBarcodeScanResultCallback.onBatchScanResultSuccess(arrayList2);
                        }
                    } else if (z4 && this$0.h) {
                        OneOFManyCodesScanResults oneOFManyCodesScanResults = new OneOFManyCodesScanResults(scanResultSuccess.getText(), scanResultSuccess.getBarcodeFormat().name());
                        this$0.p.add(oneOFManyCodesScanResults);
                        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback2 = this$0.a;
                        if (onBarcodeScanResultCallback2 != null) {
                            onBarcodeScanResultCallback2.onOneOfManyCodeResult(this$0.p);
                        }
                        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback3 = this$0.a;
                        if (onBarcodeScanResultCallback3 != null) {
                            onBarcodeScanResultCallback3.onOneofManyCodeSelected(oneOFManyCodesScanResults);
                        }
                    } else {
                        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback4 = this$0.a;
                        if (onBarcodeScanResultCallback4 != null) {
                            onBarcodeScanResultCallback4.onScanResultSuccess(scanResultSuccess);
                        }
                    }
                    BeepManager beepManager = this$0.j;
                    if (beepManager != null) {
                        beepManager.playBeepSoundAndVibrate();
                    }
                    this$0.o.add(result);
                    croppedBitmap.recycle();
                    return;
                }
            }
        }
        this$0.a();
    }

    public final void a(Bitmap bitmap, C0084b c0084b, y yVar, boolean z, int i, boolean z2) {
        boolean z3;
        BarcodeScanner barcodeScanner = AbstractC0094l.a;
        String str = c0084b.b;
        RectF rectF = c0084b.d;
        new ArrayList();
        ScanResultSuccess scanResultSuccess = null;
        GrayU8 grayU8BitmapToGray = ConvertBitmap.bitmapToGray(bitmap, null, null);
        Intrinsics.checkNotNullExpressionValue(grayU8BitmapToGray, "bitmapToGray(...)");
        QrCodePreciseDetector qrCodePreciseDetectorQrcode = FactoryFiducial.qrcode(new ConfigQrCode(), GrayU8.class);
        Intrinsics.checkNotNullExpressionValue(qrCodePreciseDetectorQrcode, "qrcode(...)");
        qrCodePreciseDetectorQrcode.process(grayU8BitmapToGray);
        List detections = qrCodePreciseDetectorQrcode.getDetections();
        if (detections.size() > 0) {
            String str2 = ((QrCode) detections.get(0)).message;
            Polygon2D_F64 polygon2D_F64 = ((QrCode) detections.get(0)).bounds;
            ArrayList arrayList = new ArrayList();
            arrayList.add(new PointF((float) polygon2D_F64.get(0).x, (float) polygon2D_F64.get(0).y));
            arrayList.add(new PointF((float) polygon2D_F64.get(1).x, (float) polygon2D_F64.get(1).y));
            arrayList.add(new PointF((float) polygon2D_F64.get(2).x, (float) polygon2D_F64.get(2).y));
            arrayList.add(new PointF((float) polygon2D_F64.get(3).x, (float) polygon2D_F64.get(3).y));
            Intrinsics.checkNotNull(str2);
            z3 = z;
            scanResultSuccess = new ScanResultSuccess(str2, BarcodeFormat.QR_CODE, z3, arrayList, rectF, str);
        } else {
            z3 = z;
        }
        if (scanResultSuccess == null) {
            a(bitmap, c0084b, z3);
            return;
        }
        BeepManager beepManager = this.j;
        if (beepManager != null) {
            beepManager.playBeepSoundAndVibrate();
        }
        this.o.add(c0084b);
        y yVar2 = y.INITIAL;
        bitmap.recycle();
        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this.a;
        if (onBarcodeScanResultCallback != null) {
            onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
        }
    }

    public final void a(C0084b c0084b, LowLightResponse lowLightResponse) {
        Matrix matrix = this.m;
        if (matrix != null) {
            matrix.mapRect(c0084b.d);
        }
        Log.v(this.b, "Result Location: " + c0084b + ".location");
        Bitmap bitmap = lowLightResponse.getBitmap();
        if (bitmap == null) {
            a();
            return;
        }
        if (c0084b.b.equals("qr_code")) {
            y yVar = y.INITIAL;
            ScanflowLog scanflowLog = ScanflowLog.INSTANCE;
            scanflowLog.v(this.b, "IsLongDistanceImage: false");
            scanflowLog.v(this.b, "Is Long Distance Image : false");
            a(bitmap, c0084b, yVar, false, 1, lowLightResponse.isLowLight());
            return;
        }
        y yVar2 = y.INITIAL;
        ScanflowLog.INSTANCE.v(this.b, "IsLongDistanceImage: false");
        lowLightResponse.isLowLight();
        a(bitmap, c0084b, false);
    }

    public final void a() {
        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this.a;
        if (onBarcodeScanResultCallback != null) {
            onBarcodeScanResultCallback.onScanResultFailure("Scan Failed!");
        }
    }
}
