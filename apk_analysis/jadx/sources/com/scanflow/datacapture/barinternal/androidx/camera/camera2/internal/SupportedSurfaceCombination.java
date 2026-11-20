package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.content.Context;
import android.graphics.SurfaceTexture;
import android.hardware.camera2.CameraCharacteristics;
import android.hardware.camera2.params.StreamConfigurationMap;
import android.media.CamcorderProfile;
import android.media.MediaRecorder;
import android.os.Build;
import android.util.Pair;
import android.util.Range;
import android.util.Rational;
import android.util.Size;
import androidx.camera.core.CameraUnavailableException;
import androidx.camera.core.DynamicRange;
import androidx.camera.core.impl.AttachedSurfaceInfo;
import androidx.camera.core.impl.CameraMode;
import androidx.camera.core.impl.StreamSpec;
import androidx.camera.core.impl.SurfaceCombination;
import androidx.camera.core.impl.SurfaceConfig;
import androidx.camera.core.impl.SurfaceSizeDefinition;
import androidx.camera.core.impl.UseCaseConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraAccessExceptionCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCharacteristicsCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraManagerCompat;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.ExtraSupportedSurfaceCombinationsContainer;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.ResolutionCorrector;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.workaround.TargetAspectRatio;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.AspectRatioUtil;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.CompareSizesByArea;
import com.scanflow.datacapture.barinternal.androidx.camera.core.internal.utils.SizeUtil;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
final class SupportedSurfaceCombination {
    private final CamcorderProfileHelper mCamcorderProfileHelper;
    private final String mCameraId;
    private final CameraCharacteristicsCompat mCharacteristics;
    private final DisplayInfoManager mDisplayInfoManager;
    private final DynamicRangeResolver mDynamicRangeResolver;
    private final ExtraSupportedSurfaceCombinationsContainer mExtraSupportedSurfaceCombinationsContainer;
    private final int mHardwareLevel;
    private boolean mIsBurstCaptureSupported;
    private boolean mIsConcurrentCameraModeSupported;
    private boolean mIsPreviewStabilizationSupported;
    private boolean mIsRawSupported;
    private boolean mIsStreamUseCaseSupported;
    private boolean mIsUltraHighResolutionSensorSupported;
    SurfaceSizeDefinition mSurfaceSizeDefinition;
    private final List mSurfaceCombinations = new ArrayList();
    private final List mUltraHighSurfaceCombinations = new ArrayList();
    private final List mConcurrentSurfaceCombinations = new ArrayList();
    private final List mPreviewStabilizationSurfaceCombinations = new ArrayList();
    private final Map mFeatureSettingsToSupportedCombinationsMap = new HashMap();
    private final List mSurfaceCombinations10Bit = new ArrayList();
    private final List mSurfaceCombinationsUltraHdr = new ArrayList();
    private final List mSurfaceCombinationsStreamUseCase = new ArrayList();
    List mSurfaceSizeDefinitionFormats = new ArrayList();
    private final TargetAspectRatio mTargetAspectRatio = new TargetAspectRatio();
    private final ResolutionCorrector mResolutionCorrector = new ResolutionCorrector();

    SupportedSurfaceCombination(Context context, String str, CameraManagerCompat cameraManagerCompat, CamcorderProfileHelper camcorderProfileHelper) throws CameraUnavailableException {
        this.mIsRawSupported = false;
        this.mIsBurstCaptureSupported = false;
        this.mIsConcurrentCameraModeSupported = false;
        this.mIsStreamUseCaseSupported = false;
        this.mIsUltraHighResolutionSensorSupported = false;
        this.mIsPreviewStabilizationSupported = false;
        String str2 = (String) Preconditions.checkNotNull(str);
        this.mCameraId = str2;
        this.mCamcorderProfileHelper = (CamcorderProfileHelper) Preconditions.checkNotNull(camcorderProfileHelper);
        this.mExtraSupportedSurfaceCombinationsContainer = new ExtraSupportedSurfaceCombinationsContainer();
        this.mDisplayInfoManager = DisplayInfoManager.getInstance(context);
        try {
            CameraCharacteristicsCompat cameraCharacteristicsCompat = cameraManagerCompat.getCameraCharacteristicsCompat(str2);
            this.mCharacteristics = cameraCharacteristicsCompat;
            Integer num = (Integer) cameraCharacteristicsCompat.get(CameraCharacteristics.INFO_SUPPORTED_HARDWARE_LEVEL);
            this.mHardwareLevel = num != null ? num.intValue() : 2;
            int[] iArr = (int[]) cameraCharacteristicsCompat.get(CameraCharacteristics.REQUEST_AVAILABLE_CAPABILITIES);
            if (iArr != null) {
                for (int i : iArr) {
                    if (i == 3) {
                        this.mIsRawSupported = true;
                    } else if (i == 6) {
                        this.mIsBurstCaptureSupported = true;
                    } else if (Build.VERSION.SDK_INT >= 31 && i == 16) {
                        this.mIsUltraHighResolutionSensorSupported = true;
                    }
                }
            }
            DynamicRangeResolver dynamicRangeResolver = new DynamicRangeResolver(this.mCharacteristics);
            this.mDynamicRangeResolver = dynamicRangeResolver;
            generateSupportedCombinationList();
            if (this.mIsUltraHighResolutionSensorSupported) {
                generateUltraHighSupportedCombinationList();
            }
            boolean zHasSystemFeature = context.getPackageManager().hasSystemFeature("android.hardware.camera.concurrent");
            this.mIsConcurrentCameraModeSupported = zHasSystemFeature;
            if (zHasSystemFeature) {
                generateConcurrentSupportedCombinationList();
            }
            if (dynamicRangeResolver.is10BitDynamicRangeSupported()) {
                generate10BitSupportedCombinationList();
            }
            if (isUltraHdrSupported()) {
                generateUltraHdrSupportedCombinationList();
            }
            boolean zIsStreamUseCaseSupported = StreamUseCaseUtil.isStreamUseCaseSupported(this.mCharacteristics);
            this.mIsStreamUseCaseSupported = zIsStreamUseCaseSupported;
            if (zIsStreamUseCaseSupported) {
                generateStreamUseCaseSupportedCombinationList();
            }
            boolean zIsPreviewStabilizationSupported = VideoStabilizationUtil.isPreviewStabilizationSupported(this.mCharacteristics);
            this.mIsPreviewStabilizationSupported = zIsPreviewStabilizationSupported;
            if (zIsPreviewStabilizationSupported) {
                generatePreviewStabilizationSupportedCombinationList();
            }
            generateSurfaceSizeDefinition();
            checkCustomization();
        } catch (CameraAccessExceptionCompat e) {
            throw CameraUnavailableExceptionHelper.createFrom(e);
        }
    }

