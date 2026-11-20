package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params;

import android.hardware.camera2.params.DynamicRangeProfiles;
import androidx.camera.core.DynamicRange;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.Collections;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
class DynamicRangesCompatBaseImpl implements DynamicRangesCompat.DynamicRangeProfilesCompatImpl {
    static final DynamicRangesCompat COMPAT_INSTANCE = new DynamicRangesCompat(new DynamicRangesCompatBaseImpl());
    private static final Set SDR_ONLY = Collections.singleton(DynamicRange.SDR);

    DynamicRangesCompatBaseImpl() {
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.DynamicRangesCompat.DynamicRangeProfilesCompatImpl
    public Set getDynamicRangeCaptureRequestConstraints(DynamicRange dynamicRange) {
        Preconditions.checkArgument(DynamicRange.SDR.equals(dynamicRange), "DynamicRange is not supported: " + dynamicRange);
        return SDR_ONLY;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.DynamicRangesCompat.DynamicRangeProfilesCompatImpl
    public Set getSupportedDynamicRanges() {
        return SDR_ONLY;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.params.DynamicRangesCompat.DynamicRangeProfilesCompatImpl
    public DynamicRangeProfiles unwrap() {
        return null;
    }
}
