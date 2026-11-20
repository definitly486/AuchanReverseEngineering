package io.appmetrica.analytics.impl;

import android.content.Context;
import java.io.File;

/* JADX INFO: loaded from: classes3.dex */
public final class Le implements InterfaceC0121a7 {
    public final File a;
    public final Sg b;

    public Le(File file, Sg sg) {
        this.a = file;
        this.b = sg;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0121a7
    public final File a(Context context, String str) {
        return new File(this.a, this.b.a(str));
    }
}
