package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.hardware.camera2.CameraCharacteristics;
import androidx.camera.core.CameraInfo;
import androidx.camera.core.CameraSelector;
import androidx.camera.core.CameraUnavailableException;
import androidx.camera.core.InitializationException;
import androidx.camera.core.impl.CameraInfoInternal;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraAccessExceptionCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraManagerCompat;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
abstract class CameraSelectionOptimizer {
    static List getSelectedAvailableCameraIds(Camera2CameraFactory camera2CameraFactory, CameraSelector cameraSelector) throws InitializationException {
        String strDecideSkippedCameraIdByHeuristic;
        try {
            ArrayList arrayList = new ArrayList();
            List<String> listAsList = Arrays.asList(camera2CameraFactory.getCameraManager().getCameraIdList());
            if (cameraSelector == null) {
                Iterator it = listAsList.iterator();
                while (it.hasNext()) {
                    arrayList.add((String) it.next());
                }
            } else {
                try {
                    strDecideSkippedCameraIdByHeuristic = decideSkippedCameraIdByHeuristic(camera2CameraFactory.getCameraManager(), cameraSelector.getLensFacing(), listAsList);
                } catch (IllegalStateException unused) {
                    strDecideSkippedCameraIdByHeuristic = null;
                }
                ArrayList arrayList2 = new ArrayList();
                for (String str : listAsList) {
                    if (!str.equals(strDecideSkippedCameraIdByHeuristic)) {
                        arrayList2.add(camera2CameraFactory.getCameraInfo(str));
                    }
                }
                Iterator<CameraInfo> it2 = cameraSelector.filter(arrayList2).iterator();
                while (it2.hasNext()) {
                    arrayList.add(((CameraInfoInternal) it2.next()).getCameraId());
                }
            }
            return arrayList;
        } catch (CameraUnavailableException e) {
            throw new InitializationException(e);
        } catch (CameraAccessExceptionCompat e2) {
            throw new InitializationException(CameraUnavailableExceptionHelper.createFrom(e2));
        }
    }

    private static String decideSkippedCameraIdByHeuristic(CameraManagerCompat cameraManagerCompat, Integer num, List list) {
        if (num != null && list.contains(CommonUrlParts.Values.FALSE_INTEGER) && list.contains("1")) {
            if (num.intValue() == 1) {
                if (((Integer) cameraManagerCompat.getCameraCharacteristicsCompat(CommonUrlParts.Values.FALSE_INTEGER).get(CameraCharacteristics.LENS_FACING)).intValue() == 1) {
                    return "1";
                }
            } else if (num.intValue() == 0 && ((Integer) cameraManagerCompat.getCameraCharacteristicsCompat("1").get(CameraCharacteristics.LENS_FACING)).intValue() == 0) {
                return CommonUrlParts.Values.FALSE_INTEGER;
            }
        }
        return null;
    }
}
