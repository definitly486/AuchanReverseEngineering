package com.scanflow.datacapture.barinternal.androidx.core.os;

import android.os.Build;
import android.os.Bundle;
import android.os.Parcelable;
import android.util.SparseArray;
import java.io.Serializable;
import java.util.ArrayList;

/* JADX INFO: loaded from: classes.dex */
public abstract class BundleCompat {
    public static Object getParcelable(Bundle bundle, String str, Class cls) {
        if (Build.VERSION.SDK_INT >= 34) {
            return Api33Impl.getParcelable(bundle, str, cls);
        }
        Parcelable parcelable = bundle.getParcelable(str);
        if (cls.isInstance(parcelable)) {
            return parcelable;
        }
        return null;
    }

    public static Parcelable[] getParcelableArray(Bundle bundle, String str, Class cls) {
        if (Build.VERSION.SDK_INT >= 34) {
            return (Parcelable[]) Api33Impl.getParcelableArray(bundle, str, cls);
        }
        return bundle.getParcelableArray(str);
    }

    public static ArrayList getParcelableArrayList(Bundle bundle, String str, Class cls) {
        if (Build.VERSION.SDK_INT >= 34) {
            return Api33Impl.getParcelableArrayList(bundle, str, cls);
        }
        return bundle.getParcelableArrayList(str);
    }

    public static SparseArray getSparseParcelableArray(Bundle bundle, String str, Class cls) {
        if (Build.VERSION.SDK_INT >= 34) {
            return Api33Impl.getSparseParcelableArray(bundle, str, cls);
        }
        return bundle.getSparseParcelableArray(str);
    }

    public static Serializable getSerializable(Bundle bundle, String str, Class cls) {
        if (Build.VERSION.SDK_INT >= 34) {
            return Api33Impl.getSerializable(bundle, str, cls);
        }
        Serializable serializable = bundle.getSerializable(str);
        if (cls.isInstance(serializable)) {
            return serializable;
        }
        return null;
    }

    static class Api33Impl {
        static Object getParcelable(Bundle bundle, String str, Class cls) {
            return bundle.getParcelable(str, cls);
        }

        static Object[] getParcelableArray(Bundle bundle, String str, Class cls) {
            return bundle.getParcelableArray(str, cls);
        }

        static ArrayList getParcelableArrayList(Bundle bundle, String str, Class cls) {
            return bundle.getParcelableArrayList(str, cls);
        }

        static SparseArray getSparseParcelableArray(Bundle bundle, String str, Class cls) {
            return bundle.getSparseParcelableArray(str, cls);
        }

        static Serializable getSerializable(Bundle bundle, String str, Class cls) {
            return bundle.getSerializable(str, cls);
        }
    }
}
