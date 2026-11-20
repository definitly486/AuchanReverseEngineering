package com.scanflow.datacapture.barinternal.androidx.camera.core.internal.compat;

import android.os.Build;

/* JADX INFO: loaded from: classes.dex */
public abstract class MediaActionSoundCompat {
    public static boolean mustPlayShutterSound() {
        if (Build.VERSION.SDK_INT >= 33) {
            return MediaActionSoundCompatApi33Impl.mustPlayShutterSound();
        }
        return MediaActionSoundCompatBaseImpl.mustPlayShutterSound();
    }
}