    private boolean isUltraHdrSupported() {
        int[] outputFormats = this.mCharacteristics.getStreamConfigurationMapCompat().getOutputFormats();
        if (outputFormats == null) {
            return false;
        }
        for (int i : outputFormats) {
            if (i == 4101) {
                return true;
            }
        }
        return false;
    }

    boolean checkSupported(FeatureSettings featureSettings, List list) {
        Iterator it = getSurfaceCombinationsByFeatureSettings(featureSettings).iterator();
        boolean z = false;
        while (it.hasNext()) {
            z = ((SurfaceCombination) it.next()).getOrderedSupportedSurfaceConfigList(list) != null;
            if (z) {
                break;
            }
        }
        return z;
    }

    List getOrderedSupportedStreamUseCaseSurfaceConfigList(FeatureSettings featureSettings, List list) {
        if (!StreamUseCaseUtil.shouldUseStreamUseCase(featureSettings)) {
            return null;
        }
        Iterator it = this.mSurfaceCombinationsStreamUseCase.iterator();
        while (it.hasNext()) {
            List orderedSupportedSurfaceConfigList = ((SurfaceCombination) it.next()).getOrderedSupportedSurfaceConfigList(list);
            if (orderedSupportedSurfaceConfigList != null) {
                return orderedSupportedSurfaceConfigList;
            }
        }
        return null;
    }

    private List getSurfaceCombinationsByFeatureSettings(FeatureSettings featureSettings) {
        if (this.mFeatureSettingsToSupportedCombinationsMap.containsKey(featureSettings)) {
            return (List) this.mFeatureSettingsToSupportedCombinationsMap.get(featureSettings);
        }
        List arrayList = new ArrayList();
        if (featureSettings.isUltraHdrOn()) {
            if (featureSettings.getCameraMode() == 0) {
                arrayList.addAll(this.mSurfaceCombinationsUltraHdr);
            }
        } else if (featureSettings.getRequiredMaxBitDepth() == 8) {
            int cameraMode = featureSettings.getCameraMode();
            if (cameraMode == 1) {
                arrayList = this.mConcurrentSurfaceCombinations;
            } else if (cameraMode == 2) {
                arrayList.addAll(this.mUltraHighSurfaceCombinations);
                arrayList.addAll(this.mSurfaceCombinations);
            } else {
                arrayList.addAll(featureSettings.isPreviewStabilizationOn() ? this.mPreviewStabilizationSurfaceCombinations : this.mSurfaceCombinations);
            }
        } else if (featureSettings.getRequiredMaxBitDepth() == 10 && featureSettings.getCameraMode() == 0) {
            arrayList.addAll(this.mSurfaceCombinations10Bit);
        }
        this.mFeatureSettingsToSupportedCombinationsMap.put(featureSettings, arrayList);
        return arrayList;
    }

    SurfaceConfig transformSurfaceConfig(int i, int i2, Size size) {
        return SurfaceConfig.transformSurfaceConfig(i, i2, size, getUpdatedSurfaceSizeDefinitionByFormat(i2));
    }

    static int getMaxFrameRate(CameraCharacteristicsCompat cameraCharacteristicsCompat, int i, Size size) {
        try {
            return (int) (1.0E9d / ((StreamConfigurationMap) cameraCharacteristicsCompat.get(CameraCharacteristics.SCALER_STREAM_CONFIGURATION_MAP)).getOutputMinFrameDuration(i, size));
        } catch (Exception unused) {
            return 0;
        }
    }

    private static int getRangeLength(Range range) {
        return (((Integer) range.getUpper()).intValue() - ((Integer) range.getLower()).intValue()) + 1;
    }

    private static int getRangeDistance(Range range, Range range2) {
        Preconditions.checkState((range.contains((Integer) range2.getUpper()) || range.contains((Integer) range2.getLower())) ? false : true, "Ranges must not intersect");
        if (((Integer) range.getLower()).intValue() > ((Integer) range2.getUpper()).intValue()) {
            return ((Integer) range.getLower()).intValue() - ((Integer) range2.getUpper()).intValue();
        }
        return ((Integer) range2.getLower()).intValue() - ((Integer) range.getUpper()).intValue();
    }

    private static Range compareIntersectingRanges(Range range, Range range2, Range range3) {
        double rangeLength = getRangeLength(range2.intersect(range));
        double rangeLength2 = getRangeLength(range3.intersect(range));
        double rangeLength3 = rangeLength2 / ((double) getRangeLength(range3));
        double rangeLength4 = rangeLength / ((double) getRangeLength(range2));
        return (rangeLength2 <= rangeLength ? rangeLength2 != rangeLength ? rangeLength4 >= 0.5d || rangeLength3 <= rangeLength4 : rangeLength3 <= rangeLength4 && (rangeLength3 != rangeLength4 || ((Integer) range3.getLower()).intValue() <= ((Integer) range2.getLower()).intValue()) : rangeLength3 < 0.5d && rangeLength3 < rangeLength4) ? range2 : range3;
    }

