package com.scanflow.datacapture.barinternal.androidx.savedstate;

import android.os.Bundle;
import android.os.IBinder;
import android.os.Parcelable;
import android.util.Size;
import android.util.SizeF;
import android.util.SparseArray;
import java.io.Serializable;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SavedStateWriter.android.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SavedStateWriter {
    /* JADX INFO: renamed from: constructor-impl, reason: not valid java name */
    public static Bundle m591constructorimpl(Bundle source) {
        Intrinsics.checkNotNullParameter(source, "source");
        return source;
    }

    /* JADX INFO: renamed from: putBinder-impl, reason: not valid java name */
    public static final void m593putBinderimpl(Bundle bundle, String key, IBinder value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putBinder(key, value);
    }

    /* JADX INFO: renamed from: putBoolean-impl, reason: not valid java name */
    public static final void m594putBooleanimpl(Bundle bundle, String key, boolean z) {
        Intrinsics.checkNotNullParameter(key, "key");
        bundle.putBoolean(key, z);
    }

    /* JADX INFO: renamed from: putChar-impl, reason: not valid java name */
    public static final void m596putCharimpl(Bundle bundle, String key, char c) {
        Intrinsics.checkNotNullParameter(key, "key");
        bundle.putChar(key, c);
    }

    /* JADX INFO: renamed from: putCharSequence-impl, reason: not valid java name */
    public static final void m598putCharSequenceimpl(Bundle bundle, String key, CharSequence value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putCharSequence(key, value);
    }

    /* JADX INFO: renamed from: putDouble-impl, reason: not valid java name */
    public static final void m601putDoubleimpl(Bundle bundle, String key, double d) {
        Intrinsics.checkNotNullParameter(key, "key");
        bundle.putDouble(key, d);
    }

    /* JADX INFO: renamed from: putFloat-impl, reason: not valid java name */
    public static final void m603putFloatimpl(Bundle bundle, String key, float f) {
        Intrinsics.checkNotNullParameter(key, "key");
        bundle.putFloat(key, f);
    }

    /* JADX INFO: renamed from: putInt-impl, reason: not valid java name */
    public static final void m605putIntimpl(Bundle bundle, String key, int i) {
        Intrinsics.checkNotNullParameter(key, "key");
        bundle.putInt(key, i);
    }

    /* JADX INFO: renamed from: putLong-impl, reason: not valid java name */
    public static final void m609putLongimpl(Bundle bundle, String key, long j) {
        Intrinsics.checkNotNullParameter(key, "key");
        bundle.putLong(key, j);
    }

    /* JADX INFO: renamed from: putNull-impl, reason: not valid java name */
    public static final void m611putNullimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        bundle.putString(key, null);
    }

    /* JADX INFO: renamed from: putParcelable-impl, reason: not valid java name */
    public static final void m612putParcelableimpl(Bundle bundle, String key, Parcelable value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putParcelable(key, value);
    }

    /* JADX INFO: renamed from: putJavaSerializable-impl, reason: not valid java name */
    public static final void m608putJavaSerializableimpl(Bundle bundle, String key, Serializable value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putSerializable(key, value);
    }

    /* JADX INFO: renamed from: putSize-impl, reason: not valid java name */
    public static final void m616putSizeimpl(Bundle bundle, String key, Size value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putSize(key, value);
    }

    /* JADX INFO: renamed from: putSizeF-impl, reason: not valid java name */
    public static final void m617putSizeFimpl(Bundle bundle, String key, SizeF value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putSizeF(key, value);
    }

    /* JADX INFO: renamed from: putString-impl, reason: not valid java name */
    public static final void m619putStringimpl(Bundle bundle, String key, String value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putString(key, value);
    }

    /* JADX INFO: renamed from: putIntList-impl, reason: not valid java name */
    public static final void m607putIntListimpl(Bundle bundle, String key, List value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putIntegerArrayList(key, SavedStateWriterKt.toArrayListUnsafe(value));
    }

    /* JADX INFO: renamed from: putCharSequenceList-impl, reason: not valid java name */
    public static final void m600putCharSequenceListimpl(Bundle bundle, String key, List value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putCharSequenceArrayList(key, SavedStateWriterKt.toArrayListUnsafe(value));
    }

    /* JADX INFO: renamed from: putStringList-impl, reason: not valid java name */
    public static final void m621putStringListimpl(Bundle bundle, String key, List value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putStringArrayList(key, SavedStateWriterKt.toArrayListUnsafe(value));
    }

    /* JADX INFO: renamed from: putParcelableList-impl, reason: not valid java name */
    public static final void m614putParcelableListimpl(Bundle bundle, String key, List value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putParcelableArrayList(key, SavedStateWriterKt.toArrayListUnsafe(value));
    }

    /* JADX INFO: renamed from: putBooleanArray-impl, reason: not valid java name */
    public static final void m595putBooleanArrayimpl(Bundle bundle, String key, boolean[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putBooleanArray(key, value);
    }

    /* JADX INFO: renamed from: putCharArray-impl, reason: not valid java name */
    public static final void m597putCharArrayimpl(Bundle bundle, String key, char[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putCharArray(key, value);
    }

    /* JADX INFO: renamed from: putCharSequenceArray-impl, reason: not valid java name */
    public static final void m599putCharSequenceArrayimpl(Bundle bundle, String key, CharSequence[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putCharSequenceArray(key, value);
    }

    /* JADX INFO: renamed from: putDoubleArray-impl, reason: not valid java name */
    public static final void m602putDoubleArrayimpl(Bundle bundle, String key, double[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putDoubleArray(key, value);
    }

    /* JADX INFO: renamed from: putFloatArray-impl, reason: not valid java name */
    public static final void m604putFloatArrayimpl(Bundle bundle, String key, float[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putFloatArray(key, value);
    }

    /* JADX INFO: renamed from: putIntArray-impl, reason: not valid java name */
    public static final void m606putIntArrayimpl(Bundle bundle, String key, int[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putIntArray(key, value);
    }

    /* JADX INFO: renamed from: putLongArray-impl, reason: not valid java name */
    public static final void m610putLongArrayimpl(Bundle bundle, String key, long[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putLongArray(key, value);
    }

    /* JADX INFO: renamed from: putStringArray-impl, reason: not valid java name */
    public static final void m620putStringArrayimpl(Bundle bundle, String key, String[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putStringArray(key, value);
    }

    /* JADX INFO: renamed from: putParcelableArray-impl, reason: not valid java name */
    public static final void m613putParcelableArrayimpl(Bundle bundle, String key, Parcelable[] value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putParcelableArray(key, value);
    }

    /* JADX INFO: renamed from: putSparseParcelableArray-impl, reason: not valid java name */
    public static final void m618putSparseParcelableArrayimpl(Bundle bundle, String key, SparseArray value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putSparseParcelableArray(key, value);
    }

    /* JADX INFO: renamed from: putSavedState-impl, reason: not valid java name */
    public static final void m615putSavedStateimpl(Bundle bundle, String key, Bundle value) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(value, "value");
        bundle.putBundle(key, value);
    }

    /* JADX INFO: renamed from: putAll-impl, reason: not valid java name */
    public static final void m592putAllimpl(Bundle bundle, Bundle from) {
        Intrinsics.checkNotNullParameter(from, "from");
        bundle.putAll(from);
    }

    /* JADX INFO: renamed from: remove-impl, reason: not valid java name */
    public static final void m622removeimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        bundle.remove(key);
    }
}
