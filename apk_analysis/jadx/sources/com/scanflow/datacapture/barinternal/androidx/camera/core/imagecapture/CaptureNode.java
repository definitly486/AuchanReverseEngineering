package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import android.util.Size;
import android.view.Surface;
import androidx.camera.core.ForwardingImageProxy;
import androidx.camera.core.ImageCaptureException;
import androidx.camera.core.ImageProxy;
import androidx.camera.core.ImageReaderProxyProvider;
import androidx.camera.core.ImageReaderProxys;
import androidx.camera.core.Logger;
import androidx.camera.core.MetadataImageReader;
import androidx.camera.core.SafeCloseImageReaderProxy;
import androidx.camera.core.impl.CameraCaptureCallback;
import androidx.camera.core.impl.CameraCaptureCallbacks;
import androidx.camera.core.impl.DeferrableSurface;
import androidx.camera.core.impl.ImageReaderProxy;
import androidx.camera.core.impl.ImmediateSurface;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import androidx.camera.core.impl.utils.futures.FutureCallback;
import androidx.camera.core.impl.utils.futures.Futures;
import androidx.core.util.Consumer;
import com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.Threads;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Edge;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
class CaptureNode {
    private In mInputEdge;
    private ProcessingNode.In mOutputEdge;
    SafeCloseImageReaderProxy mSafeCloseImageReaderForPostview;
    SafeCloseImageReaderProxy mSafeCloseImageReaderProxy;
    ProcessingRequest mCurrentRequest = null;
    private NoMetadataImageReader mNoMetadataImageReader = null;

    CaptureNode() {
    }

