package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import android.graphics.Bitmap;
import androidx.camera.core.ImageCapture;
import androidx.camera.core.ImageCaptureException;
import androidx.camera.core.ImageProxy;
import androidx.camera.core.Logger;
import androidx.camera.core.impl.Quirks;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import androidx.camera.core.internal.compat.quirk.DeviceQuirks;
import androidx.camera.core.internal.compat.quirk.IncorrectJpegMetadataQuirk;
import androidx.camera.core.internal.compat.quirk.LowMemoryQuirk;
import androidx.core.util.Consumer;
import com.scanflow.datacapture.barinternal.androidx.camera.core.internal.utils.ImageUtil;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Edge;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.InternalImageProcessor;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Operation;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Packet;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.Objects;
import java.util.concurrent.Executor;

/* JADX INFO: loaded from: classes.dex */
public class ProcessingNode {
    private Operation mBitmap2JpegBytes;
    private Operation mBitmapEffect;
    final Executor mBlockingExecutor;
    private final boolean mHasIncorrectJpegMetadataQuirk;
    private Operation mImage2Bitmap;
    private Operation mImage2JpegBytes;
    final InternalImageProcessor mImageProcessor;
    private Operation mInput2Packet;
    private In mInputEdge;
    private Operation mJpegBytes2CroppedBitmap;
    private Operation mJpegBytes2Disk;
    private Operation mJpegBytes2Image;
    private Operation mJpegImage2Result;
    private final Quirks mQuirks;

    ProcessingNode(Executor executor, InternalImageProcessor internalImageProcessor) {
        this(executor, internalImageProcessor, DeviceQuirks.getAll());
    }

    ProcessingNode(Executor executor, InternalImageProcessor internalImageProcessor, Quirks quirks) {
        if (DeviceQuirks.get(LowMemoryQuirk.class) != null) {
            this.mBlockingExecutor = CameraXExecutors.newSequentialExecutor(executor);
        } else {
            this.mBlockingExecutor = executor;
        }
        this.mImageProcessor = internalImageProcessor;
        this.mQuirks = quirks;
        this.mHasIncorrectJpegMetadataQuirk = quirks.contains(IncorrectJpegMetadataQuirk.class);
    }

