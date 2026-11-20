package androidx.camera.core.impl;

import android.util.Range;
import android.util.Rational;
import androidx.camera.core.ExposureState;
import androidx.camera.core.FocusMeteringAction;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.SessionProcessorUtil;
import com.scanflow.datacapture.barinternal.androidx.camera.core.internal.ImmutableZoomState;

/* JADX INFO: loaded from: classes.dex */
public class RestrictedCameraInfo extends ForwardingCameraInfo {
    private final CameraConfig mCameraConfig;
    private final CameraInfoInternal mCameraInfo;
    private boolean mIsCaptureProcessProgressSupported;
    private boolean mIsPostviewSupported;
    private final SessionProcessor mSessionProcessor;

    public RestrictedCameraInfo(CameraInfoInternal cameraInfoInternal, CameraConfig cameraConfig) {
        super(cameraInfoInternal);
        this.mIsPostviewSupported = false;
        this.mIsCaptureProcessProgressSupported = false;
        this.mCameraInfo = cameraInfoInternal;
        this.mCameraConfig = cameraConfig;
        this.mSessionProcessor = cameraConfig.getSessionProcessor(null);
        setPostviewSupported(cameraConfig.isPostviewSupported());
        setCaptureProcessProgressSupported(cameraConfig.isCaptureProcessProgressSupported());
    }

    public CameraConfig getCameraConfig() {
        return this.mCameraConfig;
    }

    @Override // androidx.camera.core.impl.ForwardingCameraInfo, androidx.camera.core.impl.CameraInfoInternal
    public CameraInfoInternal getImplementation() {
        return this.mCameraInfo;
    }

    @Override // androidx.camera.core.impl.ForwardingCameraInfo, androidx.camera.core.CameraInfo
    public boolean hasFlashUnit() {
        if (SessionProcessorUtil.isOperationSupported(this.mSessionProcessor, 5)) {
            return this.mCameraInfo.hasFlashUnit();
        }
        return false;
    }

    @Override // androidx.camera.core.impl.ForwardingCameraInfo, androidx.camera.core.CameraInfo
    public LiveData getTorchState() {
        if (!SessionProcessorUtil.isOperationSupported(this.mSessionProcessor, 6)) {
            return new MutableLiveData(0);
        }
        return this.mCameraInfo.getTorchState();
    }

    @Override // androidx.camera.core.impl.ForwardingCameraInfo, androidx.camera.core.CameraInfo
    public LiveData getZoomState() {
        if (!SessionProcessorUtil.isOperationSupported(this.mSessionProcessor, 0)) {
            return new MutableLiveData(ImmutableZoomState.create(1.0f, 1.0f, 1.0f, 0.0f));
        }
        return this.mCameraInfo.getZoomState();
    }

    @Override // androidx.camera.core.impl.ForwardingCameraInfo, androidx.camera.core.CameraInfo
    public ExposureState getExposureState() {
        if (!SessionProcessorUtil.isOperationSupported(this.mSessionProcessor, 7)) {
            return new ExposureState() { // from class: androidx.camera.core.impl.RestrictedCameraInfo.1
                @Override // androidx.camera.core.ExposureState
                public int getExposureCompensationIndex() {
                    return 0;
                }

                @Override // androidx.camera.core.ExposureState
                public boolean isExposureCompensationSupported() {
                    return false;
                }

                @Override // androidx.camera.core.ExposureState
                public Range getExposureCompensationRange() {
                    return new Range(0, 0);
                }

                @Override // androidx.camera.core.ExposureState
                public Rational getExposureCompensationStep() {
                    return Rational.ZERO;
                }
            };
        }
        return this.mCameraInfo.getExposureState();
    }

    @Override // androidx.camera.core.impl.ForwardingCameraInfo, androidx.camera.core.CameraInfo
    public boolean isFocusMeteringSupported(FocusMeteringAction focusMeteringAction) {
        FocusMeteringAction modifiedFocusMeteringAction = SessionProcessorUtil.getModifiedFocusMeteringAction(this.mSessionProcessor, focusMeteringAction);
        if (modifiedFocusMeteringAction == null) {
            return false;
        }
        return this.mCameraInfo.isFocusMeteringSupported(modifiedFocusMeteringAction);
    }

    public void setPostviewSupported(boolean z) {
        this.mIsPostviewSupported = z;
    }

    public void setCaptureProcessProgressSupported(boolean z) {
        this.mIsCaptureProcessProgressSupported = z;
    }

    @Override // androidx.camera.core.impl.CameraInfoInternal
    public boolean isPostviewSupported() {
        return this.mIsPostviewSupported;
    }

    @Override // androidx.camera.core.impl.CameraInfoInternal
    public boolean isCaptureProcessProgressSupported() {
        return this.mIsCaptureProcessProgressSupported;
    }
}
