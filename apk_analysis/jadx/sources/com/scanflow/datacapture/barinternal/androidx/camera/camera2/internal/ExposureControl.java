package com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal;

import android.hardware.camera2.CaptureRequest;
import android.hardware.camera2.CaptureResult;
import android.hardware.camera2.TotalCaptureResult;
import android.util.Range;
import androidx.camera.core.CameraControl;
import androidx.camera.core.ExposureState;
import androidx.camera.core.impl.Config;
import androidx.camera.core.impl.utils.futures.Futures;
import androidx.concurrent.futures.CallbackToFutureAdapter;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.impl.Camera2ImplConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.compat.CameraCharacteristicsCompat;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.concurrent.Executor;

/* JADX INFO: loaded from: classes.dex */
public class ExposureControl {
    private final Camera2CameraControlImpl mCameraControl;
    private final Executor mExecutor;
    private final ExposureStateImpl mExposureStateImpl;
    private boolean mIsActive = false;
    private Camera2CameraControlImpl.CaptureResultListener mRunningCaptureResultListener;
    private CallbackToFutureAdapter.Completer mRunningCompleter;

    ExposureControl(Camera2CameraControlImpl camera2CameraControlImpl, CameraCharacteristicsCompat cameraCharacteristicsCompat, Executor executor) {
        this.mCameraControl = camera2CameraControlImpl;
        this.mExposureStateImpl = new ExposureStateImpl(cameraCharacteristicsCompat, 0);
        this.mExecutor = executor;
    }

    static ExposureState getDefaultExposureState(CameraCharacteristicsCompat cameraCharacteristicsCompat) {
        return new ExposureStateImpl(cameraCharacteristicsCompat, 0);
    }

    void setActive(boolean z) {
        if (z == this.mIsActive) {
            return;
        }
        this.mIsActive = z;
        if (z) {
            return;
        }
        this.mExposureStateImpl.setExposureCompensationIndex(0);
        clearRunningTask();
    }

    void setCaptureRequestOption(Camera2ImplConfig.Builder builder) {
        builder.setCaptureRequestOptionWithPriority(CaptureRequest.CONTROL_AE_EXPOSURE_COMPENSATION, Integer.valueOf(this.mExposureStateImpl.getExposureCompensationIndex()), Config.OptionPriority.REQUIRED);
    }

    ExposureState getExposureState() {
        return this.mExposureStateImpl;
    }

    ListenableFuture setExposureCompensationIndex(final int i) {
        if (!this.mExposureStateImpl.isExposureCompensationSupported()) {
            return Futures.immediateFailedFuture(new IllegalArgumentException("ExposureCompensation is not supported"));
        }
        Range exposureCompensationRange = this.mExposureStateImpl.getExposureCompensationRange();
        if (!exposureCompensationRange.contains(Integer.valueOf(i))) {
            return Futures.immediateFailedFuture(new IllegalArgumentException("Requested ExposureCompensation " + i + " is not within valid range [" + exposureCompensationRange.getUpper() + ".." + exposureCompensationRange.getLower() + "]"));
        }
        this.mExposureStateImpl.setExposureCompensationIndex(i);
        return Futures.nonCancellationPropagating(CallbackToFutureAdapter.getFuture(new CallbackToFutureAdapter.Resolver() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ExposureControl$$ExternalSyntheticLambda0
            @Override // androidx.concurrent.futures.CallbackToFutureAdapter.Resolver
            public final Object attachCompleter(CallbackToFutureAdapter.Completer completer) {
                return ExposureControl.$r8$lambda$AYv29E4dTcRbv5mxB7EUx_BaCbg(this.f$0, i, completer);
            }
        }));
    }

    public static /* synthetic */ Object $r8$lambda$AYv29E4dTcRbv5mxB7EUx_BaCbg(final ExposureControl exposureControl, final int i, final CallbackToFutureAdapter.Completer completer) {
        exposureControl.mExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ExposureControl$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                ExposureControl.$r8$lambda$1kxhfZr7gubJH_H2icbROHCkSvs(this.f$0, completer, i);
            }
        });
        return "setExposureCompensationIndex[" + i + "]";
    }

    public static /* synthetic */ void $r8$lambda$1kxhfZr7gubJH_H2icbROHCkSvs(ExposureControl exposureControl, final CallbackToFutureAdapter.Completer completer, final int i) {
        if (!exposureControl.mIsActive) {
            exposureControl.mExposureStateImpl.setExposureCompensationIndex(0);
            completer.setException(new CameraControl.OperationCanceledException("Camera is not active."));
            return;
        }
        exposureControl.clearRunningTask();
        Preconditions.checkState(exposureControl.mRunningCompleter == null, "mRunningCompleter should be null when starting set a new exposure compensation value");
        Preconditions.checkState(exposureControl.mRunningCaptureResultListener == null, "mRunningCaptureResultListener should be null when starting set a new exposure compensation value");
        Camera2CameraControlImpl.CaptureResultListener captureResultListener = new Camera2CameraControlImpl.CaptureResultListener() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.ExposureControl$$ExternalSyntheticLambda2
            @Override // com.scanflow.datacapture.barinternal.androidx.camera.camera2.internal.Camera2CameraControlImpl.CaptureResultListener
            public final boolean onCaptureResult(TotalCaptureResult totalCaptureResult) {
                return ExposureControl.$r8$lambda$JGxfKthZBxLwi7upNDYUb6mPzBE(i, completer, totalCaptureResult);
            }
        };
        exposureControl.mRunningCaptureResultListener = captureResultListener;
        exposureControl.mRunningCompleter = completer;
        exposureControl.mCameraControl.addCaptureResultListener(captureResultListener);
        exposureControl.mCameraControl.updateSessionConfigSynchronous();
    }

    public static /* synthetic */ boolean $r8$lambda$JGxfKthZBxLwi7upNDYUb6mPzBE(int i, CallbackToFutureAdapter.Completer completer, TotalCaptureResult totalCaptureResult) {
        Integer num = (Integer) totalCaptureResult.get(CaptureResult.CONTROL_AE_STATE);
        Integer num2 = (Integer) totalCaptureResult.get(CaptureResult.CONTROL_AE_EXPOSURE_COMPENSATION);
        if (num != null && num2 != null) {
            int iIntValue = num.intValue();
            if ((iIntValue != 2 && iIntValue != 3 && iIntValue != 4) || num2.intValue() != i) {
                return false;
            }
            completer.set(Integer.valueOf(i));
            return true;
        }
        if (num2 == null || num2.intValue() != i) {
            return false;
        }
        completer.set(Integer.valueOf(i));
        return true;
    }

    private void clearRunningTask() {
        CallbackToFutureAdapter.Completer completer = this.mRunningCompleter;
        if (completer != null) {
            completer.setException(new CameraControl.OperationCanceledException("Cancelled by another setExposureCompensationIndex()"));
            this.mRunningCompleter = null;
        }
        Camera2CameraControlImpl.CaptureResultListener captureResultListener = this.mRunningCaptureResultListener;
        if (captureResultListener != null) {
            this.mCameraControl.removeCaptureResultListener(captureResultListener);
            this.mRunningCaptureResultListener = null;
        }
    }
}
