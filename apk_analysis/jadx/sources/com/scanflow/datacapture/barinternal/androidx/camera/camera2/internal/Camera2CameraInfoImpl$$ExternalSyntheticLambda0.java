package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.hardware.camera2.CameraCharacteristics;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCharacteristicsCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.CameraCharacteristicsProvider;

/* JADX INFO: compiled from: R8$$SyntheticClass */
/* JADX INFO: loaded from: classes.dex */
public final /* synthetic */ class Camera2CameraInfoImpl$$ExternalSyntheticLambda0 implements CameraCharacteristicsProvider {
    public final /* synthetic */ CameraCharacteristicsCompat f$0;

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.CameraCharacteristicsProvider
    public final Object get(CameraCharacteristics.Key key) {
        return this.f$0.get(key);
    }
}
