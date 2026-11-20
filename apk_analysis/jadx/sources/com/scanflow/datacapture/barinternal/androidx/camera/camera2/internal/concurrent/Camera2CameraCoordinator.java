package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.concurrent;

import androidx.camera.core.CameraInfo;
import androidx.camera.core.InitializationException;
import androidx.camera.core.Logger;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CameraIdUtil;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraAccessExceptionCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraManagerCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.interop.Camera2CameraInfo;
import com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent.CameraCoordinator;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public class Camera2CameraCoordinator implements CameraCoordinator {
    private final CameraManagerCompat mCameraManager;
    private int mCameraOperatingMode = 0;
    private final Map mConcurrentCameraIdMap = new HashMap();
    private Set mConcurrentCameraIds = new HashSet();
    private final List mConcurrentCameraModeListeners = new ArrayList();
    private List mActiveConcurrentCameraInfos = new ArrayList();

    public Camera2CameraCoordinator(CameraManagerCompat cameraManagerCompat) {
        this.mCameraManager = cameraManagerCompat;
        retrieveConcurrentCameraIds();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent.CameraCoordinator
    public String getPairedConcurrentCameraId(String str) {
        if (!this.mConcurrentCameraIdMap.containsKey(str)) {
            return null;
        }
        for (String str2 : (List) this.mConcurrentCameraIdMap.get(str)) {
            Iterator it = this.mActiveConcurrentCameraInfos.iterator();
            while (it.hasNext()) {
                if (str2.equals(Camera2CameraInfo.from((CameraInfo) it.next()).getCameraId())) {
                    return str2;
                }
            }
        }
        return null;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent.CameraCoordinator
    public int getCameraOperatingMode() {
        return this.mCameraOperatingMode;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent.CameraCoordinator
    public void setCameraOperatingMode(int i) {
        if (i != this.mCameraOperatingMode) {
            Iterator it = this.mConcurrentCameraModeListeners.iterator();
            while (it.hasNext()) {
                ((CameraCoordinator.ConcurrentCameraModeListener) it.next()).onCameraOperatingModeUpdated(this.mCameraOperatingMode, i);
            }
        }
        if (this.mCameraOperatingMode == 2 && i != 2) {
            this.mActiveConcurrentCameraInfos.clear();
        }
        this.mCameraOperatingMode = i;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent.CameraCoordinator
    public void addListener(CameraCoordinator.ConcurrentCameraModeListener concurrentCameraModeListener) {
        this.mConcurrentCameraModeListeners.add(concurrentCameraModeListener);
    }

    private void retrieveConcurrentCameraIds() {
        Set hashSet = new HashSet();
        try {
            hashSet = this.mCameraManager.getConcurrentCameraIds();
        } catch (CameraAccessExceptionCompat unused) {
            Logger.e("Camera2CameraCoordinator", "Failed to get concurrent camera ids");
        }
        Iterator it = hashSet.iterator();
        while (it.hasNext()) {
            ArrayList arrayList = new ArrayList((Set) it.next());
            if (arrayList.size() >= 2) {
                String str = (String) arrayList.get(0);
                String str2 = (String) arrayList.get(1);
                try {
                    if (CameraIdUtil.isBackwardCompatible(this.mCameraManager, str) && CameraIdUtil.isBackwardCompatible(this.mCameraManager, str2)) {
                        this.mConcurrentCameraIds.add(new HashSet(Arrays.asList(str, str2)));
                        if (!this.mConcurrentCameraIdMap.containsKey(str)) {
                            this.mConcurrentCameraIdMap.put(str, new ArrayList());
                        }
                        if (!this.mConcurrentCameraIdMap.containsKey(str2)) {
                            this.mConcurrentCameraIdMap.put(str2, new ArrayList());
                        }
                        ((List) this.mConcurrentCameraIdMap.get(str)).add((String) arrayList.get(1));
                        ((List) this.mConcurrentCameraIdMap.get(str2)).add((String) arrayList.get(0));
                    }
                } catch (InitializationException unused2) {
                    Logger.d("Camera2CameraCoordinator", "Concurrent camera id pair: (" + str + ", " + str2 + ") is not backward compatible");
                }
            }
        }
    }
}
