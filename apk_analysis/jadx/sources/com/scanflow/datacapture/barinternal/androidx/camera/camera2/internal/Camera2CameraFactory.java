package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.content.Context;
import androidx.camera.core.CameraSelector;
import androidx.camera.core.CameraUnavailableException;
import androidx.camera.core.Logger;
import androidx.camera.core.impl.CameraFactory;
import androidx.camera.core.impl.CameraInternal;
import androidx.camera.core.impl.CameraStateRegistry;
import androidx.camera.core.impl.CameraThreadConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraAccessExceptionCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraManagerCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.concurrent.Camera2CameraCoordinator;
import com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent.CameraCoordinator;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public final class Camera2CameraFactory implements CameraFactory {
    private final List mAvailableCameraIds;
    private final CameraCoordinator mCameraCoordinator;
    private final Map mCameraInfos = new HashMap();
    private final CameraManagerCompat mCameraManager;
    private final long mCameraOpenRetryMaxTimeoutInMs;
    private final CameraStateRegistry mCameraStateRegistry;
    private final Context mContext;
    private final DisplayInfoManager mDisplayInfoManager;
    private final CameraThreadConfig mThreadConfig;

    public Camera2CameraFactory(Context context, CameraThreadConfig cameraThreadConfig, CameraSelector cameraSelector, long j) {
        this.mContext = context;
        this.mThreadConfig = cameraThreadConfig;
        CameraManagerCompat cameraManagerCompatFrom = CameraManagerCompat.from(context, cameraThreadConfig.getSchedulerHandler());
        this.mCameraManager = cameraManagerCompatFrom;
        this.mDisplayInfoManager = DisplayInfoManager.getInstance(context);
        this.mAvailableCameraIds = getBackwardCompatibleCameraIds(CameraSelectionOptimizer.getSelectedAvailableCameraIds(this, cameraSelector));
        Camera2CameraCoordinator camera2CameraCoordinator = new Camera2CameraCoordinator(cameraManagerCompatFrom);
        this.mCameraCoordinator = camera2CameraCoordinator;
        CameraStateRegistry cameraStateRegistry = new CameraStateRegistry(camera2CameraCoordinator, 1);
        this.mCameraStateRegistry = cameraStateRegistry;
        camera2CameraCoordinator.addListener(cameraStateRegistry);
        this.mCameraOpenRetryMaxTimeoutInMs = j;
    }

    @Override // androidx.camera.core.impl.CameraFactory
    public CameraInternal getCamera(String str) {
        if (!this.mAvailableCameraIds.contains(str)) {
            throw new IllegalArgumentException("The given camera id is not on the available camera id list.");
        }
        return new Camera2CameraImpl(this.mContext, this.mCameraManager, str, getCameraInfo(str), this.mCameraCoordinator, this.mCameraStateRegistry, this.mThreadConfig.getCameraExecutor(), this.mThreadConfig.getSchedulerHandler(), this.mDisplayInfoManager, this.mCameraOpenRetryMaxTimeoutInMs);
    }

    Camera2CameraInfoImpl getCameraInfo(String str) throws CameraUnavailableException {
        try {
            Camera2CameraInfoImpl camera2CameraInfoImpl = (Camera2CameraInfoImpl) this.mCameraInfos.get(str);
            if (camera2CameraInfoImpl != null) {
                return camera2CameraInfoImpl;
            }
            Camera2CameraInfoImpl camera2CameraInfoImpl2 = new Camera2CameraInfoImpl(str, this.mCameraManager);
            this.mCameraInfos.put(str, camera2CameraInfoImpl2);
            return camera2CameraInfoImpl2;
        } catch (CameraAccessExceptionCompat e) {
            throw CameraUnavailableExceptionHelper.createFrom(e);
        }
    }

    @Override // androidx.camera.core.impl.CameraFactory
    public Set getAvailableCameraIds() {
        return new LinkedHashSet(this.mAvailableCameraIds);
    }

    @Override // androidx.camera.core.impl.CameraFactory
    public CameraCoordinator getCameraCoordinator() {
        return this.mCameraCoordinator;
    }

    @Override // androidx.camera.core.impl.CameraFactory
    public CameraManagerCompat getCameraManager() {
        return this.mCameraManager;
    }

    private List getBackwardCompatibleCameraIds(List list) {
        ArrayList arrayList = new ArrayList();
        Iterator it = list.iterator();
        while (it.hasNext()) {
            String str = (String) it.next();
            if (str.equals(CommonUrlParts.Values.FALSE_INTEGER) || str.equals("1")) {
                arrayList.add(str);
            } else if (CameraIdUtil.isBackwardCompatible(this.mCameraManager, str)) {
                arrayList.add(str);
            } else {
                Logger.d("Camera2CameraFactory", "Camera " + str + " is filtered out because its capabilities do not contain REQUEST_AVAILABLE_CAPABILITIES_BACKWARD_COMPATIBLE.");
            }
        }
        return arrayList;
    }
}