    public ProcessingNode.In transform(In in) {
        Consumer consumer;
        ImageReaderProxy imageReaderProxy;
        Preconditions.checkState(this.mInputEdge == null && this.mSafeCloseImageReaderProxy == null, "CaptureNode does not support recreation yet.");
        this.mInputEdge = in;
        Size size = in.getSize();
        int inputFormat = in.getInputFormat();
        boolean zIsVirtualCamera = in.isVirtualCamera();
        CameraCaptureCallback anonymousClass1 = new AnonymousClass1();
        if (!zIsVirtualCamera && in.getImageReaderProxyProvider() == null) {
            MetadataImageReader metadataImageReader = new MetadataImageReader(size.getWidth(), size.getHeight(), inputFormat, 4);
            anonymousClass1 = CameraCaptureCallbacks.createComboCallback(anonymousClass1, metadataImageReader.getCameraCaptureCallback());
            consumer = new Consumer() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$$ExternalSyntheticLambda0
                @Override // androidx.core.util.Consumer
                public final void accept(Object obj) {
                    this.f$0.onRequestAvailable((ProcessingRequest) obj);
                }
            };
            imageReaderProxy = metadataImageReader;
        } else {
            NoMetadataImageReader noMetadataImageReader = new NoMetadataImageReader(createImageReaderProxy(in.getImageReaderProxyProvider(), size.getWidth(), size.getHeight(), inputFormat));
            this.mNoMetadataImageReader = noMetadataImageReader;
            consumer = new Consumer() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$$ExternalSyntheticLambda1
                @Override // androidx.core.util.Consumer
                public final void accept(Object obj) {
                    CaptureNode.m499$r8$lambda$7aA5yFpboCKw0n21h0OvTjZyL0(this.f$0, (ProcessingRequest) obj);
                }
            };
            imageReaderProxy = noMetadataImageReader;
        }
        in.setCameraCaptureCallback(anonymousClass1);
        Surface surface = imageReaderProxy.getSurface();
        Objects.requireNonNull(surface);
        in.setSurface(surface);
        this.mSafeCloseImageReaderProxy = new SafeCloseImageReaderProxy(imageReaderProxy);
        imageReaderProxy.setOnImageAvailableListener(new ImageReaderProxy.OnImageAvailableListener() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$$ExternalSyntheticLambda2
            @Override // androidx.camera.core.impl.ImageReaderProxy.OnImageAvailableListener
            public final void onImageAvailable(ImageReaderProxy imageReaderProxy2) {
                CaptureNode.$r8$lambda$pMuiQYF7TOgEFV3jPwxF5CXMq8Y(this.f$0, imageReaderProxy2);
            }
        }, CameraXExecutors.mainThreadExecutor());
        if (in.getPostviewSize() != null) {
            ImageReaderProxy imageReaderProxyCreateImageReaderProxy = createImageReaderProxy(in.getImageReaderProxyProvider(), in.getPostviewSize().getWidth(), in.getPostviewSize().getHeight(), in.getPostviewImageFormat());
            imageReaderProxyCreateImageReaderProxy.setOnImageAvailableListener(new ImageReaderProxy.OnImageAvailableListener() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$$ExternalSyntheticLambda3
                @Override // androidx.camera.core.impl.ImageReaderProxy.OnImageAvailableListener
                public final void onImageAvailable(ImageReaderProxy imageReaderProxy2) {
                    CaptureNode.$r8$lambda$InHJHoGDpb5EjSde7GtdzDaIFdI(this.f$0, imageReaderProxy2);
                }
            }, CameraXExecutors.mainThreadExecutor());
            this.mSafeCloseImageReaderForPostview = new SafeCloseImageReaderProxy(imageReaderProxyCreateImageReaderProxy);
            in.setPostviewSurface(imageReaderProxyCreateImageReaderProxy.getSurface(), in.getPostviewSize(), in.getPostviewImageFormat());
        }
        in.getRequestEdge().setListener(consumer);
        in.getErrorEdge().setListener(new Consumer() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$$ExternalSyntheticLambda4
            @Override // androidx.core.util.Consumer
            public final void accept(Object obj) {
                this.f$0.sendCaptureError((TakePictureManager.CaptureError) obj);
            }
        });
        ProcessingNode.In inOf = ProcessingNode.In.of(in.getInputFormat(), in.getOutputFormat());
        this.mOutputEdge = inOf;
        return inOf;
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$1, reason: invalid class name */
    class AnonymousClass1 extends CameraCaptureCallback {
        AnonymousClass1() {
        }

        @Override // androidx.camera.core.impl.CameraCaptureCallback
        public void onCaptureStarted(int i) {
            CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$1$$ExternalSyntheticLambda1
                @Override // java.lang.Runnable
                public final void run() {
                    CaptureNode.AnonymousClass1.m500$r8$lambda$9Z85vUMCoUYHuaiE1yUNMe4EM(this.f$0);
                }
            });
        }

        /* JADX INFO: renamed from: $r8$lambda$9Z-85vUMCoUYHuaiE1yU-NMe4EM, reason: not valid java name */
        public static /* synthetic */ void m500$r8$lambda$9Z85vUMCoUYHuaiE1yUNMe4EM(AnonymousClass1 anonymousClass1) {
            ProcessingRequest processingRequest = CaptureNode.this.mCurrentRequest;
            if (processingRequest != null) {
                processingRequest.onCaptureStarted();
            }
        }

        @Override // androidx.camera.core.impl.CameraCaptureCallback
        public void onCaptureProcessProgressed(int i, final int i2) {
            CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$1$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    CaptureNode.AnonymousClass1.$r8$lambda$MGCZJvSMnFbJoxIZMXUjnrGd84Q(this.f$0, i2);
                }
            });
        }

        public static /* synthetic */ void $r8$lambda$MGCZJvSMnFbJoxIZMXUjnrGd84Q(AnonymousClass1 anonymousClass1, int i) {
            ProcessingRequest processingRequest = CaptureNode.this.mCurrentRequest;
            if (processingRequest != null) {
                processingRequest.onCaptureProcessProgressed(i);
            }
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$7aA-5yFpboCKw0n21h0OvTjZyL0, reason: not valid java name */
    public static /* synthetic */ void m499$r8$lambda$7aA5yFpboCKw0n21h0OvTjZyL0(CaptureNode captureNode, ProcessingRequest processingRequest) {
        captureNode.onRequestAvailable(processingRequest);
        captureNode.mNoMetadataImageReader.acceptProcessingRequest(processingRequest);
    }

    public static /* synthetic */ void $r8$lambda$pMuiQYF7TOgEFV3jPwxF5CXMq8Y(CaptureNode captureNode, ImageReaderProxy imageReaderProxy) {
        captureNode.getClass();
        try {
            ImageProxy imageProxyAcquireLatestImage = imageReaderProxy.acquireLatestImage();
            if (imageProxyAcquireLatestImage != null) {
                captureNode.onImageProxyAvailable(imageProxyAcquireLatestImage);
                return;
            }
            ProcessingRequest processingRequest = captureNode.mCurrentRequest;
            if (processingRequest != null) {
                captureNode.sendCaptureError(TakePictureManager.CaptureError.of(processingRequest.getRequestId(), new ImageCaptureException(2, "Failed to acquire latest image", null)));
            }
        } catch (IllegalStateException e) {
            ProcessingRequest processingRequest2 = captureNode.mCurrentRequest;
            if (processingRequest2 != null) {
                captureNode.sendCaptureError(TakePictureManager.CaptureError.of(processingRequest2.getRequestId(), new ImageCaptureException(2, "Failed to acquire latest image", e)));
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$InHJHoGDpb5EjSde7GtdzDaIFdI(CaptureNode captureNode, ImageReaderProxy imageReaderProxy) {
        captureNode.getClass();
        try {
            ImageProxy imageProxyAcquireLatestImage = imageReaderProxy.acquireLatestImage();
            if (imageProxyAcquireLatestImage != null) {
                captureNode.propagatePostviewImage(imageProxyAcquireLatestImage);
            }
        } catch (IllegalStateException e) {
            Logger.e("CaptureNode", "Failed to acquire latest image of postview", e);
        }
    }

    private static ImageReaderProxy createImageReaderProxy(ImageReaderProxyProvider imageReaderProxyProvider, int i, int i2, int i3) {
        if (imageReaderProxyProvider != null) {
            return imageReaderProxyProvider.newInstance(i, i2, i3, 4, 0L);
        }
        return ImageReaderProxys.createIsolatedReader(i, i2, i3, 4);
    }

    void onImageProxyAvailable(ImageProxy imageProxy) {
        Threads.checkMainThread();
        if (this.mCurrentRequest == null) {
            Logger.w("CaptureNode", "Discarding ImageProxy which was inadvertently acquired: " + imageProxy);
            imageProxy.close();
            return;
        }
        if (((Integer) imageProxy.getImageInfo().getTagBundle().getTag(this.mCurrentRequest.getTagBundleKey())) == null) {
            Logger.w("CaptureNode", "Discarding ImageProxy which was acquired for aborted request");
            imageProxy.close();
        } else {
            matchAndPropagateImage(imageProxy);
        }
    }

    private void matchAndPropagateImage(ImageProxy imageProxy) {
        Threads.checkMainThread();
        ProcessingNode.In in = this.mOutputEdge;
        Objects.requireNonNull(in);
        in.getEdge().accept(ProcessingNode.InputPacket.of(this.mCurrentRequest, imageProxy));
        ProcessingRequest processingRequest = this.mCurrentRequest;
        this.mCurrentRequest = null;
        processingRequest.onImageCaptured();
    }

    private void propagatePostviewImage(ImageProxy imageProxy) {
        if (this.mCurrentRequest == null) {
            Logger.w("CaptureNode", "Postview image is closed due to request completed or aborted");
            imageProxy.close();
        } else {
            ProcessingNode.In in = this.mOutputEdge;
            Objects.requireNonNull(in);
            in.getPostviewEdge().accept(ProcessingNode.InputPacket.of(this.mCurrentRequest, imageProxy));
        }
    }

    void onRequestAvailable(final ProcessingRequest processingRequest) {
        Threads.checkMainThread();
        Preconditions.checkState(processingRequest.getStageIds().size() == 1, "only one capture stage is supported.");
        Preconditions.checkState(getCapacity() > 0, "Too many acquire images. Close image to be able to process next.");
        this.mCurrentRequest = processingRequest;
        Futures.addCallback(processingRequest.getCaptureFuture(), new FutureCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode.2
            @Override // androidx.camera.core.impl.utils.futures.FutureCallback
            public void onSuccess(Void r1) {
            }

            @Override // androidx.camera.core.impl.utils.futures.FutureCallback
            public void onFailure(Throwable th) {
                Threads.checkMainThread();
                if (processingRequest == CaptureNode.this.mCurrentRequest) {
                    Logger.w("CaptureNode", "request aborted, id=" + CaptureNode.this.mCurrentRequest.getRequestId());
                    if (CaptureNode.this.mNoMetadataImageReader != null) {
                        CaptureNode.this.mNoMetadataImageReader.clearProcessingRequest();
                    }
                    CaptureNode.this.mCurrentRequest = null;
                }
            }
        }, CameraXExecutors.directExecutor());
    }

    void sendCaptureError(TakePictureManager.CaptureError captureError) {
        Threads.checkMainThread();
        ProcessingRequest processingRequest = this.mCurrentRequest;
        if (processingRequest == null || processingRequest.getRequestId() != captureError.getRequestId()) {
            return;
        }
        this.mCurrentRequest.onCaptureFailure(captureError.getImageCaptureException());
    }

    public void release() {
        Threads.checkMainThread();
        In in = this.mInputEdge;
        Objects.requireNonNull(in);
        SafeCloseImageReaderProxy safeCloseImageReaderProxy = this.mSafeCloseImageReaderProxy;
        Objects.requireNonNull(safeCloseImageReaderProxy);
        releaseInputResources(in, safeCloseImageReaderProxy, this.mSafeCloseImageReaderForPostview);
    }

    private void releaseInputResources(In in, final SafeCloseImageReaderProxy safeCloseImageReaderProxy, final SafeCloseImageReaderProxy safeCloseImageReaderProxy2) {
        in.getSurface().close();
        in.getSurface().getTerminationFuture().addListener(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$$ExternalSyntheticLambda5
            @Override // java.lang.Runnable
            public final void run() {
                safeCloseImageReaderProxy.safeClose();
            }
        }, CameraXExecutors.mainThreadExecutor());
        if (in.getPostviewSurface() != null) {
            in.getPostviewSurface().close();
            in.getPostviewSurface().getTerminationFuture().addListener(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode$$ExternalSyntheticLambda6
                @Override // java.lang.Runnable
                public final void run() {
                    CaptureNode.$r8$lambda$rWWtbZD2YG5XEuVxruKY108_pIc(safeCloseImageReaderProxy2);
                }
            }, CameraXExecutors.mainThreadExecutor());
        }
    }

    public static /* synthetic */ void $r8$lambda$rWWtbZD2YG5XEuVxruKY108_pIc(SafeCloseImageReaderProxy safeCloseImageReaderProxy) {
        if (safeCloseImageReaderProxy != null) {
            safeCloseImageReaderProxy.safeClose();
        }
    }

    public int getCapacity() {
        Threads.checkMainThread();
        Preconditions.checkState(this.mSafeCloseImageReaderProxy != null, "The ImageReader is not initialized.");
        return this.mSafeCloseImageReaderProxy.getCapacity();
    }

    public void setOnImageCloseListener(ForwardingImageProxy.OnImageCloseListener onImageCloseListener) {
        Threads.checkMainThread();
        Preconditions.checkState(this.mSafeCloseImageReaderProxy != null, "The ImageReader is not initialized.");
        this.mSafeCloseImageReaderProxy.setOnImageCloseListener(onImageCloseListener);
    }

    static abstract class In {
        private CameraCaptureCallback mCameraCaptureCallback = new CameraCaptureCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.CaptureNode.In.1
        };
        private DeferrableSurface mPostviewSurface = null;
        private DeferrableSurface mSurface;

        abstract Edge getErrorEdge();

        abstract ImageReaderProxyProvider getImageReaderProxyProvider();

        abstract int getInputFormat();

        abstract int getOutputFormat();

        abstract int getPostviewImageFormat();

        abstract Size getPostviewSize();

        abstract Edge getRequestEdge();

        abstract Size getSize();

        abstract boolean isVirtualCamera();

        In() {
        }

        DeferrableSurface getSurface() {
            DeferrableSurface deferrableSurface = this.mSurface;
            Objects.requireNonNull(deferrableSurface);
            return deferrableSurface;
        }

        DeferrableSurface getPostviewSurface() {
            return this.mPostviewSurface;
        }

        void setSurface(Surface surface) {
            Preconditions.checkState(this.mSurface == null, "The surface is already set.");
            this.mSurface = new ImmediateSurface(surface, getSize(), getInputFormat());
        }

        void setPostviewSurface(Surface surface, Size size, int i) {
            this.mPostviewSurface = new ImmediateSurface(surface, size, i);
        }

        CameraCaptureCallback getCameraCaptureCallback() {
            return this.mCameraCaptureCallback;
        }

        void setCameraCaptureCallback(CameraCaptureCallback cameraCaptureCallback) {
            this.mCameraCaptureCallback = cameraCaptureCallback;
        }

        static In of(Size size, int i, int i2, boolean z, ImageReaderProxyProvider imageReaderProxyProvider, Size size2, int i3) {
            return new AutoValue_CaptureNode_In(size, i, i2, z, imageReaderProxyProvider, size2, i3, new Edge(), new Edge());
        }
    }
}
