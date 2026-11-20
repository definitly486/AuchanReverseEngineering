package androidx.camera.video;

import android.content.ContentResolver;
import android.content.ContentValues;
import android.net.Uri;

/* JADX INFO: loaded from: classes.dex */
public final class MediaStoreOutputOptions extends OutputOptions {
    public static final ContentValues EMPTY_CONTENT_VALUES = new ContentValues();

    public ContentResolver getContentResolver() {
        throw null;
    }

    public Uri getCollectionUri() {
        throw null;
    }

    public ContentValues getContentValues() {
        throw null;
    }

    public String toString() {
        throw null;
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof MediaStoreOutputOptions)) {
            return false;
        }
        ((MediaStoreOutputOptions) obj).getClass();
        throw null;
    }

    public int hashCode() {
        throw null;
    }
}
