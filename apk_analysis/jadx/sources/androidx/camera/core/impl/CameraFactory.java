package androidx.camera.core.impl;

import android.content.Context;
import androidx.camera.core.CameraSelector;
import com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent.CameraCoordinator;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public interface CameraFactory {

    public interface Provider {
        CameraFactory newInstance(Context context, CameraThreadConfig cameraThreadConfig, CameraSelector cameraSelector, long j);
    }

    Set getAvailableCameraIds();

    CameraInternal getCamera(String str);

    CameraCoordinator getCameraCoordinator();

    Object getCameraManager();
}
