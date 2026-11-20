package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.hardware.camera2.CameraCharacteristics;
import android.os.Build;
import androidx.camera.core.Logger;
import androidx.camera.core.impl.AttachedSurfaceInfo;
import androidx.camera.core.impl.Config;
import androidx.camera.core.impl.ImageCaptureConfig;
import androidx.camera.core.impl.ImageInputConfig;
import androidx.camera.core.impl.MutableOptionsBundle;
import androidx.camera.core.impl.SessionConfig;
import androidx.camera.core.impl.StreamSpec;
import androidx.camera.core.impl.SurfaceConfig;
import androidx.camera.core.impl.UseCaseConfig;
import androidx.camera.core.impl.UseCaseConfigFactory;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.impl.Camera2ImplConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCharacteristicsCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.core.streamsharing.StreamSharingConfig;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public abstract class StreamUseCaseUtil {
    public static final Config.Option STREAM_USE_CASE_STREAM_SPEC_OPTION = Config.Option.create("camera2.streamSpec.streamUseCase", Long.TYPE);
    private static final Map STREAM_USE_CASE_TO_ELIGIBLE_CAPTURE_TYPES_MAP;
    private static final Map STREAM_USE_CASE_TO_ELIGIBLE_STREAM_SHARING_CHILDREN_TYPES_MAP;

    static {
        HashMap map = new HashMap();
        STREAM_USE_CASE_TO_ELIGIBLE_CAPTURE_TYPES_MAP = map;
        HashMap map2 = new HashMap();
        STREAM_USE_CASE_TO_ELIGIBLE_STREAM_SHARING_CHILDREN_TYPES_MAP = map2;
        if (Build.VERSION.SDK_INT >= 33) {
            HashSet hashSet = new HashSet();
            UseCaseConfigFactory.CaptureType captureType = UseCaseConfigFactory.CaptureType.PREVIEW;
            hashSet.add(captureType);
            UseCaseConfigFactory.CaptureType captureType2 = UseCaseConfigFactory.CaptureType.METERING_REPEATING;
            hashSet.add(captureType2);
            map.put(4L, hashSet);
            HashSet hashSet2 = new HashSet();
            hashSet2.add(captureType);
            hashSet2.add(captureType2);
            hashSet2.add(UseCaseConfigFactory.CaptureType.IMAGE_ANALYSIS);
            map.put(1L, hashSet2);
            HashSet hashSet3 = new HashSet();
            UseCaseConfigFactory.CaptureType captureType3 = UseCaseConfigFactory.CaptureType.IMAGE_CAPTURE;
            hashSet3.add(captureType3);
            map.put(2L, hashSet3);
            HashSet hashSet4 = new HashSet();
            UseCaseConfigFactory.CaptureType captureType4 = UseCaseConfigFactory.CaptureType.VIDEO_CAPTURE;
            hashSet4.add(captureType4);
            map.put(3L, hashSet4);
            HashSet hashSet5 = new HashSet();
            hashSet5.add(captureType);
            hashSet5.add(captureType3);
            hashSet5.add(captureType4);
            map2.put(4L, hashSet5);
            HashSet hashSet6 = new HashSet();
            hashSet6.add(captureType);
            hashSet6.add(captureType4);
            map2.put(3L, hashSet6);
        }
    }

    public static void populateSurfaceToStreamUseCaseMapping(Collection collection, Collection collection2, Map map) {
        ArrayList arrayList = new ArrayList(collection2);
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            SessionConfig sessionConfig = (SessionConfig) it.next();
            Config implementationOptions = sessionConfig.getImplementationOptions();
            Config.Option<?> option = STREAM_USE_CASE_STREAM_SPEC_OPTION;
            if (implementationOptions.containsOption(option) && sessionConfig.getSurfaces().size() != 1) {
                Logger.e("StreamUseCaseUtil", String.format("SessionConfig has stream use case but also contains %d surfaces, abort populateSurfaceToStreamUseCaseMapping().", Integer.valueOf(sessionConfig.getSurfaces().size())));
                return;
            }
            if (sessionConfig.getImplementationOptions().containsOption(option)) {
                Iterator it2 = collection.iterator();
                int i = 0;
                while (it2.hasNext()) {
                    SessionConfig sessionConfig2 = (SessionConfig) it2.next();
                    if (((UseCaseConfig) arrayList.get(i)).getCaptureType() == UseCaseConfigFactory.CaptureType.METERING_REPEATING) {
                        Preconditions.checkState(!sessionConfig2.getSurfaces().isEmpty(), "MeteringRepeating should contain a surface");
                        map.put(sessionConfig2.getSurfaces().get(0), 1L);
                    } else {
                        Config implementationOptions2 = sessionConfig2.getImplementationOptions();
                        Config.Option<?> option2 = STREAM_USE_CASE_STREAM_SPEC_OPTION;
                        if (implementationOptions2.containsOption(option2) && !sessionConfig2.getSurfaces().isEmpty()) {
                            map.put(sessionConfig2.getSurfaces().get(0), (Long) sessionConfig2.getImplementationOptions().retrieveOption(option2));
                        }
                    }
                    i++;
                }
                return;
            }
        }
    }

    public static Camera2ImplConfig getStreamSpecImplementationOptions(UseCaseConfig useCaseConfig) {
        MutableOptionsBundle mutableOptionsBundleCreate = MutableOptionsBundle.create();
        Config.Option<?> option = Camera2ImplConfig.STREAM_USE_CASE_OPTION;
        if (useCaseConfig.containsOption(option)) {
            mutableOptionsBundleCreate.insertOption(option, (Long) useCaseConfig.retrieveOption(option));
        }
        Config.Option<Boolean> option2 = UseCaseConfig.OPTION_ZSL_DISABLED;
        if (useCaseConfig.containsOption(option2)) {
            mutableOptionsBundleCreate.insertOption(option2, (Boolean) useCaseConfig.retrieveOption(option2));
        }
        Config.Option<?> option3 = ImageCaptureConfig.OPTION_IMAGE_CAPTURE_MODE;
        if (useCaseConfig.containsOption(option3)) {
            mutableOptionsBundleCreate.insertOption(option3, (Integer) useCaseConfig.retrieveOption(option3));
        }
        Config.Option<Integer> option4 = ImageInputConfig.OPTION_INPUT_FORMAT;
        if (useCaseConfig.containsOption(option4)) {
            mutableOptionsBundleCreate.insertOption(option4, (Integer) useCaseConfig.retrieveOption(option4));
        }
        return new Camera2ImplConfig(mutableOptionsBundleCreate);
    }

    public static boolean isStreamUseCaseSupported(CameraCharacteristicsCompat cameraCharacteristicsCompat) {
        long[] jArr;
        return (Build.VERSION.SDK_INT < 33 || (jArr = (long[]) cameraCharacteristicsCompat.get(CameraCharacteristics.SCALER_AVAILABLE_STREAM_USE_CASES)) == null || jArr.length == 0) ? false : true;
    }

    public static boolean shouldUseStreamUseCase(SupportedSurfaceCombination.FeatureSettings featureSettings) {
        return featureSettings.getCameraMode() == 0 && featureSettings.getRequiredMaxBitDepth() == 8;
    }

    public static boolean populateStreamUseCaseStreamSpecOptionWithInteropOverride(CameraCharacteristicsCompat cameraCharacteristicsCompat, List list, Map map, Map map2) {
        int i = 0;
        if (Build.VERSION.SDK_INT < 33) {
            return false;
        }
        ArrayList arrayList = new ArrayList(map.keySet());
        Iterator it = list.iterator();
        while (it.hasNext()) {
            Preconditions.checkNotNull(((AttachedSurfaceInfo) it.next()).getImplementationOptions());
        }
        int size = arrayList.size();
        int i2 = 0;
        while (i2 < size) {
            Object obj = arrayList.get(i2);
            i2++;
            Preconditions.checkNotNull(((StreamSpec) Preconditions.checkNotNull((StreamSpec) map.get((UseCaseConfig) obj))).getImplementationOptions());
        }
        long[] jArr = (long[]) cameraCharacteristicsCompat.get(CameraCharacteristics.SCALER_AVAILABLE_STREAM_USE_CASES);
        if (jArr != null && jArr.length != 0) {
            HashSet hashSet = new HashSet();
            for (long j : jArr) {
                hashSet.add(Long.valueOf(j));
            }
            if (isValidCamera2InteropOverride(list, arrayList, hashSet)) {
                Iterator it2 = list.iterator();
                while (it2.hasNext()) {
                    AttachedSurfaceInfo attachedSurfaceInfo = (AttachedSurfaceInfo) it2.next();
                    Config implementationOptions = attachedSurfaceInfo.getImplementationOptions();
                    Config updatedImplementationOptionsWithUseCaseStreamSpecOption = getUpdatedImplementationOptionsWithUseCaseStreamSpecOption(implementationOptions, ((Long) implementationOptions.retrieveOption(Camera2ImplConfig.STREAM_USE_CASE_OPTION)).longValue());
                    if (updatedImplementationOptionsWithUseCaseStreamSpecOption != null) {
                        map2.put(attachedSurfaceInfo, attachedSurfaceInfo.toStreamSpec(updatedImplementationOptionsWithUseCaseStreamSpecOption));
                    }
                }
                int size2 = arrayList.size();
                while (i < size2) {
                    Object obj2 = arrayList.get(i);
                    i++;
                    UseCaseConfig useCaseConfig = (UseCaseConfig) obj2;
                    StreamSpec streamSpec = (StreamSpec) map.get(useCaseConfig);
                    Config implementationOptions2 = streamSpec.getImplementationOptions();
                    Config updatedImplementationOptionsWithUseCaseStreamSpecOption2 = getUpdatedImplementationOptionsWithUseCaseStreamSpecOption(implementationOptions2, ((Long) implementationOptions2.retrieveOption(Camera2ImplConfig.STREAM_USE_CASE_OPTION)).longValue());
                    if (updatedImplementationOptionsWithUseCaseStreamSpecOption2 != null) {
                        map.put(useCaseConfig, streamSpec.toBuilder().setImplementationOptions(updatedImplementationOptionsWithUseCaseStreamSpecOption2).build());
                    }
                }
                return true;
            }
        }
        return false;
    }

    public static boolean areStreamUseCasesAvailableForSurfaceConfigs(CameraCharacteristicsCompat cameraCharacteristicsCompat, List list) {
        long[] jArr;
        if (Build.VERSION.SDK_INT < 33 || (jArr = (long[]) cameraCharacteristicsCompat.get(CameraCharacteristics.SCALER_AVAILABLE_STREAM_USE_CASES)) == null || jArr.length == 0) {
            return false;
        }
        HashSet hashSet = new HashSet();
        for (long j : jArr) {
            hashSet.add(Long.valueOf(j));
        }
        Iterator it = list.iterator();
        while (it.hasNext()) {
            if (!hashSet.contains(Long.valueOf(((SurfaceConfig) it.next()).getStreamUseCase()))) {
                return false;
            }
        }
        return true;
    }

    private static boolean isEligibleCaptureType(UseCaseConfigFactory.CaptureType captureType, long j, List list) {
        if (Build.VERSION.SDK_INT < 33) {
            return false;
        }
        if (captureType == UseCaseConfigFactory.CaptureType.STREAM_SHARING) {
            Map map = STREAM_USE_CASE_TO_ELIGIBLE_STREAM_SHARING_CHILDREN_TYPES_MAP;
            if (!map.containsKey(Long.valueOf(j))) {
                return false;
            }
            Set set = (Set) map.get(Long.valueOf(j));
            if (list.size() != set.size()) {
                return false;
            }
            Iterator it = list.iterator();
            while (it.hasNext()) {
                if (!set.contains((UseCaseConfigFactory.CaptureType) it.next())) {
                    return false;
                }
            }
            return true;
        }
        Map map2 = STREAM_USE_CASE_TO_ELIGIBLE_CAPTURE_TYPES_MAP;
        return map2.containsKey(Long.valueOf(j)) && ((Set) map2.get(Long.valueOf(j))).contains(captureType);
    }

    public static boolean areCaptureTypesEligible(Map map, Map map2, List list) {
        List captureTypes;
        UseCaseConfigFactory.CaptureType captureType;
        for (int i = 0; i < list.size(); i++) {
            long streamUseCase = ((SurfaceConfig) list.get(i)).getStreamUseCase();
            if (map.containsKey(Integer.valueOf(i))) {
                AttachedSurfaceInfo attachedSurfaceInfo = (AttachedSurfaceInfo) map.get(Integer.valueOf(i));
                if (attachedSurfaceInfo.getCaptureTypes().size() == 1) {
                    captureType = (UseCaseConfigFactory.CaptureType) attachedSurfaceInfo.getCaptureTypes().get(0);
                } else {
                    captureType = UseCaseConfigFactory.CaptureType.STREAM_SHARING;
                }
                if (!isEligibleCaptureType(captureType, streamUseCase, attachedSurfaceInfo.getCaptureTypes())) {
                    return false;
                }
            } else if (map2.containsKey(Integer.valueOf(i))) {
                UseCaseConfig useCaseConfig = (UseCaseConfig) map2.get(Integer.valueOf(i));
                UseCaseConfigFactory.CaptureType captureType2 = useCaseConfig.getCaptureType();
                if (useCaseConfig.getCaptureType() == UseCaseConfigFactory.CaptureType.STREAM_SHARING) {
                    captureTypes = ((StreamSharingConfig) useCaseConfig).getCaptureTypes();
                } else {
                    captureTypes = Collections.EMPTY_LIST;
                }
                if (!isEligibleCaptureType(captureType2, streamUseCase, captureTypes)) {
                    return false;
                }
            } else {
                throw new AssertionError("SurfaceConfig does not map to any use case");
            }
        }
        return true;
    }

    public static void populateStreamUseCaseStreamSpecOptionWithSupportedSurfaceConfigs(Map map, Map map2, Map map3, Map map4, List list) {
        for (int i = 0; i < list.size(); i++) {
            long streamUseCase = ((SurfaceConfig) list.get(i)).getStreamUseCase();
            if (map3.containsKey(Integer.valueOf(i))) {
                AttachedSurfaceInfo attachedSurfaceInfo = (AttachedSurfaceInfo) map3.get(Integer.valueOf(i));
                Config updatedImplementationOptionsWithUseCaseStreamSpecOption = getUpdatedImplementationOptionsWithUseCaseStreamSpecOption(attachedSurfaceInfo.getImplementationOptions(), streamUseCase);
                if (updatedImplementationOptionsWithUseCaseStreamSpecOption != null) {
                    map2.put(attachedSurfaceInfo, attachedSurfaceInfo.toStreamSpec(updatedImplementationOptionsWithUseCaseStreamSpecOption));
                }
            } else if (map4.containsKey(Integer.valueOf(i))) {
                UseCaseConfig useCaseConfig = (UseCaseConfig) map4.get(Integer.valueOf(i));
                StreamSpec streamSpec = (StreamSpec) map.get(useCaseConfig);
                Config updatedImplementationOptionsWithUseCaseStreamSpecOption2 = getUpdatedImplementationOptionsWithUseCaseStreamSpecOption(streamSpec.getImplementationOptions(), streamUseCase);
                if (updatedImplementationOptionsWithUseCaseStreamSpecOption2 != null) {
                    map.put(useCaseConfig, streamSpec.toBuilder().setImplementationOptions(updatedImplementationOptionsWithUseCaseStreamSpecOption2).build());
                }
            } else {
                throw new AssertionError("SurfaceConfig does not map to any use case");
            }
        }
    }

    private static Config getUpdatedImplementationOptionsWithUseCaseStreamSpecOption(Config config, long j) {
        Config.Option<?> option = STREAM_USE_CASE_STREAM_SPEC_OPTION;
        if (config.containsOption(option) && ((Long) config.retrieveOption(option)).longValue() == j) {
            return null;
        }
        MutableOptionsBundle mutableOptionsBundleFrom = MutableOptionsBundle.from(config);
        mutableOptionsBundleFrom.insertOption(option, Long.valueOf(j));
        return new Camera2ImplConfig(mutableOptionsBundleFrom);
    }

    public static boolean containsZslUseCase(List list, List list2) {
        Iterator it = list.iterator();
        while (it.hasNext()) {
            AttachedSurfaceInfo attachedSurfaceInfo = (AttachedSurfaceInfo) it.next();
            if (isZslUseCase(attachedSurfaceInfo.getImplementationOptions(), (UseCaseConfigFactory.CaptureType) attachedSurfaceInfo.getCaptureTypes().get(0))) {
                return true;
            }
        }
        Iterator it2 = list2.iterator();
        while (it2.hasNext()) {
            UseCaseConfig useCaseConfig = (UseCaseConfig) it2.next();
            if (isZslUseCase(useCaseConfig, useCaseConfig.getCaptureType())) {
                return true;
            }
        }
        return false;
    }

    private static boolean isZslUseCase(Config config, UseCaseConfigFactory.CaptureType captureType) {
        if (((Boolean) config.retrieveOption(UseCaseConfig.OPTION_ZSL_DISABLED, Boolean.FALSE)).booleanValue()) {
            return false;
        }
        Config.Option<?> option = ImageCaptureConfig.OPTION_IMAGE_CAPTURE_MODE;
        return config.containsOption(option) && TemplateTypeUtil.getSessionConfigTemplateType(captureType, ((Integer) config.retrieveOption(option)).intValue()) == 5;
    }

    private static boolean areStreamUseCasesAvailable(Set set, Set set2) {
        Iterator it = set2.iterator();
        while (it.hasNext()) {
            if (!set.contains((Long) it.next())) {
                return false;
            }
        }
        return true;
    }

    private static void throwInvalidCamera2InteropOverrideException() {
        throw new IllegalArgumentException("Either all use cases must have non-default stream use case assigned or none should have it");
    }

    private static boolean isValidCamera2InteropOverride(List list, List list2, Set set) {
        boolean z;
        boolean z2;
        HashSet hashSet = new HashSet();
        Iterator it = list.iterator();
        if (it.hasNext()) {
            AttachedSurfaceInfo attachedSurfaceInfo = (AttachedSurfaceInfo) it.next();
            Config implementationOptions = attachedSurfaceInfo.getImplementationOptions();
            Config.Option<?> option = Camera2ImplConfig.STREAM_USE_CASE_OPTION;
            if (implementationOptions.containsOption(option) && ((Long) attachedSurfaceInfo.getImplementationOptions().retrieveOption(option)).longValue() != 0) {
                z = true;
                z2 = false;
            } else {
                z2 = true;
                z = false;
            }
        } else {
            z = false;
            z2 = false;
        }
        Iterator it2 = list2.iterator();
        while (it2.hasNext()) {
            UseCaseConfig useCaseConfig = (UseCaseConfig) it2.next();
            Config.Option<?> option2 = Camera2ImplConfig.STREAM_USE_CASE_OPTION;
            if (useCaseConfig.containsOption(option2)) {
                Long l = (Long) useCaseConfig.retrieveOption(option2);
                if (l.longValue() != 0) {
                    if (z2) {
                        throwInvalidCamera2InteropOverrideException();
                    }
                    hashSet.add(l);
                    z = true;
                } else if (z) {
                    throwInvalidCamera2InteropOverrideException();
                }
            } else if (z) {
                throwInvalidCamera2InteropOverrideException();
            }
            z2 = true;
        }
        return !z2 && areStreamUseCasesAvailable(set, hashSet);
    }
}
