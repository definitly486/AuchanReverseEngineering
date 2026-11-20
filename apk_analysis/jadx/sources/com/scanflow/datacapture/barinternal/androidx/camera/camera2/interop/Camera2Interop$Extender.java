package com.scanflow.datacapture.barinternal.androidx.camera.camera2.interop;

import android.hardware.camera2.CaptureRequest;
import androidx.camera.core.ExtendableBuilder;
import androidx.camera.core.impl.Config;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.impl.Camera2ImplConfig;

/* JADX INFO: loaded from: classes.dex */
public final class Camera2Interop$Extender {
    ExtendableBuilder mBaseBuilder;

    public Camera2Interop$Extender(ExtendableBuilder extendableBuilder) {
        this.mBaseBuilder = extendableBuilder;
    }

    public Camera2Interop$Extender setCaptureRequestOption(CaptureRequest.Key key, Object obj) {
        this.mBaseBuilder.getMutableConfig().insertOption(Camera2ImplConfig.createCaptureRequestOption(key), Config.OptionPriority.ALWAYS_OVERRIDE, obj);
        return this;
    }
}