    private Range getClosestSupportedDeviceFrameRate(Range range, int i) {
        if (range != null) {
            Range rangeCompareIntersectingRanges = StreamSpec.FRAME_RATE_RANGE_UNSPECIFIED;
            if (!range.equals(rangeCompareIntersectingRanges)) {
                Range[] rangeArr = (Range[]) this.mCharacteristics.get(CameraCharacteristics.CONTROL_AE_AVAILABLE_TARGET_FPS_RANGES);
                if (rangeArr == null) {
                    return rangeCompareIntersectingRanges;
                }
                Range range2 = new Range(Integer.valueOf(Math.min(((Integer) range.getLower()).intValue(), i)), Integer.valueOf(Math.min(((Integer) range.getUpper()).intValue(), i)));
                int rangeLength = 0;
                for (Range range3 : rangeArr) {
                    if (i >= ((Integer) range3.getLower()).intValue()) {
                        if (rangeCompareIntersectingRanges.equals(StreamSpec.FRAME_RATE_RANGE_UNSPECIFIED)) {
                            rangeCompareIntersectingRanges = range3;
                        }
                        if (range3.equals(range2)) {
                            return range3;
                        }
                        try {
                            int rangeLength2 = getRangeLength(range3.intersect(range2));
                            if (rangeLength == 0) {
                                rangeLength = rangeLength2;
                            } else {
                                if (rangeLength2 >= rangeLength) {
                                    rangeCompareIntersectingRanges = compareIntersectingRanges(range2, rangeCompareIntersectingRanges, range3);
                                    rangeLength = getRangeLength(range2.intersect(rangeCompareIntersectingRanges));
                                }
                                range3 = rangeCompareIntersectingRanges;
                            }
                        } catch (IllegalArgumentException unused) {
                            if (rangeLength != 0 || (getRangeDistance(range3, range2) >= getRangeDistance(rangeCompareIntersectingRanges, range2) && (getRangeDistance(range3, range2) != getRangeDistance(rangeCompareIntersectingRanges, range2) || (((Integer) range3.getLower()).intValue() <= ((Integer) rangeCompareIntersectingRanges.getUpper()).intValue() && getRangeLength(range3) >= getRangeLength(rangeCompareIntersectingRanges))))) {
                            }
                        }
                        rangeCompareIntersectingRanges = range3;
                    }
                }
                return rangeCompareIntersectingRanges;
            }
        }
        return StreamSpec.FRAME_RATE_RANGE_UNSPECIFIED;
    }

    private Range getUpdatedTargetFramerate(Range range, Range range2) {
        if (range2 == null) {
            return range;
        }
        if (range != null) {
            try {
                return range2.intersect(range);
            } catch (IllegalArgumentException unused) {
            }
        }
        return range2;
    }

    private int getUpdatedMaximumFps(int i, int i2, Size size) {
        return Math.min(i, getMaxFrameRate(this.mCharacteristics, i2, size));
    }

