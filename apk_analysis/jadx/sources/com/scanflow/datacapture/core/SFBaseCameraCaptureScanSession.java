package com.scanflow.datacapture.core;

import android.app.Activity;
import com.scanflow.datacapture.barinternal.b.a;
import com.scanflow.datacapture.core.camera.BaseCameraCaptureScan;
import com.scanflow.datacapture.core.camera.ScanflowReader;
import com.scanflow.datacapture.core.camera.analyze.Analyzer;
import com.scanflow.datacapture.sfbarcode.SFCameraView;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class SFBaseCameraCaptureScanSession {
    public static final SFBaseCameraCaptureScanSession INSTANCE = new SFBaseCameraCaptureScanSession();

    private SFBaseCameraCaptureScanSession() {
    }

    public ScanflowReader createLicenseSession(Activity appContext, String SCANFLOW_LICENSE_KEY) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        return new BaseCameraCaptureScan(appContext, SCANFLOW_LICENSE_KEY);
    }

    public ScanflowReader createScanSession(Activity activity, String SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, Analyzer<Object> analyzer) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        return new BaseCameraCaptureScan(activity, SCANFLOW_LICENSE_KEY, sfCameraView, analyzer);
    }

    public ScanflowReader createScanSession(Activity activity, String SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, Analyzer<Object> analyzer, float f) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        return new BaseCameraCaptureScan(activity, SCANFLOW_LICENSE_KEY, sfCameraView, analyzer, f);
    }

    public ScanflowReader createScanSession(Activity appContext, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sfcamera.SFCameraView sfCameraView, float f) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        return new BaseCameraCaptureScan(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, new a(appContext, sfCameraView, SCANFLOW_LICENSE_KEY), f);
    }

    public ScanflowReader createScanSession(Activity appContext, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sfcamera.SFCameraView sfCameraView, Analyzer<Object> analyzer, float f) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        return new BaseCameraCaptureScan(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, analyzer, f);
    }

    public ScanflowReader createScanSession(Activity appContext, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sfdocument.SFCameraView sfCameraView, Analyzer<Object> analyzer) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        return new BaseCameraCaptureScan(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, analyzer, 0.0f, 16, (DefaultConstructorMarker) null);
    }

    public ScanflowReader createScanSession(Activity appContext, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sfidcard.SFCameraView sfCameraView, Analyzer<Object> analyzer) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        return new BaseCameraCaptureScan(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, analyzer, 0.0f, 16, (DefaultConstructorMarker) null);
    }

    public ScanflowReader createScanSession(Activity appContext, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sftext.SFCameraView sfCameraView, Analyzer<Object> analyzer) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        return new BaseCameraCaptureScan(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, analyzer);
    }

    public ScanflowReader createScanSession(Activity appContext, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sftext.SFCameraView sfCameraView, Analyzer<Object> analyzer, float f) {
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        return new BaseCameraCaptureScan(appContext, SCANFLOW_LICENSE_KEY, sfCameraView, analyzer, f);
    }
}
