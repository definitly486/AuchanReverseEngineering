package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

import android.view.Surface;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.BufferProvider;
import java.util.concurrent.Executor;

/* JADX INFO: loaded from: classes.dex */
public interface Encoder {

    public interface ByteBufferInput extends EncoderInput, BufferProvider {
    }

    public interface EncoderInput {
    }

    public interface SurfaceInput extends EncoderInput {

        public interface OnSurfaceUpdateListener {
            void onSurfaceUpdate(Surface surface);
        }

        void setOnSurfaceUpdateListener(Executor executor, OnSurfaceUpdateListener onSurfaceUpdateListener);
    }

    int getConfiguredBitrate();

    EncoderInfo getEncoderInfo();

    EncoderInput getInput();

    ListenableFuture getReleasedFuture();

    void pause();

    void release();

    void requestKeyFrame();

    void setEncoderCallback(EncoderCallback encoderCallback, Executor executor);

    void start();

    void stop(long j);
}
