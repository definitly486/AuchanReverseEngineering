package com.scanflow.datacapture.barinternal.androidx.camera.core.internal;

import android.graphics.Matrix;
import android.graphics.Rect;
import android.graphics.RectF;
import android.graphics.SurfaceTexture;
import android.util.Log;
import android.util.Pair;
import android.util.Size;
import android.view.Surface;
import androidx.camera.core.Camera;
import androidx.camera.core.CameraControl;
import androidx.camera.core.CameraEffect;
import androidx.camera.core.CameraInfo;
import androidx.camera.core.DynamicRange;
import androidx.camera.core.ImageCapture;
import androidx.camera.core.LayoutSettings;
import androidx.camera.core.Logger;
import androidx.camera.core.Preview;
import androidx.camera.core.SurfaceRequest;
import androidx.camera.core.UseCase;
import androidx.camera.core.ViewPort;
import androidx.camera.core.impl.AttachedSurfaceInfo;
import androidx.camera.core.impl.CameraConfig;
import androidx.camera.core.impl.CameraControlInternal;
import androidx.camera.core.impl.CameraDeviceSurfaceManager;
import androidx.camera.core.impl.CameraInfoInternal;
import androidx.camera.core.impl.CameraInternal;
import androidx.camera.core.impl.Config;
import androidx.camera.core.impl.Identifier;
import androidx.camera.core.impl.ImageCaptureConfig;
import androidx.camera.core.impl.MutableOptionsBundle;
import androidx.camera.core.impl.PreviewConfig;
import androidx.camera.core.impl.RestrictedCameraControl;
import androidx.camera.core.impl.RestrictedCameraInfo;
import androidx.camera.core.impl.SessionConfig;
import androidx.camera.core.impl.StreamSpec;
import androidx.camera.core.impl.UseCaseConfig;
import androidx.camera.core.impl.UseCaseConfigFactory;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import androidx.camera.core.internal.TargetConfig;
import androidx.core.util.Consumer;
import com.scanflow.datacapture.barinternal.androidx.camera.core.concurrent.CameraCoordinator;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.TransformUtils;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.TargetUtils;
import com.scanflow.datacapture.barinternal.androidx.camera.core.streamsharing.StreamSharing;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public final class CameraUseCaseAdapter implements Camera {
    private final RestrictedCameraControl mAdapterCameraControl;
    private final RestrictedCameraInfo mAdapterCameraInfo;
    private final RestrictedCameraInfo mAdapterSecondaryCameraInfo;
    private final CameraConfig mCameraConfig;
    private final CameraCoordinator mCameraCoordinator;
    private final CameraDeviceSurfaceManager mCameraDeviceSurfaceManager;
    private final CameraInternal mCameraInternal;
    private final CameraId mId;
    private final LayoutSettings mLayoutSettings;
    private UseCase mPlaceholderForExtensions;
    private final CameraInternal mSecondaryCameraInternal;
    private final LayoutSettings mSecondaryLayoutSettings;
    private StreamSharing mStreamSharing;
    private final UseCaseConfigFactory mUseCaseConfigFactory;
    private ViewPort mViewPort;
    private final List mAppUseCases = new ArrayList();
    private final List mCameraUseCases = new ArrayList();
    private List mEffects = Collections.EMPTY_LIST;
    private final Object mLock = new Object();
    private boolean mAttached = true;
    private Config mInteropConfig = null;

    public CameraUseCaseAdapter(CameraInternal cameraInternal, CameraInternal cameraInternal2, RestrictedCameraInfo restrictedCameraInfo, RestrictedCameraInfo restrictedCameraInfo2, LayoutSettings layoutSettings, LayoutSettings layoutSettings2, CameraCoordinator cameraCoordinator, CameraDeviceSurfaceManager cameraDeviceSurfaceManager, UseCaseConfigFactory useCaseConfigFactory) {
        this.mCameraInternal = cameraInternal;
        this.mSecondaryCameraInternal = cameraInternal2;
        this.mLayoutSettings = layoutSettings;
        this.mSecondaryLayoutSettings = layoutSettings2;
        this.mCameraCoordinator = cameraCoordinator;
        this.mCameraDeviceSurfaceManager = cameraDeviceSurfaceManager;
        this.mUseCaseConfigFactory = useCaseConfigFactory;
        CameraConfig cameraConfig = restrictedCameraInfo.getCameraConfig();
        this.mCameraConfig = cameraConfig;
        this.mAdapterCameraControl = new RestrictedCameraControl(cameraInternal.getCameraControlInternal(), cameraConfig.getSessionProcessor(null));
        this.mAdapterCameraInfo = restrictedCameraInfo;
        this.mAdapterSecondaryCameraInfo = restrictedCameraInfo2;
        this.mId = generateCameraId(restrictedCameraInfo, restrictedCameraInfo2);
    }

    public static CameraId generateCameraId(RestrictedCameraInfo restrictedCameraInfo, RestrictedCameraInfo restrictedCameraInfo2) {
        StringBuilder sb = new StringBuilder();
        sb.append(restrictedCameraInfo.getCameraId());
        sb.append(restrictedCameraInfo2 == null ? "" : restrictedCameraInfo2.getCameraId());
        return CameraId.create(sb.toString(), restrictedCameraInfo.getCameraConfig().getCompatibilityId());
    }

    public CameraId getCameraId() {
        return this.mId;
    }

    public void setViewPort(ViewPort viewPort) {
        synchronized (this.mLock) {
            this.mViewPort = viewPort;
        }
    }

    public void setEffects(List list) {
        synchronized (this.mLock) {
            this.mEffects = list;
        }
    }

    public void addUseCases(Collection collection) {
        synchronized (this.mLock) {
            try {
                this.mCameraInternal.setExtendedConfig(this.mCameraConfig);
                CameraInternal cameraInternal = this.mSecondaryCameraInternal;
                if (cameraInternal != null) {
                    cameraInternal.setExtendedConfig(this.mCameraConfig);
                }
                LinkedHashSet linkedHashSet = new LinkedHashSet(this.mAppUseCases);
                linkedHashSet.addAll(collection);
                try {
                    CameraInternal cameraInternal2 = this.mSecondaryCameraInternal;
                    updateUseCases(linkedHashSet, cameraInternal2 != null, cameraInternal2 != null);
                } catch (IllegalArgumentException e) {
                    throw new CameraException(e);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public void removeUseCases(Collection collection) {
        synchronized (this.mLock) {
            LinkedHashSet linkedHashSet = new LinkedHashSet(this.mAppUseCases);
            linkedHashSet.removeAll(collection);
            CameraInternal cameraInternal = this.mSecondaryCameraInternal;
            updateUseCases(linkedHashSet, cameraInternal != null, cameraInternal != null);
        }
    }

    void updateUseCases(Collection collection, boolean z, boolean z2) {
        int i;
        StreamSpec streamSpec;
        Config implementationOptions;
        synchronized (this.mLock) {
            try {
                checkUnsupportedFeatureCombinationAndThrow(collection);
                if (!z && hasExtension() && hasVideoCapture(collection)) {
                    updateUseCases(collection, true, z2);
                    return;
                }
                StreamSharing streamSharingCreateOrReuseStreamSharing = createOrReuseStreamSharing(collection, z);
                UseCase useCaseCalculatePlaceholderForExtensions = calculatePlaceholderForExtensions(collection, streamSharingCreateOrReuseStreamSharing);
                Collection collectionCalculateCameraUseCases = calculateCameraUseCases(collection, useCaseCalculatePlaceholderForExtensions, streamSharingCreateOrReuseStreamSharing);
                ArrayList arrayList = new ArrayList(collectionCalculateCameraUseCases);
                arrayList.removeAll(this.mCameraUseCases);
                ArrayList arrayList2 = new ArrayList(collectionCalculateCameraUseCases);
                arrayList2.retainAll(this.mCameraUseCases);
                ArrayList arrayList3 = new ArrayList(this.mCameraUseCases);
                arrayList3.removeAll(collectionCalculateCameraUseCases);
                Map configs = getConfigs(arrayList, this.mCameraConfig.getUseCaseConfigFactory(), this.mUseCaseConfigFactory);
                Map mapCalculateSuggestedStreamSpecs = Collections.EMPTY_MAP;
                try {
                    Map mapCalculateSuggestedStreamSpecs2 = calculateSuggestedStreamSpecs(getCameraMode(), this.mCameraInternal.getCameraInfoInternal(), arrayList, arrayList2, configs);
                    if (this.mSecondaryCameraInternal != null) {
                        int cameraMode = getCameraMode();
                        CameraInternal cameraInternal = this.mSecondaryCameraInternal;
                        Objects.requireNonNull(cameraInternal);
                        mapCalculateSuggestedStreamSpecs = calculateSuggestedStreamSpecs(cameraMode, cameraInternal.getCameraInfoInternal(), arrayList, arrayList2, configs);
                    }
                    updateViewPortAndSensorToBufferMatrix(mapCalculateSuggestedStreamSpecs2, collectionCalculateCameraUseCases);
                    updateEffects(this.mEffects, collectionCalculateCameraUseCases, collection);
                    int size = arrayList3.size();
                    int i2 = 0;
                    while (i2 < size) {
                        Object obj = arrayList3.get(i2);
                        i2++;
                        ((UseCase) obj).unbindFromCamera(this.mCameraInternal);
                    }
                    this.mCameraInternal.detachUseCases(arrayList3);
                    if (this.mSecondaryCameraInternal != null) {
                        int size2 = arrayList3.size();
                        int i3 = 0;
                        while (i3 < size2) {
                            Object obj2 = arrayList3.get(i3);
                            i3++;
                            CameraInternal cameraInternal2 = this.mSecondaryCameraInternal;
                            Objects.requireNonNull(cameraInternal2);
                            ((UseCase) obj2).unbindFromCamera(cameraInternal2);
                        }
                        CameraInternal cameraInternal3 = this.mSecondaryCameraInternal;
                        Objects.requireNonNull(cameraInternal3);
                        cameraInternal3.detachUseCases(arrayList3);
                    }
                    if (arrayList3.isEmpty()) {
                        int size3 = arrayList2.size();
                        int i4 = 0;
                        while (i4 < size3) {
                            Object obj3 = arrayList2.get(i4);
                            i4++;
                            UseCase useCase = (UseCase) obj3;
                            if (!mapCalculateSuggestedStreamSpecs2.containsKey(useCase) || (implementationOptions = (streamSpec = (StreamSpec) mapCalculateSuggestedStreamSpecs2.get(useCase)).getImplementationOptions()) == null) {
                                i = size3;
                            } else {
                                i = size3;
                                if (hasImplementationOptionChanged(streamSpec, useCase.getSessionConfig())) {
                                    useCase.updateSuggestedStreamSpecImplementationOptions(implementationOptions);
                                    if (this.mAttached) {
                                        this.mCameraInternal.onUseCaseUpdated(useCase);
                                        CameraInternal cameraInternal4 = this.mSecondaryCameraInternal;
                                        if (cameraInternal4 != null) {
                                            Objects.requireNonNull(cameraInternal4);
                                            cameraInternal4.onUseCaseUpdated(useCase);
                                        }
                                    }
                                }
                            }
                            size3 = i;
                        }
                    }
                    int i5 = 0;
                    for (int size4 = arrayList.size(); i5 < size4; size4 = size4) {
                        Object obj4 = arrayList.get(i5);
                        i5++;
                        UseCase useCase2 = (UseCase) obj4;
                        ConfigPair configPair = (ConfigPair) configs.get(useCase2);
                        Objects.requireNonNull(configPair);
                        CameraInternal cameraInternal5 = this.mSecondaryCameraInternal;
                        if (cameraInternal5 != null) {
                            CameraInternal cameraInternal6 = this.mCameraInternal;
                            Objects.requireNonNull(cameraInternal5);
                            useCase2.bindToCamera(cameraInternal6, cameraInternal5, configPair.mExtendedConfig, configPair.mCameraConfig);
                            useCase2.updateSuggestedStreamSpec((StreamSpec) Preconditions.checkNotNull((StreamSpec) mapCalculateSuggestedStreamSpecs2.get(useCase2)), (StreamSpec) mapCalculateSuggestedStreamSpecs.get(useCase2));
                        } else {
                            useCase2.bindToCamera(this.mCameraInternal, null, configPair.mExtendedConfig, configPair.mCameraConfig);
                            useCase2.updateSuggestedStreamSpec((StreamSpec) Preconditions.checkNotNull((StreamSpec) mapCalculateSuggestedStreamSpecs2.get(useCase2)), null);
                        }
                    }
                    if (this.mAttached) {
                        this.mCameraInternal.attachUseCases(arrayList);
                        CameraInternal cameraInternal7 = this.mSecondaryCameraInternal;
                        if (cameraInternal7 != null) {
                            Objects.requireNonNull(cameraInternal7);
                            cameraInternal7.attachUseCases(arrayList);
                        }
                    }
                    int size5 = arrayList.size();
                    int i6 = 0;
                    while (i6 < size5) {
                        Object obj5 = arrayList.get(i6);
                        i6++;
                        ((UseCase) obj5).notifyState();
                    }
                    this.mAppUseCases.clear();
                    this.mAppUseCases.addAll(collection);
                    this.mCameraUseCases.clear();
                    this.mCameraUseCases.addAll(collectionCalculateCameraUseCases);
                    this.mPlaceholderForExtensions = useCaseCalculatePlaceholderForExtensions;
                    this.mStreamSharing = streamSharingCreateOrReuseStreamSharing;
                } catch (IllegalArgumentException e) {
                    if (!z && !hasExtension() && this.mCameraCoordinator.getCameraOperatingMode() != 2) {
                        updateUseCases(collection, true, z2);
                        return;
                    }
                    throw e;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private static boolean hasImplementationOptionChanged(StreamSpec streamSpec, SessionConfig sessionConfig) {
        Config implementationOptions = streamSpec.getImplementationOptions();
        Config implementationOptions2 = sessionConfig.getImplementationOptions();
        if (implementationOptions.listOptions().size() != sessionConfig.getImplementationOptions().listOptions().size()) {
            return true;
        }
        for (Config.Option<?> option : implementationOptions.listOptions()) {
            if (!implementationOptions2.containsOption(option) || !Objects.equals(implementationOptions2.retrieveOption(option), implementationOptions.retrieveOption(option))) {
                return true;
            }
        }
        return false;
    }

    private int getCameraMode() {
        synchronized (this.mLock) {
            try {
                return this.mCameraCoordinator.getCameraOperatingMode() == 2 ? 1 : 0;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private boolean hasExtension() {
        boolean z;
        synchronized (this.mLock) {
            z = this.mCameraConfig.getSessionProcessor(null) != null;
        }
        return z;
    }

    private Set getStreamSharingChildren(Collection collection, boolean z) {
        HashSet hashSet = new HashSet();
        int sharingTargets = getSharingTargets(z);
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            UseCase useCase = (UseCase) it.next();
            Preconditions.checkArgument(!StreamSharing.isStreamSharing(useCase), "Only support one level of sharing for now.");
            if (useCase.isEffectTargetsSupported(sharingTargets)) {
                hashSet.add(useCase);
            }
        }
        return hashSet;
    }

    private int getSharingTargets(boolean z) {
        int targets;
        synchronized (this.mLock) {
            try {
                Iterator it = this.mEffects.iterator();
                CameraEffect cameraEffect = null;
                while (true) {
                    targets = 0;
                    if (!it.hasNext()) {
                        break;
                    }
                    CameraEffect cameraEffect2 = (CameraEffect) it.next();
                    if (TargetUtils.getNumberOfTargets(cameraEffect2.getTargets()) > 1) {
                        Preconditions.checkState(cameraEffect == null, "Can only have one sharing effect.");
                        cameraEffect = cameraEffect2;
                    }
                }
                if (cameraEffect != null) {
                    targets = cameraEffect.getTargets();
                }
                if (z) {
                    targets |= 3;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return targets;
    }

    private StreamSharing createOrReuseStreamSharing(Collection collection, boolean z) {
        synchronized (this.mLock) {
            try {
                Set streamSharingChildren = getStreamSharingChildren(collection, z);
                if (streamSharingChildren.size() >= 2 || (hasExtension() && hasVideoCapture(streamSharingChildren))) {
                    StreamSharing streamSharing = this.mStreamSharing;
                    if (streamSharing != null && streamSharing.getChildren().equals(streamSharingChildren)) {
                        StreamSharing streamSharing2 = this.mStreamSharing;
                        Objects.requireNonNull(streamSharing2);
                        return streamSharing2;
                    }
                    if (!isStreamSharingChildrenCombinationValid(streamSharingChildren)) {
                        return null;
                    }
                    return new StreamSharing(this.mCameraInternal, this.mSecondaryCameraInternal, this.mLayoutSettings, this.mSecondaryLayoutSettings, streamSharingChildren, this.mUseCaseConfigFactory);
                }
                return null;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    static boolean isStreamSharingChildrenCombinationValid(Collection collection) {
        int[] iArr = {1, 2, 4};
        HashSet hashSet = new HashSet();
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            UseCase useCase = (UseCase) it.next();
            for (int i = 0; i < 3; i++) {
                int i2 = iArr[i];
                if (useCase.isEffectTargetsSupported(i2)) {
                    if (hashSet.contains(Integer.valueOf(i2))) {
                        return false;
                    }
                    hashSet.add(Integer.valueOf(i2));
                }
            }
        }
        return true;
    }

    static Collection calculateCameraUseCases(Collection collection, UseCase useCase, StreamSharing streamSharing) {
        ArrayList arrayList = new ArrayList(collection);
        if (useCase != null) {
            arrayList.add(useCase);
        }
        if (streamSharing != null) {
            arrayList.add(streamSharing);
            arrayList.removeAll(streamSharing.getChildren());
        }
        return arrayList;
    }

    public List getUseCases() {
        ArrayList arrayList;
        synchronized (this.mLock) {
            arrayList = new ArrayList(this.mAppUseCases);
        }
        return arrayList;
    }

    public void attachUseCases() {
        synchronized (this.mLock) {
            try {
                if (!this.mAttached) {
                    if (!this.mCameraUseCases.isEmpty()) {
                        this.mCameraInternal.setExtendedConfig(this.mCameraConfig);
                        CameraInternal cameraInternal = this.mSecondaryCameraInternal;
                        if (cameraInternal != null) {
                            cameraInternal.setExtendedConfig(this.mCameraConfig);
                        }
                    }
                    this.mCameraInternal.attachUseCases(this.mCameraUseCases);
                    CameraInternal cameraInternal2 = this.mSecondaryCameraInternal;
                    if (cameraInternal2 != null) {
                        cameraInternal2.attachUseCases(this.mCameraUseCases);
                    }
                    restoreInteropConfig();
                    Iterator it = this.mCameraUseCases.iterator();
                    while (it.hasNext()) {
                        ((UseCase) it.next()).notifyState();
                    }
                    this.mAttached = true;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public void setActiveResumingMode(boolean z) {
        this.mCameraInternal.setActiveResumingMode(z);
    }

    public void detachUseCases() {
        synchronized (this.mLock) {
            try {
                if (this.mAttached) {
                    this.mCameraInternal.detachUseCases(new ArrayList(this.mCameraUseCases));
                    CameraInternal cameraInternal = this.mSecondaryCameraInternal;
                    if (cameraInternal != null) {
                        cameraInternal.detachUseCases(new ArrayList(this.mCameraUseCases));
                    }
                    cacheInteropConfig();
                    this.mAttached = false;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private void restoreInteropConfig() {
        synchronized (this.mLock) {
            try {
                if (this.mInteropConfig != null) {
                    this.mCameraInternal.getCameraControlInternal().addInteropConfig(this.mInteropConfig);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private void cacheInteropConfig() {
        synchronized (this.mLock) {
            CameraControlInternal cameraControlInternal = this.mCameraInternal.getCameraControlInternal();
            this.mInteropConfig = cameraControlInternal.getInteropConfig();
            cameraControlInternal.clearInteropConfig();
        }
    }

    private Map calculateSuggestedStreamSpecs(int i, CameraInfoInternal cameraInfoInternal, Collection collection, Collection collection2, Map map) {
        Rect sensorRect;
        ArrayList arrayList = new ArrayList();
        String cameraId = cameraInfoInternal.getCameraId();
        HashMap map2 = new HashMap();
        HashMap map3 = new HashMap();
        Iterator it = collection2.iterator();
        while (true) {
            if (!it.hasNext()) {
                break;
            }
            UseCase useCase = (UseCase) it.next();
            AttachedSurfaceInfo attachedSurfaceInfoCreate = AttachedSurfaceInfo.create(this.mCameraDeviceSurfaceManager.transformSurfaceConfig(i, cameraId, useCase.getImageFormat(), useCase.getAttachedSurfaceResolution()), useCase.getImageFormat(), useCase.getAttachedSurfaceResolution(), ((StreamSpec) Preconditions.checkNotNull(useCase.getAttachedStreamSpec())).getDynamicRange(), StreamSharing.getCaptureTypes(useCase), useCase.getAttachedStreamSpec().getImplementationOptions(), useCase.getCurrentConfig().getTargetFrameRate(null));
            arrayList.add(attachedSurfaceInfoCreate);
            map3.put(attachedSurfaceInfoCreate, useCase);
            map2.put(useCase, useCase.getAttachedStreamSpec());
        }
        if (!collection.isEmpty()) {
            HashMap map4 = new HashMap();
            HashMap map5 = new HashMap();
            try {
                sensorRect = this.mCameraInternal.getCameraControlInternal().getSensorRect();
            } catch (NullPointerException unused) {
                sensorRect = null;
            }
            SupportedOutputSizesSorter supportedOutputSizesSorter = new SupportedOutputSizesSorter(cameraInfoInternal, sensorRect != null ? TransformUtils.rectToSize(sensorRect) : null);
            Iterator it2 = collection.iterator();
            boolean z = false;
            while (it2.hasNext()) {
                UseCase useCase2 = (UseCase) it2.next();
                ConfigPair configPair = (ConfigPair) map.get(useCase2);
                UseCaseConfig<?> useCaseConfigMergeConfigs = useCase2.mergeConfigs(cameraInfoInternal, configPair.mExtendedConfig, configPair.mCameraConfig);
                map4.put(useCaseConfigMergeConfigs, useCase2);
                map5.put(useCaseConfigMergeConfigs, supportedOutputSizesSorter.getSortedSupportedOutputSizes(useCaseConfigMergeConfigs));
                if (useCase2.getCurrentConfig() instanceof PreviewConfig) {
                    z = ((PreviewConfig) useCase2.getCurrentConfig()).getPreviewStabilizationMode() == 2;
                }
            }
            Pair suggestedStreamSpecs = this.mCameraDeviceSurfaceManager.getSuggestedStreamSpecs(i, cameraId, arrayList, map5, z, hasVideoCapture(collection));
            for (Map.Entry entry : map4.entrySet()) {
                map2.put((UseCase) entry.getValue(), (StreamSpec) ((Map) suggestedStreamSpecs.first).get(entry.getKey()));
            }
            for (Map.Entry entry2 : ((Map) suggestedStreamSpecs.second).entrySet()) {
                if (map3.containsKey(entry2.getKey())) {
                    map2.put((UseCase) map3.get(entry2.getKey()), (StreamSpec) entry2.getValue());
                }
            }
        }
        return map2;
    }

    static void updateEffects(List list, Collection collection, Collection collection2) {
        List effectsOnUseCases = setEffectsOnUseCases(list, collection);
        ArrayList arrayList = new ArrayList(collection2);
        arrayList.removeAll(collection);
        List effectsOnUseCases2 = setEffectsOnUseCases(effectsOnUseCases, arrayList);
        if (effectsOnUseCases2.size() > 0) {
            Logger.w("CameraUseCaseAdapter", "Unused effects: " + effectsOnUseCases2);
        }
    }

    private static List setEffectsOnUseCases(List list, Collection collection) {
        ArrayList arrayList = new ArrayList(list);
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            UseCase useCase = (UseCase) it.next();
            useCase.setEffect(null);
            Iterator it2 = list.iterator();
            while (it2.hasNext()) {
                CameraEffect cameraEffect = (CameraEffect) it2.next();
                if (useCase.isEffectTargetsSupported(cameraEffect.getTargets())) {
                    Preconditions.checkState(useCase.getEffect() == null, useCase + " already has effect" + useCase.getEffect());
                    useCase.setEffect(cameraEffect);
                    arrayList.remove(cameraEffect);
                }
            }
        }
        return arrayList;
    }

    private void updateViewPortAndSensorToBufferMatrix(Map map, Collection collection) {
        Map map2;
        synchronized (this.mLock) {
            try {
                if (this.mViewPort == null || collection.isEmpty()) {
                    map2 = map;
                } else {
                    map2 = map;
                    Map mapCalculateViewPortRects = ViewPorts.calculateViewPortRects(this.mCameraInternal.getCameraControlInternal().getSensorRect(), this.mCameraInternal.getCameraInfoInternal().getLensFacing() == 0, this.mViewPort.getAspectRatio(), this.mCameraInternal.getCameraInfoInternal().getSensorRotationDegrees(this.mViewPort.getRotation()), this.mViewPort.getScaleType(), this.mViewPort.getLayoutDirection(), map2);
                    Iterator it = collection.iterator();
                    while (it.hasNext()) {
                        UseCase useCase = (UseCase) it.next();
                        useCase.setViewPortCropRect((Rect) Preconditions.checkNotNull((Rect) mapCalculateViewPortRects.get(useCase)));
                    }
                }
                Iterator it2 = collection.iterator();
                while (it2.hasNext()) {
                    UseCase useCase2 = (UseCase) it2.next();
                    useCase2.setSensorToBufferTransformMatrix(calculateSensorToBufferTransformMatrix(this.mCameraInternal.getCameraControlInternal().getSensorRect(), ((StreamSpec) Preconditions.checkNotNull((StreamSpec) map2.get(useCase2))).getResolution()));
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private static Matrix calculateSensorToBufferTransformMatrix(Rect rect, Size size) {
        Preconditions.checkArgument(rect.width() > 0 && rect.height() > 0, "Cannot compute viewport crop rects zero sized sensor rect.");
        RectF rectF = new RectF(rect);
        Matrix matrix = new Matrix();
        matrix.setRectToRect(new RectF(0.0f, 0.0f, size.getWidth(), size.getHeight()), rectF, Matrix.ScaleToFit.CENTER);
        matrix.invert(matrix);
        return matrix;
    }

    private static class ConfigPair {
        UseCaseConfig mCameraConfig;
        UseCaseConfig mExtendedConfig;

        ConfigPair(UseCaseConfig useCaseConfig, UseCaseConfig useCaseConfig2) {
            this.mExtendedConfig = useCaseConfig;
            this.mCameraConfig = useCaseConfig2;
        }
    }

    private static Map getConfigs(Collection collection, UseCaseConfigFactory useCaseConfigFactory, UseCaseConfigFactory useCaseConfigFactory2) {
        UseCaseConfig<?> defaultConfig;
        HashMap map = new HashMap();
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            UseCase useCase = (UseCase) it.next();
            if (StreamSharing.isStreamSharing(useCase)) {
                defaultConfig = generateExtendedStreamSharingConfigFromPreview(useCaseConfigFactory, (StreamSharing) useCase);
            } else {
                defaultConfig = useCase.getDefaultConfig(false, useCaseConfigFactory);
            }
            map.put(useCase, new ConfigPair(defaultConfig, useCase.getDefaultConfig(true, useCaseConfigFactory2)));
        }
        return map;
    }

    private static UseCaseConfig generateExtendedStreamSharingConfigFromPreview(UseCaseConfigFactory useCaseConfigFactory, StreamSharing streamSharing) {
        UseCaseConfig<?> defaultConfig = new Preview.Builder().build().getDefaultConfig(false, useCaseConfigFactory);
        if (defaultConfig == null) {
            return null;
        }
        MutableOptionsBundle mutableOptionsBundleFrom = MutableOptionsBundle.from((Config) defaultConfig);
        mutableOptionsBundleFrom.removeOption(TargetConfig.OPTION_TARGET_CLASS);
        return streamSharing.getUseCaseConfigBuilder(mutableOptionsBundleFrom).getUseCaseConfig();
    }

    private void checkUnsupportedFeatureCombinationAndThrow(Collection collection) {
        if (hasExtension()) {
            if (hasNonSdrConfig(collection)) {
                throw new IllegalArgumentException("Extensions are only supported for use with standard dynamic range.");
            }
            if (hasUltraHdrImageCapture(collection)) {
                throw new IllegalArgumentException("Extensions are not supported for use with Ultra HDR image capture.");
            }
        }
        synchronized (this.mLock) {
            try {
                if (!this.mEffects.isEmpty() && hasUltraHdrImageCapture(collection)) {
                    throw new IllegalArgumentException("Ultra HDR image capture does not support for use with CameraEffect.");
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private static boolean hasNonSdrConfig(Collection collection) {
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            if (isNotSdr(((UseCase) it.next()).getCurrentConfig().getDynamicRange())) {
                return true;
            }
        }
        return false;
    }

    private static boolean isNotSdr(DynamicRange dynamicRange) {
        return (dynamicRange.getBitDepth() == 10) || (dynamicRange.getEncoding() != 1 && dynamicRange.getEncoding() != 0);
    }

    private static boolean hasUltraHdrImageCapture(Collection collection) {
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            UseCase useCase = (UseCase) it.next();
            if (isImageCapture(useCase)) {
                UseCaseConfig<?> currentConfig = useCase.getCurrentConfig();
                Config.Option<?> option = ImageCaptureConfig.OPTION_OUTPUT_FORMAT;
                if (currentConfig.containsOption(option) && ((Integer) Preconditions.checkNotNull((Integer) currentConfig.retrieveOption(option))).intValue() == 1) {
                    return true;
                }
            }
        }
        return false;
    }

    public static abstract class CameraId {
        public abstract Identifier getCameraConfigId();

        public abstract String getCameraIdString();

        public static CameraId create(String str, Identifier identifier) {
            return new AutoValue_CameraUseCaseAdapter_CameraId(str, identifier);
        }
    }

    public static final class CameraException extends Exception {
        public CameraException(Throwable th) {
            super(th);
        }
    }

    @Override // androidx.camera.core.Camera
    public CameraControl getCameraControl() {
        return this.mAdapterCameraControl;
    }

    @Override // androidx.camera.core.Camera
    public CameraInfo getCameraInfo() {
        return this.mAdapterCameraInfo;
    }

    public CameraInfo getSecondaryCameraInfo() {
        return this.mAdapterSecondaryCameraInfo;
    }

    @Override // androidx.camera.core.Camera
    public CameraConfig getExtendedConfig() {
        CameraConfig cameraConfig;
        synchronized (this.mLock) {
            cameraConfig = this.mCameraConfig;
        }
        return cameraConfig;
    }

    @Override // androidx.camera.core.Camera
    public boolean isUseCasesCombinationSupported(boolean z, UseCase... useCaseArr) {
        Collection collectionAsList = Arrays.asList(useCaseArr);
        if (z) {
            collectionAsList = calculateCameraUseCases(collectionAsList, null, createOrReuseStreamSharing(collectionAsList, true));
        }
        Collection collection = collectionAsList;
        synchronized (this.mLock) {
            try {
                try {
                    calculateSuggestedStreamSpecs(getCameraMode(), this.mCameraInternal.getCameraInfoInternal(), collection, Collections.EMPTY_LIST, getConfigs(collection, this.mCameraConfig.getUseCaseConfigFactory(), this.mUseCaseConfigFactory));
                } catch (IllegalArgumentException unused) {
                    return false;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return true;
    }

    /* JADX WARN: Code duplicated, block: B:23:0x0049  */
    private UseCase calculatePlaceholderForExtensions(Collection collection, StreamSharing streamSharing) {
        UseCase useCaseCreateExtraImageCapture;
        synchronized (this.mLock) {
            try {
                ArrayList arrayList = new ArrayList(collection);
                if (streamSharing != null) {
                    arrayList.add(streamSharing);
                    arrayList.removeAll(streamSharing.getChildren());
                }
                if (!isCoexistingPreviewImageCaptureRequired()) {
                    useCaseCreateExtraImageCapture = null;
                } else if (isExtraPreviewRequired(arrayList)) {
                    if (isPreview(this.mPlaceholderForExtensions)) {
                        useCaseCreateExtraImageCapture = this.mPlaceholderForExtensions;
                    } else {
                        useCaseCreateExtraImageCapture = createExtraPreview();
                    }
                } else if (!isExtraImageCaptureRequired(arrayList)) {
                    useCaseCreateExtraImageCapture = null;
                } else if (isImageCapture(this.mPlaceholderForExtensions)) {
                    useCaseCreateExtraImageCapture = this.mPlaceholderForExtensions;
                } else {
                    useCaseCreateExtraImageCapture = createExtraImageCapture();
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return useCaseCreateExtraImageCapture;
    }

    private boolean isCoexistingPreviewImageCaptureRequired() {
        boolean z;
        synchronized (this.mLock) {
            z = true;
            if (this.mCameraConfig.getUseCaseCombinationRequiredRule() != 1) {
                z = false;
            }
        }
        return z;
    }

    private static boolean isExtraPreviewRequired(Collection collection) {
        Iterator it = collection.iterator();
        boolean z = false;
        boolean z2 = false;
        while (it.hasNext()) {
            UseCase useCase = (UseCase) it.next();
            if (isPreview(useCase) || StreamSharing.isStreamSharing(useCase)) {
                z2 = true;
            } else if (isImageCapture(useCase)) {
                z = true;
            }
        }
        return z && !z2;
    }

    private static boolean isExtraImageCaptureRequired(Collection collection) {
        Iterator it = collection.iterator();
        boolean z = false;
        boolean z2 = false;
        while (it.hasNext()) {
            UseCase useCase = (UseCase) it.next();
            if (isPreview(useCase) || StreamSharing.isStreamSharing(useCase)) {
                z = true;
            } else if (isImageCapture(useCase)) {
                z2 = true;
            }
        }
        return z && !z2;
    }

    private static boolean hasVideoCapture(Collection collection) {
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            if (isVideoCapture((UseCase) it.next())) {
                return true;
            }
        }
        return false;
    }

    private static boolean isVideoCapture(UseCase useCase) {
        if (useCase != null) {
            if (useCase.getCurrentConfig().containsOption(UseCaseConfig.OPTION_CAPTURE_TYPE)) {
                return useCase.getCurrentConfig().getCaptureType() == UseCaseConfigFactory.CaptureType.VIDEO_CAPTURE;
            }
            Log.e("CameraUseCaseAdapter", useCase + " UseCase does not have capture type.");
        }
        return false;
    }

    private static boolean isPreview(UseCase useCase) {
        return useCase instanceof Preview;
    }

    private static boolean isImageCapture(UseCase useCase) {
        return useCase instanceof ImageCapture;
    }

    private Preview createExtraPreview() {
        Preview previewBuild = new Preview.Builder().setTargetName("Preview-Extra").build();
        previewBuild.setSurfaceProvider(new Preview.SurfaceProvider() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.internal.CameraUseCaseAdapter$$ExternalSyntheticLambda0
            @Override // androidx.camera.core.Preview.SurfaceProvider
            public final void onSurfaceRequested(SurfaceRequest surfaceRequest) {
                CameraUseCaseAdapter.$r8$lambda$5hNd8fSJgscI21DT4954dmCDmuQ(surfaceRequest);
            }
        });
        return previewBuild;
    }

    public static /* synthetic */ void $r8$lambda$5hNd8fSJgscI21DT4954dmCDmuQ(SurfaceRequest surfaceRequest) {
        final SurfaceTexture surfaceTexture = new SurfaceTexture(0);
        surfaceTexture.setDefaultBufferSize(surfaceRequest.getResolution().getWidth(), surfaceRequest.getResolution().getHeight());
        surfaceTexture.detachFromGLContext();
        final Surface surface = new Surface(surfaceTexture);
        surfaceRequest.provideSurface(surface, CameraXExecutors.directExecutor(), new Consumer() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.internal.CameraUseCaseAdapter$$ExternalSyntheticLambda1
            @Override // androidx.core.util.Consumer
            public final void accept(Object obj) {
                CameraUseCaseAdapter.m505$r8$lambda$LnyTrDpxDU4Lj0jFr7wqOCUqwI(surface, surfaceTexture, (SurfaceRequest.Result) obj);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$LnyT-rDpxDU4Lj0jFr7wqOCUqwI, reason: not valid java name */
    public static /* synthetic */ void m505$r8$lambda$LnyTrDpxDU4Lj0jFr7wqOCUqwI(Surface surface, SurfaceTexture surfaceTexture, SurfaceRequest.Result result) {
        surface.release();
        surfaceTexture.release();
    }

    private ImageCapture createExtraImageCapture() {
        return new ImageCapture.Builder().setTargetName("ImageCapture-Extra").build();
    }
}
