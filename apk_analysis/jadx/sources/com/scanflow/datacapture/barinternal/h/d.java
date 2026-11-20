package com.scanflow.datacapture.barinternal.h;

import android.content.SharedPreferences;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public abstract class d {
    public static final a a(SharedPreferences sharedPrefs, Pair pair) {
        Intrinsics.checkNotNullParameter(sharedPrefs, "<this>");
        Intrinsics.checkNotNullParameter(pair, "pair");
        Intrinsics.checkNotNullParameter(pair, "pair");
        Intrinsics.checkNotNullParameter(sharedPrefs, "sharedPrefs");
        return new a((String) pair.getFirst(), pair.getSecond(), sharedPrefs);
    }
}
