package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import io.appmetrica.analytics.AdType;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public abstract class G {
    public static final Map a = MapsKt.mapOf(TuplesKt.to(AdType.NATIVE, 1), TuplesKt.to(AdType.BANNER, 2), TuplesKt.to(AdType.REWARDED, 3), TuplesKt.to(AdType.INTERSTITIAL, 4), TuplesKt.to(AdType.MREC, 5), TuplesKt.to(AdType.APP_OPEN, 7), TuplesKt.to(AdType.OTHER, 6));
}
