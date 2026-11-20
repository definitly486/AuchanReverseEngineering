package io.appmetrica.analytics.screenshot.impl;

import android.os.Parcel;
import android.os.Parcelable;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class A implements Parcelable.Creator {
    @Override // android.os.Parcelable.Creator
    public final Object createFromParcel(Parcel parcel) {
        boolean z = parcel.readByte() != 0;
        List listCreateStringArrayList = parcel.createStringArrayList();
        if (listCreateStringArrayList == null) {
            listCreateStringArrayList = CollectionsKt.emptyList();
        }
        return new B(z, listCreateStringArrayList, parcel.readLong());
    }

    @Override // android.os.Parcelable.Creator
    public final Object[] newArray(int i) {
        return new B[i];
    }
}
