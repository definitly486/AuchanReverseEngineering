package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio;

import androidx.camera.core.Logger;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.nio.ByteBuffer;
import java.util.Queue;
import java.util.concurrent.ConcurrentLinkedQueue;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Executor;
import java.util.concurrent.FutureTask;
import java.util.concurrent.atomic.AtomicBoolean;

/* JADX INFO: loaded from: classes.dex */
public class BufferedAudioStream implements AudioStream {
    private final AudioStream mAudioStream;
    private int mBufferSize;
    private final int mBytesPerFrame;
    private final int mQueueMaxSize;
    private final int mSampleRate;
    private final AtomicBoolean mIsStarted = new AtomicBoolean(false);
    private final AtomicBoolean mIsReleased = new AtomicBoolean(false);
    private final Queue mAudioDataQueue = new ConcurrentLinkedQueue();
    private final Executor mProducerExecutor = CameraXExecutors.newSequentialExecutor(CameraXExecutors.audioExecutor());
    private final Object mLock = new Object();
    private AudioData mAudioDataNotFullyRead = null;
    private final AtomicBoolean mIsCollectingAudioData = new AtomicBoolean(false);

    public BufferedAudioStream(AudioStream audioStream, AudioSettings audioSettings) {
        this.mAudioStream = audioStream;
        int bytesPerFrame = audioSettings.getBytesPerFrame();
        this.mBytesPerFrame = bytesPerFrame;
        int sampleRate = audioSettings.getSampleRate();
        this.mSampleRate = sampleRate;
        Preconditions.checkArgument(((long) bytesPerFrame) > 0, "mBytesPerFrame must be greater than 0.");
        Preconditions.checkArgument(((long) sampleRate) > 0, "mSampleRate must be greater than 0.");
        this.mQueueMaxSize = 500;
        this.mBufferSize = bytesPerFrame * 1024;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioStream
    public void start() throws AudioStream.AudioStreamException {
        checkNotReleasedOrThrow();
        if (this.mIsStarted.getAndSet(true)) {
            return;
        }
        FutureTask futureTask = new FutureTask(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.BufferedAudioStream$$ExternalSyntheticLambda2
            @Override // java.lang.Runnable
            public final void run() {
                BufferedAudioStream.m530$r8$lambda$Qxmczpr0MZ1FIiG4XorkjcTOcY(this.f$0);
            }
        }, null);
        this.mProducerExecutor.execute(futureTask);
        try {
            futureTask.get();
        } catch (InterruptedException | ExecutionException e) {
            this.mIsStarted.set(false);
            throw new AudioStream.AudioStreamException(e);
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$Qxmcz-pr0MZ1FIiG4XorkjcTOcY, reason: not valid java name */
    public static /* synthetic */ void m530$r8$lambda$Qxmczpr0MZ1FIiG4XorkjcTOcY(BufferedAudioStream bufferedAudioStream) {
        bufferedAudioStream.getClass();
        try {
            bufferedAudioStream.mAudioStream.start();
            bufferedAudioStream.startCollectingAudioData();
        } catch (AudioStream.AudioStreamException e) {
            throw new RuntimeException(e);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioStream
    public void stop() {
        checkNotReleasedOrThrow();
        if (this.mIsStarted.getAndSet(false)) {
            this.mProducerExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.BufferedAudioStream$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    BufferedAudioStream.m529$r8$lambda$LTPEJ5GISHc681Jsgk8ftBcI6M(this.f$0);
                }
            });
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$LTPEJ5GISHc681Jsgk8f-tBcI6M, reason: not valid java name */
    public static /* synthetic */ void m529$r8$lambda$LTPEJ5GISHc681Jsgk8ftBcI6M(BufferedAudioStream bufferedAudioStream) {
        bufferedAudioStream.mIsCollectingAudioData.set(false);
        bufferedAudioStream.mAudioStream.stop();
        synchronized (bufferedAudioStream.mLock) {
            bufferedAudioStream.mAudioDataNotFullyRead = null;
            bufferedAudioStream.mAudioDataQueue.clear();
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioStream
    public void release() {
        if (this.mIsReleased.getAndSet(true)) {
            return;
        }
        this.mProducerExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.BufferedAudioStream$$ExternalSyntheticLambda5
            @Override // java.lang.Runnable
            public final void run() {
                BufferedAudioStream.m531$r8$lambda$Vn1oKj8yfSlvPJVMF7PNrOOWEY(this.f$0);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$Vn1oKj8yf-SlvPJVMF7PNrOOWEY, reason: not valid java name */
    public static /* synthetic */ void m531$r8$lambda$Vn1oKj8yfSlvPJVMF7PNrOOWEY(BufferedAudioStream bufferedAudioStream) {
        bufferedAudioStream.mIsCollectingAudioData.set(false);
        bufferedAudioStream.mAudioStream.release();
        synchronized (bufferedAudioStream.mLock) {
            bufferedAudioStream.mAudioDataNotFullyRead = null;
            bufferedAudioStream.mAudioDataQueue.clear();
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioStream
    public AudioStream.PacketInfo read(ByteBuffer byteBuffer) {
        boolean z;
        checkNotReleasedOrThrow();
        checkStartedOrThrow();
        updateCollectionBufferSizeAsync(byteBuffer.remaining());
        AudioStream.PacketInfo packetInfoOf = AudioStream.PacketInfo.of(0, 0L);
        do {
            synchronized (this.mLock) {
                try {
                    AudioData audioData = this.mAudioDataNotFullyRead;
                    this.mAudioDataNotFullyRead = null;
                    if (audioData == null) {
                        audioData = (AudioData) this.mAudioDataQueue.poll();
                    }
                    if (audioData != null) {
                        packetInfoOf = audioData.read(byteBuffer);
                        if (audioData.getRemainingBufferSizeInBytes() > 0) {
                            this.mAudioDataNotFullyRead = audioData;
                        }
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
            z = packetInfoOf.getSizeInBytes() <= 0 && this.mIsStarted.get() && !this.mIsReleased.get();
            if (z) {
                try {
                    Thread.sleep(1L);
                } catch (InterruptedException e) {
                    Logger.w("BufferedAudioStream", "Interruption while waiting for audio data", e);
                    return packetInfoOf;
                }
            }
        } while (z);
        return packetInfoOf;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioStream
    public void setCallback(final AudioStream.AudioStreamCallback audioStreamCallback, final Executor executor) {
        boolean z = true;
        Preconditions.checkState(!this.mIsStarted.get(), "AudioStream can not be started when setCallback.");
        checkNotReleasedOrThrow();
        if (audioStreamCallback != null && executor == null) {
            z = false;
        }
        Preconditions.checkArgument(z, "executor can't be null with non-null callback.");
        this.mProducerExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.BufferedAudioStream$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                this.f$0.mAudioStream.setCallback(audioStreamCallback, executor);
            }
        });
    }

    private void checkNotReleasedOrThrow() {
        Preconditions.checkState(!this.mIsReleased.get(), "AudioStream has been released.");
    }

    private void checkStartedOrThrow() {
        Preconditions.checkState(this.mIsStarted.get(), "AudioStream has not been started.");
    }

    private void updateCollectionBufferSizeAsync(final int i) {
        this.mProducerExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.BufferedAudioStream$$ExternalSyntheticLambda3
            @Override // java.lang.Runnable
            public final void run() {
                this.f$0.updateCollectionBufferSize(i);
            }
        });
    }

    /* JADX INFO: Access modifiers changed from: private */
    public void updateCollectionBufferSize(int i) {
        int i2 = this.mBufferSize;
        if (i2 == i) {
            return;
        }
        int i3 = this.mBytesPerFrame;
        this.mBufferSize = (i / i3) * i3;
        Logger.d("BufferedAudioStream", "Update buffer size from " + i2 + " to " + this.mBufferSize);
    }

    private void startCollectingAudioData() {
        if (this.mIsCollectingAudioData.getAndSet(true)) {
            return;
        }
        collectAudioData();
    }

    /* JADX INFO: Access modifiers changed from: private */
    public void collectAudioData() {
        if (this.mIsCollectingAudioData.get()) {
            ByteBuffer byteBufferAllocateDirect = ByteBuffer.allocateDirect(this.mBufferSize);
            AudioData audioData = new AudioData(byteBufferAllocateDirect, this.mAudioStream.read(byteBufferAllocateDirect), this.mBytesPerFrame, this.mSampleRate);
            int i = this.mQueueMaxSize;
            synchronized (this.mLock) {
                try {
                    this.mAudioDataQueue.offer(audioData);
                    while (this.mAudioDataQueue.size() > i) {
                        this.mAudioDataQueue.poll();
                        Logger.w("BufferedAudioStream", "Drop audio data due to full of queue.");
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
            if (this.mIsCollectingAudioData.get()) {
                this.mProducerExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.BufferedAudioStream$$ExternalSyntheticLambda4
                    @Override // java.lang.Runnable
                    public final void run() {
                        this.f$0.collectAudioData();
                    }
                });
            }
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    static class AudioData {
        private final ByteBuffer mByteBuffer;
        private final int mBytesPerFrame;
        private final int mSampleRate;
        private long mTimestampNs;

        AudioData(ByteBuffer byteBuffer, AudioStream.PacketInfo packetInfo, int i, int i2) {
            byteBuffer.rewind();
            int iLimit = byteBuffer.limit() - byteBuffer.position();
            if (iLimit != packetInfo.getSizeInBytes()) {
                throw new IllegalStateException("Byte buffer size is not match with packet info: " + iLimit + " != " + packetInfo.getSizeInBytes());
            }
            this.mBytesPerFrame = i;
            this.mSampleRate = i2;
            this.mByteBuffer = byteBuffer;
            this.mTimestampNs = packetInfo.getTimestampNs();
        }

        public int getRemainingBufferSizeInBytes() {
            return this.mByteBuffer.remaining();
        }

        public AudioStream.PacketInfo read(ByteBuffer byteBuffer) {
            int iRemaining;
            long j = this.mTimestampNs;
            int iPosition = this.mByteBuffer.position();
            int iPosition2 = byteBuffer.position();
            if (this.mByteBuffer.remaining() > byteBuffer.remaining()) {
                iRemaining = byteBuffer.remaining();
                this.mTimestampNs += AudioUtils.frameCountToDurationNs(AudioUtils.sizeToFrameCount(iRemaining, this.mBytesPerFrame), this.mSampleRate);
                ByteBuffer byteBufferDuplicate = this.mByteBuffer.duplicate();
                byteBufferDuplicate.position(iPosition).limit(iPosition + iRemaining);
                byteBuffer.put(byteBufferDuplicate).limit(iPosition2 + iRemaining).position(iPosition2);
            } else {
                iRemaining = this.mByteBuffer.remaining();
                byteBuffer.put(this.mByteBuffer).limit(iPosition2 + iRemaining).position(iPosition2);
            }
            this.mByteBuffer.position(iPosition + iRemaining);
            return AudioStream.PacketInfo.of(iRemaining, j);
        }
    }
}
