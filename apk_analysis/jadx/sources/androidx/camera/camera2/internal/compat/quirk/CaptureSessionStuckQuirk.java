package androidx.camera.camera2.internal.compat.quirk;

import android.hardware.camera2.CameraCharacteristics;
import androidx.camera.core.impl.Quirk;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCharacteristicsCompat;

/* JADX INFO: loaded from: classes.dex */
public class CaptureSessionStuckQuirk implements Quirk {
    static boolean load(CameraCharacteristicsCompat cameraCharacteristicsCompat) {
        Integer num = (Integer) cameraCharacteristicsCompat.get(CameraCharacteristics.INFO_SUPPORTED_HARDWARE_LEVEL);
        return num != null && num.intValue() == 2;
    }
}
