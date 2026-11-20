package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

import android.media.MediaFormat;
import androidx.camera.core.impl.Timebase;

/* JADX INFO: loaded from: classes.dex */
public interface EncoderConfig {
    Timebase getInputTimebase();

    String getMimeType();

    MediaFormat toMediaFormat();
}
