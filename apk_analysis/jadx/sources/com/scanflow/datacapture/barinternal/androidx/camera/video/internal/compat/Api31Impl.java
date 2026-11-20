package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.compat;

import android.content.Context;
import android.media.AudioRecord;

/* JADX INFO: loaded from: classes.dex */
public abstract class Api31Impl {
    public static void setContext(AudioRecord.Builder builder, Context context) {
        builder.setContext(context);
    }
}
