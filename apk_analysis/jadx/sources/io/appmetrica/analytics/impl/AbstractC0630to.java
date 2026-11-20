package io.appmetrica.analytics.impl;

import androidx.fragment.app.FragmentTransaction;
import com.scanflow.datacapture.barinternal.kotlin.collections.SetsKt;
import java.util.Set;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.to, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0630to {
    public static final Set a;

    static {
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        a = SetsKt.setOf((Object[]) new Integer[]{42, 8224, 6145, 0, 40977, 41000, Integer.valueOf(FragmentTransaction.TRANSIT_FRAGMENT_OPEN), 40976});
    }

    public static final Set a() {
        return a;
    }
}
