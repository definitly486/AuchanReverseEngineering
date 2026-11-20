package com.scanflow.datacapture.barinternal.d;

import android.hardware.camera2.CaptureRequest;
import androidx.camera.core.ImageAnalysis;
import androidx.camera.core.Preview;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.interop.Camera2Interop$Extender;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class a {
    public static ImageAnalysis a(ImageAnalysis.Builder builder) {
        Intrinsics.checkNotNullParameter(builder, "builder");
        Camera2Interop$Extender camera2Interop$Extender = new Camera2Interop$Extender(builder);
        camera2Interop$Extender.setCaptureRequestOption(CaptureRequest.CONTROL_SCENE_MODE, 16);
        camera2Interop$Extender.setCaptureRequestOption(CaptureRequest.CONTROL_VIDEO_STABILIZATION_MODE, 1);
        camera2Interop$Extender.setCaptureRequestOption(CaptureRequest.LENS_OPTICAL_STABILIZATION_MODE, 1);
        ImageAnalysis imageAnalysisBuild = builder.build();
        Intrinsics.checkNotNullExpressionValue(imageAnalysisBuild, "build(...)");
        return imageAnalysisBuild;
    }

    public static Preview a(Preview.Builder builder) {
        Intrinsics.checkNotNullParameter(builder, "builder");
        Camera2Interop$Extender camera2Interop$Extender = new Camera2Interop$Extender(builder);
        camera2Interop$Extender.setCaptureRequestOption(CaptureRequest.CONTROL_SCENE_MODE, 16);
        camera2Interop$Extender.setCaptureRequestOption(CaptureRequest.CONTROL_VIDEO_STABILIZATION_MODE, 1);
        camera2Interop$Extender.setCaptureRequestOption(CaptureRequest.LENS_OPTICAL_STABILIZATION_MODE, 1);
        Preview previewBuild = builder.build();
        Intrinsics.checkNotNullExpressionValue(previewBuild, "build(...)");
        return previewBuild;
    }
}
