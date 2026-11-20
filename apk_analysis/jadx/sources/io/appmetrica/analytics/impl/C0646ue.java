package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ue, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0646ue implements Ko {
    public final String a;

    public C0646ue(String str) {
        this.a = str;
    }

    @Override // io.appmetrica.analytics.impl.Ko
    public final Io a(String str) {
        if (!StringUtils.isNullOrEmpty(str)) {
            return new Io(this, true, "");
        }
        return new Io(this, false, this.a + " is empty.");
    }
}
