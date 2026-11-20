package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import android.graphics.Bitmap;
import androidx.camera.core.ImageCapture;
import androidx.camera.core.ImageCaptureException;
import androidx.camera.core.ImageProxy;
import androidx.concurrent.futures.CallbackToFutureAdapter;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.Threads;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class RequestWithCallback implements TakePictureCallback {
    private CallbackToFutureAdapter.Completer mCaptureCompleter;
    private ListenableFuture mCaptureRequestFuture;
    private CallbackToFutureAdapter.Completer mCompleteCompleter;
    private final TakePictureRequest.RetryControl mRetryControl;
    private final TakePictureRequest mTakePictureRequest;
    private boolean mIsAborted = false;
    private boolean mIsStarted = false;
    private final ListenableFuture mCaptureFuture = CallbackToFutureAdapter.getFuture(new CallbackToFutureAdapter.Resolver() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.RequestWithCallback$$ExternalSyntheticLambda0
        @Override // androidx.concurrent.futures.CallbackToFutureAdapter.Resolver
        public final Object attachCompleter(CallbackToFutureAdapter.Completer completer) {
            return RequestWithCallback.$r8$lambda$4DfLjuWIdGQWgwhesnaQmu5FNZg(this.f$0, completer);
        }
    });
    private final ListenableFuture mCompleteFuture = CallbackToFutureAdapter.getFuture(new CallbackToFutureAdapter.Resolver() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.RequestWithCallback$$ExternalSyntheticLambda1
        @Override // androidx.concurrent.futures.CallbackToFutureAdapter.Resolver
        public final Object attachCompleter(CallbackToFutureAdapter.Completer completer) {
            return RequestWithCallback.$r8$lambda$x6WJbb6dLrcDiRKy1pekTJsFKUo(this.f$0, completer);
        }
    });

    RequestWithCallback(TakePictureRequest takePictureRequest, TakePictureRequest.RetryControl retryControl) {
        this.mTakePictureRequest = takePictureRequest;
        this.mRetryControl = retryControl;
    }

    public static /* synthetic */ Object $r8$lambda$4DfLjuWIdGQWgwhesnaQmu5FNZg(RequestWithCallback requestWithCallback, CallbackToFutureAdapter.Completer completer) {
        requestWithCallback.mCaptureCompleter = completer;
        return "CaptureCompleteFuture";
    }

    public static /* synthetic */ Object $r8$lambda$x6WJbb6dLrcDiRKy1pekTJsFKUo(RequestWithCallback requestWithCallback, CallbackToFutureAdapter.Completer completer) {
        requestWithCallback.mCompleteCompleter = completer;
        return "RequestCompleteFuture";
    }

    public void setCaptureRequestFuture(ListenableFuture listenableFuture) {
        Threads.checkMainThread();
        Preconditions.checkState(this.mCaptureRequestFuture == null, "CaptureRequestFuture can only be set once.");
        this.mCaptureRequestFuture = listenableFuture;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public void onCaptureStarted() {
        Threads.checkMainThread();
        if (this.mIsAborted || this.mIsStarted) {
            return;
        }
        this.mIsStarted = true;
        ImageCapture.OnImageCapturedCallback inMemoryCallback = this.mTakePictureRequest.getInMemoryCallback();
        if (inMemoryCallback != null) {
            inMemoryCallback.onCaptureStarted();
        }
        ImageCapture.OnImageSavedCallback onDiskCallback = this.mTakePictureRequest.getOnDiskCallback();
        if (onDiskCallback != null) {
            onDiskCallback.onCaptureStarted();
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public void onImageCaptured() {
        Threads.checkMainThread();
        if (this.mIsAborted) {
            return;
        }
        if (!this.mIsStarted) {
            onCaptureStarted();
        }
        this.mCaptureCompleter.set(null);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public void onFinalResult(ImageCapture.OutputFileResults outputFileResults) {
        Threads.checkMainThread();
        if (this.mIsAborted) {
            return;
        }
        checkOnImageCaptured();
        markComplete();
        this.mTakePictureRequest.onResult(outputFileResults);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public void onFinalResult(ImageProxy imageProxy) {
        Threads.checkMainThread();
        if (this.mIsAborted) {
            imageProxy.close();
            return;
        }
        checkOnImageCaptured();
        markComplete();
        this.mTakePictureRequest.onResult(imageProxy);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public void onCaptureProcessProgressed(int i) {
        Threads.checkMainThread();
        if (this.mIsAborted) {
            return;
        }
        this.mTakePictureRequest.onCaptureProcessProgressed(i);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public void onPostviewBitmapAvailable(Bitmap bitmap) {
        Threads.checkMainThread();
        if (this.mIsAborted) {
            return;
        }
        this.mTakePictureRequest.onPostviewBitmapAvailable(bitmap);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public void onProcessFailure(ImageCaptureException imageCaptureException) {
        Threads.checkMainThread();
        if (this.mIsAborted) {
            return;
        }
        checkOnImageCaptured();
        markComplete();
        onFailure(imageCaptureException);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public boolean isAborted() {
        return this.mIsAborted;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureCallback
    public void onCaptureFailure(ImageCaptureException imageCaptureException) {
        Threads.checkMainThread();
        if (this.mIsAborted) {
            return;
        }
        boolean zDecrementRetryCounter = this.mTakePictureRequest.decrementRetryCounter();
        if (!zDecrementRetryCounter) {
            onFailure(imageCaptureException);
        }
        markComplete();
        this.mCaptureCompleter.setException(imageCaptureException);
        if (zDecrementRetryCounter) {
            this.mRetryControl.retryRequest(this.mTakePictureRequest);
        }
    }

    void abortAndSendErrorToApp(ImageCaptureException imageCaptureException) {
        Threads.checkMainThread();
        if (this.mCompleteFuture.isDone()) {
            return;
        }
        abort(imageCaptureException);
        onFailure(imageCaptureException);
    }

    void abortSilentlyAndRetry() {
        Threads.checkMainThread();
        if (this.mCompleteFuture.isDone()) {
            return;
        }
        abort(new ImageCaptureException(3, "The request is aborted silently and retried.", null));
        this.mRetryControl.retryRequest(this.mTakePictureRequest);
    }

    private void abort(ImageCaptureException imageCaptureException) {
        Threads.checkMainThread();
        this.mIsAborted = true;
        ListenableFuture listenableFuture = this.mCaptureRequestFuture;
        Objects.requireNonNull(listenableFuture);
        listenableFuture.cancel(true);
        this.mCaptureCompleter.setException(imageCaptureException);
        this.mCompleteCompleter.set(null);
    }

    ListenableFuture getCaptureFuture() {
        Threads.checkMainThread();
        return this.mCaptureFuture;
    }

    ListenableFuture getCompleteFuture() {
        Threads.checkMainThread();
        return this.mCompleteFuture;
    }

    private void checkOnImageCaptured() {
        Preconditions.checkState(this.mCaptureFuture.isDone(), "onImageCaptured() must be called before onFinalResult()");
    }

    private void markComplete() {
        Preconditions.checkState(!this.mCompleteFuture.isDone(), "The callback can only complete once.");
        this.mCompleteCompleter.set(null);
    }

    private void onFailure(ImageCaptureException imageCaptureException) {
        Threads.checkMainThread();
        this.mTakePictureRequest.onError(imageCaptureException);
    }
}
