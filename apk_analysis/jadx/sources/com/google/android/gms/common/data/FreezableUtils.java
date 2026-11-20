package com.google.android.gms.common.data;

import androidx.gridlayout.widget.GridLayout;
import java.util.ArrayList;
import java.util.Iterator;

/* JADX INFO: compiled from: com.google.android.gms:play-services-base@@18.7.2 */
/* JADX INFO: loaded from: classes.dex */
public final class FreezableUtils {
    public static <T, E extends Freezable<T>> ArrayList<T> freeze(ArrayList<E> arrayList) {
        GridLayout.Assoc assoc = (ArrayList<T>) new ArrayList(arrayList.size());
        int size = arrayList.size();
        for (int i = 0; i < size; i++) {
            assoc.add(arrayList.get(i).freeze());
        }
        return assoc;
    }

    public static <T, E extends Freezable<T>> ArrayList<T> freezeIterable(Iterable<E> iterable) {
        GridLayout.Assoc assoc = (ArrayList<T>) new ArrayList();
        Iterator<E> it = iterable.iterator();
        while (it.hasNext()) {
            assoc.add(it.next().freeze());
        }
        return assoc;
    }

    public static <T, E extends Freezable<T>> ArrayList<T> freeze(E[] eArr) {
        GridLayout.Assoc assoc = (ArrayList<T>) new ArrayList(eArr.length);
        for (E e : eArr) {
            assoc.add(e.freeze());
        }
        return assoc;
    }
}
