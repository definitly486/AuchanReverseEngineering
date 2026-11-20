package com.google.android.gms.internal.common;

import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;
import java.util.RandomAccess;

/* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
/* JADX INFO: loaded from: classes.dex */
public abstract class zzaj extends zzae implements List, RandomAccess {
    private static final zzan zza = new zzag(zzal.zza, 0);
    public static final /* synthetic */ int zzd = 0;

    zzaj() {
    }

    public static zzaj zzj() {
        return zzal.zza;
    }

    public static zzaj zzk(Object obj) {
        Object[] objArr = {obj};
        zzak.zza(objArr, 1);
        return zzq(objArr, 1);
    }

    public static zzaj zzl(Object obj, Object obj2) {
        Object[] objArr = {obj, obj2};
        zzak.zza(objArr, 2);
        return zzq(objArr, 2);
    }

    public static zzaj zzm(Object obj, Object obj2, Object obj3) {
        Object[] objArr = {obj, obj2, obj3};
        zzak.zza(objArr, 3);
        return zzq(objArr, 3);
    }

    public static zzaj zzn(Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6) {
        Object[] objArr = {obj, obj2, obj3, obj4, obj5, obj6};
        zzak.zza(objArr, 6);
        return zzq(objArr, 6);
    }

    public static zzaj zzp(Collection collection) {
        if (!(collection instanceof zzae)) {
            Object[] array = collection.toArray();
            int length = array.length;
            zzak.zza(array, length);
            return zzq(array, length);
        }
        zzaj zzajVarZze = ((zzae) collection).zze();
        if (!zzajVarZze.zzf()) {
            return zzajVarZze;
        }
        Object[] array2 = zzajVarZze.toArray();
        return zzq(array2, array2.length);
    }

    static zzaj zzq(Object[] objArr, int i) {
        return i == 0 ? zzal.zza : new zzal(objArr, i);
    }

    @Override // java.util.List
    @Deprecated
    public final void add(int i, Object obj) {
        throw new UnsupportedOperationException();
    }

    @Override // java.util.List
    @Deprecated
    public final boolean addAll(int i, Collection collection) {
        throw new UnsupportedOperationException();
    }

    @Override // java.util.AbstractCollection, java.util.Collection, java.util.List
    public boolean contains(Object obj) {
        return indexOf(obj) >= 0;
    }

    @Override // java.util.Collection, java.util.List
    public final boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (!(obj instanceof List)) {
            return false;
        }
        List list = (List) obj;
        int size = size();
        if (size != list.size()) {
            return false;
        }
        if (list instanceof RandomAccess) {
            for (int i = 0; i < size; i++) {
                if (!zzs.zza(get(i), list.get(i))) {
                    return false;
                }
            }
            return true;
        }
        Iterator it = iterator();
        Iterator it2 = list.iterator();
        while (it.hasNext()) {
            if (!it2.hasNext() || !zzs.zza(it.next(), it2.next())) {
                return false;
            }
        }
        return !it2.hasNext();
    }

    @Override // java.util.Collection, java.util.List
    public final int hashCode() {
        int size = size();
        int iHashCode = 1;
        for (int i = 0; i < size; i++) {
            iHashCode = (iHashCode * 31) + get(i).hashCode();
        }
        return iHashCode;
    }

    public int indexOf(Object obj) {
        if (obj == null) {
            return -1;
        }
        int size = size();
        for (int i = 0; i < size; i++) {
            if (obj.equals(get(i))) {
                return i;
            }
        }
        return -1;
    }

    @Override // com.google.android.gms.internal.common.zzae, java.util.AbstractCollection, java.util.Collection, java.lang.Iterable
    public final /* synthetic */ Iterator iterator() {
        return listIterator(0);
    }

    public int lastIndexOf(Object obj) {
        if (obj == null) {
            return -1;
        }
        for (int size = size() - 1; size >= 0; size--) {
            if (obj.equals(get(size))) {
                return size;
            }
        }
        return -1;
    }

    @Override // java.util.List
    public final /* synthetic */ ListIterator listIterator() {
        return listIterator(0);
    }

    @Override // java.util.List
    @Deprecated
    public final Object remove(int i) {
        throw new UnsupportedOperationException();
    }

    @Override // java.util.List
    @Deprecated
    public final Object set(int i, Object obj) {
        throw new UnsupportedOperationException();
    }

    @Override // com.google.android.gms.internal.common.zzae
    /* JADX INFO: renamed from: zza */
    public final zzam iterator() {
        return listIterator(0);
    }

    @Override // com.google.android.gms.internal.common.zzae
    @Deprecated
    public final zzaj zze() {
        return this;
    }

    @Override // com.google.android.gms.internal.common.zzae
    int zzg(Object[] objArr, int i) {
        int size = size();
        for (int i2 = 0; i2 < size; i2++) {
            objArr[i2] = get(i2);
        }
        return size;
    }

    public zzaj zzh() {
        return size() <= 1 ? this : new zzah(this);
    }

    @Override // java.util.List
    /* JADX INFO: renamed from: zzi, reason: merged with bridge method [inline-methods] */
    public zzaj subList(int i, int i2) {
        zzt.zzd(i, i2, size());
        int i3 = i2 - i;
        if (i3 == size()) {
            return this;
        }
        return i3 == 0 ? zzal.zza : new zzai(this, i, i3);
    }

    @Override // java.util.List
    /* JADX INFO: renamed from: zzr, reason: merged with bridge method [inline-methods] */
    public final zzan listIterator(int i) {
        zzt.zzc(i, size(), "index");
        return isEmpty() ? zza : new zzag(this, i);
    }

    public static zzaj zzo(Iterable iterable) {
        iterable.getClass();
        if (iterable instanceof Collection) {
            return zzp((Collection) iterable);
        }
        Iterator it = iterable.iterator();
        if (!it.hasNext()) {
            return zzal.zza;
        }
        Object next = it.next();
        if (!it.hasNext()) {
            return zzk(next);
        }
        zzaf zzafVar = new zzaf(4);
        zzafVar.zzb(next);
        zzafVar.zzc(it);
        return zzafVar.zzd();
    }
}
