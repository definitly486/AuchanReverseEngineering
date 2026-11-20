package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio;

import android.content.Context;
import androidx.camera.core.Logger;
import androidx.camera.core.impl.Observable;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import androidx.camera.core.impl.utils.futures.FutureCallback;
import androidx.camera.core.impl.utils.futures.Futures;
import androidx.concurrent.futures.CallbackToFutureAdapter;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.BufferProvider;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.InputBuffer;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.nio.ByteBuffer;
import java.nio.ShortBuffer;
import java.util.Objects;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Executor;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.concurrent.atomic.AtomicReference;

/* JADX INFO: loaded from: classes.dex */
public final class AudioSource {
    private FutureCallback mAcquireBufferCallback;
    long mAmplitudeTimestamp;
    double mAudioAmplitude;
    private final int mAudioFormat;
    public final int mAudioSource;
    AudioSourceCallback mAudioSourceCallback;
    final AudioStream mAudioStream;
    boolean mAudioStreamSilenced;
    BufferProvider mBufferProvider;
    BufferProvider.State mBufferProviderState;
    Executor mCallbackExecutor;
    final Executor mExecutor;
    boolean mInSilentStartState;
    boolean mIsSendingAudio;
    private long mLatestFailedStartTimeNs;
    boolean mMuted;
    final AtomicReference mNotifiedSilenceState;
    final AtomicBoolean mNotifiedSuspendState;
    final SilentAudioStream mSilentAudioStream;
    private final long mStartRetryIntervalNs;
    InternalState mState;
    private Observable.Observer mStateObserver;
    private byte[] mZeroBytes;

    enum InternalState {
        CONFIGURED,
        STARTED,
        RELEASED
    }

