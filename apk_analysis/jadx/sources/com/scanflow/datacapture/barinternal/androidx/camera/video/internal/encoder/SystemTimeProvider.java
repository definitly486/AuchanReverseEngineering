package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

import android.os.SystemClock;
import java.util.concurrent.TimeUnit;

/* JADX INFO: loaded from: classes.dex */
public class SystemTimeProvider implements TimeProvider {
    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.TimeProvider
    public long uptimeUs() {
        return TimeUnit.NANOSECONDS.toMicros(System.nanoTime());
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.TimeProvider
    public long realtimeUs() {
        return TimeUnit.NANOSECONDS.toMicros(SystemClock.elapsedRealtimeNanos());
    }
}
