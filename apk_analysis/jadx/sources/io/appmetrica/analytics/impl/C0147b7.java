package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.annotations.DoNotInline;
import java.io.File;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.b7, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
@DoNotInline
public final class C0147b7 implements InterfaceC0121a7 {
    private final Sg a;

    public C0147b7(Sg sg) {
        this.a = sg;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0121a7
    public File a(Context context, String str) {
        return new File(context.getNoBackupFilesDir(), this.a.a(str));
    }
}
