package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import io.appmetrica.analytics.coreapi.internal.backport.Function;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.io.File;

/* JADX INFO: loaded from: classes3.dex */
public final class Jb implements Function, Consumer {
    @Override // io.appmetrica.analytics.coreapi.internal.backport.Function
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Fb apply(File file) {
        String strA = AbstractC0332ib.a(file);
        long jLastModified = file.lastModified();
        if (StringUtils.isNullOrEmpty(strA)) {
            return null;
        }
        try {
            return new Fb(strA, jLastModified);
        } catch (Throwable unused) {
            return null;
        }
    }

    @Override // io.appmetrica.analytics.coreapi.internal.backport.Consumer
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final void consume(File file) {
        try {
            file.delete();
        } catch (Throwable unused) {
        }
    }
}
