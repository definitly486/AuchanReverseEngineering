package io.appmetrica.analytics.impl;

import android.os.Parcel;
import android.os.Parcelable;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.sb, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0591sb implements Parcelable.Creator {
    @Override // android.os.Parcelable.Creator
    public final Object createFromParcel(Parcel parcel) {
        return new C0617tb(parcel);
    }

    @Override // android.os.Parcelable.Creator
    public final Object[] newArray(int i) {
        return new C0617tb[i];
    }
}