    public Void transform(In in) {
        this.mInputEdge = in;
        in.getEdge().setListener(new Consumer() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode$$ExternalSyntheticLambda0
            @Override // androidx.core.util.Consumer
            public final void accept(Object obj) {
                ProcessingNode.m501$r8$lambda$6U13Zlx7P74SDaHwciYmFh6g8(this.f$0, (ProcessingNode.InputPacket) obj);
            }
        });
        in.getPostviewEdge().setListener(new Consumer() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode$$ExternalSyntheticLambda1
            @Override // androidx.core.util.Consumer
            public final void accept(Object obj) {
                ProcessingNode.m503$r8$lambda$EI5MKd_NwbtkM8O4wtsjxa9o4(this.f$0, (ProcessingNode.InputPacket) obj);
            }
        });
        this.mInput2Packet = new ProcessingInput2Packet();
        this.mImage2JpegBytes = new Image2JpegBytes(this.mQuirks);
        this.mJpegBytes2CroppedBitmap = new JpegBytes2CroppedBitmap();
        this.mBitmap2JpegBytes = new Bitmap2JpegBytes();
        this.mJpegBytes2Disk = new JpegBytes2Disk();
        this.mJpegImage2Result = new JpegImage2Result();
        this.mImage2Bitmap = new Image2Bitmap();
        if (in.getInputFormat() == 35 || this.mImageProcessor != null || this.mHasIncorrectJpegMetadataQuirk) {
            this.mJpegBytes2Image = new JpegBytes2Image();
        }
        InternalImageProcessor internalImageProcessor = this.mImageProcessor;
        if (internalImageProcessor == null) {
            return null;
        }
        this.mBitmapEffect = new BitmapEffect(internalImageProcessor);
        return null;
    }

    /* JADX INFO: renamed from: $r8$lambda$6U13Zlx7P74SDa-Hwc-iYmFh6g8, reason: not valid java name */
    public static /* synthetic */ void m501$r8$lambda$6U13Zlx7P74SDaHwciYmFh6g8(final ProcessingNode processingNode, final InputPacket inputPacket) {
        processingNode.getClass();
        if (inputPacket.getProcessingRequest().isAborted()) {
            inputPacket.getImageProxy().close();
        } else {
            processingNode.mBlockingExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode$$ExternalSyntheticLambda3
                @Override // java.lang.Runnable
                public final void run() {
                    this.f$0.processInputPacket(inputPacket);
                }
            });
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$EI5MKd_Nwbt-kM8O4-wtsjxa9o4, reason: not valid java name */
    public static /* synthetic */ void m503$r8$lambda$EI5MKd_NwbtkM8O4wtsjxa9o4(final ProcessingNode processingNode, final InputPacket inputPacket) {
        processingNode.getClass();
        if (inputPacket.getProcessingRequest().isAborted()) {
            Logger.w("ProcessingNode", "The postview image is closed due to request aborted");
            inputPacket.getImageProxy().close();
        } else {
            processingNode.mBlockingExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode$$ExternalSyntheticLambda2
                @Override // java.lang.Runnable
                public final void run() {
                    this.f$0.processPostviewInputPacket(inputPacket);
                }
            });
        }
    }

    public void release() {
    }

    /* JADX INFO: Access modifiers changed from: package-private */
    public void processInputPacket(InputPacket inputPacket) {
        final ProcessingRequest processingRequest = inputPacket.getProcessingRequest();
        try {
            if (inputPacket.getProcessingRequest().isInMemoryCapture()) {
                final ImageProxy imageProxyProcessInMemoryCapture = processInMemoryCapture(inputPacket);
                CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode$$ExternalSyntheticLambda4
                    @Override // java.lang.Runnable
                    public final void run() {
                        processingRequest.onFinalResult(imageProxyProcessInMemoryCapture);
                    }
                });
            } else {
                final ImageCapture.OutputFileResults outputFileResultsProcessOnDiskCapture = processOnDiskCapture(inputPacket);
                CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode$$ExternalSyntheticLambda5
                    @Override // java.lang.Runnable
                    public final void run() {
                        processingRequest.onFinalResult(outputFileResultsProcessOnDiskCapture);
                    }
                });
            }
        } catch (ImageCaptureException e) {
            sendError(processingRequest, e);
        } catch (OutOfMemoryError e2) {
            sendError(processingRequest, new ImageCaptureException(0, "Processing failed due to low memory.", e2));
        } catch (RuntimeException e3) {
            sendError(processingRequest, new ImageCaptureException(0, "Processing failed.", e3));
        }
    }

    /* JADX INFO: Access modifiers changed from: package-private */
    public void processPostviewInputPacket(InputPacket inputPacket) {
        int outputFormat = this.mInputEdge.getOutputFormat();
        Preconditions.checkArgument(outputFormat == 35 || outputFormat == 256, String.format("Postview only support YUV and JPEG output formats. Output format: %s", Integer.valueOf(outputFormat)));
        final ProcessingRequest processingRequest = inputPacket.getProcessingRequest();
        try {
            final Bitmap bitmap = (Bitmap) this.mImage2Bitmap.apply((Packet) this.mInput2Packet.apply(inputPacket));
            CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode$$ExternalSyntheticLambda6
                @Override // java.lang.Runnable
                public final void run() {
                    processingRequest.onPostviewBitmapAvailable(bitmap);
                }
            });
        } catch (Exception e) {
            inputPacket.getImageProxy().close();
            Logger.e("ProcessingNode", "process postview input packet failed.", e);
        }
    }

    ImageCapture.OutputFileResults processOnDiskCapture(InputPacket inputPacket) {
        int outputFormat = this.mInputEdge.getOutputFormat();
        Preconditions.checkArgument(ImageUtil.isJpegFormats(outputFormat), String.format("On-disk capture only support JPEG and JPEG/R output formats. Output format: %s", Integer.valueOf(outputFormat)));
        ProcessingRequest processingRequest = inputPacket.getProcessingRequest();
        Packet packetCropAndMaybeApplyEffect = (Packet) this.mImage2JpegBytes.apply(Image2JpegBytes.In.of((Packet) this.mInput2Packet.apply(inputPacket), processingRequest.getJpegQuality()));
        if (packetCropAndMaybeApplyEffect.hasCropping() || this.mBitmapEffect != null) {
            packetCropAndMaybeApplyEffect = cropAndMaybeApplyEffect(packetCropAndMaybeApplyEffect, processingRequest.getJpegQuality());
        }
        Operation operation = this.mJpegBytes2Disk;
        ImageCapture.OutputFileOptions outputFileOptions = processingRequest.getOutputFileOptions();
        Objects.requireNonNull(outputFileOptions);
        return (ImageCapture.OutputFileResults) operation.apply(JpegBytes2Disk.In.of(packetCropAndMaybeApplyEffect, outputFileOptions));
    }

    ImageProxy processInMemoryCapture(InputPacket inputPacket) {
        ProcessingRequest processingRequest = inputPacket.getProcessingRequest();
        Packet packet = (Packet) this.mInput2Packet.apply(inputPacket);
        if ((packet.getFormat() == 35 || this.mBitmapEffect != null || this.mHasIncorrectJpegMetadataQuirk) && this.mInputEdge.getOutputFormat() == 256) {
            Packet packetCropAndMaybeApplyEffect = (Packet) this.mImage2JpegBytes.apply(Image2JpegBytes.In.of(packet, processingRequest.getJpegQuality()));
            if (this.mBitmapEffect != null) {
                packetCropAndMaybeApplyEffect = cropAndMaybeApplyEffect(packetCropAndMaybeApplyEffect, processingRequest.getJpegQuality());
            }
            packet = (Packet) this.mJpegBytes2Image.apply(packetCropAndMaybeApplyEffect);
        }
        return (ImageProxy) this.mJpegImage2Result.apply(packet);
    }

    private Packet cropAndMaybeApplyEffect(Packet packet, int i) {
        Preconditions.checkState(ImageUtil.isJpegFormats(packet.getFormat()));
        Packet packet2 = (Packet) this.mJpegBytes2CroppedBitmap.apply(packet);
        Operation operation = this.mBitmapEffect;
        if (operation != null) {
            packet2 = (Packet) operation.apply(packet2);
        }
        return (Packet) this.mBitmap2JpegBytes.apply(Bitmap2JpegBytes.In.of(packet2, i));
    }

    private static void sendError(final ProcessingRequest processingRequest, final ImageCaptureException imageCaptureException) {
        CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode$$ExternalSyntheticLambda7
            @Override // java.lang.Runnable
            public final void run() {
                processingRequest.onProcessFailure(imageCaptureException);
            }
        });
    }

    static abstract class InputPacket {
        abstract ImageProxy getImageProxy();

        abstract ProcessingRequest getProcessingRequest();

        InputPacket() {
        }

        static InputPacket of(ProcessingRequest processingRequest, ImageProxy imageProxy) {
            return new AutoValue_ProcessingNode_InputPacket(processingRequest, imageProxy);
        }
    }

    static abstract class In {
        abstract Edge getEdge();

        abstract int getInputFormat();

        abstract int getOutputFormat();

        abstract Edge getPostviewEdge();

        In() {
        }

        static In of(int i, int i2) {
            return new AutoValue_ProcessingNode_In(new Edge(), new Edge(), i, i2);
        }
    }
}
