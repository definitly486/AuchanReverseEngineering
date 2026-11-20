package com.google.mediapipe.framework;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MediaPipeRunner extends Graph {
    protected Context context;

    public abstract void pause();

    public abstract void release();

    public abstract void resume();

    public abstract void start();

    public MediaPipeRunner(Context context) {
        AssetCache.create(context);
        this.context = context;
    }

    public void loadBinaryGraphFromAsset(String str) {
        try {
            loadBinaryGraph(AssetCache.getAssetCache().getAbsolutePathFromAsset(str));
        } catch (MediaPipeException unused) {
        }
    }

    public void release(long j) {
        release();
    }
}