    public AudioSource(AudioSettings audioSettings, Executor executor, Context context) {
        this(audioSettings, executor, context, new AudioStreamFactory() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda5
            @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioStreamFactory
            public final AudioStream create(AudioSettings audioSettings2, Context context2) {
                return new AudioStreamImpl(audioSettings2, context2);
            }
        }, 3000L);
    }

    AudioSource(AudioSettings audioSettings, Executor executor, Context context, AudioStreamFactory audioStreamFactory, long j) throws AudioSourceAccessException {
        this.mNotifiedSilenceState = new AtomicReference(null);
        this.mNotifiedSuspendState = new AtomicBoolean(false);
        this.mState = InternalState.CONFIGURED;
        this.mBufferProviderState = BufferProvider.State.INACTIVE;
        this.mAmplitudeTimestamp = 0L;
        Executor executorNewSequentialExecutor = CameraXExecutors.newSequentialExecutor(executor);
        this.mExecutor = executorNewSequentialExecutor;
        this.mStartRetryIntervalNs = TimeUnit.MILLISECONDS.toNanos(j);
        try {
            BufferedAudioStream bufferedAudioStream = new BufferedAudioStream(audioStreamFactory.create(audioSettings, context), audioSettings);
            this.mAudioStream = bufferedAudioStream;
            bufferedAudioStream.setCallback(new AudioStreamCallback(), executorNewSequentialExecutor);
            this.mSilentAudioStream = new SilentAudioStream(audioSettings);
            this.mAudioFormat = audioSettings.getAudioFormat();
            this.mAudioSource = audioSettings.getAudioSource();
        } catch (AudioStream.AudioStreamException | IllegalArgumentException e) {
            throw new AudioSourceAccessException("Unable to create AudioStream", e);
        }
    }

    class AudioStreamCallback implements AudioStream.AudioStreamCallback {
        AudioStreamCallback() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioStream.AudioStreamCallback
        public void onSilenceStateChanged(boolean z) {
            AudioSource audioSource = AudioSource.this;
            audioSource.mAudioStreamSilenced = z;
            if (audioSource.mState == InternalState.STARTED) {
                audioSource.notifySilenced();
            }
        }
    }

    public void setBufferProvider(final BufferProvider bufferProvider) {
        this.mExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda4
            @Override // java.lang.Runnable
            public final void run() {
                AudioSource.m525$r8$lambda$6kVduMcBJfgxc7WMTpKtmRKvag(this.f$0, bufferProvider);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$6kVduMcBJfgxc7WMTpK-tmRKvag, reason: not valid java name */
    public static /* synthetic */ void m525$r8$lambda$6kVduMcBJfgxc7WMTpKtmRKvag(AudioSource audioSource, BufferProvider bufferProvider) {
        int iOrdinal = audioSource.mState.ordinal();
        if (iOrdinal != 0 && iOrdinal != 1) {
            if (iOrdinal == 2) {
                throw new AssertionError("AudioSource is released");
            }
        } else if (audioSource.mBufferProvider != bufferProvider) {
            audioSource.resetBufferProvider(bufferProvider);
        }
    }

    public void start(final boolean z) {
        this.mExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda3
            @Override // java.lang.Runnable
            public final void run() {
                AudioSource.$r8$lambda$lmBBTiJyZWP_CukKMojMiQKKE1Y(this.f$0, z);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$lmBBTiJyZWP_CukKMojMiQKKE1Y(AudioSource audioSource, boolean z) {
        int iOrdinal = audioSource.mState.ordinal();
        if (iOrdinal != 0) {
            if (iOrdinal == 2) {
                throw new AssertionError("AudioSource is released");
            }
            return;
        }
        audioSource.mNotifiedSilenceState.set(null);
        audioSource.mNotifiedSuspendState.set(false);
        audioSource.setState(InternalState.STARTED);
        audioSource.mute(z);
        audioSource.updateSendingAudio();
    }

    public void stop() {
        this.mExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                AudioSource.m526$r8$lambda$MCIQfao3x49prQVwJnlsxvBvk(this.f$0);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$MCIQ-fao3x49prQV-wJnlsxvBvk, reason: not valid java name */
    public static /* synthetic */ void m526$r8$lambda$MCIQfao3x49prQVwJnlsxvBvk(AudioSource audioSource) {
        int iOrdinal = audioSource.mState.ordinal();
        if (iOrdinal == 1) {
            audioSource.setState(InternalState.CONFIGURED);
            audioSource.updateSendingAudio();
        } else {
            if (iOrdinal != 2) {
                return;
            }
            Logger.w("AudioSource", "AudioSource is released. Calling stop() is a no-op.");
        }
    }

    public ListenableFuture release() {
        return CallbackToFutureAdapter.getFuture(new CallbackToFutureAdapter.Resolver() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda2
            @Override // androidx.concurrent.futures.CallbackToFutureAdapter.Resolver
            public final Object attachCompleter(CallbackToFutureAdapter.Completer completer) {
                return AudioSource.$r8$lambda$2MPk8AEkDRr4z4NBzOvKQlX0GwM(this.f$0, completer);
            }
        });
    }

    public static /* synthetic */ Object $r8$lambda$2MPk8AEkDRr4z4NBzOvKQlX0GwM(final AudioSource audioSource, final CallbackToFutureAdapter.Completer completer) {
        audioSource.mExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda7
            @Override // java.lang.Runnable
            public final void run() {
                AudioSource.$r8$lambda$ATOwVKaDWdQPPa5nT9wAcxIca0s(this.f$0, completer);
            }
        });
        return "AudioSource-release";
    }

    public static /* synthetic */ void $r8$lambda$ATOwVKaDWdQPPa5nT9wAcxIca0s(AudioSource audioSource, CallbackToFutureAdapter.Completer completer) {
        audioSource.getClass();
        try {
            int iOrdinal = audioSource.mState.ordinal();
            if (iOrdinal == 0 || iOrdinal == 1) {
                audioSource.resetBufferProvider(null);
                audioSource.mSilentAudioStream.release();
                audioSource.mAudioStream.release();
                audioSource.stopSendingAudio();
                audioSource.setState(InternalState.RELEASED);
            }
            completer.set(null);
        } catch (Throwable th) {
            completer.setException(th);
        }
    }

    public void setAudioSourceCallback(final Executor executor, final AudioSourceCallback audioSourceCallback) {
        this.mExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda8
            @Override // java.lang.Runnable
            public final void run() {
                AudioSource.m524$r8$lambda$2bGbfYXQuUQnjXF6ro573qab1w(this.f$0, executor, audioSourceCallback);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$2bGb-fYXQuUQnjXF6ro573qab1w, reason: not valid java name */
    public static /* synthetic */ void m524$r8$lambda$2bGbfYXQuUQnjXF6ro573qab1w(AudioSource audioSource, Executor executor, AudioSourceCallback audioSourceCallback) {
        int iOrdinal = audioSource.mState.ordinal();
        if (iOrdinal == 0) {
            audioSource.mCallbackExecutor = executor;
            audioSource.mAudioSourceCallback = audioSourceCallback;
        } else if (iOrdinal == 1 || iOrdinal == 2) {
            throw new AssertionError("The audio recording callback must be registered before the audio source is started.");
        }
    }

    public void mute(final boolean z) {
        this.mExecutor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                AudioSource.$r8$lambda$8qn4Y49tzJEfnDKTp85w56ZVltQ(this.f$0, z);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$8qn4Y49tzJEfnDKTp85w56ZVltQ(AudioSource audioSource, boolean z) {
        int iOrdinal = audioSource.mState.ordinal();
        if (iOrdinal != 0 && iOrdinal != 1) {
            if (iOrdinal == 2) {
                throw new AssertionError("AudioSource is released");
            }
        } else {
            if (audioSource.mMuted == z) {
                return;
            }
            audioSource.mMuted = z;
            if (audioSource.mState == InternalState.STARTED) {
                audioSource.notifySilenced();
            }
        }
    }

    private void resetBufferProvider(final BufferProvider bufferProvider) {
        BufferProvider bufferProvider2 = this.mBufferProvider;
        if (bufferProvider2 != null) {
            Observable.Observer observer = this.mStateObserver;
            Objects.requireNonNull(observer);
            bufferProvider2.removeObserver(observer);
            this.mBufferProvider = null;
            this.mStateObserver = null;
            this.mAcquireBufferCallback = null;
            this.mBufferProviderState = BufferProvider.State.INACTIVE;
            updateSendingAudio();
        }
        if (bufferProvider != null) {
            this.mBufferProvider = bufferProvider;
            this.mStateObserver = new Observable.Observer() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource.1
                @Override // androidx.camera.core.impl.Observable.Observer
                public void onNewData(BufferProvider.State state) {
                    Objects.requireNonNull(state);
                    if (AudioSource.this.mBufferProvider == bufferProvider) {
                        Logger.d("AudioSource", "Receive BufferProvider state change: " + AudioSource.this.mBufferProviderState + " to " + state);
                        AudioSource audioSource = AudioSource.this;
                        if (audioSource.mBufferProviderState != state) {
                            audioSource.mBufferProviderState = state;
                            audioSource.updateSendingAudio();
                        }
                    }
                }

                @Override // androidx.camera.core.impl.Observable.Observer
                public void onError(Throwable th) {
                    AudioSource audioSource = AudioSource.this;
                    if (audioSource.mBufferProvider == bufferProvider) {
                        audioSource.notifyError(th);
                    }
                }
            };
            this.mAcquireBufferCallback = new FutureCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource.2
                @Override // androidx.camera.core.impl.utils.futures.FutureCallback
                public void onSuccess(InputBuffer inputBuffer) {
                    AudioSource audioSource = AudioSource.this;
                    if (!audioSource.mIsSendingAudio || audioSource.mBufferProvider != bufferProvider) {
                        inputBuffer.cancel();
                        return;
                    }
                    if (audioSource.mInSilentStartState && audioSource.isStartRetryIntervalReached()) {
                        AudioSource.this.retryStartAudioStream();
                    }
                    AudioStream currentAudioStream = AudioSource.this.getCurrentAudioStream();
                    ByteBuffer byteBuffer = inputBuffer.getByteBuffer();
                    AudioStream.PacketInfo packetInfo = currentAudioStream.read(byteBuffer);
                    if (packetInfo.getSizeInBytes() > 0) {
                        AudioSource audioSource2 = AudioSource.this;
                        if (audioSource2.mMuted) {
                            audioSource2.overrideBySilence(byteBuffer, packetInfo.getSizeInBytes());
                        }
                        if (AudioSource.this.mCallbackExecutor != null) {
                            long timestampNs = packetInfo.getTimestampNs();
                            AudioSource audioSource3 = AudioSource.this;
                            if (timestampNs - audioSource3.mAmplitudeTimestamp >= 200) {
                                audioSource3.mAmplitudeTimestamp = packetInfo.getTimestampNs();
                                AudioSource.this.postMaxAmplitude(byteBuffer);
                            }
                        }
                        byteBuffer.limit(byteBuffer.position() + packetInfo.getSizeInBytes());
                        inputBuffer.setPresentationTimeUs(TimeUnit.NANOSECONDS.toMicros(packetInfo.getTimestampNs()));
                        inputBuffer.submit();
                    } else {
                        Logger.w("AudioSource", "Unable to read data from AudioStream.");
                        inputBuffer.cancel();
                    }
                    AudioSource.this.sendNextAudio();
                }

                @Override // androidx.camera.core.impl.utils.futures.FutureCallback
                public void onFailure(Throwable th) {
                    if (AudioSource.this.mBufferProvider != bufferProvider) {
                        return;
                    }
                    Logger.d("AudioSource", "Unable to get input buffer, the BufferProvider could be transitioning to INACTIVE state.");
                    if (th instanceof IllegalStateException) {
                        return;
                    }
                    AudioSource.this.notifyError(th);
                }
            };
            BufferProvider.State stateFetchBufferProviderState = fetchBufferProviderState(bufferProvider);
            if (stateFetchBufferProviderState != null) {
                this.mBufferProviderState = stateFetchBufferProviderState;
                updateSendingAudio();
            }
            this.mBufferProvider.addObserver(this.mExecutor, this.mStateObserver);
        }
    }

    AudioStream getCurrentAudioStream() {
        return this.mInSilentStartState ? this.mSilentAudioStream : this.mAudioStream;
    }

    void retryStartAudioStream() {
        Preconditions.checkState(this.mInSilentStartState);
        try {
            this.mAudioStream.start();
            Logger.d("AudioSource", "Retry start AudioStream succeed");
            this.mSilentAudioStream.stop();
            this.mInSilentStartState = false;
        } catch (AudioStream.AudioStreamException e) {
            Logger.w("AudioSource", "Retry start AudioStream failed", e);
            this.mLatestFailedStartTimeNs = getCurrentSystemTimeNs();
        }
    }

    boolean isStartRetryIntervalReached() {
        Preconditions.checkState(this.mLatestFailedStartTimeNs > 0);
        return getCurrentSystemTimeNs() - this.mLatestFailedStartTimeNs >= this.mStartRetryIntervalNs;
    }

    void notifyError(final Throwable th) {
        Executor executor = this.mCallbackExecutor;
        final AudioSourceCallback audioSourceCallback = this.mAudioSourceCallback;
        if (executor == null || audioSourceCallback == null) {
            return;
        }
        executor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda11
            @Override // java.lang.Runnable
            public final void run() {
                audioSourceCallback.onError(th);
            }
        });
    }

    void notifySilenced() {
        Executor executor = this.mCallbackExecutor;
        final AudioSourceCallback audioSourceCallback = this.mAudioSourceCallback;
        if (executor == null || audioSourceCallback == null) {
            return;
        }
        final boolean z = this.mMuted || this.mInSilentStartState || this.mAudioStreamSilenced;
        if (Objects.equals(this.mNotifiedSilenceState.getAndSet(Boolean.valueOf(z)), Boolean.valueOf(z))) {
            return;
        }
        executor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda6
            @Override // java.lang.Runnable
            public final void run() {
                audioSourceCallback.onSilenceStateChanged(z);
            }
        });
    }

    void notifySuspended(final boolean z) {
        Executor executor = this.mCallbackExecutor;
        final AudioSourceCallback audioSourceCallback = this.mAudioSourceCallback;
        if (executor == null || audioSourceCallback == null || this.mNotifiedSuspendState.getAndSet(z) == z) {
            return;
        }
        executor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda10
            @Override // java.lang.Runnable
            public final void run() {
                audioSourceCallback.onSuspendStateChanged(z);
            }
        });
    }

    void overrideBySilence(ByteBuffer byteBuffer, int i) {
        byte[] bArr = this.mZeroBytes;
        if (bArr == null || bArr.length < i) {
            this.mZeroBytes = new byte[i];
        }
        int iPosition = byteBuffer.position();
        byteBuffer.put(this.mZeroBytes, 0, i);
        byteBuffer.limit(byteBuffer.position()).position(iPosition);
    }

    void updateSendingAudio() {
        if (this.mState == InternalState.STARTED) {
            boolean z = this.mBufferProviderState == BufferProvider.State.ACTIVE;
            notifySuspended(!z);
            if (z) {
                startSendingAudio();
                return;
            } else {
                stopSendingAudio();
                return;
            }
        }
        stopSendingAudio();
    }

    private void startSendingAudio() {
        if (this.mIsSendingAudio) {
            return;
        }
        try {
            Logger.d("AudioSource", "startSendingAudio");
            this.mAudioStream.start();
            this.mInSilentStartState = false;
        } catch (AudioStream.AudioStreamException e) {
            Logger.w("AudioSource", "Failed to start AudioStream", e);
            this.mInSilentStartState = true;
            this.mSilentAudioStream.start();
            this.mLatestFailedStartTimeNs = getCurrentSystemTimeNs();
            notifySilenced();
        }
        this.mIsSendingAudio = true;
        sendNextAudio();
    }

    private void stopSendingAudio() {
        if (this.mIsSendingAudio) {
            this.mIsSendingAudio = false;
            Logger.d("AudioSource", "stopSendingAudio");
            this.mAudioStream.stop();
        }
    }

    void sendNextAudio() {
        BufferProvider bufferProvider = this.mBufferProvider;
        Objects.requireNonNull(bufferProvider);
        ListenableFuture listenableFutureAcquireBuffer = bufferProvider.acquireBuffer();
        FutureCallback futureCallback = this.mAcquireBufferCallback;
        Objects.requireNonNull(futureCallback);
        Futures.addCallback(listenableFutureAcquireBuffer, futureCallback, this.mExecutor);
    }

    void setState(InternalState internalState) {
        Logger.d("AudioSource", "Transitioning internal state: " + this.mState + " --> " + internalState);
        this.mState = internalState;
    }

    void postMaxAmplitude(ByteBuffer byteBuffer) {
        Executor executor = this.mCallbackExecutor;
        final AudioSourceCallback audioSourceCallback = this.mAudioSourceCallback;
        if (this.mAudioFormat == 2) {
            ShortBuffer shortBufferAsShortBuffer = byteBuffer.asShortBuffer();
            double dMax = 0.0d;
            while (shortBufferAsShortBuffer.hasRemaining()) {
                dMax = Math.max(dMax, Math.abs((int) shortBufferAsShortBuffer.get()));
            }
            this.mAudioAmplitude = dMax / 32767.0d;
            if (executor == null || audioSourceCallback == null) {
                return;
            }
            executor.execute(new Runnable() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSource$$ExternalSyntheticLambda9
                @Override // java.lang.Runnable
                public final void run() {
                    audioSourceCallback.onAmplitudeValue(this.f$0.mAudioAmplitude);
                }
            });
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    private static BufferProvider.State fetchBufferProviderState(BufferProvider bufferProvider) {
        try {
            ListenableFuture listenableFutureFetchData = bufferProvider.fetchData();
            if (listenableFutureFetchData.isDone()) {
                return (BufferProvider.State) listenableFutureFetchData.get();
            }
        } catch (InterruptedException | ExecutionException unused) {
        }
        return null;
    }

    public static boolean isSettingsSupported(int i, int i2, int i3) {
        return AudioStreamImpl.isSettingsSupported(i, i2, i3);
    }

    private static long getCurrentSystemTimeNs() {
        return System.nanoTime();
    }

    public interface AudioSourceCallback {
        void onAmplitudeValue(double d);

        void onError(Throwable th);

        void onSilenceStateChanged(boolean z);

        default void onSuspendStateChanged(boolean z) {
        }
    }
}
