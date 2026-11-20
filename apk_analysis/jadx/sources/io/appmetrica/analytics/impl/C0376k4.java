package io.appmetrica.analytics.impl;

import android.os.Bundle;
import io.appmetrica.analytics.coreapi.internal.identifiers.AdvertisingIdsHolder;
import io.appmetrica.analytics.internal.IdentifiersResult;
import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.k4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0376k4 {
    public final Rm a;
    public final W b;

    public C0376k4(Rm rm, W w) {
        this.a = rm;
        this.b = w;
    }

    public final C0350j4 a(HashMap map) {
        C0706wm c0706wmE = this.a.e();
        AdvertisingIdsHolder identifiers = this.b.getIdentifiers();
        return new C0350j4(C0350j4.a(c0706wmE.d), C0350j4.a(c0706wmE.a), C0350j4.a(c0706wmE.b), C0350j4.a(c0706wmE.j), C0350j4.a(c0706wmE.i), C0350j4.a(Cb.a(Wm.a(c0706wmE.k))), C0350j4.a(Cb.a(map)), new IdentifiersResult(identifiers.getGoogle().mAdTrackingInfo == null ? null : identifiers.getGoogle().mAdTrackingInfo.advId, identifiers.getGoogle().mStatus, identifiers.getGoogle().mErrorExplanation), new IdentifiersResult(identifiers.getHuawei().mAdTrackingInfo == null ? null : identifiers.getHuawei().mAdTrackingInfo.advId, identifiers.getHuawei().mStatus, identifiers.getHuawei().mErrorExplanation), new IdentifiersResult(identifiers.getYandex().mAdTrackingInfo == null ? null : identifiers.getYandex().mAdTrackingInfo.advId, identifiers.getYandex().mStatus, identifiers.getYandex().mErrorExplanation), C0350j4.a(Cb.a(c0706wmE.h)), AbstractC0138ao.a(), c0706wmE.o + ((long) c0706wmE.z.a), C0350j4.a(c0706wmE.n.f), new Bundle());
    }
}
