package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreapi.internal.identifiers.AdTrackingInfo;
import io.appmetrica.analytics.coreapi.internal.identifiers.AdTrackingInfoResult;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Locale;
import java.util.UUID;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.e8, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0225e8 {
    public final W a;
    public final C0452n2 b;

    public C0225e8(W w, C0452n2 c0452n2) {
        this.a = w;
        this.b = c0452n2;
    }

    public final String a() {
        byte[] bArrDigest;
        AdTrackingInfoResult yandex = this.a.getIdentifiers().getYandex();
        if (!yandex.isValid()) {
            String id = this.b.getAppSetId().getId();
            if (id != null && id.length() != 0) {
                try {
                    UUID.fromString(id);
                    if (!Intrinsics.areEqual(id, "00000000-0000-0000-0000-000000000000")) {
                        return StringsKt.replace$default(id, "-", "", false, 4, (Object) null);
                    }
                } catch (Throwable unused) {
                }
            }
            return StringsKt.replace$default(UUID.randomUUID().toString(), "-", "", false, 4, (Object) null).toLowerCase(Locale.US);
        }
        AdTrackingInfo adTrackingInfo = yandex.mAdTrackingInfo;
        Intrinsics.checkNotNull(adTrackingInfo);
        String str = adTrackingInfo.advId;
        Intrinsics.checkNotNull(str);
        try {
            bArrDigest = MessageDigest.getInstance("MD5").digest(str.getBytes(Charsets.UTF_8));
        } catch (NoSuchAlgorithmException unused2) {
            bArrDigest = new byte[0];
        }
        return StringUtils.toHexString(bArrDigest);
    }

    public C0225e8() {
        this(Ka.k().c(), Ka.k().d());
    }
}
