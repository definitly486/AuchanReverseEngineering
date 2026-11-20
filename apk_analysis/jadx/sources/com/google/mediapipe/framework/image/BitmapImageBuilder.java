package com.google.mediapipe.framework.image;

import android.content.Context;
import android.graphics.Bitmap;
import android.net.Uri;
import android.provider.MediaStore;

/* JADX INFO: loaded from: classes3.dex */
public class BitmapImageBuilder {
    private final Bitmap bitmap;
    private long timestamp;

    public BitmapImageBuilder(Bitmap bitmap) {
        this.bitmap = bitmap;
        this.timestamp = 0L;
    }

    public BitmapImageBuilder(Context context, Uri uri) {
        this(MediaStore.Images.Media.getBitmap(context.getContentResolver(), uri));
    }

    BitmapImageBuilder setTimestamp(long j) {
        this.timestamp = j;
        return this;
    }

    public MPImage build() {
        return new MPImage(new BitmapImageContainer(this.bitmap), this.timestamp, this.bitmap.getWidth(), this.bitmap.getHeight());
    }
}
