package androidx.camera.video;

import java.util.Arrays;
import java.util.Collections;
import java.util.HashSet;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public abstract class AudioStats {
    private static final Set ERROR_STATES = Collections.unmodifiableSet(new HashSet(Arrays.asList(2, 3, 4)));

    abstract double getAudioAmplitudeInternal();

    public abstract int getAudioState();

    public abstract Throwable getErrorCause();

    AudioStats() {
    }

    static AudioStats of(int i, Throwable th, double d) {
        return new AutoValue_AudioStats(i, d, th);
    }
}