    /* JADX WARN: Type inference fix 'apply assigned field type' failed
    java.lang.UnsupportedOperationException: ArgType.getObject(), call class: class jadx.core.dex.instructions.args.ArgType$UnknownArg
    	at jadx.core.dex.instructions.args.ArgType.getObject(ArgType.java:596)
    	at jadx.core.dex.attributes.nodes.ClassTypeVarsAttr.getTypeVarsMapFor(ClassTypeVarsAttr.java:35)
    	at jadx.core.dex.nodes.utils.TypeUtils.replaceClassGenerics(TypeUtils.java:177)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.insertExplicitUseCast(FixTypesVisitor.java:397)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.tryFieldTypeWithNewCasts(FixTypesVisitor.java:359)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.applyFieldType(FixTypesVisitor.java:309)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.visit(FixTypesVisitor.java:94)
     */
    Pair getSuggestedStreamSpecifications(int i, List list, Map map, boolean z, boolean z2) {
        int i2;
        Map map2;
        Map map3;
        HashMap map4;
        List list2;
        Map map5;
        List list3;
        String str;
        String str2;
        Map map6;
        List list4;
        List list5;
        HashMap map7;
        boolean z3;
        refreshPreviewSize();
        ArrayList arrayList = new ArrayList(map.keySet());
        List useCasesPriorityOrder = getUseCasesPriorityOrder(arrayList);
        Map mapResolveAndValidateDynamicRanges = this.mDynamicRangeResolver.resolveAndValidateDynamicRanges(list, arrayList, useCasesPriorityOrder);
        FeatureSettings featureSettingsCreateFeatureSettings = createFeatureSettings(i, mapResolveAndValidateDynamicRanges, z, isUltraHdrOn(list, map));
        boolean zIsUseCasesCombinationSupported = isUseCasesCombinationSupported(featureSettingsCreateFeatureSettings, list, map);
        String str3 = " New configs: ";
        String str4 = "No supported surface combination is found for camera device - Id : ";
        if (!zIsUseCasesCombinationSupported) {
            throw new IllegalArgumentException("No supported surface combination is found for camera device - Id : " + this.mCameraId + ".  May be attempting to bind too many use cases. Existing surfaces: " + list + " New configs: " + arrayList);
        }
        Range targetFpsRange = getTargetFpsRange(list, arrayList, useCasesPriorityOrder);
        Map mapFilterSupportedSizes = filterSupportedSizes(map, featureSettingsCreateFeatureSettings, targetFpsRange);
        List arrayList2 = new ArrayList();
        Iterator it = useCasesPriorityOrder.iterator();
        while (it.hasNext()) {
            UseCaseConfig useCaseConfig = (UseCaseConfig) arrayList.get(((Integer) it.next()).intValue());
            arrayList2.add(applyResolutionSelectionOrderRelatedWorkarounds((List) mapFilterSupportedSizes.get(useCaseConfig), useCaseConfig.getInputFormat()));
            mapFilterSupportedSizes = mapFilterSupportedSizes;
        }
        List allPossibleSizeArrangements = getAllPossibleSizeArrangements(arrayList2);
        HashMap map8 = new HashMap();
        HashMap map9 = new HashMap();
        Map map10 = new HashMap();
        Map map11 = new HashMap();
        boolean zContainsZslUseCase = StreamUseCaseUtil.containsZslUseCase(list, arrayList);
        int maxSupportedFpsFromAttachedSurfaces = getMaxSupportedFpsFromAttachedSurfaces(list);
        if (!this.mIsStreamUseCaseSupported || zContainsZslUseCase) {
            i2 = maxSupportedFpsFromAttachedSurfaces;
            map2 = map10;
            map3 = map11;
            map4 = map9;
            list2 = null;
        } else {
            Iterator it2 = allPossibleSizeArrangements.iterator();
            List orderedSupportedStreamUseCaseSurfaceConfigList = null;
            while (true) {
                if (!it2.hasNext()) {
                    Map map12 = map11;
                    i2 = maxSupportedFpsFromAttachedSurfaces;
                    map2 = map10;
                    map3 = map12;
                    z3 = zIsUseCasesCombinationSupported;
                    map4 = map9;
                    break;
                }
                z3 = zIsUseCasesCombinationSupported;
                map4 = map9;
                Pair surfaceConfigListAndFpsCeiling = getSurfaceConfigListAndFpsCeiling(i, list, (List) it2.next(), arrayList, useCasesPriorityOrder, maxSupportedFpsFromAttachedSurfaces, map10, map11);
                Map map13 = map11;
                i2 = maxSupportedFpsFromAttachedSurfaces;
                map2 = map10;
                map3 = map13;
                orderedSupportedStreamUseCaseSurfaceConfigList = getOrderedSupportedStreamUseCaseSurfaceConfigList(featureSettingsCreateFeatureSettings, (List) surfaceConfigListAndFpsCeiling.first);
                if (orderedSupportedStreamUseCaseSurfaceConfigList != null && !StreamUseCaseUtil.areCaptureTypesEligible(map2, map3, orderedSupportedStreamUseCaseSurfaceConfigList)) {
                    orderedSupportedStreamUseCaseSurfaceConfigList = null;
                }
                if (orderedSupportedStreamUseCaseSurfaceConfigList != null) {
                    if (StreamUseCaseUtil.areStreamUseCasesAvailableForSurfaceConfigs(this.mCharacteristics, orderedSupportedStreamUseCaseSurfaceConfigList)) {
                        break;
                    }
                    orderedSupportedStreamUseCaseSurfaceConfigList = null;
                }
                map2.clear();
                map3.clear();
                map10 = map2;
                maxSupportedFpsFromAttachedSurfaces = i2;
                map11 = map3;
                map9 = map4;
                zIsUseCasesCombinationSupported = z3;
            }
            if (orderedSupportedStreamUseCaseSurfaceConfigList == null && !z3) {
                throw new IllegalArgumentException("No supported surface combination is found for camera device - Id : " + this.mCameraId + ".  May be attempting to bind too many use cases. Existing surfaces: " + list + " New configs: " + arrayList);
            }
            list2 = orderedSupportedStreamUseCaseSurfaceConfigList;
        }
        Iterator it3 = allPossibleSizeArrangements.iterator();
        int i3 = Integer.MAX_VALUE;
        int i4 = Integer.MAX_VALUE;
        int i5 = Integer.MAX_VALUE;
        boolean z4 = false;
        boolean z5 = false;
        List list6 = null;
        List list7 = null;
        while (true) {
            if (it3.hasNext()) {
                List list8 = (List) it3.next();
                Map map14 = map2;
                int i6 = i2;
                str = str3;
                map5 = map3;
                int i7 = i4;
                list3 = list2;
                int i8 = i3;
                str2 = str4;
                map6 = map14;
                Pair surfaceConfigListAndFpsCeiling2 = getSurfaceConfigListAndFpsCeiling(i, list, list8, arrayList, useCasesPriorityOrder, i6, null, null);
                List list9 = (List) surfaceConfigListAndFpsCeiling2.first;
                int iIntValue = ((Integer) surfaceConfigListAndFpsCeiling2.second).intValue();
                boolean z6 = targetFpsRange == null || i6 <= iIntValue || iIntValue >= ((Integer) targetFpsRange.getLower()).intValue();
                if (!z4 && checkSupported(featureSettingsCreateFeatureSettings, list9)) {
                    if (i7 == i8 || i7 < iIntValue) {
                        list6 = list8;
                        i7 = iIntValue;
                    }
                    if (z6) {
                        if (z5) {
                            list4 = list8;
                            i4 = iIntValue;
                        } else {
                            list6 = list8;
                            i7 = iIntValue;
                            z4 = true;
                        }
                    }
                }
                if (list3 == null || z5 || getOrderedSupportedStreamUseCaseSurfaceConfigList(featureSettingsCreateFeatureSettings, list9) == null) {
                    i5 = i5;
                } else {
                    int i9 = i5;
                    if (i9 != i8 && i9 >= iIntValue) {
                        i5 = i9;
                    } else {
                        list7 = list8;
                        i5 = iIntValue;
                    }
                    if (!z6) {
                        continue;
                    } else {
                        if (z4) {
                            i5 = iIntValue;
                            list4 = list6;
                            list5 = list8;
                            i4 = i7;
                            break;
                        }
                        list7 = list8;
                        i5 = iIntValue;
                        z5 = true;
                    }
                }
                i2 = i6;
                i3 = i8;
                i4 = i7;
                map2 = map6;
                str4 = str2;
                list2 = list3;
                map3 = map5;
                str3 = str;
            } else {
                map5 = map3;
                list3 = list2;
                str = str3;
                str2 = str4;
                map6 = map2;
                list4 = list6;
            }
            list5 = list7;
            break;
        }
        if (list4 != null) {
            Range closestSupportedDeviceFrameRate = targetFpsRange != null ? getClosestSupportedDeviceFrameRate(targetFpsRange, i4) : null;
            int size = arrayList.size();
            int i10 = 0;
            while (i10 < size) {
                Object obj = arrayList.get(i10);
                i10++;
                UseCaseConfig useCaseConfig2 = (UseCaseConfig) obj;
                List list10 = useCasesPriorityOrder;
                StreamSpec.Builder zslDisabled = StreamSpec.builder((Size) list4.get(useCasesPriorityOrder.indexOf(Integer.valueOf(arrayList.indexOf(useCaseConfig2))))).setDynamicRange((DynamicRange) Preconditions.checkNotNull((DynamicRange) mapResolveAndValidateDynamicRanges.get(useCaseConfig2))).setImplementationOptions(StreamUseCaseUtil.getStreamSpecImplementationOptions(useCaseConfig2)).setZslDisabled(z2);
                if (closestSupportedDeviceFrameRate != null) {
                    zslDisabled.setExpectedFrameRateRange(closestSupportedDeviceFrameRate);
                }
                map4.put(useCaseConfig2, zslDisabled.build());
                useCasesPriorityOrder = list10;
            }
            if (list3 == null || i4 != i5 || list4.size() != list5.size()) {
                map7 = map8;
                break;
            }
            int i11 = 0;
            while (true) {
                if (i11 < list4.size()) {
                    if (!((Size) list4.get(i11)).equals(list5.get(i11))) {
                        map7 = map8;
                        break;
                    }
                    i11++;
                } else {
                    map7 = map8;
                    if (!StreamUseCaseUtil.populateStreamUseCaseStreamSpecOptionWithInteropOverride(this.mCharacteristics, list, map4, map7)) {
                        StreamUseCaseUtil.populateStreamUseCaseStreamSpecOptionWithSupportedSurfaceConfigs(map4, map7, map6, map5, list3);
                        break;
                    }
                    break;
                }
            }
            return new Pair(map4, map7);
        }
        throw new IllegalArgumentException(str2 + this.mCameraId + " and Hardware level: " + this.mHardwareLevel + ". May be the specified resolution is too large and not supported. Existing surfaces: " + list + str + arrayList);
    }

