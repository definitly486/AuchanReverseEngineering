package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params;

import android.hardware.camera2.params.OutputConfiguration;
import android.view.Surface;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;

/* JADX INFO: loaded from: classes.dex */
public class OutputConfigurationCompatApi33Impl extends OutputConfigurationCompatApi28Impl {
    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi26Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public /* bridge */ /* synthetic */ void addSurface(Surface surface) {
        super.addSurface(surface);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi26Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public /* bridge */ /* synthetic */ void enableSurfaceSharing() {
        super.enableSurfaceSharing();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatBaseImpl
    public /* bridge */ /* synthetic */ boolean equals(Object obj) {
        return super.equals(obj);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi28Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi26Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public /* bridge */ /* synthetic */ String getPhysicalCameraId() {
        return super.getPhysicalCameraId();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi24Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public /* bridge */ /* synthetic */ Surface getSurface() {
        return super.getSurface();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatBaseImpl
    public /* bridge */ /* synthetic */ int hashCode() {
        return super.hashCode();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi28Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi26Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public /* bridge */ /* synthetic */ void setPhysicalCameraId(String str) {
        super.setPhysicalCameraId(str);
    }

    OutputConfigurationCompatApi33Impl(int i, Surface surface) {
        this(new OutputConfiguration(i, surface));
    }

    OutputConfigurationCompatApi33Impl(Object obj) {
        super(obj);
    }

    static OutputConfigurationCompatApi33Impl wrap(OutputConfiguration outputConfiguration) {
        return new OutputConfigurationCompatApi33Impl(outputConfiguration);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatBaseImpl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public void setMirrorMode(int i) {
        ((OutputConfiguration) getOutputConfiguration()).setMirrorMode(i);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi28Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi26Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public void setDynamicRangeProfile(long j) {
        ((OutputConfiguration) getOutputConfiguration()).setDynamicRangeProfile(j);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi28Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi26Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatApi24Impl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public Object getOutputConfiguration() {
        Preconditions.checkArgument(this.mObject instanceof OutputConfiguration);
        return this.mObject;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompatBaseImpl, com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public void setStreamUseCase(long j) {
        if (j == -1) {
            return;
        }
        ((OutputConfiguration) getOutputConfiguration()).setStreamUseCase(j);
    }
}
