package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params;

import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
abstract class OutputConfigurationCompatBaseImpl implements OutputConfigurationCompat.OutputConfigurationCompatImpl {
    final Object mObject;

    OutputConfigurationCompatBaseImpl(Object obj) {
        this.mObject = obj;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public void setMirrorMode(int i) {
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.OutputConfigurationCompat.OutputConfigurationCompatImpl
    public void setStreamUseCase(long j) {
    }

    public boolean equals(Object obj) {
        if (obj instanceof OutputConfigurationCompatBaseImpl) {
            return Objects.equals(this.mObject, ((OutputConfigurationCompatBaseImpl) obj).mObject);
        }
        return false;
    }

    public int hashCode() {
        return this.mObject.hashCode();
    }
}