    private static boolean isUltraHdrOn(List list, Map map) {
        Iterator it = list.iterator();
        while (it.hasNext()) {
            if (((AttachedSurfaceInfo) it.next()).getImageFormat() == 4101) {
                return true;
            }
        }
        Iterator it2 = map.keySet().iterator();
        while (it2.hasNext()) {
            if (((UseCaseConfig) it2.next()).getInputFormat() == 4101) {
                return true;
            }
        }
        return false;
    }

    private FeatureSettings createFeatureSettings(int i, Map map, boolean z, boolean z2) {
        int requiredMaxBitDepth = getRequiredMaxBitDepth(map);
        if (i != 0 && z2) {
            throw new IllegalArgumentException(String.format("Camera device id is %s. Ultra HDR is not currently supported in %s camera mode.", this.mCameraId, CameraMode.toLabelString(i)));
        }
        if (i != 0 && requiredMaxBitDepth == 10) {
            throw new IllegalArgumentException(String.format("Camera device id is %s. 10 bit dynamic range is not currently supported in %s camera mode.", this.mCameraId, CameraMode.toLabelString(i)));
        }
        return FeatureSettings.of(i, requiredMaxBitDepth, z, z2);
    }

    private boolean isUseCasesCombinationSupported(FeatureSettings featureSettings, List list, Map map) {
        ArrayList arrayList = new ArrayList();
        Iterator it = list.iterator();
        while (it.hasNext()) {
            arrayList.add(((AttachedSurfaceInfo) it.next()).getSurfaceConfig());
        }
        CompareSizesByArea compareSizesByArea = new CompareSizesByArea();
        for (UseCaseConfig useCaseConfig : map.keySet()) {
            List list2 = (List) map.get(useCaseConfig);
            Preconditions.checkArgument((list2 == null || list2.isEmpty()) ? false : true, "No available output size is found for " + useCaseConfig + ".");
            Size size = (Size) Collections.min(list2, compareSizesByArea);
            int inputFormat = useCaseConfig.getInputFormat();
            arrayList.add(SurfaceConfig.transformSurfaceConfig(featureSettings.getCameraMode(), inputFormat, size, getUpdatedSurfaceSizeDefinitionByFormat(inputFormat)));
        }
        return checkSupported(featureSettings, arrayList);
    }

