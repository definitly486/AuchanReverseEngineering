package com.google.android.gms.internal.mlkit_vision_text_bundled_common;

import android.os.Parcel;
import android.os.Parcelable;
import com.google.android.gms.common.internal.safeparcel.AbstractSafeParcelable;
import com.google.android.gms.common.internal.safeparcel.SafeParcelWriter;
import com.google.android.gms.common.internal.safeparcel.SafeParcelable;

/* JADX INFO: compiled from: com.google.mlkit:text-recognition-bundled-common@@17.0.0 */
/* JADX INFO: loaded from: classes2.dex */
@SafeParcelable.Class(creator = "BoundingBoxParcelCreator")
@SafeParcelable.Reserved({1})
public final class zbd extends AbstractSafeParcelable {
    public static final Parcelable.Creator<zbd> CREATOR = new zbe();

    @SafeParcelable.Field(id = 2)
    public final int zba;

    @SafeParcelable.Field(id = 3)
    public final int zbb;

    @SafeParcelable.Field(id = 4)
    public final int zbc;

    @SafeParcelable.Field(id = 5)
    public final int zbd;

    @SafeParcelable.Field(id = 6)
    public final float zbe;

    @SafeParcelable.Constructor
    public zbd(@SafeParcelable.Param(id = 2) int i, @SafeParcelable.Param(id = 3) int i2, @SafeParcelable.Param(id = 4) int i3, @SafeParcelable.Param(id = 5) int i4, @SafeParcelable.Param(id = 6) float f) {
        this.zba = i;
        this.zbb = i2;
        this.zbc = i3;
        this.zbd = i4;
        this.zbe = f;
    }

    @Override // android.os.Parcelable
    public final void writeToParcel(Parcel parcel, int i) {
        int i2 = this.zba;
        int iBeginObjectHeader = SafeParcelWriter.beginObjectHeader(parcel);
        SafeParcelWriter.writeInt(parcel, 2, i2);
        SafeParcelWriter.writeInt(parcel, 3, this.zbb);
        SafeParcelWriter.writeInt(parcel, 4, this.zbc);
        SafeParcelWriter.writeInt(parcel, 5, this.zbd);
        SafeParcelWriter.writeFloat(parcel, 6, this.zbe);
        SafeParcelWriter.finishObjectHeader(parcel, iBeginObjectHeader);
    }
}
