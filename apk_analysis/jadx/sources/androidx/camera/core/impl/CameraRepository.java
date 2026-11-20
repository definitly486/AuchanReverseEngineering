package androidx.camera.core.impl;

import androidx.camera.core.CameraUnavailableException;
import androidx.camera.core.InitializationException;
import androidx.camera.core.Logger;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.LinkedHashSet;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public final class CameraRepository {
    private final Object mCamerasLock = new Object();
    private final Map mCameras = new LinkedHashMap();
    private final Set mReleasingCameras = new HashSet();

    public void init(CameraFactory cameraFactory) {
        synchronized (this.mCamerasLock) {
            try {
                for (String str : cameraFactory.getAvailableCameraIds()) {
                    Logger.d("CameraRepository", "Added camera: " + str);
                    this.mCameras.put(str, cameraFactory.getCamera(str));
                }
            } catch (CameraUnavailableException e) {
                throw new InitializationException(e);
            }
        }
    }

    public LinkedHashSet getCameras() {
        LinkedHashSet linkedHashSet;
        synchronized (this.mCamerasLock) {
            linkedHashSet = new LinkedHashSet(this.mCameras.values());
        }
        return linkedHashSet;
    }
}
