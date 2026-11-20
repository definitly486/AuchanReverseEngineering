package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.compat;

import android.media.MediaMuxer;
import java.io.FileDescriptor;

/* JADX INFO: loaded from: classes.dex */
public abstract class Api26Impl {
    public static MediaMuxer createMediaMuxer(FileDescriptor fileDescriptor, int i) {
        return new MediaMuxer(fileDescriptor, i);
    }
}
