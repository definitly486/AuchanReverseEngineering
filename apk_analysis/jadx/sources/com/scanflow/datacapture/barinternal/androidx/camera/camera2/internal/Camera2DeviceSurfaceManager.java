package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.content.Context;
import android.media.CamcorderProfile;
import android.util.Pair;
import android.util.Size;
import androidx.camera.core.impl.CameraDeviceSurfaceManager;
import androidx.camera.core.impl.SurfaceConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraManagerCompat;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public final class Camera2DeviceSurfaceManager implements CameraDeviceSurfaceManager {
    private final CamcorderProfileHelper mCamcorderProfileHelper;
    private final Map mCameraSupportedSurfaceCombinationMap;

    public Camera2DeviceSurfaceManager(Context context, Object obj, Set set) {
        this(context, new CamcorderProfileHelper() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.Camera2DeviceSurfaceManager.1
            @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CamcorderProfileHelper
            public boolean hasProfile(int i, int i2) {
                return CamcorderProfile.hasProfile(i, i2);
            }

            @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.CamcorderProfileHelper
            public CamcorderProfile get(int i, int i2) {
                return CamcorderProfile.get(i, i2);
            }
        }, obj, set);
    }

    Camera2DeviceSurfaceManager(Context context, CamcorderProfileHelper camcorderProfileHelper, Object obj, Set set) {
        CameraManagerCompat cameraManagerCompatFrom;
        this.mCameraSupportedSurfaceCombinationMap = new HashMap();
        Preconditions.checkNotNull(camcorderProfileHelper);
        this.mCamcorderProfileHelper = camcorderProfileHelper;
        if (obj instanceof CameraManagerCompat) {
            cameraManagerCompatFrom = (CameraManagerCompat) obj;
        } else {
            cameraManagerCompatFrom = CameraManagerCompat.from(context);
        }
        init(context, cameraManagerCompatFrom, set);
    }

    private void init(Context context, CameraManagerCompat cameraManagerCompat, Set set) {
        Preconditions.checkNotNull(context);
        Iterator it = set.iterator();
        while (it.hasNext()) {
            String str = (String) it.next();
            this.mCameraSupportedSurfaceCombinationMap.put(str, new SupportedSurfaceCombination(context, str, cameraManagerCompat, this.mCamcorderProfileHelper));
        }
    }

    @Override // androidx.camera.core.impl.CameraDeviceSurfaceManager
    public SurfaceConfig transformSurfaceConfig(int i, String str, int i2, Size size) {
        SupportedSurfaceCombination supportedSurfaceCombination = (SupportedSurfaceCombination) this.mCameraSupportedSurfaceCombinationMap.get(str);
        if (supportedSurfaceCombination != null) {
            return supportedSurfaceCombination.transformSurfaceConfig(i, i2, size);
        }
        return null;
    }

    @Override // androidx.camera.core.impl.CameraDeviceSurfaceManager
    public Pair getSuggestedStreamSpecs(int i, String str, List list, Map map, boolean z, boolean z2) {
        Preconditions.checkArgument(!map.isEmpty(), "No new use cases to be bound.");
        SupportedSurfaceCombination supportedSurfaceCombination = (SupportedSurfaceCombination) this.mCameraSupportedSurfaceCombinationMap.get(str);
        if (supportedSurfaceCombination == null) {
            throw new IllegalArgumentException("No such camera id in supported combination list: " + str);
        }
        return supportedSurfaceCombination.getSuggestedStreamSpecifications(i, list, map, z, z2);
    }
}