    private Range getTargetFpsRange(List list, List list2, List list3) {
        Iterator it = list.iterator();
        Range updatedTargetFramerate = null;
        while (it.hasNext()) {
            updatedTargetFramerate = getUpdatedTargetFramerate(((AttachedSurfaceInfo) it.next()).getTargetFrameRate(), updatedTargetFramerate);
        }
        Iterator it2 = list3.iterator();
        while (it2.hasNext()) {
            updatedTargetFramerate = getUpdatedTargetFramerate(((UseCaseConfig) list2.get(((Integer) it2.next()).intValue())).getTargetFrameRate(null), updatedTargetFramerate);
        }
        return updatedTargetFramerate;
    }

    private int getMaxSupportedFpsFromAttachedSurfaces(List list) {
        Iterator it = list.iterator();
        int updatedMaximumFps = Integer.MAX_VALUE;
        while (it.hasNext()) {
            AttachedSurfaceInfo attachedSurfaceInfo = (AttachedSurfaceInfo) it.next();
            updatedMaximumFps = getUpdatedMaximumFps(updatedMaximumFps, attachedSurfaceInfo.getImageFormat(), attachedSurfaceInfo.getSize());
        }
        return updatedMaximumFps;
    }

    private Map filterSupportedSizes(Map map, FeatureSettings featureSettings, Range range) {
        HashMap map2 = new HashMap();
        for (UseCaseConfig useCaseConfig : map.keySet()) {
            ArrayList arrayList = new ArrayList();
            HashMap map3 = new HashMap();
            for (Size size : (List) map.get(useCaseConfig)) {
                int inputFormat = useCaseConfig.getInputFormat();
                SurfaceConfig.ConfigSize configSize = SurfaceConfig.transformSurfaceConfig(featureSettings.getCameraMode(), inputFormat, size, getUpdatedSurfaceSizeDefinitionByFormat(inputFormat)).getConfigSize();
                int maxFrameRate = range != null ? getMaxFrameRate(this.mCharacteristics, inputFormat, size) : Integer.MAX_VALUE;
                Set hashSet = (Set) map3.get(configSize);
                if (hashSet == null) {
                    hashSet = new HashSet();
                    map3.put(configSize, hashSet);
                }
                if (!hashSet.contains(Integer.valueOf(maxFrameRate))) {
                    arrayList.add(size);
                    hashSet.add(Integer.valueOf(maxFrameRate));
                }
            }
            map2.put(useCaseConfig, arrayList);
        }
        return map2;
    }

    private Pair getSurfaceConfigListAndFpsCeiling(int i, List list, List list2, List list3, List list4, int i2, Map map, Map map2) {
        ArrayList arrayList = new ArrayList();
        Iterator it = list.iterator();
        while (it.hasNext()) {
            AttachedSurfaceInfo attachedSurfaceInfo = (AttachedSurfaceInfo) it.next();
            arrayList.add(attachedSurfaceInfo.getSurfaceConfig());
            if (map != null) {
                map.put(Integer.valueOf(arrayList.size() - 1), attachedSurfaceInfo);
            }
        }
        for (int i3 = 0; i3 < list2.size(); i3++) {
            Size size = (Size) list2.get(i3);
            UseCaseConfig useCaseConfig = (UseCaseConfig) list3.get(((Integer) list4.get(i3)).intValue());
            int inputFormat = useCaseConfig.getInputFormat();
            arrayList.add(SurfaceConfig.transformSurfaceConfig(i, inputFormat, size, getUpdatedSurfaceSizeDefinitionByFormat(inputFormat)));
            if (map2 != null) {
                map2.put(Integer.valueOf(arrayList.size() - 1), useCaseConfig);
            }
            i2 = getUpdatedMaximumFps(i2, useCaseConfig.getInputFormat(), size);
        }
        return new Pair(arrayList, Integer.valueOf(i2));
    }

    List applyResolutionSelectionOrderRelatedWorkarounds(List list, int i) {
        Rational rational;
        int i2 = this.mTargetAspectRatio.get(this.mCameraId, this.mCharacteristics);
        if (i2 == 0) {
            rational = AspectRatioUtil.ASPECT_RATIO_4_3;
        } else if (i2 == 1) {
            rational = AspectRatioUtil.ASPECT_RATIO_16_9;
        } else if (i2 != 2) {
            rational = null;
        } else {
            Size maximumSize = getUpdatedSurfaceSizeDefinitionByFormat(256).getMaximumSize(256);
            rational = new Rational(maximumSize.getWidth(), maximumSize.getHeight());
        }
        if (rational != null) {
            ArrayList arrayList = new ArrayList();
            ArrayList arrayList2 = new ArrayList();
            Iterator it = list.iterator();
            while (it.hasNext()) {
                Size size = (Size) it.next();
                if (AspectRatioUtil.hasMatchingAspectRatio(size, rational)) {
                    arrayList.add(size);
                } else {
                    arrayList2.add(size);
                }
            }
            arrayList2.addAll(0, arrayList);
            list = arrayList2;
        }
        return this.mResolutionCorrector.insertOrPrioritize(SurfaceConfig.getConfigType(i), list);
    }

    private static int getRequiredMaxBitDepth(Map map) {
        Iterator it = map.values().iterator();
        while (it.hasNext()) {
            if (((DynamicRange) it.next()).getBitDepth() == 10) {
                return 10;
            }
        }
        return 8;
    }

