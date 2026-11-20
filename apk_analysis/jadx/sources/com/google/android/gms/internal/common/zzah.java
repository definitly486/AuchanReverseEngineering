package com.google.android.gms.internal.common;

import java.util.List;

/* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
/* JADX INFO: loaded from: classes.dex */
final class zzah extends zzaj {
    private final transient zzaj zza;

    zzah(zzaj zzajVar) {
        this.zza = zzajVar;
    }

    private final int zzs(int i) {
        return (this.zza.size() - 1) - i;
    }

    @Override // com.google.android.gms.internal.common.zzaj, java.util.AbstractCollection, java.util.Collection, java.util.List
    public final boolean contains(Object obj) {
        return this.zza.contains(obj);
    }

    @Override // java.util.List
    public final Object get(int i) {
        zzaj zzajVar = this.zza;
        zzt.zzb(i, zzajVar.size(), "index");
        return zzajVar.get(zzs(i));
    }

    @Override // com.google.android.gms.internal.common.zzaj, java.util.List
    public final int indexOf(Object obj) {
        int iLastIndexOf = this.zza.lastIndexOf(obj);
        if (iLastIndexOf >= 0) {
            return zzs(iLastIndexOf);
        }
        return -1;
    }

    @Override // com.google.android.gms.internal.common.zzaj, java.util.List
    public final int lastIndexOf(Object obj) {
        int iIndexOf = this.zza.indexOf(obj);
        if (iIndexOf >= 0) {
            return zzs(iIndexOf);
        }
        return -1;
    }

    @Override // java.util.AbstractCollection, java.util.Collection, java.util.List
    public final int size() {
        return this.zza.size();
    }

    @Override // com.google.android.gms.internal.common.zzaj, java.util.List
    public final /* bridge */ /* synthetic */ List subList(int i, int i2) {
        return subList(i, i2);
    }

    @Override // com.google.android.gms.internal.common.zzae
    final boolean zzf() {
        return this.zza.zzf();
    }

    @Override // com.google.android.gms.internal.common.zzaj
    public final zzaj zzh() {
        return this.zza;
    }

    @Override // com.google.android.gms.internal.common.zzaj
    /* JADX INFO: renamed from: zzi */
    public final zzaj subList(int i, int i2) {
        zzaj zzajVar = this.zza;
        zzt.zzd(i, i2, zzajVar.size());
        return zzajVar.subList(zzajVar.size() - i2, zzajVar.size() - i).zzh();
    }
}
