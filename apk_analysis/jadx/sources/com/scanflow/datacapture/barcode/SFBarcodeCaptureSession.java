package com.scanflow.datacapture.barcode;

import android.app.Activity;
import android.graphics.Bitmap;
import com.scanflow.datacapture.barcode.config.DecodeConfig;
import com.scanflow.datacapture.barinternal.M;
import com.scanflow.datacapture.core.SFBaseCameraCaptureScanSession;
import com.scanflow.datacapture.core.camera.ScanflowReader;
import com.scanflow.datacapture.sfbarcode.SFCameraView;
import java.util.HashSet;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class SFBarcodeCaptureSession {
    public static final SFBarcodeCaptureSession INSTANCE = new SFBarcodeCaptureSession();
    private static M sFBarcodeScannerAnalyzer;

    private SFBarcodeCaptureSession() {
    }

    public void changeScanMode(DecodeConfig decodeConfig) {
        Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
        M m = sFBarcodeScannerAnalyzer;
        if (m != null) {
            Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
            m.a(decodeConfig);
        }
    }

    public void clearMatrixScannedList() {
        M m = sFBarcodeScannerAnalyzer;
        if (m != null) {
            m.b0 = new HashSet();
        }
    }

    public ScanflowReader createScanSession(Activity appContext, String SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, DecodeConfig decodeConfig) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
        sFBarcodeScannerAnalyzer = new M(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, decodeConfig);
        SFBaseCameraCaptureScanSession sFBaseCameraCaptureScanSession = SFBaseCameraCaptureScanSession.INSTANCE;
        M m = sFBarcodeScannerAnalyzer;
        Intrinsics.checkNotNull(m, "null cannot be cast to non-null type com.scanflow.datacapture.core.camera.analyze.Analyzer<kotlin.Any>");
        return sFBaseCameraCaptureScanSession.createScanSession(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, m);
    }

    public SFBarcodeReader scanBitmap(Activity appContext, String SCANFLOW_LICENSE_KEY, DecodeConfig decodeConfig, SFBarcodeReader.OnBarcodeScanResultCallback callback, Bitmap bitmap) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
        Intrinsics.checkNotNullParameter(callback, "callback");
        Intrinsics.checkNotNullParameter(bitmap, "bitmap");
        return new b(appContext, SCANFLOW_LICENSE_KEY, decodeConfig, callback, bitmap);
    }

    public ScanflowReader createScanSession(Activity appContext, String SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, DecodeConfig decodeConfig, float f) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
        sFBarcodeScannerAnalyzer = new M(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, decodeConfig);
        SFBaseCameraCaptureScanSession sFBaseCameraCaptureScanSession = SFBaseCameraCaptureScanSession.INSTANCE;
        M m = sFBarcodeScannerAnalyzer;
        Intrinsics.checkNotNull(m, "null cannot be cast to non-null type com.scanflow.datacapture.core.camera.analyze.Analyzer<kotlin.Any>");
        return sFBaseCameraCaptureScanSession.createScanSession(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, m, f);
    }
}