    private static List getUseCasesPriorityOrder(List list) {
        ArrayList arrayList = new ArrayList();
        ArrayList arrayList2 = new ArrayList();
        Iterator it = list.iterator();
        while (it.hasNext()) {
            int surfaceOccupancyPriority = ((UseCaseConfig) it.next()).getSurfaceOccupancyPriority(0);
            if (!arrayList2.contains(Integer.valueOf(surfaceOccupancyPriority))) {
                arrayList2.add(Integer.valueOf(surfaceOccupancyPriority));
            }
        }
        Collections.sort(arrayList2);
        Collections.reverse(arrayList2);
        int size = arrayList2.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList2.get(i);
            i++;
            int iIntValue = ((Integer) obj).intValue();
            Iterator it2 = list.iterator();
            while (it2.hasNext()) {
                UseCaseConfig useCaseConfig = (UseCaseConfig) it2.next();
                if (iIntValue == useCaseConfig.getSurfaceOccupancyPriority(0)) {
                    arrayList.add(Integer.valueOf(list.indexOf(useCaseConfig)));
                }
            }
        }
        return arrayList;
    }

    private List getAllPossibleSizeArrangements(List list) {
        Iterator it = list.iterator();
        int size = 1;
        while (it.hasNext()) {
            size *= ((List) it.next()).size();
        }
        if (size == 0) {
            throw new IllegalArgumentException("Failed to find supported resolutions.");
        }
        ArrayList arrayList = new ArrayList();
        for (int i = 0; i < size; i++) {
            arrayList.add(new ArrayList());
        }
        int size2 = size / ((List) list.get(0)).size();
        int i2 = size;
        for (int i3 = 0; i3 < list.size(); i3++) {
            List list2 = (List) list.get(i3);
            for (int i4 = 0; i4 < size; i4++) {
                ((List) arrayList.get(i4)).add((Size) list2.get((i4 % i2) / size2));
            }
            if (i3 < list.size() - 1) {
                i2 = size2;
                size2 /= ((List) list.get(i3 + 1)).size();
            }
        }
        return arrayList;
    }

    private Size getMaxOutputSizeByFormat(StreamConfigurationMap streamConfigurationMap, int i, boolean z) {
        Size[] outputSizes;
        Size[] highResolutionOutputSizes;
        if (i == 34) {
            outputSizes = streamConfigurationMap.getOutputSizes(SurfaceTexture.class);
        } else {
            outputSizes = streamConfigurationMap.getOutputSizes(i);
        }
        if (outputSizes == null || outputSizes.length == 0) {
            return null;
        }
        CompareSizesByArea compareSizesByArea = new CompareSizesByArea();
        Size size = (Size) Collections.max(Arrays.asList(outputSizes), compareSizesByArea);
        Size size2 = SizeUtil.RESOLUTION_ZERO;
        if (z && (highResolutionOutputSizes = Api23Impl.getHighResolutionOutputSizes(streamConfigurationMap, i)) != null && highResolutionOutputSizes.length > 0) {
            size2 = (Size) Collections.max(Arrays.asList(highResolutionOutputSizes), compareSizesByArea);
        }
        return (Size) Collections.max(Arrays.asList(size, size2), compareSizesByArea);
    }

    private void generateSupportedCombinationList() {
        this.mSurfaceCombinations.addAll(GuaranteedConfigurationsUtil.generateSupportedCombinationList(this.mHardwareLevel, this.mIsRawSupported, this.mIsBurstCaptureSupported));
        this.mSurfaceCombinations.addAll(this.mExtraSupportedSurfaceCombinationsContainer.get(this.mCameraId));
    }

    private void generateUltraHighSupportedCombinationList() {
        this.mUltraHighSurfaceCombinations.addAll(GuaranteedConfigurationsUtil.getUltraHighResolutionSupportedCombinationList());
    }

    private void generateConcurrentSupportedCombinationList() {
        this.mConcurrentSurfaceCombinations.addAll(GuaranteedConfigurationsUtil.getConcurrentSupportedCombinationList());
    }

    private void generate10BitSupportedCombinationList() {
        this.mSurfaceCombinations10Bit.addAll(GuaranteedConfigurationsUtil.get10BitSupportedCombinationList());
    }

    private void generateUltraHdrSupportedCombinationList() {
        this.mSurfaceCombinationsUltraHdr.addAll(GuaranteedConfigurationsUtil.getUltraHdrSupportedCombinationList());
    }

    private void generateStreamUseCaseSupportedCombinationList() {
        if (Build.VERSION.SDK_INT >= 33) {
            this.mSurfaceCombinationsStreamUseCase.addAll(GuaranteedConfigurationsUtil.getStreamUseCaseSupportedCombinationList());
        }
    }

    private void generatePreviewStabilizationSupportedCombinationList() {
        if (Build.VERSION.SDK_INT >= 33) {
            this.mPreviewStabilizationSurfaceCombinations.addAll(GuaranteedConfigurationsUtil.getPreviewStabilizationSupportedCombinationList());
        }
    }

    private void checkCustomization() {
    }

    private void generateSurfaceSizeDefinition() {
        this.mSurfaceSizeDefinition = SurfaceSizeDefinition.create(SizeUtil.RESOLUTION_VGA, new HashMap(), this.mDisplayInfoManager.getPreviewSize(), new HashMap(), getRecordSize(), new HashMap(), new HashMap());
    }

    SurfaceSizeDefinition getUpdatedSurfaceSizeDefinitionByFormat(int i) {
        if (!this.mSurfaceSizeDefinitionFormats.contains(Integer.valueOf(i))) {
            updateS720pOrS1440pSizeByFormat(this.mSurfaceSizeDefinition.getS720pSizeMap(), SizeUtil.RESOLUTION_720P, i);
            updateS720pOrS1440pSizeByFormat(this.mSurfaceSizeDefinition.getS1440pSizeMap(), SizeUtil.RESOLUTION_1440P, i);
            updateMaximumSizeByFormat(this.mSurfaceSizeDefinition.getMaximumSizeMap(), i);
            updateUltraMaximumSizeByFormat(this.mSurfaceSizeDefinition.getUltraMaximumSizeMap(), i);
            this.mSurfaceSizeDefinitionFormats.add(Integer.valueOf(i));
        }
        return this.mSurfaceSizeDefinition;
    }

    private void updateS720pOrS1440pSizeByFormat(Map map, Size size, int i) {
        if (this.mIsConcurrentCameraModeSupported) {
            Size maxOutputSizeByFormat = getMaxOutputSizeByFormat(this.mCharacteristics.getStreamConfigurationMapCompat().toStreamConfigurationMap(), i, false);
            Integer numValueOf = Integer.valueOf(i);
            if (maxOutputSizeByFormat != null) {
                size = (Size) Collections.min(Arrays.asList(size, maxOutputSizeByFormat), new CompareSizesByArea());
            }
            map.put(numValueOf, size);
        }
    }

    private void updateMaximumSizeByFormat(Map map, int i) {
        Size maxOutputSizeByFormat = getMaxOutputSizeByFormat(this.mCharacteristics.getStreamConfigurationMapCompat().toStreamConfigurationMap(), i, true);
        if (maxOutputSizeByFormat != null) {
            map.put(Integer.valueOf(i), maxOutputSizeByFormat);
        }
    }

    private void updateUltraMaximumSizeByFormat(Map map, int i) {
        StreamConfigurationMap streamConfigurationMap;
        if (Build.VERSION.SDK_INT < 31 || !this.mIsUltraHighResolutionSensorSupported || (streamConfigurationMap = (StreamConfigurationMap) this.mCharacteristics.get(CameraCharacteristics.SCALER_STREAM_CONFIGURATION_MAP_MAXIMUM_RESOLUTION)) == null) {
            return;
        }
        map.put(Integer.valueOf(i), getMaxOutputSizeByFormat(streamConfigurationMap, i, true));
    }

    private void refreshPreviewSize() {
        this.mDisplayInfoManager.refresh();
        if (this.mSurfaceSizeDefinition == null) {
            generateSurfaceSizeDefinition();
        } else {
            this.mSurfaceSizeDefinition = SurfaceSizeDefinition.create(this.mSurfaceSizeDefinition.getAnalysisSize(), this.mSurfaceSizeDefinition.getS720pSizeMap(), this.mDisplayInfoManager.getPreviewSize(), this.mSurfaceSizeDefinition.getS1440pSizeMap(), this.mSurfaceSizeDefinition.getRecordSize(), this.mSurfaceSizeDefinition.getMaximumSizeMap(), this.mSurfaceSizeDefinition.getUltraMaximumSizeMap());
        }
    }

    private Size getRecordSize() {
        try {
            int i = Integer.parseInt(this.mCameraId);
            CamcorderProfile camcorderProfile = this.mCamcorderProfileHelper.hasProfile(i, 1) ? this.mCamcorderProfileHelper.get(i, 1) : null;
            if (camcorderProfile != null) {
                return new Size(camcorderProfile.videoFrameWidth, camcorderProfile.videoFrameHeight);
            }
            return getRecordSizeByHasProfile(i);
        } catch (NumberFormatException unused) {
            return getRecordSizeFromStreamConfigurationMap();
        }
    }

    private Size getRecordSizeFromStreamConfigurationMap() {
        Size[] outputSizes = this.mCharacteristics.getStreamConfigurationMapCompat().toStreamConfigurationMap().getOutputSizes(MediaRecorder.class);
        if (outputSizes == null) {
            return SizeUtil.RESOLUTION_480P;
        }
        Arrays.sort(outputSizes, new CompareSizesByArea(true));
        for (Size size : outputSizes) {
            int width = size.getWidth();
            Size size2 = SizeUtil.RESOLUTION_1080P;
            if (width <= size2.getWidth() && size.getHeight() <= size2.getHeight()) {
                return size;
            }
        }
        return SizeUtil.RESOLUTION_480P;
    }

    private Size getRecordSizeByHasProfile(int i) {
        CamcorderProfile camcorderProfile;
        Size size = SizeUtil.RESOLUTION_480P;
        if (this.mCamcorderProfileHelper.hasProfile(i, 10)) {
            camcorderProfile = this.mCamcorderProfileHelper.get(i, 10);
        } else if (this.mCamcorderProfileHelper.hasProfile(i, 8)) {
            camcorderProfile = this.mCamcorderProfileHelper.get(i, 8);
        } else if (this.mCamcorderProfileHelper.hasProfile(i, 12)) {
            camcorderProfile = this.mCamcorderProfileHelper.get(i, 12);
        } else if (this.mCamcorderProfileHelper.hasProfile(i, 6)) {
            camcorderProfile = this.mCamcorderProfileHelper.get(i, 6);
        } else if (this.mCamcorderProfileHelper.hasProfile(i, 5)) {
            camcorderProfile = this.mCamcorderProfileHelper.get(i, 5);
        } else {
            camcorderProfile = this.mCamcorderProfileHelper.hasProfile(i, 4) ? this.mCamcorderProfileHelper.get(i, 4) : null;
        }
        return camcorderProfile != null ? new Size(camcorderProfile.videoFrameWidth, camcorderProfile.videoFrameHeight) : size;
    }

    static class Api23Impl {
        static Size[] getHighResolutionOutputSizes(StreamConfigurationMap streamConfigurationMap, int i) {
            return streamConfigurationMap.getHighResolutionOutputSizes(i);
        }
    }

    static abstract class FeatureSettings {
        abstract int getCameraMode();

        abstract int getRequiredMaxBitDepth();

        abstract boolean isPreviewStabilizationOn();

        abstract boolean isUltraHdrOn();

        FeatureSettings() {
        }

        static FeatureSettings of(int i, int i2, boolean z, boolean z2) {
            return new AutoValue_SupportedSurfaceCombination_FeatureSettings(i, i2, z, z2);
        }
    }
}
