package com.scanflow.datacapture.core.camera.analyze;

import android.graphics.Bitmap;

/* JADX INFO: loaded from: classes3.dex */
public final class AnalyzeResult<T> {
    private Bitmap bitmap;
    private T result;

    public AnalyzeResult() {
    }

    public final Bitmap getBitmap() {
        return this.bitmap;
    }

    public final T getResult() {
        return this.result;
    }

    public final void setBitmap(Bitmap bitmap) {
        this.bitmap = bitmap;
    }

    public final void setResult(T t) {
        this.result = t;
    }

    public AnalyzeResult(Bitmap bitmap, T t) {
        this.bitmap = bitmap;
        this.result = t;
    }
}
