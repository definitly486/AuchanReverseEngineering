package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import android.util.Log;
import androidx.camera.core.ForwardingImageProxy;
import androidx.camera.core.ImageCaptureException;
import androidx.camera.core.ImageProxy;
import androidx.camera.core.Logger;
import androidx.camera.core.impl.CaptureConfig;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import androidx.camera.core.impl.utils.futures.FutureCallback;
import androidx.camera.core.impl.utils.futures.Futures;
import androidx.core.util.Pair;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.Threads;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Deque;
import java.util.Iterator;
import java.util.List;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class TakePictureManager implements ForwardingImageProxy.OnImageCloseListener, TakePictureRequest.RetryControl {
    private RequestWithCallback mCapturingRequest;
    final ImageCaptureControl mImageCaptureControl;
    ImagePipeline mImagePipeline;
    private final List mIncompleteRequests;
    final Deque mNewRequests = new ArrayDeque();
    boolean mPaused = false;

    public TakePictureManager(ImageCaptureControl imageCaptureControl) {
        Threads.checkMainThread();
        this.mImageCaptureControl = imageCaptureControl;
        this.mIncompleteRequests = new ArrayList();
    }

    public void setImagePipeline(ImagePipeline imagePipeline) {
        Threads.checkMainThread();
        this.mImagePipeline = imagePipeline;
        imagePipeline.setOnImageCloseListener(this);
    }

    public void offerRequest(TakePictureRequest takePictureRequest) {
        Threads.checkMainThread();
        this.mNewRequests.offer(takePictureRequest);
        issueNextRequest();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureRequest.RetryControl
    public void retryRequest(TakePictureRequest takePictureRequest) {
        Threads.checkMainThread();
        Logger.d("TakePictureManager", "Add a new request for retrying.");
        this.mNewRequests.addFirst(takePictureRequest);
        issueNextRequest();
    }

    public void pause() {
        Threads.checkMainThread();
        this.mPaused = true;
        RequestWithCallback requestWithCallback = this.mCapturingRequest;
        if (requestWithCallback != null) {
            requestWithCallback.abortSilentlyAndRetry();
        }
    }

    public void resume() {
        Threads.checkMainThread();
        this.mPaused = false;
        issueNextRequest();
    }

    public void abortRequests() {
        Threads.checkMainThread();
        ImageCaptureException imageCaptureException = new ImageCaptureException(3, "Camera is closed.", null);
        Iterator it = this.mNewRequests.iterator();
        while (it.hasNext()) {
            ((TakePictureRequest) it.next()).onError(imageCaptureException);
        }
        this.mNewRequests.clear();
        ArrayList arrayList = new ArrayList(this.mIncompleteRequests);
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((RequestWithCallback) obj).abortAndSendErrorToApp(imageCaptureException);
        }
    }

    void issueNextRequest() {
        Threads.checkMainThread();
        Log.d("TakePictureManager", "Issue the next TakePictureRequest.");
        if (hasCapturingRequest()) {
            Log.d("TakePictureManager", "There is already a request in-flight.");
            return;
        }
        if (this.mPaused) {
            Log.d("TakePictureManager", "The class is paused.");
            return;
        }
        if (this.mImagePipeline.getCapacity() == 0) {
            Log.d("TakePictureManager", "Too many acquire images. Close image to be able to process next.");
            return;
        }
        TakePictureRequest takePictureRequest = (TakePictureRequest) this.mNewRequests.poll();
        if (takePictureRequest == null) {
            Log.d("TakePictureManager", "No new request.");
            return;
        }
        RequestWithCallback requestWithCallback = new RequestWithCallback(takePictureRequest, this);
        trackCurrentRequests(requestWithCallback);
        Pair pairCreateRequests = this.mImagePipeline.createRequests(takePictureRequest, requestWithCallback, requestWithCallback.getCaptureFuture());
        CameraRequest cameraRequest = (CameraRequest) pairCreateRequests.first;
        Objects.requireNonNull(cameraRequest);
        ProcessingRequest processingRequest = (ProcessingRequest) pairCreateRequests.second;
        Objects.requireNonNull(processingRequest);
        this.mImagePipeline.submitProcessingRequest(processingRequest);
        requestWithCallback.setCaptureRequestFuture(submitCameraRequest(cameraRequest));
    }

    private void trackCurrentRequests(final RequestWithCallback requestWithCallback) {
        Preconditions.checkState(!hasCapturingRequest());
        this.mCapturingRequest = requestWithCallback;
        requestWithCallback.getCaptureFuture().addListener(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureManager$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                TakePictureManager.$r8$lambda$1GT3iDYVPugzAPM6XXqbkkGM1bA(this.f$0);
            }
        }, CameraXExecutors.directExecutor());
        this.mIncompleteRequests.add(requestWithCallback);
        requestWithCallback.getCompleteFuture().addListener(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureManager$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                this.f$0.mIncompleteRequests.remove(requestWithCallback);
            }
        }, CameraXExecutors.directExecutor());
    }

    public static /* synthetic */ void $r8$lambda$1GT3iDYVPugzAPM6XXqbkkGM1bA(TakePictureManager takePictureManager) {
        takePictureManager.mCapturingRequest = null;
        takePictureManager.issueNextRequest();
    }

    private ListenableFuture submitCameraRequest(final CameraRequest cameraRequest) {
        Threads.checkMainThread();
        this.mImageCaptureControl.lockFlashMode();
        ListenableFuture listenableFutureSubmitStillCaptureRequests = this.mImageCaptureControl.submitStillCaptureRequests(cameraRequest.getCaptureConfigs());
        Futures.addCallback(listenableFutureSubmitStillCaptureRequests, new FutureCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureManager.1
            @Override // androidx.camera.core.impl.utils.futures.FutureCallback
            public void onSuccess(Void r1) {
                TakePictureManager.this.mImageCaptureControl.unlockFlashMode();
            }

            @Override // androidx.camera.core.impl.utils.futures.FutureCallback
            public void onFailure(Throwable th) {
                if (cameraRequest.isAborted()) {
                    return;
                }
                int id = ((CaptureConfig) cameraRequest.getCaptureConfigs().get(0)).getId();
                if (th instanceof ImageCaptureException) {
                    TakePictureManager.this.mImagePipeline.notifyCaptureError(CaptureError.of(id, (ImageCaptureException) th));
                } else {
                    TakePictureManager.this.mImagePipeline.notifyCaptureError(CaptureError.of(id, new ImageCaptureException(2, "Failed to submit capture request", th)));
                }
                TakePictureManager.this.mImageCaptureControl.unlockFlashMode();
            }
        }, CameraXExecutors.mainThreadExecutor());
        return listenableFutureSubmitStillCaptureRequests;
    }

    boolean hasCapturingRequest() {
        return this.mCapturingRequest != null;
    }

    @Override // androidx.camera.core.ForwardingImageProxy.OnImageCloseListener
    public void onImageClose(ImageProxy imageProxy) {
        CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.TakePictureManager$$ExternalSyntheticLambda2
            @Override // java.lang.Runnable
            public final void run() {
                this.f$0.issueNextRequest();
            }
        });
    }

    static abstract class CaptureError {
        abstract ImageCaptureException getImageCaptureException();

        abstract int getRequestId();

        CaptureError() {
        }

        static CaptureError of(int i, ImageCaptureException imageCaptureException) {
            return new AutoValue_TakePictureManager_CaptureError(i, imageCaptureException);
        }
    }
}
