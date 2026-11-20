package com.google.android.gms.internal.mlkit_vision_text_bundled_common;

import android.os.Parcel;
import android.os.Parcelable;
import com.google.android.gms.common.internal.safeparcel.AbstractSafeParcelable;
import com.google.android.gms.common.internal.safeparcel.SafeParcelWriter;
import com.google.android.gms.common.internal.safeparcel.SafeParcelable;
import java.util.List;

/* JADX INFO: compiled from: com.google.mlkit:text-recognition-bundled-common@@17.0.0 */
/* JADX INFO: loaded from: classes2.dex */
@SafeParcelable.Class(creator = "TextParcelCreator")
public final class zbok extends AbstractSafeParcelable {
    public static final Parcelable.Creator<zbok> CREATOR = new zbol();

    @SafeParcelable.Field(getter = "getText", id = 1)
    private final String zba;

    @SafeParcelable.Field(getter = "getTextBlockList", id = 2)
    private final List zbb;

    @SafeParcelable.Constructor
    public zbok(@SafeParcelable.Param(id = 1) String str, @SafeParcelable.Param(id = 2) List list) {
        this.zba = str;
        this.zbb = list;
    }

    @Override // android.os.Parcelable
    public final void writeToParcel(Parcel parcel, int i) {
        String str = this.zba;
        int iBeginObjectHeader = SafeParcelWriter.beginObjectHeader(parcel);
        SafeParcelWriter.writeString(parcel, 1, str, false);
        SafeParcelWriter.writeTypedList(parcel, 2, this.zbb, false);
        SafeParcelWriter.finishObjectHeader(parcel, iBeginObjectHeader);
    }
}
